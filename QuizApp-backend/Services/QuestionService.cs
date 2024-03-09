using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using QuizApp_backend.Exceptions;
using QuizApp_backend.Models;
using QuizApp_backend.Repository;
using QuizApp_backend.Util;

namespace QuizApp_backend.Services
{
    public class QuestionService
    {
        private readonly QuestionRepo _questionRepo;
        private readonly ParticipantRepo _participantRepo;
        private Server _server;
        public QuestionService(QuestionRepo questionRepo,
                            ParticipantRepo participantRepo,
                            Server server)
        {
            _server = server;
            _questionRepo = questionRepo;
            _participantRepo = participantRepo;
        }
        public List<Question> GetQuestions(string QuizId)
        {
            return _questionRepo.FindByQuizId(QuizId);
        }
        public List<Question> GetQuestionsForPlay(string QuizId)
        {
            var questions= _questionRepo.FindByQuizId(QuizId);
            foreach(var question in questions)
            {
                question.CorrectAnswer = null;
            }
            return questions;
        }
        public bool AnswerQuestion(string quizId, Result result)
        {
            var question= _questionRepo.FindById(result.QuestionId);
            if (question == null) 
                throw new RequestException("QuestionId "+result.QuestionId+" does not exist");
            if(!_server.quizSessions.ContainsKey(question.QuizId))
                throw new RequestException("Sorry, the quiz has been closed");
            result.IsCorrect=question.CorrectAnswer.Equals(result.ChoosedOption);
            int score = (result.IsCorrect) ? 10 : -10;
            int totalScore = _participantRepo.AddScore(result.ParticipantId, score);
            var host = _server.quizSessions[question.QuizId].Host;
            if (host.Connected)
            {
                JObject jobject = new JObject();
                jobject["ParticipantId"] = result.ParticipantId;
                jobject["TotalScore"] = totalScore;
                _server.SendData(host, JsonConvert.SerializeObject(jobject));
            }
            return result.IsCorrect;
        }
    }
}
