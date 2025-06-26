using PubQuizAttendeeFrontend.Models.Dto.QuizDto;
using PubQuizAttendeeFrontend.Models.Dto.UserDto;

namespace PubQuizAttendeeFrontend.Models.Dto.OrganizationDto
{
    public class OrganizationDetailedDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int EditionsHosted { get; set; }
        public UserBriefDto Owner { get; set; } = null!;
        public List<UserBriefDto> Hosts { get; set; } = null!;
        public List<QuizMinimalDto> Quizzes { get; set; } = null!;
    }
}
