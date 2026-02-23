using BlazorDownloadFile;
using Microsoft.AspNetCore.Components;


//using Blazored.SessionStorage
//using EvictionFiler.Client.Jwt;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using System.Net;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.Services.AddScoped(sp =>
{
    var handler = new HttpClientHandler
    {
        UseCookies = true,
        CookieContainer = new CookieContainer()
    };

    var nav = sp.GetRequiredService<NavigationManager>();

    return new HttpClient(handler)
    {
        BaseAddress = new Uri(nav.BaseUri)
    };
});




//builder.Services.AddBlazoredSessionStorage();
//builder.Services.AddAuthorizationCore();
//builder.Services.AddScoped<JwtAuthStateProviders>();
//builder.Services.AddScoped<AuthenticationStateProvider>(sp => sp.GetRequiredService<JwtAuthStateProviders>());

// Service registration yahin honi chahiye:
builder.Services.AddBlazorDownloadFile();

await builder.Build().RunAsync();
