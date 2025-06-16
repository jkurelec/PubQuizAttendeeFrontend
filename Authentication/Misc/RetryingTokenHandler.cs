using PubQuizAttendeeFrontend.Authentication.Interfaces;
using PubQuizAttendeeFrontend.Models.Auth;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Components.WebAssembly.Http;

namespace PubQuizAttendeeFrontend.Authentication.Misc
{
    public class RetryingTokenHandler : DelegatingHandler
    {
        private readonly ITokenStorageService _tokenStorage;
        private readonly IHttpClientFactory _httpClientFactory;

        public RetryingTokenHandler(ITokenStorageService tokenStorage, IHttpClientFactory httpClientFactory)
        {
            _tokenStorage = tokenStorage;
            _httpClientFactory = httpClientFactory;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            // Skip retry logic if this is the refresh endpoint itself
            if (request.RequestUri?.AbsolutePath == "/auth/refresh")
            {
                return await base.SendAsync(request, cancellationToken);
            }

            var token = _tokenStorage.GetAccessToken();

            if (!string.IsNullOrWhiteSpace(token))
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }

            if (!request.Headers.Contains("AppName"))
            {
                request.Headers.Add("AppName", "Attendee");
            }

            var response = await base.SendAsync(request, cancellationToken);

            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                // Build refresh request
                var refreshRequest = new HttpRequestMessage(HttpMethod.Post, "auth/refresh");
                refreshRequest.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);
                refreshRequest.Headers.Add("AppName", "Attendee");

                var refreshClient = _httpClientFactory.CreateClient("RefreshClient");
                var refreshResponse = await refreshClient.SendAsync(refreshRequest, cancellationToken);

                if (refreshResponse.IsSuccessStatusCode)
                {
                    var result = await refreshResponse.Content.ReadFromJsonAsync<AccessTokenResponse>(cancellationToken: cancellationToken);

                    if (!string.IsNullOrWhiteSpace(result?.AccessToken))
                    {
                        _tokenStorage.SetAccessToken(result.AccessToken);

                        // Clone original request
                        var cloned = await CloneHttpRequestMessageAsync(request);
                        cloned.Headers.Authorization = new AuthenticationHeaderValue("Bearer", result.AccessToken);

                        // Use a top-level client to retry, NOT base.SendAsync to avoid infinite handler recursion
                        var retryClient = _httpClientFactory.CreateClient("ApiClient");
                        return await retryClient.SendAsync(cloned, cancellationToken);
                    }
                }
            }

            return response;
        }

        private static async Task<HttpRequestMessage> CloneHttpRequestMessageAsync(HttpRequestMessage request)
        {
            var clone = new HttpRequestMessage(request.Method, request.RequestUri);

            if (request.Content != null)
            {
                var ms = new MemoryStream();
                await request.Content.CopyToAsync(ms);
                ms.Position = 0;
                clone.Content = new StreamContent(ms);

                foreach (var header in request.Content.Headers)
                {
                    clone.Content.Headers.TryAddWithoutValidation(header.Key, header.Value);
                }
            }

            foreach (var header in request.Headers)
            {
                clone.Headers.TryAddWithoutValidation(header.Key, header.Value);
            }

            clone.Version = request.Version;
            return clone;
        }
    }
}
