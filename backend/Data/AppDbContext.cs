using Microsoft.EntityFrameworkCore;
using ControleFinanceiro.API.Models;

namespace ControleFinanceiro.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Transaction> Transactions { get; set; }
    }
}