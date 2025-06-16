using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Http;
using PubQuizAttendeeFrontend.Authentication.Interfaces;
using PubQuizAttendeeFrontend.Authentication.Misc;
using PubQuizAttendeeFrontend.Models.Auth;
using System.Net.Http.Json;

namespace PubQuizAttendeeFrontend.Authentication.Implementations
{
    namespace PubQuizAttendeeFrontend.Authentication.Implementations
    {
        public class AuthService : IAuthService
        {
            private readonly HttpClient _httpClient;
            private readonly ITokenStorageService _tokenStorage;
            private readonly AuthenticationStateProvider _authenticationStateProvider;

            public AuthService(HttpClient httpClient, ITokenStorageService tokenStorage, AuthenticationStateProvider authenticationStateProvider)
            {
                _httpClient = httpClient;
                _tokenStorage = tokenStorage;
                _authenticationStateProvider = authenticationStateProvider;
            }

            public async Task<bool> LoginAsync(LoginUserDto loginDto)
            {
                var request = new HttpRequestMessage(HttpMethod.Post, "auth/login");
                request.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);
                request.Headers.Add("AppName", "Attendee");
                request.Content = JsonContent.Create(loginDto);

                var response = await _httpClient.SendAsync(request);

                if (!response.IsSuccessStatusCode)
                    return false;

                var result = await response.Content.ReadFromJsonAsync<AccessTokenResponse>();

                if (result == null || string.IsNullOrWhiteSpace(result.AccessToken))
                    return false;

                _tokenStorage.SetAccessToken(result.AccessToken);

                if (_authenticationStateProvider is CustomAuthenticationStateProvider customAuthProvider)
                {
                    customAuthProvider.NotifyUserAuthentication(result.AccessToken);
                }

                return true;
            }


            public Task LogoutAsync()
            {
                _tokenStorage.SetAccessToken(null);

                if (_authenticationStateProvider is CustomAuthenticationStateProvider customAuthProvider)
                {
                    customAuthProvider.NotifyUserLogout();
                }

                return Task.CompletedTask;
            }

            public async Task<bool> TryRefreshTokenAsync()
            {
                try
                {
                    var request = new HttpRequestMessage(HttpMethod.Post, "auth/refresh");
                    request.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);
                    request.Headers.Add("AppName", "Attendee");

                    var response = await _httpClient.SendAsync(request);

                    if (!response.IsSuccessStatusCode)
                        return false;

                    var result = await response.Content.ReadFromJsonAsync<AccessTokenResponse>();

                    if (result == null || string.IsNullOrWhiteSpace(result.AccessToken))
                        return false;

                    _tokenStorage.SetAccessToken(result.AccessToken);
                    return true;
                }
                catch
                {
                    return false;
                }
            }

            public async Task<bool> RegisterAsync(RegisterUserDto registerDto)
            {
                try
                {
                    var request = new HttpRequestMessage(HttpMethod.Post, "api/auth/register");
                    request.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);
                    request.Headers.Add("AppName", "Attendee");
                    request.Content = JsonContent.Create(registerDto);

                    var response = await _httpClient.SendAsync(request);

                    if (response.IsSuccessStatusCode)
                    {
                        return true;
                    }
                    else
                    {
                        var errorContent = await response.Content.ReadAsStringAsync();
                        return false;
                    }
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
    }
}
