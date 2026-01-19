using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MSFD_BlazorApiDemo;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// Add a named HttpClient for external API calls
builder.Services.AddHttpClient("ExternalAPI", client =>
{
    // No BaseAddress so it can make requests to any URL
});

await builder.Build().RunAsync();
