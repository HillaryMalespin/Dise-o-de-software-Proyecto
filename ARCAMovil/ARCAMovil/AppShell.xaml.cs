using ARCAMovil.Pages;

namespace ARCAMovil;

public partial class AppShell : Shell {
    public AppShell() {
        InitializeComponent();

        // Registramos la ruta para poder navegar a la página de detalle
        Routing.RegisterRoute(nameof(NoticiaDetallePage), typeof(NoticiaDetallePage));
    }
}
