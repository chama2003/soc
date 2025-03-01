using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pharmacy_spc.module
{
    public class quatation
    {
        public int quatation_id { get; set; }
        public string quatation_date { get; set; }
        public string supplier_name { get; set; }
        public int supplier_id { get; set; }
       
        public string status { get; set; }
    }
}