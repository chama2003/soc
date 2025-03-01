using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pharmacy_spc.module
{
    public class stock_view
    {
        public int inventory_id { get; set; }
        
        public string drug_name { get; set; }
        public string drug_id { get; set; }
        public string warehouse_name { get; set; }

        public int quantity_in_stock { get; set; }
        public int purchase_price { get; set; }
        public int selling_price { get; set; }
    }
}