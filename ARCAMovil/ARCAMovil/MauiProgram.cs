using Microsoft.Extensions.Logging;
using ARCAMovil.Services;
using ARCAMovil.ViewModels;
using ARCAMovil.Pages;
using CommunityToolkit.Maui;

namespace ARCAMovil;

public static class MauiProgram {
    public static MauiApp CreateMauiApp() {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts => {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

#if DEBUG
        builder.Logging.AddDebug();
#endif

        // CONFIGURACIÓN DE LA CONEXIÓN
        // Función para obtener la URL base correcta según la plataforma
        string GetApiBaseAddress() {
            // Para el emulador de Android, usamos 10.0.2.2 para apuntar al localhost de la PC
            if (DeviceInfo.Current.Platform == DevicePlatform.Android)
                return "https://10.0.2.2:5001";
            // Para otras plataformas (Windows, iOS en Mac), localhost funciona
            return "https://localhost:5001";
        }

        var httpClientHandler = new HttpClientHandler();
#if DEBUG
        httpClientHandler.ServerCertificateCustomValidationCallback =
            (message, cert, chain, errors) => true;
#endif

        // Registro de servicios con la nueva configuración
        builder.Services
            .AddSingleton(new HttpClient(httpClientHandler) { BaseAddress = new Uri(GetApiBaseAddress()) })
            .AddTransient<NoticiasService>()
            .AddTransient<InicioViewModel>()
            .AddTransient<InicioPage>()
            .AddTransient<NoticiaDetalleViewModel>()
            .AddTransient<NoticiaDetallePage>();

        return builder.Build();
    }
}