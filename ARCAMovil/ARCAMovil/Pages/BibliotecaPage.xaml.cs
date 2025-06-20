namespace ARCAMovil.Pages;
using ARCAMovil.Helpers;
public partial class BibliotecaPage : ContentPage
{
    public BibliotecaPage()
    {
        InitializeComponent();
    }

    
    private async void OnCarpetaClicked(object sender, EventArgs e)
    {
        var boton = sender as Button;
        var carpeta = boton?.Text;

        if (!string.IsNullOrEmpty(carpeta))
        {
            await Navigation.PushAsync(new CarpetaPage(carpeta, new List<CarpetaPage.ArchivoPdf>()));
        }
    }
}
