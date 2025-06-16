using Microsoft.AspNetCore.Components.Authorization;
using PubQuizAttendeeFrontend.Authentication.Interfaces;
using PubQuizAttendeeFrontend.Models.Auth;
using System.Net.Http;
using System.Net.Http.Json;
using System.Security.Claims;

namespace PubQuizAttendeeFrontend.Authentication.Misc
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly ITokenStorageService _tokenStorage;
        private readonly HttpClient _httpClient;

        public CustomAuthenticationStateProvider(ITokenStorageService tokenStorage, HttpClient httpClient)
        {
            _tokenStorage = tokenStorage;
            _httpClient = httpClient;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var token = _tokenStorage.GetAccessToken();

            if (string.IsNullOrWhiteSpace(token))
            {
                var tokenSet = await TryRefreshTokenAsync();
                if (tokenSet)
                    token = _tokenStorage.GetAccessToken();
            }

            var identity = !string.IsNullOrWhiteSpace(token)
                ? new ClaimsIdentity(JwtParser.ParseClaimsFromJwt(token), "jwt")
                : new ClaimsIdentity();

            return new AuthenticationState(new ClaimsPrincipal(identity));
        }

        public void NotifyUserAuthentication(string token)
        {
            var claims = JwtParser.ParseClaimsFromJwt(token);
            var identity = new ClaimsIdentity(claims, "jwt");
            var user = new ClaimsPrincipal(identity);

            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
        }

        public void NotifyUserLogout()
        {
            var anonymous = new ClaimsPrincipal(new ClaimsIdentity());
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(anonymous)));
        }

        public async Task<bool> TryRefreshTokenAsync()
        {
            try
            {
                var response = await _httpClient.PostAsync("auth/refresh", null);

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
    }
}
