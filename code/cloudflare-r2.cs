using Amazon.Runtime;
using Amazon.S3.Model;
using Amazon.S3;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using System.Threading.Tasks;
using System.IO;
using System;

namespace img_download.code
{
    public class cloudflare_r2
    {
        public static IAmazonS3 s3Client;
        public void r2()
        {
            var accessKey = "86865871a6326e4d42f276360642b6aa";
            var secretKey = "552be82ed5470adb752360536d5544783adcf53e0e6bd8d60314d8ca90c1cca5";
            var credentials = new BasicAWSCredentials(accessKey, secretKey);
            s3Client = new AmazonS3Client(credentials, new AmazonS3Config
            {

                ServiceURL = "https://8e80cd87e8145c036bce913407c4ad6c.r2.cloudflarestorage.com",
            });
        }

        public async Task<string> up_img(byte[] imageBytes,string key)
        {
            try
            {
                r2();


                var request = new PutObjectRequest
                {
                   
                    BucketName = "b2b-img",
                    Key = key,
                    InputStream = new MemoryStream(imageBytes),
                    DisablePayloadSigning = true
                };

                var response = await s3Client.PutObjectAsync(request);

                return string.Format("https://img.china-sups.com/{0}",key);
            }
            catch (Exception ex)
            {
                return "no";
            }
           
        }
        public async Task delete_all()
        {
            try
            {
                r2();
                string bucketName = "b2b-img";
                ListObjectsV2Request listRequest = new ListObjectsV2Request
                {
                    BucketName = "b2b-img"
                };
                ListObjectsV2Response listResponse;
               
                do
                {
                    listResponse = await s3Client.ListObjectsV2Async(listRequest);

                    // 删除存储桶中的每个对象
                    foreach (var obj in listResponse.S3Objects)
                    {
                        await s3Client.DeleteObjectAsync(bucketName, obj.Key);
                        Console.WriteLine($"Deleted object: {obj.Key}");
                    }

                    // 设置下一页标记以继续列出对象
                    listRequest.ContinuationToken = listResponse.NextContinuationToken;

                } while (listResponse.IsTruncated);


            }
            catch (Exception ex)
            {

            }
        }

       
    }
    
}
