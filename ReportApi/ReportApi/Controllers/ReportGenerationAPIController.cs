using ReportApi.Context; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ReportApi.Controllers
{
    public class ReportGenerationAPIController : ApiController
    {
        private TransactionDBEntities db = new TransactionDBEntities();

        [HttpGet]
        public IHttpActionResult GetFinancialReport(int  Id, DateTime startDate, DateTime endDate)
        {
            var transactions = db.tbl_transaction
                .Where(t => t.client_id == Id && t.trans_date >= startDate && t.trans_date <= endDate)
                .ToList();

            decimal totalIncome = transactions.Where(t => t.trans_type == "I").Sum(t => Convert.ToDecimal(t.trans_amount));
            decimal totalExpenses = transactions.Where(t => t.trans_type == "E").Sum(t => Convert.ToDecimal(t.trans_amount));
            decimal profitLoss = totalIncome - totalExpenses;

            var financialReport = new ReportModel
            {
                TotalIncome = totalIncome,
                TotalExpenses = totalExpenses,
                ProfitLoss = profitLoss
            };

            return Ok(financialReport);
        }
    }
}
