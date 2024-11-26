using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using FinanceManagementSystem.Backend.Models;
using FinanceManagementSystem.Backend.Data;

namespace FinanceManagementSystem.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IncomesController : ControllerBase
    {
        private readonly FinanceDbContext _context;

        public IncomesController(FinanceDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<Income>> PostIncome([FromBody] Income income)
        {
            if (ModelState.IsValid)
            {
                _context.Incomes.Add(income);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetIncome), new { id = income.IncomeId }, income);
            }
            return BadRequest(ModelState);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Income>> GetIncome(int id)
        {
            var income = await _context.Incomes.FindAsync(id);

            if (income == null)
            {
                return NotFound();
            }

            return income;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutIncome(int id, Income income)
        {
            if (id != income.IncomeId)
            {
                return BadRequest();
            }

            _context.Entry(income).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IncomeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        private bool IncomeExists(int id)
        {
            return _context.Incomes.Any(e => e.IncomeId == id);
        }
    }
}
