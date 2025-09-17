namespace PubQuizAttendeeFrontend.Models.Dto.RecommendationDto
{
    public class UserFeedbackDto
    {
        public int UserId { get; set; }
        public int EditionId { get; set; }
        public float GeneralRating { get; set; }
        public float HostRating { get; set; }
        public int DifficultyRating { get; set; }
        public int DurationRating { get; set; }
        public int NumberOfPeopleRating { get; set; }
    }
}
