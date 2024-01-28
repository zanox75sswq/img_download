using Amazon.Util.Internal;
using img_download.code;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace img_download.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        /// <summary>
        /// 开始下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("bing_download")]
        public async Task<string> bing_download(int start_id)
        {
            public_properties.last_id = start_id;
            while (true)
            {
                int id =  get_list(100).Result;
            }
            return "";
        }
        /// <summary>
        /// 返回最后的id
        /// </summary>
        /// <returns></returns>
        [HttpGet("get_last_id")]
        public async Task<int> get_last_id()
        {
            return public_properties.last_id;
        }
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="start_id"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        private async Task<int> get_list(int size)
        {
            using (var db = new Models.b2bContext())
            {
                var query = db.product_tabs.FromSqlRaw(string.Format("SELECT * FROM product_tab WHERE lang='en' and id>{0} ORDER BY id LIMIT {1};", public_properties.last_id, size)).ToList();
                int last_id = query[query.Count - 1].id;//最后一条id
                public_properties.last_id = last_id;
                List<Models.product_tab> product_list = new List<Models.product_tab>();
                product_list = query;
                List<Task> tasks = new List<Task>(); // 存储任务列表
                HashSet<Models.product_tab> processedData = new HashSet<Models.product_tab>();//存储已处理的数据
                for (int i = 0; i < 50; i++)
                {
                    tasks.Add(Task.Run(async () =>
                    {
                        while (product_list.Count > 0)
                        {
                            try
                            {
                                Models.product_tab product = new Models.product_tab();
                                lock (product_list)
                                {
                                    if (product_list.Count > 0)
                                    {
                                        product = product_list[product_list.Count - 1];
                                        product_list.RemoveAt(product_list.Count - 1);
                                    }
                                }
                                if (product != null && product.revise!=1)
                                {
                                    // 在这里对取出的数据进行处理
                                    // 可以在这里调用您的方法进行处理，例如 await ProcessDataAsync(data)

                                    //product.img 不用下载直接从相册里选第一条

                                    

                                    //相册下载
                                    List<string> new_img_list = new List<string>();
                                    foreach (var img in JsonConvert.DeserializeObject<List<string>>(product.img_item))
                                    {
                                      string new_img = await dl_up(img);
                                      if (new_img != "no")
                                      {
                                         new_img_list.Add(new_img);//新的相册
                                      }
                                    }
                                    //整理（如果首图下载出错，就从相册重选,新列表中也必须要有1张图）
                                    if (new_img_list.Count>0)
                                    {
                                        //首图
                                        product.img = new_img_list[0];
                                        //相册
                                        product.img_item = JsonConvert.SerializeObject(new_img_list);
                                        //修改状态
                                        product.revise = 1;
                                        //已修改数据
                                        lock (processedData)
                                        {
                                            processedData.Add(product);
                                            
                                        }
                                        var k = await update_product(product);
                                    }
                                    
                                }
                            }
                            catch(Exception ex)
                            {

                            }

                            await Task.Delay(2); // 等待一小段时间，避免线程饥饿
                        }
                    }));
                }
                await Task.WhenAll(tasks); // 等待所有任务完成
                //入库
                //foreach (var new_porduct in processedData)
                //{
                //    var k = await update_product(new_porduct);
                //}
                
                return last_id;
            }

        }
       /// <summary>
       /// 更新数据
       /// </summary>
       /// <param name="m_id"></param>
       /// <returns></returns>
        private async Task<string> update_product(Models.product_tab new_product)
        {

          
            using (var db = new Models.b2bContext())
            {
                try
                {
                    string sql = String.Format("UPDATE product_tab SET img='{0}',img_item='{1}',revise = 1 WHERE m_id = '{2}'",new_product.img,new_product.img_item,new_product.m_id);
                    await db.Database.ExecuteSqlRawAsync(sql);
                    await db.SaveChangesAsync(); // 提交更改



                    //var product = db.product_tabs.Where(b => b.m_id == new_product.m_id).ToList();
                    //foreach (var item in product)
                    //{
                    //    item.img = new_product.img;
                    //    item.img_item = new_product.img_item;
                    //    item.revise = 1;
                    //}
                    //db.SaveChanges();

                }
                catch (Exception ex)
                {

                }
                return "ok";
            }
        }

        /// <summary>
        /// 下载并上传
        /// </summary>
        /// <param name="i_img_url"></param>
        /// <param name="Md5Key"></param>
        /// <returns></returns>
        private async Task<string> dl_up(string img)
        {
            string i_img_url;

            if (!img.Contains("https://"))
            {
                i_img_url = Encoding.UTF8.GetString(ForceDecodeBase64String(img.Replace("/imgs/", "").Replace(".jpg", "")));
            }
            else
            {
                i_img_url = img;
              
            }
            string Md5Key = MD5Helper.GetMd5Hash(i_img_url);
            //下载首图
            var imgbytes = await Picture(i_img_url);

            if (imgbytes != null)
            {
                //下载成功上传
                cloudflare_r2 r2 = new cloudflare_r2();
                return await r2.up_img(imgbytes, Md5Key + ".jpg");
            }
            else
            {
                return "no";
            }
        }

        /// <summary>
        /// 下载图片
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        private async Task<byte[]> Picture(string url)
        {
            HttpClient client = new HttpClient();
            try
            {
                client.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (iPhone; CPU iPhone OS 16_6 like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) Version/16.6 Mobile/15E148 Safari/604.1");

                // 发起GET请求并获取响应
                HttpResponseMessage response = await client.GetAsync(url);

                // 确保响应成功
                response.EnsureSuccessStatusCode();

                // 读取响应内容
                byte[] imageBytes = await response.Content.ReadAsByteArrayAsync();


                // 保存图片到本地
                // var k= File.WriteAllBytes("image.jpg", imageBytes);

                return imageBytes; ;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {


                client.Dispose();
            }

        }
        /// <summary>
        /// 强解
        /// </summary>
        /// <param name="base64String"></param>
        /// <returns></returns>
        private static byte[] ForceDecodeBase64String(string base64String)
        {
            int paddingChars = base64String.Length % 4;
            if (paddingChars > 0)
            {
                base64String += new string('=', 4 - paddingChars);
            }

            int base64Length = base64String.Length;
            byte[] base64Bytes = Encoding.ASCII.GetBytes(base64String);

            return Convert.FromBase64String(Encoding.ASCII.GetString(base64Bytes, 0, base64Length));
        }
        /// <summary>
        /// 实时更新图片
        /// </summary>
        /// <param name="id"></param>
        /// <param name="m_id"></param>
        /// <returns></returns>
        [HttpGet("Realtime")]

        public async Task<string> Get_img(string id, string m_id)
        {
            //下载图片
            using (var db = new Models.b2bContext())
            {
                try
                {
                    var m_id_s = await db.product_tabs.Where(b => b.m_id == m_id && b.revise == 1).ToListAsync();
                    if (m_id_s.Count > 0)
                    {
                        //已经有图片源
                        var u_product = await db.product_tabs.Where(b => b.m_id == m_id && b.id == int.Parse(id)).FirstAsync();
                        u_product.img = m_id_s[0].img;
                        u_product.img_item = m_id_s[0].img_item;
                        u_product.revise = 1;
                        await db.SaveChangesAsync();
                    }
                    else
                    {
                        //没有图片源
                        var u_product = await db.product_tabs.Where(b => b.m_id == m_id && b.id == int.Parse(id)).FirstAsync();

                        //相册下载
                        List<string> new_img_list = new List<string>();
                        foreach (var img in JsonConvert.DeserializeObject<List<string>>(u_product.img_item))
                        {
                            string new_img = await dl_up(img);
                            if (new_img != "no")
                            {
                                new_img_list.Add(new_img);//新的相册
                            }
                        }
                        //整理（如果首图下载出错，就从相册重选,新列表中也必须要有1张图）
                        if (new_img_list.Count > 1)
                        {
                            //首图
                            u_product.img = new_img_list[0];
                            //相册
                            u_product.img_item = JsonConvert.SerializeObject(new_img_list);
                            //修改状态
                            u_product.revise = 1;

                            var k = await update_product(u_product);
                        }
                    }
                }catch(Exception ex)
                {

                }
            }
            return "ok";
        }
    }
}
