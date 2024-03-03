namespace QuizApp_backend.Models
{
    public class Quiz
    {
        public string Id { get; set; }
        public string CreatorId { get; set; }
        public string Title { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Code { get; set; }
        public string Status { get; set; }
    }
}
