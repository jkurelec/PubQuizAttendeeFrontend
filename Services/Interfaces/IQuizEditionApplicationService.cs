using PubQuizAttendeeFrontend.Models.Dto.ApplicationDto;

namespace PubQuizAttendeeFrontend.Services.Interfaces
{
    public interface IQuizEditionApplicationService
    {
        Task<IEnumerable<AcceptedQuizEditionApplicationDto>> GetAcceptedApplicationsByEdition(int id);
        Task<bool> CheckIfUserApplied(int editionId);
    }
}
