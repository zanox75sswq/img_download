using System;
using System.Collections.Generic;

#nullable disable

namespace img_download.Models
{
    public partial class product_tab
    {
        public int id { get; set; }
        public string m_id { get; set; }
        public string lang { get; set; }
        public string title { get; set; }
        public string keywords { get; set; }
        public string img { get; set; }
        public string img_item { get; set; }
        public string price { get; set; }
        public string product_origin { get; set; }
        public string min_order { get; set; }
        public string tag { get; set; }
        public string __category { get; set; }
        public string companyName { get; set; }
        public string source_url { get; set; }
        public string source_id { get; set; }
        public string url { get; set; }
        public int? status { get; set; }
        public int? revise { get; set; }
        public DateTime? insert_time { get; set; }
        public int? new_content { get; set; }
        public string item_id { get; set; }
    }
}
