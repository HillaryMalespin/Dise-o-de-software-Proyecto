using ARCAMovil.Pages; 

namespace ARCAMovil;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        MainPage = new NavigationPage(new InicioPage()); // Página principal
    }
}
