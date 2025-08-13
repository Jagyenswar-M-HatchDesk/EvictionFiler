using BlazorDownloadFile;

using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);


// Service registration yahin honi chahiye:
builder.Services.AddBlazorDownloadFile();

await builder.Build().RunAsync();
