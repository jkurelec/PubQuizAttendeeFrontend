using PubQuizAttendeeFrontend.Models.Dto.QuizCategoryDto;
using PubQuizAttendeeFrontend.Models.Dto.QuizDto;
using PubQuizAttendeeFrontend.Models.Dto.UserDto;

namespace PubQuizAttendeeFrontend.Models.Dto.TeamDto
{
    public class TeamDetailedDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int OwnerId;
        public QCategoryDto Category { get; set; } = null!;
        public QuizMinimalDto Quiz { get; set; } = null!;
        public IEnumerable<UserBriefDto> TeamMembers { get; set; } = new List<UserBriefDto>();
    }
}
