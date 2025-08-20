using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Biblioteca.Mvc.Controllers
{
    public class AuthorsController : Controller
    {
        private readonly IHttpClientFactory _httpFactory;

        public AuthorsController(IHttpClientFactory httpFactory)
        {
            _httpFactory = httpFactory;
        }

        // GET: /Authors
        public async Task<IActionResult> Index()
        {
            try
            {
                var client = _httpFactory.CreateClient();
                var response = await client.GetStringAsync("http://localhost:5000/api/authors");
                return Content(response, "application/json");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao acessar Biblioteca.Api: {ex.Message}");
            }
        }
    }
}
