namespace QuizApp_backend.Models
{
    public class Result
    {
        public string Id { get; set; }
        public string ChoosedAnswer { get; set; }
        public bool IsCorrect { get; set; }
        public string ParticipantId { get; set; }
        public string QuestionId { get; set; }
    }
}
