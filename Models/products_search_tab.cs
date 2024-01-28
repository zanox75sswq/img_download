using System;
using System.Collections.Generic;

#nullable disable

namespace img_download.Models
{
    public partial class products_search_tab
    {
        public int id { get; set; }
        public string kw { get; set; }
        public string wordEnWithDefault { get; set; }
        public string lang { get; set; }
        public string search_json { get; set; }
        public int? page { get; set; }
    }
}
