public class DocumentoDescargado
{
    public int DescargaID { get; set; }
    public int DocumentoID { get; set; }
    public Documento Documento { get; set; }

    public string DispositivoID { get; set; }
    public DateTime FechaDescarga { get; set; }
}
