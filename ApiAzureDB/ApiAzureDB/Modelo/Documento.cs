public class Documento
{
    public int DocumentoID { get; set; }
    public string Titulo { get; set; }
    public string Descripcion { get; set; }
    public string NombreArchivo { get; set; }
    public string RutaAzureBlob { get; set; }
    public int Version { get; set; }
    public DateTime FechaPublicacion { get; set; }
    public DateTime FechaUltimaActualizacion { get; set; }
    public bool EsVisible { get; set; }
    public int UsuarioModificacionID { get; set; }
    public Usuario UsuarioModificacion { get; set; }
    public string OCRTextoCompleto { get; set; }
    public int TamanioBytes { get; set; }
    public string Checksum { get; set; }

    public ICollection<DocumentoCarpeta> DocumentoCarpetas { get; set; }
    public ICollection<DocumentoCategoria> DocumentoCategorias { get; set; }
    public ICollection<Notificacion> Notificaciones { get; set; }
    public ICollection<DocumentoDescargado> Descargas { get; set; }
}
