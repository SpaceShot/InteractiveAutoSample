using AutoRenderModeServices.Client.Features;
using AutoRenderModeServices.Client.Features.WebScraper;
using AutoRenderModeServices.Client.Pages;
using AutoRenderModeServices.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddHttpClient();

builder.Services.AddScoped<IWebScraperService, WebScraperServiceServer>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(Counter).Assembly);

app.MapGet("/webscraper/bing", async (IWebScraperService _webScraper) =>
{
    var responseText = await _webScraper.Get();
    
    if (string.IsNullOrWhiteSpace(responseText))
    {
        return Results.Problem(detail: "Didn't work");
    }

    return Results.Ok(responseText);
});

app.Run();
