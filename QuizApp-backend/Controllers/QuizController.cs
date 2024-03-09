using Newtonsoft.Json;
using QuizApp_backend.Models;
using QuizApp_backend.Services;

namespace QuizApp_backend.Controllers
{
    public class QuizController
    {
        public string prefix = "/quiz";
        private readonly QuizService _quizService;
        public QuizController(QuizService quizService)
        {
            _quizService = quizService;
        }
        public string RouteRequests(string url, string payload)
        {
            url=url.Substring(prefix.Length);
            string result = "";
            if (url.Equals("/addQuiz"))
                result = AddQuiz(payload);
            return result;
        }
        public string AddQuiz(string payload) 
        {
            Quiz quiz=JsonConvert.DeserializeObject<Quiz>(payload);
            var savedQuiz=_quizService.AddQuiz(quiz);
            return JsonConvert.SerializeObject(savedQuiz);
        }
        public string GetQuizzes(string quizId)
        {
            var quizzes=_quizService.GetQuizzes(quizId);
            return JsonConvert.SerializeObject(quizzes);
        }
    }
}
