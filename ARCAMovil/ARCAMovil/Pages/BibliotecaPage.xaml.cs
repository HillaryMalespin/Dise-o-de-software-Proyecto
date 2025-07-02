using ARCAMovil.Services;
using ARCAMovil.ViewModels;

namespace ARCAMovil.Pages
{
    public partial class BibliotecaPage : ContentPage
    {
        public BibliotecaPage()
        {
            InitializeComponent();
            BindingContext = new BibliotecaViewModel(new CarpetasService(new HttpClient()));
        }
    }
}
