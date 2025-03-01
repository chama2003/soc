using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pharmacy_spc.module
{
    public class Orders
    {
        public int order_id { get; set; }
        public int drug_id { get; set; }
        public int Pharmacy_id { get; set; }
        public int quantity { get; set; }
        public int unit_price { get; set; }
        public string logged_phr { get; set; }
    }
}