public class Notificacion
{
    public int NotificacionID { get; set; }
    public string Titulo { get; set; }
    public string Mensaje { get; set; }
    public DateTime FechaCreacion { get; set; }
    public bool EsImportante { get; set; }

    public int UsuarioCreacionID { get; set; }
    public Usuario UsuarioCreacion { get; set; }

    public int? DocumentoRelacionadoID { get; set; }
    public Documento DocumentoRelacionado { get; set; }
}
