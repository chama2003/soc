using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pharmacy_spc.module
{
    public class Payments
    {
        public int payment_id { get; set; }
        public int order_id { get; set; }
        public int payment_date { get; set; }
        public int amount_paid { get; set; }
        public string payment_status { get; set; }

    }
}