using System;
using System.Collections.Generic;

#nullable disable

namespace img_download.Models
{
    public partial class product_description_tab
    {
        public int id { get; set; }
        public string m_id { get; set; }
        public string lang { get; set; }
        public string name { get; set; }
        public string img { get; set; }
        public string new_url { get; set; }
        public string product_json { get; set; }
        public DateTime? insert_time { get; set; }
    }
}
