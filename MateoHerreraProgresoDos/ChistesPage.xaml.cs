using System.Net.Http.Json;

namespace MateoHerreraProgresoDos;

public partial class ChistesPage : ContentPage
{
    private readonly HttpClient _httpClient = new();

    public ChistesPage()
    {
        InitializeComponent();
        ObtenerChiste(); // Para que cargue un chiste al abrir la página
    }

    private async void OnObtenerChisteClicked(object sender, EventArgs e)
    {
        await ObtenerChiste();
    }

    private async Task ObtenerChiste()
    {
        try
        {
            var chiste = await _httpClient.GetFromJsonAsync<Chiste>("https://official-joke-api.appspot.com/random_joke");
            if (chiste != null)
            {
                ChisteLabel.Text = $"{chiste.setup}\n\n{chiste.punchline}";
            }
        }
        catch (Exception ex)
        {
            ChisteLabel.Text = "Error al obtener el chiste: " + ex.Message;
        }
    }
}

public class Chiste
{
    public string setup { get; set; }
    public string punchline { get; set; }
}
