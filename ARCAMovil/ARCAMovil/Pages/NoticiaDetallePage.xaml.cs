using ARCAMovil.ViewModels;

namespace ARCAMovil.Pages;

public partial class NoticiaDetallePage : ContentPage {
    public NoticiaDetallePage(NoticiaDetalleViewModel viewModel) {
        InitializeComponent();
        BindingContext = viewModel;
    }
}