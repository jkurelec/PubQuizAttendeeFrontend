using PubQuizAttendeeFrontend.Models.Dto.QuizCategoryDto;

namespace PubQuizAttendeeFrontend.Models.Dto.QuizEditionDto
{
    public partial class QuizEditionMinimalDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public QCategoryDto Category { get; set; } = null!;
        public DateTime Time { get; set; }
        public int Rating { get; set; }
        public int MaxTeams { get; set; }
        public int AcceptedTeams { get; set; }
        public int PendingTeams { get; set; }
        public string? ProfileImage { get; set; }
    }

    public partial class QuizEditionMinimalDto
    {
        public float? Match { get; set; }
    }
}
