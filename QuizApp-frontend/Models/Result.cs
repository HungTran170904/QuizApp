namespace QuizApp_frontend.Models
{
    public class Result
    {
        public string ParticipantId { get; set; }
        public string QuestionId { get; set; }
        public string ChoosedOption { get; set; }
        public bool IsCorrect { get; set; }
    }
}
