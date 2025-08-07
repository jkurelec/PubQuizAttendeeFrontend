using PubQuizAttendeeFrontend.Models.Dto.QuizAnswerDto;
using PubQuizAttendeeFrontend.Models.Dto.QuizDto;
using PubQuizAttendeeFrontend.Models.Dto.QuizEditionDto;
using PubQuizAttendeeFrontend.Models.Dto.TeamDto;

namespace PubQuizAttendeeFrontend.Models.Dto.UserDto
{
    public class UserDetailedDto
    {
        public int Id { get; set; }
        public string Username { get; set; } = null!;
        public int Rating { get; set; }
        public int Role { get; set; }
        public string ProfileImage { get; set; } = string.Empty;
        public IEnumerable<QuizMinimalDto> HostingQuizzes { get; set; } = new List<QuizMinimalDto>();
        public IEnumerable<QuizEditionMinimalDto> EditionsHosted { get; set; } = new List<QuizEditionMinimalDto>();
        public IEnumerable<TeamBreifDto> CurrentTeams { get; set; } = new List<TeamBreifDto>();
        public IEnumerable<QuizEditionResultForUserDto> AttendedEditions { get; set; } = new List<QuizEditionResultForUserDto>();
    }
}