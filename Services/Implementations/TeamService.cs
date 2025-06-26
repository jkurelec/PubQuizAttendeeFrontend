using Newtonsoft.Json;
using PubQuizAttendeeFrontend.Authentication.Misc;
using PubQuizAttendeeFrontend.Models.Dto.TeamDto;
using PubQuizAttendeeFrontend.Services.Interfaces;

namespace PubQuizAttendeeFrontend.Services.Implementations
{
    public class TeamService : ITeamService
    {
        private readonly HttpClient _httpClient;
        private readonly UserInfoService _userInfoService;
        private const string BasePath = "team/";

        public TeamService(HttpClient httpClient, UserInfoService userInfoService)
        {
            _httpClient = httpClient;
            _userInfoService = userInfoService;
        }

        public async Task<IEnumerable<TeamDetailedDto>> GetUserTeams()
        {
            var userInfo = await _userInfoService.GetUserInfoAsync();

            if (userInfo == null)
                return new List<TeamDetailedDto>();

            var response = await _httpClient.GetAsync($"{BasePath}/user/{userInfo.Id}");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var teams = JsonConvert.DeserializeObject<List<TeamDetailedDto>>(json);

                return teams ?? new List<TeamDetailedDto>();
            }

            return new List<TeamDetailedDto>();
        }
    }
}
