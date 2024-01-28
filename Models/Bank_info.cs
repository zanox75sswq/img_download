using System;
using System.Collections.Generic;

#nullable disable

namespace img_download.Models
{
    public partial class Bank_info
    {
        public int id { get; set; }
        public string Bank_Name { get; set; }
        public string A_C { get; set; }
        public string Berf { get; set; }
        public string Swift_Code { get; set; }
        public string Branch { get; set; }
        public string Bank_Address { get; set; }
        public int? Pay_Currency { get; set; }
    }
}
