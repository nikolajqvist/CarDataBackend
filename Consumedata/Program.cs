using System.Text.Json;
using System.Net.Http;
using System.Text;
namespace Consumedata;

class Program
{
    static async Task Main(string[] args)
    {
        HttpClient client = new HttpClient(){
            BaseAddress = new Uri("https://localhost:7175"),
        };
        await GetIt(client);
        await PostIt(client, 659485, 55, "Dame");
    }
    static async Task GetIt(HttpClient httpClient)
    {
        using HttpResponseMessage response = await httpClient.GetAsync("/api/cardata");

        response.EnsureSuccessStatusCode();

        var jsonResponse = await response.Content.ReadAsStringAsync();
        Console.WriteLine($"{jsonResponse}\n");
    }
    static async Task PostIt(HttpClient httpClient, int TestPersonNumber, int Age, string Gender){
        using StringContent jsonContent = new(
                JsonSerializer.Serialize(new 
                    {
                    TestPersonNumber = TestPersonNumber,
                    Age = Age,
                    Gender = Gender
                    }),
                    Encoding.UTF8,
                    "application/json");
        using HttpResponseMessage response = await httpClient.PostAsync("/api/userp", jsonContent); 

        response.EnsureSuccessStatusCode();

        var jsonResponse = await response.Content.ReadAsStringAsync();
        Console.WriteLine($"{jsonResponse}");
    }
}
