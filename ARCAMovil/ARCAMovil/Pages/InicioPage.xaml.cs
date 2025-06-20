using ARCAMovil.Helpers;

namespace ARCAMovil.Pages {
    public partial class InicioPage : ContentPage {
        public InicioPage() {
            InitializeComponent();
            // Agrega esta línea para ocultar la barra de navegación de arriba
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private async void OnMenuClicked(object sender, EventArgs e) {
            // Cambiamos las opciones que se muestran en el menú emergente
            string action = await DisplayActionSheet("Opciones", "Cancelar", null,
                "Biblioteca de Documentos",
                "Notificaciones",
                "Contacto",
                "Descargas");

            // Llamamos a nuestro método centralizado para que él se encargue de la navegación.
            await MenuNavigationHelper.HandleMenuSelection(action, this.Navigation);
        }
    }
}
