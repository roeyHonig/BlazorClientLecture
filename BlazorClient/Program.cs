using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BlazorClient;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped(sp =>
{
    return new HttpClient(new BrowserHttpHandler
    {
        Credentials = FetchCredentialsOption.Include
    })
    {
        BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
    };
});

await builder.Build().RunAsync();
