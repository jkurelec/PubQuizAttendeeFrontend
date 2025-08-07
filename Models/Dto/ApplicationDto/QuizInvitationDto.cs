using PubQuizAttendeeFrontend.Models.Dto.QuizDto;
using PubQuizAttendeeFrontend.Models.Dto.UserDto;

namespace PubQuizAttendeeFrontend.Models.Dto.ApplicationDto
{
    public class QuizInvitationDto
    {
        public int InvitationId { get; set; }
        public UserBriefDto User { get; set; } = null!;
        public QuizMinimalDto Quiz { get; set; } = null!;
    }
}
