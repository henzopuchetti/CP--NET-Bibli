using System.Net.Http;
using System.Threading.Tasks;

namespace Biblioteca.Mvc.Services
{
    public class BibliotecaService
    {
        private readonly HttpClient _http;

        public BibliotecaService(HttpClient http)
        {
            _http = http;
        }

        public async Task<string> GetBooks()
        {
            var response = await _http.GetStringAsync("api/books"); // ajusta a URL se necessário
            return response;
        }
    }
}
