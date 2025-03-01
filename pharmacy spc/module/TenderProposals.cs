using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pharmacy_spc.module
{
    public class Tender_Proposals
    {

        public int tender_id { get; set; }
        public int supplier_id { get; set; }
        public int drug_id { get; set; }
        public int proposal_date { get; set; }
        public string proposal_status { get; set; }
        public int tender_price { get; set; }
    }
}