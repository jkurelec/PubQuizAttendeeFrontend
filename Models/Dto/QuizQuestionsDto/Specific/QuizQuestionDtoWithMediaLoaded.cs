using PubQuizAttendeeFrontend.Models.Dto.QuizQuestionsDto.Basic;

namespace PubQuizAttendeeFrontend.Models.Dto.QuizQuestionsDto.Specific
{
    public class QuizQuestionDtoWithMediaLoaded : QuizQuestionDto
    {
        public byte[]? Media { get; set; }
    }
}
