using PubQuizAttendeeFrontend.Models.Dto.UserDto;

namespace PubQuizAttendeeFrontend.Models.Dto.TeamDto
{
    public class TeamRegisterDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public IEnumerable<UserBriefDto> Memebers { get; set; } = new List<UserBriefDto>();
    }
}
