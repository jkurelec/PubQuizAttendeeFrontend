using PubQuizAttendeeFrontend.Models.Dto.QuizEditionDto;
using PubQuizAttendeeFrontend.Models.Dto.TeamDto;

namespace PubQuizAttendeeFrontend.Models.Dto.QuizAnswerDto
{
    public class QuizEditionResultForUserDto
    {
        public int Id { get; set; }
        public int? Rank { get; set; }
        public decimal TeamPoints { get; set; }
        public decimal TotalPoints { get; set; }
        public int Rating { get; set; }
        public virtual QuizEditionMinimalDto Edition { get; set; } = null!;
        public virtual TeamBreifDto Team { get; set; } = null!;
    }
}
