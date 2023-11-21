using System.Text.Json;

public class CatFact
{
    public string Fact { get; set; }
}

class Program
{
    static async Task Main(string[] args)
    {
        var url = "https://catfact.ninja/fact";
        var json = await MakeHttpGet(url);
        var cat = JsonSerializer.Deserialize<CatFact>(json , 
            new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        Console.WriteLine("Fact: " + cat.Fact);
    }


    private static async Task<string> MakeHttpGet(string url)
    {
        using (var client = new HttpClient())
        {
            using (var response = await client.GetAsync(url))
            {
                using (var content = response.Content)
                {
                    return await content.ReadAsStringAsync();
                }
            }
        }
    }
}