namespace AutoRenderModeServices.Client.Features.WebScraper
{
    public interface IWebScraperService
    {
        Task<string> Get();
    }
}