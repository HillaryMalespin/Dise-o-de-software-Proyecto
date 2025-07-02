using ARCAMovil.Models;
using System.Net.Http.Json;

namespace ARCAMovil.Services
{
    public class CarpetasService
    {
        private readonly HttpClient _httpClient;

        public CarpetasService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<CarpetaDto>> ObtenerCarpetasAsync()
        {
            var url = "https://10.0.2.2:5001/api/CarpetasTematicas";
            // 
            var carpetas = await _httpClient.GetFromJsonAsync<List<CarpetaDto>>(url);
            return carpetas ?? new List<CarpetaDto>();
        }
    }
}
