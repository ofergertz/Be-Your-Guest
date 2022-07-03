using BeMyGuest.Client;
using Client.BusinessComponents.Requests;
using Client.BusinessComponents.Validators.Requests.Identity;
using Client.Model.Requests;
using Client.Model.Validators.Requests.Identity;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddTransient<IRegisterRequestValidator, RegisterRequestValidator>();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddMudServices();
builder.Services.AddLocalization(options =>
{
    options.ResourcesPath = "Resources";
});
await builder.Build().RunAsync();
