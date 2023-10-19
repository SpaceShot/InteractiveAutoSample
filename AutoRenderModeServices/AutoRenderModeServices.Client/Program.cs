using AutoRenderModeServices.Client.Features.WebScraper;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IWebScraperService, WebScraperServiceWasm>();

await builder.Build().RunAsync();
