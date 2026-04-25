using Microsoft.AspNetCore.Mvc;
using ControleFinanceiro.API.Data;
using ControleFinanceiro.API.Models;

namespace ControleFinanceiro.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TransactionsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetTransactions([FromQuery] string? tipo, [FromQuery] string? categoria)
        {
            var query = _context.Transactions.AsQueryable();

            if (!string.IsNullOrEmpty(tipo))
            {
                query = query.Where(t => t.Tipo.ToLower() == tipo.ToLower());
            }

            if (!string.IsNullOrEmpty(categoria))
            {
                query = query.Where(t => t.Categoria.ToLower().Contains(categoria.ToLower()));
            }

            var transactions = query.ToList();

            return Ok(transactions);
        }

        [HttpPost]
        public IActionResult Post(Transaction transaction)
        {
            var type = transaction.Tipo.ToLower();

            if (type != "ganho" && type != "despesa")
                return BadRequest("Tipo tem que ser 'ganho' or 'despesa'");

            transaction.Tipo = type;

            _context.Transactions.Add(transaction);
            _context.SaveChanges();

            return Ok(transaction);
        }

        [HttpGet("balance")]
        public IActionResult GetBalance()
        {
            var ganho = _context.Transactions
                .Where(t => t.Tipo.ToLower() == "ganho")
                .Sum(t => (double?)t.Quantidade) ?? 0;

            var despesa = _context.Transactions
                .Where(t => t.Tipo.ToLower() == "despesa")
                .Sum(t => (double?)t.Quantidade) ?? 0;

            return Ok(new
            {
                ganhoTotal = ganho,
                despesaTotal = despesa,
                balance = ganho - despesa
            });
        }
    }
}
