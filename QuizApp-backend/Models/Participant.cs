namespace QuizApp_backend.Models
{
    public class Participant
    {
        public string Id { get; set; }
        public string QuizId { get; set; }
        public string Name { get; set; }
        public int TotalScore { get; set; } = 0;
        public DateTime? AttendedAt { get; set; }
        public DateTime? FinishedAt { get; set; }
        public List<Result> Results { get; set; } = new List<Result>();
    }
}
