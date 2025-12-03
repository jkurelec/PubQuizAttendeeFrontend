namespace PubQuizAttendeeFrontend.Models.Dto.RecommendationDto
{
    public class UserFeedbackDto
    {
        public int UserId { get; set; }
        public int EditionId { get; set; }
        public float GeneralRating { get; set; }
        public float HostRating { get; set; }
        public float DifficultyRating { get; set; }
        public float DurationRating { get; set; }
        public float NumberOfPeopleRating { get; set; }
    }
}
