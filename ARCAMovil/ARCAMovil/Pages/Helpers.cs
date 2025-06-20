using ARCAMovil.Pages;
using Microsoft.Maui.Controls;
using System.Linq;
using System.Threading.Tasks;

namespace ARCAMovil.Helpers {
    public static class MenuNavigationHelper {
        public static async Task HandleMenuSelection(string action, INavigation navigation) {
            // Si el usuario presiona "Cancelar" o no selecciona nada, no hacemos nada.
            if (string.IsNullOrEmpty(action) || action == "Cancelar") {
                return;
            }

            // Obtenemos la página actual para evitar navegar a la misma página donde ya estamos.
            var currentPage = navigation.NavigationStack.LastOrDefault()?.GetType();

            switch (action) {
                case "Inicio":
                    // Es mejor usar PopToRootAsync para volver a la página de inicio original.
                    if (navigation.NavigationStack.Count > 1) {
                        await navigation.PopToRootAsync();
                    }
                    break;

                case "Biblioteca de Documentos":
                    if (currentPage != typeof(BibliotecaPage))
                        await navigation.PushAsync(new BibliotecaPage());
                    break;

                case "Notificaciones":
                    if (currentPage != typeof(NotificacionesPage))
                        await navigation.PushAsync(new NotificacionesPage());
                    break;

                case "Contacto":
                    if (currentPage != typeof(ContactoPage))
                        await navigation.PushAsync(new ContactoPage());
                    break;

                case "Descargas":
                    if (currentPage != typeof(DescargasPage))
                        await navigation.PushAsync(new DescargasPage());
                    break;
            }
        }
    }
}
