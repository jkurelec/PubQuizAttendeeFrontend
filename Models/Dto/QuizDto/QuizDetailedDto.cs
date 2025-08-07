using PubQuizAttendeeFrontend.Models.Dto.LocationDto;
using PubQuizAttendeeFrontend.Models.Dto.OrganizationDto;
using PubQuizAttendeeFrontend.Models.Dto.QuizCategoryDto;
using PubQuizAttendeeFrontend.Models.Dto.QuizEditionDto;
using PubQuizAttendeeFrontend.Models.Dto.QuizLeagueDto;
using PubQuizAttendeeFrontend.Models.Dto.TeamDto;

namespace PubQuizAttendeeFrontend.Models.Dto.QuizDto
{
    public class QuizDetailedDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public OrganizationMinimalDto Organization { get; set; } = new();
        public int Rating { get; set; }
        public int EditionsHosted { get; set; }
        public IEnumerable<LocationBriefDto> Locations { get; set; } = new List<LocationBriefDto>();
        public IEnumerable<QCategoryDto> Categories { get; set; } = new List<QCategoryDto>();
        public IEnumerable<QuizLeagueMinimalDto> QuizLeagues { get; set; } = null!;
        public IEnumerable<QuizEditionMinimalDto> QuizEditions { get; set; } = null!;
        public IEnumerable<TeamBreifDto> Teams { get; set; } = null!;
        public string? ProfileImage { get; set; }
    }
}
