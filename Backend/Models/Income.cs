using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceManagementSystem.Backend.Models
{
    public class Income
    {
        public int IncomeId { get; set; }
        public int UserId { get; set; }
        public int CategoryId { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Amount { get; set; }

        public DateTime Date { get; set; }
    }
}
