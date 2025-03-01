using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pharmacy_spc.module
{
    public class Transactions
    {
        public int transaction_id { get; set; }
        public int pharmacy_id { get; set; }
        public int drug_id { get; set; }
        public int quantity_sold { get; set; }
        public int sale_date { get; set; }
        public int sale_price { get; set; }

    }
}