using PubQuizAttendeeFrontend.Models.Dto.QuizCategoryDto;
using PubQuizAttendeeFrontend.Models.Dto.QuizDto;
using PubQuizAttendeeFrontend.Models.Dto.UserDto;

namespace PubQuizAttendeeFrontend.Models.Dto.TeamDto
{
    public partial class TeamDetailedDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int OwnerId { get; set; }
        public QCategoryDto Category { get; set; } = null!;
        public QuizMinimalDto Quiz { get; set; } = null!;
        public IEnumerable<UserTeamDto> TeamMembers { get; set; } = new List<UserTeamDto>();
    }

    public partial class TeamDetailedDto
    {
        public string? NewName { get; set; }
    }
}
