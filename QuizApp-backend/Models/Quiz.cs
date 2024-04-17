namespace QuizApp_backend.Models
{
    public class Quiz
    {
        public string Id { get; set; }
        public string CreatorId { get; set; }
        public string Title { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string Status { get; set; } // stop, play, host
        public bool IsBlocked { get; set; } = false;
        public List<Question> Questions { get; set; }
    }
}
