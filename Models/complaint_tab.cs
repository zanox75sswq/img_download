using System;
using System.Collections.Generic;

#nullable disable

namespace img_download.Models
{
    public partial class complaint_tab
    {
        public int id { get; set; }
        public string m_id { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string company_name { get; set; }
        public string msg { get; set; }
    }
}
