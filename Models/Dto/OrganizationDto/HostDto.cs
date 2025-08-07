using PubQuizAttendeeFrontend.Models.Dto.UserDto;

namespace PubQuizAttendeeFrontend.Models.Dto.OrganizationDto
{
    public class HostDto
    {
        public bool IsOwner { get; set; } = false;
        public required UserBriefDto UserBrief { get; set; }
        public required HostPermissionsDto HostPermissions { get; set; }
    }
}
