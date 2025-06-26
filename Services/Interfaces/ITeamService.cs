using PubQuizAttendeeFrontend.Models.Dto.TeamDto;

namespace PubQuizAttendeeFrontend.Services.Interfaces
{
    public interface ITeamService
    {
        Task<IEnumerable<TeamDetailedDto>> GetUserTeams();
    }
}
