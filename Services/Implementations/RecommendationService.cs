using PubQuizAttendeeFrontend.Models.Dto.RecommendationDto;
using PubQuizAttendeeFrontend.Services.Interfaces;
using System.Net.Http.Json;

namespace PubQuizAttendeeFrontend.Services.Implementations
{
    public class RecommendationService : IRecommendationService
    {
        private readonly HttpClient _http;
        private const string BasePath = "recommendation";

        public RecommendationService(HttpClient http)
        {
            _http = http;
        }

        public async Task<EditionFeedbackRequestDto?> GetEditionInfoForFeedback()
        {
            var response = await _http.GetFromJsonAsync<EditionFeedbackRequestDto?>($"{BasePath}/feedback-request");
            return response ;
        }

        public async Task SendFeedback(UserFeedbackDto feedback)
        {
            _ = await _http.PostAsJsonAsync($"{BasePath}/feedback", feedback);
        }
    }
}
