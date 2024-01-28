using System;
using System.Collections.Generic;

#nullable disable

namespace img_download.Models
{
    public partial class user_info
    {
        public int id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string phone { get; set; }
        public DateTime? insert_time { get; set; }
    }
}
