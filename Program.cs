using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using PubQuizAttendeeFrontend;
using PubQuizAttendeeFrontend.Authentication.Implementations;
using PubQuizAttendeeFrontend.Authentication.Interfaces;
using PubQuizAttendeeFrontend.Authentication.Misc;
using PubQuizAttendeeFrontend.Services.Implementations;
using PubQuizAttendeeFrontend.Services.Interfaces;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddAuthorizationCore();
builder.Services.AddMudServices();

builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
builder.Services.AddScoped<ITokenStorageService, TokenStorageService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<UserInfoService>();

builder.Services.AddScoped<IQuizEditionService, QuizEditionService>();
builder.Services.AddScoped<IQuizEditionApplicationService, QuizEditionApplicationService>();
builder.Services.AddScoped<ITeamService, TeamService>();
builder.Services.AddScoped<IOrganizationService, OrganizationService>();
builder.Services.AddScoped<IQuizService, QuizService>();
builder.Services.AddScoped<IQuizCategoryService, QuizCategoryService>();
builder.Services.AddScoped<ILocationService, LocationService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ILocationService, LocationService>();
builder.Services.AddScoped<IQuizLeagueService, QuizLeagueService>();
builder.Services.AddScoped<IQuizEditionService, QuizEditionService>();
builder.Services.AddScoped<IQuizEditionApplicationService, QuizEditionApplicationService>();
builder.Services.AddScoped<IUpcomingQuizQuestionService, UpcomingQuizQuestionService>();
builder.Services.AddScoped<IPrivateMediaService, PrivateMediaService>();
builder.Services.AddScoped<IQuizAnswerService, QuizAnswerService>();
builder.Services.AddScoped<IEloCalculatorService, EloCalculatorService>();
builder.Services.AddScoped<IRecommendationService, RecommendationService>();


builder.Services.AddTransient<RetryingTokenHandler>();

builder.Services.AddHttpClient("ApiClient", client =>
{
    client.BaseAddress = new Uri("https://localhost:7062/");
    client.DefaultRequestHeaders.Add("AppName", "Attendee");
})
.AddHttpMessageHandler<RetryingTokenHandler>();

builder.Services.AddHttpClient("RefreshClient", client =>
{
    client.BaseAddress = new Uri("https://localhost:7062/");
})
.ConfigureHttpClient(c => c.DefaultRequestHeaders.Add("AppName", "Attendee"));

builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("ApiClient"));

builder.Services.AddMudServices(config =>
{
    config.SnackbarConfiguration.PositionClass = MudBlazor.Defaults.Classes.Position.TopRight;
    config.SnackbarConfiguration.PreventDuplicates = false;
    config.SnackbarConfiguration.NewestOnTop = true;
    config.SnackbarConfiguration.ShowCloseIcon = true;
    config.SnackbarConfiguration.VisibleStateDuration = 4000;
});

await builder.Build().RunAsync();
