using System.Collections.ObjectModel;
using static ARCAMovil.Pages.CarpetaPage;

namespace ARCAMovil.Pages; // ⚠️ Debe coincidir con el espacio de nombres del proyecto

public partial class CarpetaPage : ContentPage
{
    public CarpetaPage(string carpetaNombre, List<ArchivoPdf> archivos)
    {
        InitializeComponent();

        CarpetaLabel.Text = carpetaNombre + ":";
        Archivos = new ObservableCollection<ArchivoPdf>(archivos);
        ArchivosCollectionView.ItemsSource = Archivos;

        ArchivosCollectionView.SelectionChanged += OnArchivoSeleccionado;
    }

    public class ArchivoPdf
    {
        public string Nombre { get; set; }
        public string Fecha { get; set; }
        public string RutaArchivo { get; set; }
    }

    public ObservableCollection<ArchivoPdf> Archivos { get; set; } = new();

    private async void OnArchivoSeleccionado(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is ArchivoPdf archivo)
        {
            await Navigation.PushAsync(new LectorPdfPage(archivo.RutaArchivo));
        }
    }
}


