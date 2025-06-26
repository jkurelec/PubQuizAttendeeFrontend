using PubQuizAttendeeFrontend.Models.Dto.QuizAnswerDto;

namespace PubQuizAttendeeFrontend.Models.Dto.QuizEditionDto
{
    public class PastQuizEditionDetailedDto : QuizEditionDetailedDto
    {
        public QuizEditionRoundsDto Rounds { get; set; } = new();
        public IEnumerable<QuizEditionResultDetailedDto> Results { get; set; } = new List<QuizEditionResultDetailedDto>();
    }
}
