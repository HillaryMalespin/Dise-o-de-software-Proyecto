using Microsoft.Maui.Controls;
using System;
using ARCAMovil.Helpers;

namespace ARCAMovil.Pages {
    public partial class NotificacionesPage : ContentPage {
        public NotificacionesPage() {
            InitializeComponent();
        }

        // Método para que el botón de menú del encabezado funcione
        private async void OnMenuClicked(object sender, EventArgs e) {
            // Muestra las mismas opciones que en las otras páginas
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