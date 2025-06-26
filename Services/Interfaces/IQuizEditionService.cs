using PubQuizAttendeeFrontend.Enums;
using PubQuizAttendeeFrontend.Models.Dto.ApplicationDto;
using PubQuizAttendeeFrontend.Models.Dto.QuizEditionDto;

namespace PubQuizAttendeeFrontend.Services.Interfaces
{
    public interface IQuizEditionService
    {
        Task<(IEnumerable<QuizEditionMinimalDto> Items, int TotalCount)> GetAllPage(int page, int pageSize, EditionFilter filter);

        Task<(IEnumerable<QuizEditionMinimalDto> Items, int TotalCount)> GetUpcomingPage(int page, int pageSize, EditionFilter filter);

        Task<(IEnumerable<QuizEditionMinimalDto> Items, int TotalCount)> GetCompletedPage(int page, int pageSize, EditionFilter filter);
        Task<QuizEditionDetailedDto> GetById(int id);
        Task<IEnumerable<AcceptedQuizEditionApplicationDto>> GetAcceptedApplications(int editionId);
    }
}
