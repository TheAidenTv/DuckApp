using Newtonsoft.Json;

namespace DuckApp;

public partial class MainPage : ContentPage
{

    public MainPage()
    {
        InitializeComponent();
        GenerateRandomDuck(this, EventArgs.Empty);
    }

    private async void GenerateRandomDuck(object sender, EventArgs e)
    {
        string url = "https://random-d.uk/api/random";

        HttpClient client = new HttpClient();
        HttpResponseMessage response = await client.GetAsync(url);

        if (response.IsSuccessStatusCode)
        {
            string json = await response.Content.ReadAsStringAsync();
            Duck duck = JsonConvert.DeserializeObject<Duck>(json);

            duckImage.Source = duck.url;
        }
        else
        {
            duckImage.Source = "error.png";
        }
    }
}

internal class Duck
{
    public string url { get; set; }
}