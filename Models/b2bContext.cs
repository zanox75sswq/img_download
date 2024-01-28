using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace img_download.Models
{
    public partial class b2bContext : DbContext
    {
        public b2bContext()
        {
        }

        public b2bContext(DbContextOptions<b2bContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bank_info> Bank_infos { get; set; }
        public virtual DbSet<a_link> a_links { get; set; }
        public virtual DbSet<art_tab> art_tabs { get; set; }
        public virtual DbSet<bank_tab> bank_tabs { get; set; }
        public virtual DbSet<category_show_tab> category_show_tabs { get; set; }
        public virtual DbSet<complaint_tab> complaint_tabs { get; set; }
        public virtual DbSet<google_keyword> google_keywords { get; set; }
        public virtual DbSet<googlebot_tab> googlebot_tabs { get; set; }
        public virtual DbSet<img_key> img_keys { get; set; }
        public virtual DbSet<index_info> index_infos { get; set; }
        public virtual DbSet<index_products_tab> index_products_tabs { get; set; }
        public virtual DbSet<item_tab> item_tabs { get; set; }
        public virtual DbSet<not_kw> not_kws { get; set; }
        public virtual DbSet<old_link> old_links { get; set; }
        public virtual DbSet<order_tab> order_tabs { get; set; }
        public virtual DbSet<poe_account> poe_accounts { get; set; }
        public virtual DbSet<product_body_tab> product_body_tabs { get; set; }
        public virtual DbSet<product_description_tab> product_description_tabs { get; set; }
        public virtual DbSet<product_tab> product_tabs { get; set; }
        public virtual DbSet<products_search_tab> products_search_tabs { get; set; }
        public virtual DbSet<proxy_tab> proxy_tabs { get; set; }
        public virtual DbSet<switch_tab> switch_tabs { get; set; }
        public virtual DbSet<temp_duplicate> temp_duplicates { get; set; }
        public virtual DbSet<test_tab> test_tabs { get; set; }
        public virtual DbSet<translate_workers_tab> translate_workers_tabs { get; set; }
        public virtual DbSet<user_info> user_infos { get; set; }
        public virtual DbSet<web_info> web_infos { get; set; }
        public virtual DbSet<whatsapp_tab> whatsapp_tabs { get; set; }
        public virtual DbSet<workers_tab> workers_tabs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=8.222.170.179;userid=root;pwd=81de4567c861e36d;port=3306;database=b2b;sslmode=none", Microsoft.EntityFrameworkCore.ServerVersion.Parse("5.7.40-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_general_ci");

            modelBuilder.Entity<Bank_info>(entity =>
            {
                entity.ToTable("Bank_info");

                entity.Property(e => e.id)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.A_C)
                    .HasMaxLength(255)
                    .HasComment("帐号");

                entity.Property(e => e.Bank_Address)
                    .HasMaxLength(255)
                    .HasComment("银行地址");

                entity.Property(e => e.Bank_Name)
                    .HasMaxLength(255)
                    .HasComment("银行名");

                entity.Property(e => e.Berf)
                    .HasMaxLength(255)
                    .HasComment("户名");

                entity.Property(e => e.Branch)
                    .HasMaxLength(255)
                    .HasComment("支行");

                entity.Property(e => e.Pay_Currency)
                    .HasColumnType("int(255)")
                    .HasComment("支付货币：1、美金；2、欧元；3、英镑");

                entity.Property(e => e.Swift_Code)
                    .HasMaxLength(255)
                    .HasComment("银行代码");
            });

            modelBuilder.Entity<a_link>(entity =>
            {
                entity.ToTable("a_link");

                entity.Property(e => e.id).HasColumnType("int(11)");

                entity.Property(e => e.link).HasMaxLength(500);

                entity.Property(e => e.title).HasMaxLength(255);
            });

            modelBuilder.Entity<art_tab>(entity =>
            {
                entity.ToTable("art_tab");

                entity.HasIndex(e => e.md5_string, "md5s")
                    .IsUnique();

                entity.Property(e => e.id).HasColumnType("int(11)");

                entity.Property(e => e.description).HasMaxLength(1000);

                entity.Property(e => e.insert_time)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.keywords).HasMaxLength(1000);

                entity.Property(e => e.lang).HasMaxLength(1000);

                entity.Property(e => e.title).HasMaxLength(500);
            });

            modelBuilder.Entity<bank_tab>(entity =>
            {
                entity.ToTable("bank_tab");

                entity.Property(e => e.id)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.bank_info).HasComment("银行信息");

                entity.Property(e => e.bank_name)
                    .HasMaxLength(255)
                    .HasComment("银行名称");
            });

            modelBuilder.Entity<category_show_tab>(entity =>
            {
                entity.ToTable("category_show_tab");

                entity.Property(e => e.id).HasColumnType("int(11)");

                entity.Property(e => e.__Category_name)
                    .HasMaxLength(255)
                    .HasColumnName("\r\nCategory_name");
            });

            modelBuilder.Entity<complaint_tab>(entity =>
            {
                entity.ToTable("complaint_tab");

                entity.Property(e => e.id).HasColumnType("int(11)");

                entity.Property(e => e.company_name).HasMaxLength(1000);

                entity.Property(e => e.email).HasMaxLength(255);

                entity.Property(e => e.m_id).HasMaxLength(100);

                entity.Property(e => e.phone).HasMaxLength(100);
            });

            modelBuilder.Entity<google_keyword>(entity =>
            {
                entity.HasIndex(e => e.keywords, "keyw")
                    .IsUnique();

                entity.Property(e => e.id).HasColumnType("int(11)");

                entity.Property(e => e.key).HasMaxLength(255);

                entity.Property(e => e.link).HasMaxLength(255);

                entity.Property(e => e.status)
                    .HasColumnType("int(255) unsigned zerofill")
                    .HasDefaultValueSql("'000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000'");
            });

            modelBuilder.Entity<googlebot_tab>(entity =>
            {
                entity.ToTable("googlebot_tab");

                entity.Property(e => e.id).HasColumnType("int(11)");

                entity.Property(e => e.insert_time)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.url).HasMaxLength(500);
            });

            modelBuilder.Entity<img_key>(entity =>
            {
                entity.ToTable("img_key");

                entity.HasIndex(e => e.md5, "md5")
                    .IsUnique();

                entity.Property(e => e.id).HasColumnType("int(11)");

                entity.Property(e => e.key).HasMaxLength(1000);
            });

            modelBuilder.Entity<index_info>(entity =>
            {
                entity.ToTable("index_info");

                entity.Property(e => e.id).HasColumnType("int(11)");

                entity.Property(e => e.last_id)
                    .HasColumnType("int(11)")
                    .HasComment("索引最后的id");
            });

            modelBuilder.Entity<index_products_tab>(entity =>
            {
                entity.ToTable("index_products_tab");

                entity.HasIndex(e => e.kw, "kw");

                entity.Property(e => e.id).HasColumnType("int(11)");

                entity.Property(e => e.kw)
                    .HasMaxLength(200)
                    .HasComment("关键词");

                entity.Property(e => e.lang)
                    .HasMaxLength(10)
                    .HasComment("语言");

                entity.Property(e => e.page)
                    .HasColumnType("int(11)")
                    .HasComment("页码");

                entity.Property(e => e.search_json).HasComment("json");

                entity.Property(e => e.wordEnWithDefault).HasMaxLength(255);
            });

            modelBuilder.Entity<item_tab>(entity =>
            {
                entity.ToTable("item_tab");

                entity.Property(e => e.id).HasColumnType("int(11)");

                entity.Property(e => e.__search_key)
                    .HasMaxLength(1000)
                    .HasColumnName("\r\nsearch_key")
                    .HasComment("搜索标识");

                entity.Property(e => e.body).HasComment("内容");

                entity.Property(e => e.description)
                    .HasMaxLength(1000)
                    .HasComment("描述");

                entity.Property(e => e.insert_time)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasComment("时间");

                entity.Property(e => e.key)
                    .HasMaxLength(500)
                    .HasComment("url key");

                entity.Property(e => e.keywords)
                    .HasMaxLength(1000)
                    .HasComment("关键词");

                entity.Property(e => e.lang)
                    .HasMaxLength(255)
                    .HasComment("语言");

                entity.Property(e => e.title)
                    .HasMaxLength(1000)
                    .HasComment("标题");
            });

            modelBuilder.Entity<not_kw>(entity =>
            {
                entity.ToTable("not_kw");

                entity.Property(e => e.id).HasColumnType("int(11)");

                entity.Property(e => e.kw)
                    .HasMaxLength(500)
                    .HasComment("禁止的关键词");
            });

            modelBuilder.Entity<old_link>(entity =>
            {
                entity.ToTable("old_link");

                entity.HasIndex(e => e.html_file, "html")
                    .IsUnique();

                entity.Property(e => e.id).HasColumnType("int(11)");

                entity.Property(e => e.html_file).HasMaxLength(250);
            });

            modelBuilder.Entity<order_tab>(entity =>
            {
                entity.ToTable("order_tab");

                entity.Property(e => e.id).HasColumnType("int(11)");

                entity.Property(e => e.__address)
                    .HasMaxLength(1000)
                    .HasColumnName("\r\naddress")
                    .HasComment("地址");

                entity.Property(e => e.__payment_picture)
                    .HasMaxLength(500)
                    .HasColumnName("\r\npayment_picture")
                    .HasComment("付款截图");

                entity.Property(e => e.__product_price)
                    .HasMaxLength(255)
                    .HasColumnName("\r\nproduct_price")
                    .HasDefaultValueSql("'0.00'")
                    .HasComment("产品价格");

                entity.Property(e => e.__product_shipping_costs)
                    .HasMaxLength(255)
                    .HasColumnName("\r\nproduct_shipping_costs")
                    .HasDefaultValueSql("'0.00'")
                    .HasComment("运费");

                entity.Property(e => e.city)
                    .HasMaxLength(255)
                    .HasComment("城市");

                entity.Property(e => e.company_name)
                    .HasMaxLength(255)
                    .HasComment("公司名");

                entity.Property(e => e.country)
                    .HasMaxLength(255)
                    .HasComment("国家");

                entity.Property(e => e.first_name)
                    .HasMaxLength(255)
                    .HasComment("名字");

                entity.Property(e => e.insert_time)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.last_name)
                    .HasMaxLength(255)
                    .HasComment("姓");

                entity.Property(e => e.order_notes)
                    .HasMaxLength(6000)
                    .HasComment("订单备注");

                entity.Property(e => e.pay_currency)
                    .HasColumnType("int(255)")
                    .HasDefaultValueSql("'0'")
                    .HasComment("支付货币1、美元；2、欧元；3、英镑");

                entity.Property(e => e.payment_method)
                    .HasColumnType("int(255)")
                    .HasDefaultValueSql("'0'")
                    .HasComment("支付方式1、美元帐号；2、欧元；3、英镑；4、pingpong");

                entity.Property(e => e.phone)
                    .HasMaxLength(255)
                    .HasComment("电话");

                entity.Property(e => e.pingpong_link)
                    .HasMaxLength(1000)
                    .HasComment("pinpang支付链接");

                entity.Property(e => e.product_m_id).HasMaxLength(11);

                entity.Property(e => e.product_weight)
                    .HasMaxLength(255)
                    .HasComment("重量");

                entity.Property(e => e.quantity).HasColumnType("int(11)");

                entity.Property(e => e.status)
                    .HasColumnType("int(255)")
                    .HasDefaultValueSql("'0'")
                    .HasComment("1、等待商家审核；2、等待客户付款；3、已付款等待发货；4、已发货等收货；5、确认收货；6、客户申诉");

                entity.Property(e => e.total)
                    .HasMaxLength(255)
                    .HasComment("总价");

                entity.Property(e => e.transport_information)
                    .HasMaxLength(1000)
                    .HasComment("运输信息");

                entity.Property(e => e.user_id).HasColumnType("int(11)");

                entity.Property(e => e.zip_code)
                    .HasMaxLength(255)
                    .HasComment("邮编");
            });

            modelBuilder.Entity<poe_account>(entity =>
            {
                entity.ToTable("poe_account");

                entity.Property(e => e.id)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.cookies_id).HasMaxLength(255);

                entity.Property(e => e.email).HasMaxLength(255);
            });

            modelBuilder.Entity<product_body_tab>(entity =>
            {
                entity.ToTable("product_body_tab");

                entity.HasIndex(e => e.m_id, "my_id");

                entity.Property(e => e.id)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.lang).HasMaxLength(100);

                entity.Property(e => e.m_id).HasMaxLength(100);
            });

            modelBuilder.Entity<product_description_tab>(entity =>
            {
                entity.ToTable("product_description_tab");

                entity.HasIndex(e => e.m_id, "my_id");

                entity.Property(e => e.id).HasColumnType("int(11)");

                entity.Property(e => e.img)
                    .HasMaxLength(500)
                    .HasComment("图片");

                entity.Property(e => e.insert_time)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.lang)
                    .HasMaxLength(500)
                    .HasComment("语言");

                entity.Property(e => e.m_id)
                    .HasMaxLength(100)
                    .HasComment("新的id");

                entity.Property(e => e.name)
                    .HasMaxLength(500)
                    .HasComment("标题");

                entity.Property(e => e.new_url)
                    .HasMaxLength(500)
                    .HasComment("新地址");

                entity.Property(e => e.product_json).HasComment("产品json");
            });

            modelBuilder.Entity<product_tab>(entity =>
            {
                entity.ToTable("product_tab");

                entity.HasIndex(e => e.m_id, "my_id");

                entity.Property(e => e.id).HasColumnType("int(11)");

                entity.Property(e => e.__category)
                    .HasColumnName("\r\ncategory")
                    .HasComment("分类");

                entity.Property(e => e.companyName)
                    .HasMaxLength(255)
                    .HasComment("公司名");

                entity.Property(e => e.img).HasComment("图片");

                entity.Property(e => e.img_item).HasComment("相册");

                entity.Property(e => e.insert_time)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasComment("时间");

                entity.Property(e => e.item_id)
                    .HasMaxLength(500)
                    .HasComment("专题id");

                entity.Property(e => e.keywords)
                    .HasMaxLength(1000)
                    .HasComment("关键词");

                entity.Property(e => e.lang)
                    .HasMaxLength(255)
                    .HasComment("语言");

                entity.Property(e => e.m_id).HasComment("本站id");

                entity.Property(e => e.min_order)
                    .HasMaxLength(255)
                    .HasComment("最小订单");

                entity.Property(e => e.new_content)
                    .HasColumnType("int(4)")
                    .HasComment("新内容");

                entity.Property(e => e.price)
                    .HasMaxLength(255)
                    .HasComment("价格");

                entity.Property(e => e.product_origin)
                    .HasMaxLength(255)
                    .HasComment("产地");

                entity.Property(e => e.revise)
                    .HasColumnType("int(10)")
                    .HasComment("是否修改过内容");

                entity.Property(e => e.source_id)
                    .HasMaxLength(20)
                    .HasComment("来源id");

                entity.Property(e => e.source_url).HasComment("来源url");

                entity.Property(e => e.status)
                    .HasColumnType("int(10)")
                    .HasComment("状态");

                entity.Property(e => e.tag).HasComment("标签");

                entity.Property(e => e.title)
                    .HasMaxLength(1000)
                    .HasComment("标题");

                entity.Property(e => e.url)
                    .HasMaxLength(255)
                    .HasComment("url");
            });

            modelBuilder.Entity<products_search_tab>(entity =>
            {
                entity.ToTable("products_search_tab");

                entity.HasIndex(e => e.kw, "kw");

                entity.Property(e => e.id).HasColumnType("int(11)");

                entity.Property(e => e.kw)
                    .HasMaxLength(200)
                    .HasComment("关键词");

                entity.Property(e => e.lang)
                    .HasMaxLength(10)
                    .HasComment("语言");

                entity.Property(e => e.page)
                    .HasColumnType("int(11)")
                    .HasComment("页码");

                entity.Property(e => e.search_json).HasComment("json");

                entity.Property(e => e.wordEnWithDefault).HasMaxLength(255);
            });

            modelBuilder.Entity<proxy_tab>(entity =>
            {
                entity.ToTable("proxy_tab");

                entity.Property(e => e.id).HasColumnType("int(11)");

                entity.Property(e => e.proxy_info).HasMaxLength(500);
            });

            modelBuilder.Entity<switch_tab>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("switch_tab");

                entity.Property(e => e.whatsapp_status).HasColumnType("int(255)");
            });

            modelBuilder.Entity<temp_duplicate>(entity =>
            {
                entity.Property(e => e.id)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<test_tab>(entity =>
            {
                entity.ToTable("test_tab");

                entity.HasIndex(e => new { e.m_id, e.lang }, "gt")
                    .IsUnique();

                entity.Property(e => e.id).HasColumnType("int(11)");

                entity.Property(e => e.m_id).HasMaxLength(500);
            });

            modelBuilder.Entity<translate_workers_tab>(entity =>
            {
                entity.ToTable("translate_workers_tab");

                entity.Property(e => e.id).HasColumnType("int(11)");

                entity.Property(e => e.url).HasMaxLength(1000);
            });

            modelBuilder.Entity<user_info>(entity =>
            {
                entity.ToTable("user_info");

                entity.HasIndex(e => e.email, "emil")
                    .IsUnique();

                entity.Property(e => e.id).HasColumnType("int(11)");

                entity.Property(e => e.first_name).HasMaxLength(255);

                entity.Property(e => e.insert_time)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.last_name).HasMaxLength(255);

                entity.Property(e => e.password).HasMaxLength(255);

                entity.Property(e => e.phone).HasMaxLength(255);
            });

            modelBuilder.Entity<web_info>(entity =>
            {
                entity.ToTable("web_info");

                entity.Property(e => e.id).HasColumnType("int(11)");

                entity.Property(e => e.__universal_tag)
                    .HasMaxLength(500)
                    .HasColumnName("\r\nuniversal_tag")
                    .HasComment("通用tag");

                entity.Property(e => e.index_description).HasMaxLength(500);

                entity.Property(e => e.index_keywords).HasMaxLength(500);

                entity.Property(e => e.index_title).HasMaxLength(500);

                entity.Property(e => e.lang).HasMaxLength(255);

                entity.Property(e => e.search_tag)
                    .HasMaxLength(255)
                    .HasComment("搜索tag");

                entity.Property(e => e.web_url).HasMaxLength(500);
            });

            modelBuilder.Entity<whatsapp_tab>(entity =>
            {
                entity.ToTable("whatsapp_tab");

                entity.Property(e => e.id).HasColumnType("int(20)");

                entity.Property(e => e.key).HasMaxLength(500);

                entity.Property(e => e.lang).HasMaxLength(255);

                entity.Property(e => e.tg).HasMaxLength(500);

                entity.Property(e => e.whatsapp).HasMaxLength(500);
            });

            modelBuilder.Entity<workers_tab>(entity =>
            {
                entity.ToTable("workers_tab");

                entity.HasIndex(e => e.workers, "1q")
                    .IsUnique();

                entity.Property(e => e.id).HasColumnType("int(11)");

                entity.Property(e => e.workers).HasMaxLength(500);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
