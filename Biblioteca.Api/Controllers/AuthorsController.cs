using Biblioteca.Infrastructure;
using Biblioteca.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Biblioteca.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorsController : ControllerBase
    {
        private readonly BibliotecaDbContext _context;

        public AuthorsController(BibliotecaDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAuthors() =>
            Ok(await _context.Authors.Include(a => a.Books).ToListAsync());

        [HttpPost]
        public async Task<IActionResult> AddAuthor(Author author)
        {
            _context.Authors.Add(author);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetAuthors), new { id = author.Id }, author);
        }
    }
}
