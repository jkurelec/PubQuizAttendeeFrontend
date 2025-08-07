using PubQuizAttendeeFrontend.Models.Dto.ApplicationDto;

namespace PubQuizAttendeeFrontend.Services.Interfaces
{
    public interface IQuizEditionApplicationService
    {
        Task<IEnumerable<AcceptedQuizEditionApplicationDto>> GetAcceptedApplicationsByEdition(int id);
        Task<bool> CheckIfUserApplied(int editionId);
        Task ApplyForEdition(QuizEditionApplicationRequestDto applicationRequestDto);
        Task<bool> CanUserWithdraw(int teamId, int editionId);
        Task WithdrawFromEdition(int editionId);
    }
}
