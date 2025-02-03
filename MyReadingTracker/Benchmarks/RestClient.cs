using System.Net.Http.Headers;
using System.Net.Http.Json;
using MyReadingTracker.Resources.Responses.Resources;

namespace Benchmarks;

public class RestClient
{
    private static readonly HttpClient client = new HttpClient();
    public async Task<HttpResponseMessage> GetSmallPayloadAsync()
    {
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        var id = "1";
        var response = await client.GetAsync($"http://localhost:5099/api/book/{id}");
        return response;
    }
}