using System.Text.Json.Serialization;

namespace ARCAMovil.Models {
    public class NoticiaSummaryDto {
        [JsonPropertyName("noticiaId")]
        public int NoticiaId { get; set; }

        [JsonPropertyName("titulo")]
        public string Titulo { get; set; }

        [JsonPropertyName("imagenUrl")]
        public string ImagenUrl { get; set; }

        [JsonPropertyName("fechaPublicacion")]
        public DateTime FechaPublicacion { get; set; }
    }
}