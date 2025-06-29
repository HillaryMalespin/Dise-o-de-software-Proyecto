using ARCAMovil.Models;
using ARCAMovil.Pages;
using ARCAMovil.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace ARCAMovil.ViewModels {
    public partial class InicioViewModel : ObservableObject {
        private readonly NoticiasService _noticiasService;

        [ObservableProperty]
        private ObservableCollection<NoticiaSummaryDto> _noticias;

        [ObservableProperty]
        private bool _isLoading;

        public InicioViewModel(NoticiasService noticiasService) {
            _noticiasService = noticiasService;
            _noticias = new ObservableCollection<NoticiaSummaryDto>();
            CargarNoticiasCommand.Execute(null);
        }

        [RelayCommand]
        private async Task CargarNoticiasAsync() {
            if (IsLoading) return;
            try {
                IsLoading = true;
                var noticiasList = await _noticiasService.GetNoticiasAsync();
                if (noticiasList != null) {
                    Noticias.Clear();
                    foreach (var noticia in noticiasList) {
                        Noticias.Add(noticia);
                    }
                }
            } catch (Exception ex) {
                System.Diagnostics.Debug.WriteLine($"---> Error en ViewModel al cargar noticias: {ex.Message}");
            } finally {
                IsLoading = false;
            }
        }

        [RelayCommand]
        private async Task GoToDetails(NoticiaSummaryDto noticia) {
            if (noticia == null) return;
            await Shell.Current.GoToAsync(nameof(NoticiaDetallePage), true, new Dictionary<string, object>
            {
                { "NoticiaId", noticia.NoticiaId }
            });
        }
    }
}