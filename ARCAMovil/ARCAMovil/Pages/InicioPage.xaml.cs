namespace ARCAMovil.Pages

{
    public partial class InicioPage : ContentPage
    {
        public InicioPage()
        {
            InitializeComponent();
        }
        private async void OnMenuClicked(object sender, EventArgs e)
        {
            string action = await DisplayActionSheet("Opciones", "Cancelar", null, "Biblioteca");

            if (action == "Biblioteca")
            {
                await Navigation.PushAsync(new BibliotecaPage());
            }
        }


    }
}
