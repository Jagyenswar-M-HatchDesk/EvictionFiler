using BlazorDownloadFile;
using Blazored.TextEditor;

using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Syncfusion.Blazor;
var builder = WebAssemblyHostBuilder.CreateDefault(args);


builder.Services.AddSyncfusionBlazor();


// Service registration yahin honi chahiye:
builder.Services.AddBlazorDownloadFile();

await builder.Build().RunAsync();
