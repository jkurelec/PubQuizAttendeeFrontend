using Microsoft.AspNetCore.Components.Forms;
using PubQuizAttendeeFrontend.Models.Dto.QuizQuestionsDto.Specific;
using PubQuizAttendeeFrontend.Models.Dto.QuizQuestionsDto.Basic;

namespace PubQuizAttendeeFrontend.Services.Interfaces
{
    public interface IUpcomingQuizQuestionService
    {
        Task<QuizQuestionDto?> AddQuestion(QuizQuestionDto dto, IBrowserFile? file);
        Task<QuizSegmentDto?> AddSegment(QuizSegmentDto dto);
        Task<QuizRoundDto?> AddRound(QuizRoundDto dto);
        Task<bool> DeleteQuestion(int id);
        Task<bool> DeleteSegment(int id);
        Task<bool> DeleteRound(int id);
        Task<QuizQuestionDto?> EditQuestion(QuizQuestionDto dto, IBrowserFile? file);
        Task<QuizSegmentDto?> EditSegment(QuizSegmentDto dto);
        Task<QuizQuestionDto?> GetQuestion(int id);
        Task<QuizSegmentDto?> GetSegment(int id);
        Task<QuizRoundDto?> GetRound(int id);
        Task<IEnumerable<QuizRoundBriefDto>> GetRounds(int editionId);
        Task<QuizSegmentDto?> UpdateQuestionOrder(UpdateOrderDto dto);
        Task<QuizRoundDto?> UpdateSegmentOrder(UpdateOrderDto dto);
        Task<List<QuizRoundDto>> UpdateRoundOrder(UpdateOrderDto dto);
    }
}
