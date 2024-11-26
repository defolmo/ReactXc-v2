using Microsoft.EntityFrameworkCore;
using FinanceManagementSystem.Backend.Models;

namespace FinanceManagementSystem.Backend.Data
{
    public class FinanceDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Income> Incomes { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Report> Reports { get; set; }

        public FinanceDbContext(DbContextOptions<FinanceDbContext> options) : base(options) { }
    }
}
