using ecomeal.client.Components;
using EcoMeal.Site.Services;
using Microsoft.AspNetCore.Components.Authorization;
using MudBlazor.Services; 

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddTransient<AuthenticationHeaderHandler>();
builder.Services.AddMudServices();

// --- MODIFICAREA 1: HttpClient cu bypass pentru certificatul SSL în Development ---
var apiClientBuilder = builder.Services.AddHttpClient("EcoMealApi", client =>
{
    client.BaseAddress = new Uri("https://localhost:7045/");
}).AddHttpMessageHandler<AuthenticationHeaderHandler>();

if (builder.Environment.IsDevelopment())
{
    apiClientBuilder.ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
    {
        ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
    });
}
// ----------------------------------------------------------------------------------

builder.Services.AddScoped(sp => 
    sp.GetRequiredService<IHttpClientFactory>().CreateClient("EcoMealApi"));

// --- MODIFICAREA 2: Adăugarea noului serviciu de comenzi (OrderService) ---
builder.Services.AddScoped<EcoMeal.Client.Services.BusinessService>();
builder.Services.AddScoped<EcoMeal.Client.Services.PackageService>();
builder.Services.AddScoped<EcoMeal.Client.Services.SearchService>();
builder.Services.AddScoped<EcoMeal.Client.Services.OrderService>(); // <-- Adăugat
// --------------------------------------------------------------------------

builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();
app.UseAntiforgery();
app.MapStaticAssets();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();