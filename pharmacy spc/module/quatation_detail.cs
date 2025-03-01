using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pharmacy_spc.module
{
    public class quatation_detail
    {
        public int qd_id { get; set; }
        public int drug_id { get; set; }
        public int quantity { get; set; }
        public int unit_price { get; set; }
        public int quatation_id { get; set; }
       
        public string drug_name { get; set; }
        
            
    }
}