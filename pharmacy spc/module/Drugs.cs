using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pharmacy_spc.module
{
    public class Drugs
    {
        
        public int drug_id { get; set; }
        public string drug_name { get; set; }
        public int supplier_id { get; set; }
        public int minimum_order { get; set; }
        public string supplier_name { get; set; }
    }
}