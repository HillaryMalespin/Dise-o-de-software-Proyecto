using ARCAMovil.Models;
using ARCAMovil.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace ARCAMovil.ViewModels
{
    public partial class BibliotecaViewModel : ObservableObject
    {
        private readonly CarpetasService _carpetasService;

        [ObservableProperty]
        private ObservableCollection<CarpetaDto> carpetas = new();

        [ObservableProperty]
        private bool isLoading;

        public BibliotecaViewModel(CarpetasService carpetasService)
        {
            _carpetasService = carpetasService;
            _ = CargarCarpetasAsync();
        }

        private async Task CargarCarpetasAsync()
        {
            if (IsLoading) return;
            try
            {
                IsLoading = true;
                var resultado = await _carpetasService.ObtenerCarpetasAsync();
                Carpetas.Clear();
                foreach (var carpeta in resultado)
                    Carpetas.Add(carpeta);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error al cargar carpetas: {ex.Message}");
            }
            finally
            {
                IsLoading = false;
            }
        }
    }
}
