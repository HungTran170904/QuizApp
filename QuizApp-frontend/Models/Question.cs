using System.Collections.ObjectModel;

namespace QuizApp_frontend.Models
{
    public class Question
    {
        public string Id { get; set; }
        public string QuizId { get; set; }
        public string QuestionText { get; set; }
        public string CorrectAnswer { get; set; }
        public int TimeOut { get; set; }
        public List<string> Options { get; set; }=new List<string>();
    }
}
