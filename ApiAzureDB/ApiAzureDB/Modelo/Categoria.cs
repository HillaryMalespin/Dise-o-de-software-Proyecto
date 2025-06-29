public class Categoria
{
    public int CategoriaID { get; set; }
    public string Nombre { get; set; }
    public string Descripcion { get; set; }
    public bool EsVisible { get; set; }
    public DateTime FechaCreacion { get; set; }

    public int UsuarioCreacionID { get; set; }
    public Usuario UsuarioCreacion { get; set; }

    public ICollection<DocumentoCategoria> DocumentoCategorias { get; set; }
}
