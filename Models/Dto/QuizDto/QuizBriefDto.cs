using PubQuizAttendeeFrontend.Models.Dto.OrganizationDto;

namespace PubQuizAttendeeFrontend.Models.Dto.QuizDto
{
    public class QuizBriefDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public OrganizationMinimalDto Organization { get; set; } = null!;
        public int Rating { get; set; }
        public int EditionsHosted { get; set; }
        public string? ProfileImage { get; set; }
    }
}
