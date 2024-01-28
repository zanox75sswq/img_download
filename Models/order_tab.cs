using System;
using System.Collections.Generic;

#nullable disable

namespace img_download.Models
{
    public partial class order_tab
    {
        public int id { get; set; }
        public string product_m_id { get; set; }
        public int? user_id { get; set; }
        public int? quantity { get; set; }
        public string __product_price { get; set; }
        public string __product_shipping_costs { get; set; }
        public string product_weight { get; set; }
        public string total { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string phone { get; set; }
        public string company_name { get; set; }
        public string country { get; set; }
        public string city { get; set; }
        public string __address { get; set; }
        public string zip_code { get; set; }
        public string order_notes { get; set; }
        public string transport_information { get; set; }
        public int? payment_method { get; set; }
        public string pingpong_link { get; set; }
        public int? pay_currency { get; set; }
        public string __payment_picture { get; set; }
        public int? status { get; set; }
        public DateTime? insert_time { get; set; }
    }
}
