namespace ARCAMovil {
    public partial class App : Application {
        public App() {
            InitializeComponent();

            // La forma correcta de iniciar una app con Shell es crear una instancia de AppShell.
            MainPage = new AppShell();
        }
    }
}