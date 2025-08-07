using PubQuizAttendeeFrontend.Models.Dto.QuizCategoryDto;
using PubQuizAttendeeFrontend.Models.Dto.QuizDto;
using PubQuizAttendeeFrontend.Models.Dto.UserDto;

namespace PubQuizAttendeeFrontend.Models.Dto.ApplicationDto
{
    public class QuizEditionApplicationDto
    {
        public int Id { get; set; }
        public int TeamId { get; set; }
        public string TeamName { get; set; } = null!;
        public bool? Response { get; set; }
        public QCategoryDto TeamCategory { get; set; } = null!;
        public QuizMinimalDto TeamQuiz { get; set; } = null!;
        public IEnumerable<UserBriefDto> TeamMembers { get; set; } = new List<UserBriefDto>();
    }
}
