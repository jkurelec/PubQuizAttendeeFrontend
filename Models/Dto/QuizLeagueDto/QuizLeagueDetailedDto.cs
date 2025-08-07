using PubQuizAttendeeFrontend.Models.Dto.PrizesDto;
using PubQuizAttendeeFrontend.Models.Dto.QuizDto;
using PubQuizAttendeeFrontend.Models.Dto.QuizEditionDto;

namespace PubQuizAttendeeFrontend.Models.Dto.QuizLeagueDto
{
    public class QuizLeagueDetailedDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public IEnumerable<LeaguePoints> Points { get; set; } = new List<LeaguePoints>();
        public IEnumerable<PrizeDto> Prizes { get; set; } = new List<PrizeDto>();
        public QuizMinimalDto Quiz { get; set; } = null!;
        public bool Finished { get; set; }
        public IEnumerable<QuizEditionMinimalDto> Editions { get; set; } = new List<QuizEditionMinimalDto>();
        public IEnumerable<QuizLeagueRoundDto> Rounds { get; set; } = new List<QuizLeagueRoundDto>();
    }
}
