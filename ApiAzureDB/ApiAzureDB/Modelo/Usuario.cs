public class Usuario
{
    public int UsuarioID { get; set; }
    public string Nombre { get; set; }
    public string PrimerApellido { get; set; }
    public string SegundoApellido { get; set; }
    public string CorreoInstitucional { get; set; }
    public string Rol { get; set; }
    public string EstadoCuenta { get; set; }
    public DateTime FechaCreacion { get; set; }
    public DateTime? FechaUltimoAcceso { get; set; }
    public string AzureADObjectID { get; set; }
    public int IntentosFallidos { get; set; }
    public DateTime? FechaBloqueo { get; set; }

    public ICollection<CarpetaTematica> CarpetasCreadas { get; set; }
    public ICollection<Categoria> CategoriasCreadas { get; set; }
    public ICollection<Documento> DocumentosModificados { get; set; }
    public ICollection<Noticia> NoticiasCreadas { get; set; }
    public ICollection<Notificacion> NotificacionesCreadas { get; set; }
}
