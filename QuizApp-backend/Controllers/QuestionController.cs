using Newtonsoft.Json;
using QuizApp_backend.Services;

namespace QuizApp_backend.Controllers
{
    public class QuestionController
    {
        public string prefix = "/question";
        private readonly QuestionService _questionService;
        public QuestionController(QuestionService questionService) 
        {
            _questionService = questionService;
        }
        public string RouteRequests(string url, string payload)
        {
            url=url.Substring(prefix.Length);
            string result = "";
            if(url.Equals("/getQuestions"))
                result=GetQuestions(payload);
            else if(url.Equals("/getQuestionsForPlay"))
                result=GetQuestionsForPlay(payload);
            return result;
        }
        public string GetQuestions(string quizId)
        {
            var questions=_questionService.GetQuestions(quizId);
            return JsonConvert.SerializeObject(questions);
        }
        public string GetQuestionsForPlay(string quizId)
        {
            var questions = _questionService.GetQuestionsForPlay(quizId);
            return JsonConvert.SerializeObject(questions);
        }
    }
}
