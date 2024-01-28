using System;
using System.Collections.Generic;

#nullable disable

namespace img_download.Models
{
    public partial class item_tab
    {
        public int id { get; set; }
        public string key { get; set; }
        public string lang { get; set; }
        public string title { get; set; }
        public string keywords { get; set; }
        public string description { get; set; }
        public string body { get; set; }
        public string __search_key { get; set; }
        public DateTime? insert_time { get; set; }
    }
}
