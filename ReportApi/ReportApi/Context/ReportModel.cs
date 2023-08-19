using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReportApi.Context
{
    public class ReportModel
    {
        public decimal TotalIncome { get; set; }
        public decimal TotalExpenses { get; set; }
        public decimal ProfitLoss { get; set; }
    }
}