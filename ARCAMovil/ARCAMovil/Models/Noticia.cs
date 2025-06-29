using System.Text.Json.Serialization;

namespace ARCAMovil.Models {
    public class Noticia {
        [JsonPropertyName("noticiaId")]
        public int NoticiaID { get; set; }

        [JsonPropertyName("titulo")]
        public string Titulo { get; set; }

        [JsonPropertyName("contenido")]
        public string Contenido { get; set; }

        [JsonPropertyName("imagenUrl")]
        public string ImagenURL { get; set; }

        [JsonPropertyName("fechaPublicacion")]
        public DateTime FechaPublicacion { get; set; }

        [JsonPropertyName("esArchivada")]
        public bool EsArchivada { get; set; }

        [JsonPropertyName("usuarioCreacionId")]
        public int UsuarioCreacionID { get; set; }
    }
}