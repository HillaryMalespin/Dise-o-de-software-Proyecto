using ARCAMovil.Pages;
using Microsoft.Maui.Controls;

namespace ARCAMovil;

public partial class App : Application {
    public App() {
        InitializeComponent();

        MainPage = new NavigationPage(new InicioPage()); // Página principal
    }
}
