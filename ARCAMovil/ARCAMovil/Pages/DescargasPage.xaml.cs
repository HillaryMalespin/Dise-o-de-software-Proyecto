using Microsoft.Maui.Controls;
using System;
using ARCAMovil.Helpers;

namespace ARCAMovil.Pages {
    public partial class DescargasPage : ContentPage {
        public DescargasPage() {
            InitializeComponent();
        }

        // Método para que el botón de menú del encabezado funcione
        private async void OnMenuClicked(object sender, EventArgs e) {
            // Lógica para mostrar el menú de opciones

            string action = await DisplayActionSheet("Opciones", "Cancelar", null,
                "Inicio",
                "Biblioteca de Documentos",
                "Notificaciones",
                "Contacto",
                "Descargas");

            // Llamamos a nuestro método centralizado para que él se encargue de la navegación.
            await MenuNavigationHelper.HandleMenuSelection(action, this.Navigation);
        }

        // Lógica para el botón de filtro (FAB)
        private async void OnFilterClicked(object sender, EventArgs e) {
            // mostrar opciones de filtro, por ejemplo
            await DisplayAlert("Filtro", "Funcionalidad de filtro no implementada.", "OK");
        }

        // Lógica para los botones de borrar de cada elemento
        private async void OnDeleteClicked(object sender, EventArgs e) {
            bool confirm = await DisplayAlert("Confirmar", "¿Estás seguro de que quieres eliminar este documento de tus descargas?", "Sí, eliminar", "No");
            if (confirm) {
                // Aquí iría la lógica para eliminar el archivo
            }
        }
    }
}