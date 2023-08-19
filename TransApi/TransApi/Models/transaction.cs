using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TransApi.Models
{
    public class transaction
    {
        public int trans_id { get; set; }
        public int client_id { get; set; }
        public int acc_no { get; set; }
        public decimal trans_amount { get; set; }
        public string trans_description { get; set; }
        public string trans_type { get; set; }
        public string dr_cr { get; set; }
        public System.DateTime trans_date { get; set; }
        public decimal total_income { get; set; }
        public decimal total_expense { get; set; }
    }
}