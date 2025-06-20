using System;
using Microsoft.Maui.Controls;
using ARCAMovil.Helpers;

namespace ARCAMovil.Pages
{
    public partial class FormularioSugerenciaPage : ContentPage
    {
        public FormularioSugerenciaPage()
        {
            InitializeComponent();
        }

        private void OnLimpiarClicked(object sender, EventArgs e)
        {
            NombreEntry.Text = string.Empty;
            AsuntoEntry.Text = string.Empty;
            EmailEntry.Text = string.Empty;
            MensajeEditor.Text = string.Empty;
        }

        private async void OnEnviarClicked(object sender, EventArgs e)
        {
            await DisplayAlert("Enviado", "Gracias por tu sugerencia.", "OK");
        }
    }
}
