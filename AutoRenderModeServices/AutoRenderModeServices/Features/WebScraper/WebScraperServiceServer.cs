using AutoRenderModeServices.Client.Features.WebScraper;

namespace AutoRenderModeServices.Client.Features;

public class WebScraperServiceServer(IHttpClientFactory _httpClientFactory) : IWebScraperService
{
    public async Task<string> Get()
    {
        var client = _httpClientFactory.CreateClient();

        var responseMessage = await client.GetAsync("https://www.bing.com");

        if (responseMessage.IsSuccessStatusCode)
        {
            var text = await responseMessage.Content.ReadAsStringAsync();
            return text;
        }

        return "";
    }

}
