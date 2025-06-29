public class Noticia
{
    public int NoticiaID { get; set; }
    public string Titulo { get; set; }
    public string Contenido { get; set; }
    public string ImagenURL { get; set; }
    public DateTime FechaPublicacion { get; set; }
    public bool EsArchivada { get; set; }

    public int UsuarioCreacionID { get; set; }
    public Usuario UsuarioCreacion { get; set; }
}
