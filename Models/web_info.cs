using System;
using System.Collections.Generic;

#nullable disable

namespace img_download.Models
{
    public partial class web_info
    {
        public int id { get; set; }
        public string lang { get; set; }
        public string index_title { get; set; }
        public string index_keywords { get; set; }
        public string index_description { get; set; }
        public string __universal_tag { get; set; }
        public string web_url { get; set; }
        public string search_tag { get; set; }
    }
}
