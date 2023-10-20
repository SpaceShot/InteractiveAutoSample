using System.Net.Http.Json;

namespace AutoRenderModeServices.Client.Features.WebScraper;

public class WebScraperServiceWasm(HttpClient _httpClient) : IWebScraperService
{
    public async Task<string> Get()
    {
        return await _httpClient.GetFromJsonAsync<string>("webscraper/bing") ?? "empty reply";
    }
}
