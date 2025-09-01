namespace PubQuizAttendeeFrontend.Models.Dto.QuizAnswerDto
{
    public partial class QuizAnswerDetailedDto : NewQuizAnswerDto
    {
        public int Id { get; set; }
        public int SegmentResultId { get; set; }
    }

    public partial class QuizAnswerDetailedDto
    {
        public int Number { get; set; }
    }
}
