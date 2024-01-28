using System;
using System.Collections.Generic;

#nullable disable

namespace img_download.Models
{
    public partial class art_tab
    {
        public int id { get; set; }
        public string title { get; set; }
        public string keywords { get; set; }
        public string description { get; set; }
        public string lang { get; set; }
        public DateTime? insert_time { get; set; }
        public string content_json { get; set; }
        public string md5_string { get; set; }
    }
}
