using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using ARCAMovil.Models;

namespace ARCAMovil.Services {
    public class NoticiasService {
        private readonly HttpClient _httpClient;

        public NoticiasService(HttpClient httpClient) {
            _httpClient = httpClient;
        }

        public async Task<List<NoticiaSummaryDto>> GetNoticiasAsync() {
            try {
                var response = await _httpClient.GetAsync("api/Noticias");
                if (response.IsSuccessStatusCode) {
                    return await response.Content.ReadFromJsonAsync<List<NoticiaSummaryDto>>();
                }
            } catch (Exception ex) {
                System.Diagnostics.Debug.WriteLine($"---> Error al obtener resúmenes de noticias: {ex.Message}");
            }
            return new List<NoticiaSummaryDto>();
        }

        public async Task<Noticia> GetNoticiaDetailAsync(int noticiaId) {
            try {
                var response = await _httpClient.GetAsync($"api/Noticias/{noticiaId}");
                if (response.IsSuccessStatusCode) {
                    return await response.Content.ReadFromJsonAsync<Noticia>();
                }
            } catch (Exception ex) {
                System.Diagnostics.Debug.WriteLine($"---> Error al obtener detalle de noticia: {ex.Message}");
            }
            return null;
        }
    }
}