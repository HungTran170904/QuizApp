using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using QuizApp_backend.Models;
using QuizApp_backend.Services;
using System.Net.Sockets;

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
        public string RouteRequests(string url,string accountId,string payload, TcpClient client)
        {
            url=url.Substring(prefix.Length);
            string result = "";
            if (url.Equals("/addQuiz"))
                result = AddQuiz(payload);
            else if (url.Equals("/getQuizzes"))
                result = GetQuizzes(payload);
            else if (url.Equals("/startGame"))
                HostGame(accountId,payload, client);
            else if (url.Equals("/stopGame"))
                StopGame(accountId,payload);
            else if(url.Equals("/updateBlock"))
                UpdateBlock(accountId,payload);
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
        public void HostGame(string accountId,string quizId, TcpClient client)
        {
            _quizService.HostGame(accountId,quizId,client);
        }
        public void StopGame(string accountId, string quizId)
        {
            _quizService.StopGame(accountId,quizId);
        }
        public void UpdateBlock(string accountId, string payload)
        {
            var jobject=JObject.Parse(payload);
            string quizId =(string) jobject["quizId"];
            bool isBlocked = (bool)jobject["isBlocked"];
            _quizService.UpdateBlock(accountId, quizId, isBlocked);
        }
    }
}
