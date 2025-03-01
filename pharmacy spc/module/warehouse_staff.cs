using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pharmacy_spc.module
{
    public class warehouse_staff
    {
        public int staff_id { get; set; }
        public string staff_name { get; set; }
        public string staff_address { get; set; }
        public string staff_email { get; set; }
        public int staff_contact_number { get; set; }
        public string password { get; set; }
    }
}