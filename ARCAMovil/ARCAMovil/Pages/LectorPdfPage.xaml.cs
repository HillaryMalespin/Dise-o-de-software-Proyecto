namespace ARCAMovil.Pages;

public partial class LectorPdfPage : ContentPage
{
    public LectorPdfPage(string urlPdf)
    {
        InitializeComponent();
        MostrarPdfLocal();
    }

    private void MostrarPdfLocal()
    {
        var rutaLocal = Path.Combine(FileSystem.AppDataDirectory, "ley_constitutiva_ccss.pdf");

        if (!File.Exists(rutaLocal))
        {
            DisplayAlert("Error", "No se encontró el archivo PDF local.", "OK");
            return;
        }

        PdfViewer.Source = new UrlWebViewSource
        {
            Url = $"file://{rutaLocal}"
        };
    }
}
