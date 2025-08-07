using Microsoft.AspNetCore.Components.Forms;
using PubQuizAttendeeFrontend.Models.Dto.QuizDto;

namespace PubQuizAttendeeFrontend.Services.Interfaces
{
    public interface IQuizService
    {
        Task<IEnumerable<QuizBriefDto>> GetAllBrief();
        Task<IEnumerable<QuizDetailedDto>> GetAllDetailed();
        Task<QuizBriefDto?> GetBriefById(int id);
        Task<QuizDetailedDto?> GetDetailedById(int id);
        Task<QuizDetailedDto?> Add(NewQuizDto quiz);
        Task<QuizDetailedDto?> Update(NewQuizDto quiz);
        Task Delete(int id);
        Task<IEnumerable<QuizMinimalDto>> GetByHostAndOrganization(int organizationId);
        Task<string?> UpdateProfileImage(IBrowserFile image, int quizId);
    }
}
