using PubQuizAttendeeFrontend.Models.Dto.QuizQuestionsDto.Basic;

namespace PubQuizAttendeeFrontend.Models.Dto.QuizEditionDto
{
    public class QuizEditionRoundsDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public IEnumerable<QuizRoundDto> Rounds { get; set; } = null!;
    }
}
