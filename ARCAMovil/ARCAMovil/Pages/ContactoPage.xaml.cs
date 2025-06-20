using ARCAMovil.Helpers;


namespace ARCAMovil.Pages {

    public partial class ContactoPage : ContentPage {
        public ContactoPage() {
            InitializeComponent();
        }

        private async void OnFormularioClicked(object sender, EventArgs e) {
            await Navigation.PushAsync(new FormularioSugerenciaPage());
        }

        // AÑADIR ESTE MÉTODO PARA QUE EL BOTÓN DE MENÚ FUNCIONE
        private async void OnMenuClicked(object sender, EventArgs e) {
            string action = await DisplayActionSheet("Opciones", "Cancelar", null,
                "Inicio",
                "Biblioteca de Documentos",
                "Notificaciones",
                "Contacto",
                "Descargas");

            // Llamamos a nuestro método centralizado para que él se encargue de la navegación.
            await MenuNavigationHelper.HandleMenuSelection(action, this.Navigation);
        }

    }
}