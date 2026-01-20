using System.Net.Http.Json;
string url = "https://official-joke-api.appspot.com/random_joke";

using var httpClient = new HttpClient();

var response = await httpClient.GetFromJsonAsync<Joke>(url);

Console.WriteLine(response.Setup);
Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine(response.Punchline);
Console.ResetColor();

class Joke
{
    public int Id { get; set; }
    public string Type { get; set; }
    public string Setup { get; set; }
    public string Punchline { get; set; }
}