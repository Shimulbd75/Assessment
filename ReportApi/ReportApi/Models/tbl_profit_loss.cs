//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ReportApi.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_profit_loss
    {
        public int Id { get; set; }
        public Nullable<decimal> TotalIncome { get; set; }
        public Nullable<decimal> TotalExpenses { get; set; }
        public Nullable<decimal> ProfitLoss { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public string TransactionType { get; set; }
        public Nullable<decimal> amount { get; set; }
    }
}