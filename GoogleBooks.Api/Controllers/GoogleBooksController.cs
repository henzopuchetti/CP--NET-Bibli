using Microsoft.AspNetCore.Mvc;

namespace GoogleBooks.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GoogleBooksController : ControllerBase
    {
        private readonly HttpClient _client;
        private readonly ILogger<GoogleBooksController> _logger;

        public GoogleBooksController(IHttpClientFactory factory, ILogger<GoogleBooksController> logger)
        {
            _client = factory.CreateClient("GoogleBooks");
            _logger = logger;
        }

        // GET api/googlebooks/{isbn}
        [HttpGet("{isbn}")]
        public async Task<IActionResult> GetBook(string isbn)
        {
            var response = await _client.GetAsync($"volumes?q=isbn:{isbn}");
            if (!response.IsSuccessStatusCode)
            {
                _logger.LogWarning("Erro ao buscar livro ISBN {isbn}", isbn);
                return StatusCode((int)response.StatusCode);
            }

            var json = await response.Content.ReadAsStringAsync();
            return Ok(json);
        }
    }
}
