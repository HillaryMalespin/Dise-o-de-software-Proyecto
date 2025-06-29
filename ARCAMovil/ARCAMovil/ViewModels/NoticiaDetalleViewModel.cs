using ARCAMovil.Models;
using ARCAMovil.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Threading.Tasks;

namespace ARCAMovil.ViewModels {
    [QueryProperty(nameof(NoticiaId), "NoticiaId")]
    // ASEGÚRATE DE QUE LA PALABRA 'partial' ESTÉ AQUÍ
    public partial class NoticiaDetalleViewModel : ObservableObject {
        private readonly NoticiasService _noticiasService;

        [ObservableProperty]
        private Noticia _noticiaMostrada;

        private int _noticiaId;
        public int NoticiaId {
            get => _noticiaId;
            set {
                _noticiaId = value;
                LoadNoticiaDetailsAsync(value);
            }
        }

        public NoticiaDetalleViewModel(NoticiasService noticiasService) {
            _noticiasService = noticiasService;
            _noticiaMostrada = new Noticia();
        }

        private async Task LoadNoticiaDetailsAsync(int noticiaId) {
            if (noticiaId == 0) return;

            var result = await _noticiasService.GetNoticiaDetailAsync(noticiaId);
            if (result != null) {
                NoticiaMostrada = result;
            }
        }
    }
}