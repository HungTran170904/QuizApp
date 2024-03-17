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
                result = AddQuiz(accountId,payload);
            else if (url.Equals("/getQuizzes"))
                result = GetQuizzes(payload);
            else if(url.Equals("/startGame"))
                StartGame(accountId,payload);
            else if (url.Equals("/startGame"))
                HostGame(accountId,payload, client);
            else if (url.Equals("/stopGame"))
                StopGame(accountId,payload);
            else if(url.Equals("/updateBlock"))
                UpdateBlock(accountId,payload);
            return result;
        }
        public string AddQuiz(string accountId,string payload) 
        {
            Quiz quiz=JsonConvert.DeserializeObject<Quiz>(payload);
            quiz.CreatorId=accountId;
            var savedQuiz=_quizService.AddQuiz(quiz);
            return JsonConvert.SerializeObject(savedQuiz);
        }
        public string GetQuizzes(string accountId)
        {
            var quizzes=_quizService.GetQuizzes(accountId);
            return JsonConvert.SerializeObject(quizzes);
        }
        public void HostGame(string accountId,string quizId, TcpClient client)
        {
            _quizService.HostGame(accountId,quizId,client);
        }
        public void StartGame(string accountId, string quizId)
        {
            _quizService.StartGame(accountId,quizId);
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
