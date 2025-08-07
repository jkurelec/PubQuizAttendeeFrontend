using Microsoft.AspNetCore.Components.Forms;
using PubQuizAttendeeFrontend.Models.Dto.ApplicationDto;
using PubQuizAttendeeFrontend.Models.Dto.OrganizationDto;
using PubQuizAttendeeFrontend.Models.Dto.QuizDto;

namespace PubQuizAttendeeFrontend.Services.Interfaces
{
    public interface IOrganizationService
    {
        Task<IEnumerable<OrganizationBriefDto>> GetAll();
        Task<OrganizationBriefDto?> GetById(int id);
        Task<IEnumerable<HostQuizzesDto>> GetHostsFromOrganization(int organizerId);
        Task<HostDto?> GetHost(int hostId, int quizId);
        Task<OrganizationBriefDto?> Add(NewOrganizationDto newOrganizer);
        Task<HostDto?> AddHost(NewHostDto newHost);
        Task<OrganizationBriefDto?> Update(OrganizationUpdateDto updatedOrganizer);
        Task<HostDto?> UpdateHost(NewHostDto updatedHost);
        Task Delete(int id);
        Task DeleteHost(int organizerId, int hostId);
        Task RemoveHostFromQuiz(int organizerId, int hostId, int quizId);
        Task InviteHostToOrganization(QuizInvitationRequestDto request);
        Task RespondToInvitation(ApplicationResponseDto response);
        Task<IEnumerable<QuizInvitationDto>> GetInvitations();
        Task<IEnumerable<OrganizationMinimalDto>> GetByHost();
        Task<OrganizationMinimalDto?> GetOwnerOrganization();
        Task<IEnumerable<QuizMinimalDto>> GetAvaliableQuizzesForNewHost(int hostId);
        Task<IEnumerable<QuizInvitationDto>> GetOrganizationPendingQuizInvitations();
        Task<IEnumerable<HostDto>> GetHostsByQuiz(int quizId);
        Task<string?> UpdateProfileImage(IBrowserFile image);
    }
}
