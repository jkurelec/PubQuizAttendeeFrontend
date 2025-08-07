using PubQuizAttendeeFrontend.Models.Dto.QuizAnswerDto;

namespace PubQuizAttendeeFrontend.Models.Dto.QuizAnswerDto
{
    public class QuizSegmentResultDetailedDto : NewQuizSegmentResultDto
    {
        public int Id { get; set; }
        public int RoundResultId { get; set; }
        public new IEnumerable<QuizAnswerDetailedDto> QuizAnswers { get; set; } = new List<QuizAnswerDetailedDto>();
    }
}
