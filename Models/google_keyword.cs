using System;
using System.Collections.Generic;

#nullable disable

namespace img_download.Models
{
    public partial class google_keyword
    {
        public int id { get; set; }
        public string keywords { get; set; }
        public uint? status { get; set; }
        public string key { get; set; }
        public string link { get; set; }
    }
}
