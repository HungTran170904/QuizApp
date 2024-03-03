using System.Collections.ObjectModel;

namespace QuizApp_backend.Models
{
    public class Question
    {
        public string Id { get; set; }
        public string QuestionText { get; set; }
        public string QuestionType { get; set; }
        public string CorrectAnswer { get; set; }
        public int TimeOut { get; set; }
        public string ImageLink { get; set; }
        public List<Option> Options { get; set; }=new List<Option>();
    }
}
