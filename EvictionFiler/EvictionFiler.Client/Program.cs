using BlazorDownloadFile;

//using Blazored.SessionStorage
//using EvictionFiler.Client.Jwt;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);





//builder.Services.AddBlazoredSessionStorage();
//builder.Services.AddAuthorizationCore();
//builder.Services.AddScoped<JwtAuthStateProviders>();
//builder.Services.AddScoped<AuthenticationStateProvider>(sp => sp.GetRequiredService<JwtAuthStateProviders>());

// Service registration yahin honi chahiye:
builder.Services.AddBlazorDownloadFile();

await builder.Build().RunAsync();
