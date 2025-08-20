using Biblioteca.Infrastructure;
using Biblioteca.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Biblioteca.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoansController : ControllerBase
    {
        private readonly BibliotecaDbContext _context;

        public LoansController(BibliotecaDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetLoans() =>
            Ok(await _context.Loans.Include(l => l.Book).ToListAsync());

        [HttpPost]
        public async Task<IActionResult> AddLoan(Loan loan)
        {
            _context.Loans.Add(loan);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetLoans), new { id = loan.Id }, loan);
        }
    }
}
