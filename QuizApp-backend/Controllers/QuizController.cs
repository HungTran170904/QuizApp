using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using QuizApp_backend.Models;
using QuizApp_backend.Services;
using System.Buffers.Text;
using System.Net.Sockets;

namespace QuizApp_backend.Controllers
{
    public class QuizController
    {
        public string prefix = "/quiz";
        private readonly QuizService _quizService;
        private readonly FileService _fileService;
        public QuizController(QuizService quizService,
            FileService fileService)
        {
            _quizService = quizService;
            _fileService = fileService;
        }
        public string RouteRequests(string url,string accountId,string payload, TcpClient client)
        {
            url=url.Substring(prefix.Length);
            string result = "";
            if (url.Equals("/addQuiz"))
                result = AddQuiz(accountId,payload);
            else if (url.Equals("/getQuizzes"))
                result = GetQuizzes(accountId);
            else if(url.Equals("/startGame"))
                StartGame(accountId,payload);
            else if (url.Equals("/hostGame"))
                result=HostGame(accountId,payload, client);
            else if (url.Equals("/stopGame"))
                result=StopGame(accountId,payload);
            else if(url.Equals("/updateBlock"))
                UpdateBlock(accountId,payload);
            else if(url.Equals("/getQuizReport"))
                result= GetQuizReport(accountId,payload);
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
        public string HostGame(string accountId,string quizId, TcpClient client)
        {
            return _quizService.HostGame(accountId,quizId,client);
        }
        public void StartGame(string accountId, string quizId)
        {
            _quizService.StartGame(accountId,quizId);
        }
        public string StopGame(string accountId, string quizId)
        {
            List<Participant> partcipants=_quizService.StopGame(accountId,quizId);
            if (partcipants == null) return "";
            else return JsonConvert.SerializeObject(partcipants);
        }
        public void UpdateBlock(string accountId, string payload)
        {
            var jobject=JObject.Parse(payload);
            string quizId =(string) jobject["quizId"];
            bool isBlocked = (bool)jobject["isBlocked"];
            _quizService.UpdateBlock(accountId, quizId, isBlocked);
        }
        public string GetQuizReport(string accountId, string quizId)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                _fileService.CreateExcelFile(stream, accountId, quizId);
                return Convert.ToBase64String(stream.ToArray());
            }
        }
    }
}
