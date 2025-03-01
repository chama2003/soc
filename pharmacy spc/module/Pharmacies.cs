using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pharmacy_spc.module
{
    public class Pharmacies
    {

        public int pharmacy_id { get; set; }
        public string pharmacy_name { get; set; }
        public string location { get; set; }
        public int contact_number { get; set; }
        public string email { get; set; }
        public string password { get; set; }
    }
}