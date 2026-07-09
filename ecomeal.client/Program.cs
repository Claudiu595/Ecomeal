using ecomeal.client.Components;
using MudBlazor.Services; // Adăugat pentru MudBlazor

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Înregistrăm MudBlazor
builder.Services.AddMudServices();

builder.Services.AddHttpClient("EcoMealApi", client =>
{
    client.BaseAddress = new Uri("https://localhost:7045/");
});

builder.Services.AddScoped(sp => 
    sp.GetRequiredService<IHttpClientFactory>().CreateClient("EcoMealApi"));

// Înregistrăm serviciile tale folosind namespace-ul corect (Client)
builder.Services.AddScoped<EcoMeal.Client.Services.BusinessService>();
builder.Services.AddScoped<EcoMeal.Client.Services.PackageService>();
builder.Services.AddScoped<EcoMeal.Client.Services.SearchService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
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