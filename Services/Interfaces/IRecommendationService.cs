using PubQuizAttendeeFrontend.Models.Dto.RecommendationDto;

namespace PubQuizAttendeeFrontend.Services.Interfaces
{
    public interface IRecommendationService
    {
        Task<EditionFeedbackRequestDto?> GetEditionInfoForFeedback();
        Task SendFeedback(UserFeedbackDto feedback);
    }
}
