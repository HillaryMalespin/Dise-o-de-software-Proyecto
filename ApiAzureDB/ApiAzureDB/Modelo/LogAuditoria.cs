public class LogAuditoria
{
    public int LogID { get; set; }
    public DateTime FechaHora { get; set; }
    public int? UsuarioID { get; set; }
    public Usuario Usuario { get; set; }
    public string Accion { get; set; }
    public string Detalles { get; set; }
    public string DireccionIP { get; set; }
}
