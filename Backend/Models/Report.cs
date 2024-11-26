using System;

namespace FinanceManagementSystem.Backend.Models
{
    public class Report
    {
        public int ReportId { get; set; }
        public int UserId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string ReportData { get; set; }
    }
}
