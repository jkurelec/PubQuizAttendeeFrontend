using PubQuizAttendeeFrontend.Models.Dto.QuizAnswerDto;

namespace PubQuizAttendeeFrontend.Services.Interfaces
{
    public interface IQuizAnswerService
    {
        Task<IEnumerable<QuizRoundResultDetailedDto>> GetTeamAnswers(int editionResultId);
        Task<IEnumerable<QuizEditionResultBriefDto>> GetEditionResults(int editionId);
        Task<IEnumerable<QuizEditionResultBriefDto>> RankTeamsOnEdition(int editionId);
        Task<IEnumerable<QuizEditionResultBriefDto>> BreakTie(int promotedId, int editionId);
        Task<QuizRoundResultDetailedDto?> GradeTeamAnswers(NewQuizRoundResultDto roundDto);
        Task<QuizRoundResultMinimalDto?> AddTeamRoundPoints(NewQuizRoundResultDto roundDto);
        Task<QuizRoundResultMinimalDto?> UpdateTeamRoundPoints(NewQuizRoundResultDto roundDto);
        Task<QuizAnswerDetailedDto?> UpdateAnswerPoints(QuizAnswerDetailedDto answerDto);
        Task<QuizAnswerDetailedDto?> UpdateTeamRoundPoints(QuizAnswerDetailedDto answerDto);
    }
}
