using System;
using System.Collections.Generic;

#nullable disable

namespace img_download.Models
{
    public partial class img_key
    {
        public int id { get; set; }
        public string key { get; set; }
        public string md5 { get; set; }
    }
}
