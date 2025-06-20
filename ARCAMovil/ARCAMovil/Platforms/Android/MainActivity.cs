using Android.App;
using Android.Content.PM; // <-- Asegúrate de tener esto
using Android.OS;

namespace ARCAMovil;

[Activity(
    Theme = "@style/Maui.SplashTheme",
    MainLauncher = true,
    LaunchMode = LaunchMode.SingleTop,
    ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode |
                           ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density,
    ScreenOrientation = ScreenOrientation.Portrait)] // <-- ESTA LÍNEA FUERZA MODO VERTICAL
public class MainActivity : MauiAppCompatActivity {
}
