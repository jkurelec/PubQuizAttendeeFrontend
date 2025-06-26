using PubQuizAttendeeFrontend.Models.Dto.QuizDto;

namespace PubQuizAttendeeFrontend.Models.Dto.QuizLeagueDto
{
    public class QuizLeagueBriefDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public QuizMinimalDto Quiz { get; set; } = null!;
    }
}
