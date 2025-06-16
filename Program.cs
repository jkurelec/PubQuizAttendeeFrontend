using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using PubQuizAttendeeFrontend;
using PubQuizAttendeeFrontend.Authentication.Implementations;
using PubQuizAttendeeFrontend.Authentication.Implementations.PubQuizAttendeeFrontend.Authentication.Implementations;
using PubQuizAttendeeFrontend.Authentication.Interfaces;
using PubQuizAttendeeFrontend.Authentication.Misc;
using Microsoft.AspNetCore.Components.WebAssembly.Http;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddAuthorizationCore();
builder.Services.AddMudServices();

builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
builder.Services.AddScoped<ITokenStorageService, TokenStorageService>();
builder.Services.AddScoped<IAuthService, AuthService>();


builder.Services.AddTransient<RetryingTokenHandler>();

builder.Services.AddHttpClient("ApiClient", client =>
{
    client.BaseAddress = new Uri("https://localhost:44353/");
})
.AddHttpMessageHandler<RetryingTokenHandler>();

builder.Services.AddHttpClient("RefreshClient", client =>
{
    client.BaseAddress = new Uri("https://localhost:44353/");
});

builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("ApiClient"));

await builder.Build().RunAsync();
