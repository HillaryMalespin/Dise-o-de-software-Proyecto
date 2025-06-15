using System;
using Microsoft.Maui.Controls;

namespace ARCAMovil.Pages;

public partial class ListaPdfPage : ContentPage
{
    private readonly string carpeta;

    public ListaPdfPage(string carpetaSeleccionada)
    {
        InitializeComponent();
        carpeta = carpetaSeleccionada;
        lblTituloCarpeta.Text = carpeta + ":";

        MostrarDocumentos(carpeta);
    }

    private void MostrarDocumentos(string carpeta)
    {
        // Aquí defines tus documentos estáticos (luego puedes cargarlos de un JSON, API, etc.)
        var documentos = new List<(string Titulo, string Archivo, string Fecha)>
        {
            ("Guía de Vacunación Antitosferínica", "guia_vacunacion_tosferina.pdf", "30/4/2025"),
            ("Protocolo de Atención en Urgencias para Crisis de Tosferina", "protocolo_urgencias_tosferina.pdf", "30/4/2025"),
            ("Recomendaciones para el Manejo de Brotes en Guarderías y Escuelas", "recomendaciones_brotes_guarderias.pdf", "30/4/2025")
        };

        foreach (var doc in documentos)
        {
            var frame = new Frame
            {
                BackgroundColor = Color.FromArgb("#F9F9F9"),
                CornerRadius = 10,
                HasShadow = true,
                Padding = 10,
                Content = new StackLayout
                {
                    Spacing = 5,
                    Children =
                    {
                        new Label
                        {
                            Text = doc.Titulo,
                            FontAttributes = FontAttributes.Bold,
                            FontSize = 14,
                            TextColor = Color.FromArgb("#003366")
                        },
                        new Label
                        {
                            Text = $"Última Actualización: {doc.Fecha}",
                            FontSize = 12,
                            TextColor = Colors.Gray
                        }
                    }
                }
            };

            var tapGesture = new TapGestureRecognizer();
            tapGesture.Tapped += async (s, e) =>
            {
                await Navigation.PushAsync(new LectorPdfPage(doc.Archivo));
            };

            frame.GestureRecognizers.Add(tapGesture);
            PdfStack.Children.Add(frame);
        }
    }
}
