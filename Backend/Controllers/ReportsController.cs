using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinanceManagementSystem.Backend.Models;
using FinanceManagementSystem.Backend.Data;

namespace FinanceManagementSystem.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReportsController : ControllerBase
    {
        private readonly FinanceDbContext _context;

        public ReportsController(FinanceDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<Report>> GenerateReport([FromBody] Report report)
        {
            var incomes = await _context.Incomes
                .Where(i => i.UserId == report.UserId && i.Date >= report.StartDate && i.Date <= report.EndDate)
                .ToListAsync();

            var expenses = await _context.Expenses
                .Where(e => e.UserId == report.UserId && e.Date >= report.StartDate && e.Date <= report.EndDate)
                .ToListAsync();

            // Generate report data
            string reportData = GenerateReportData(incomes, expenses);

            report.ReportData = reportData;
            _context.Reports.Add(report);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetReport), new { id = report.ReportId }, report);
        }

        private string GenerateReportData(List<Income> incomes, List<Expense> expenses)
        {
            // Logic to generate report data
            return "Report Data";
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Report>> GetReport(int id)
        {
            var report = await _context.Reports.FindAsync(id);

            if (report == null)
            {
                return NotFound();
            }

            return report;
        }
    }
}
