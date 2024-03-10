using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.Extensions.Hosting;
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
        private readonly SocketService _socketService;
        public QuestionService(QuestionRepo questionRepo,
                            ParticipantRepo participantRepo,
                            SocketService socketService)
        {
            _socketService= socketService;
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
        private async Task SendScoreToHost(Question question, Result result)
        {
            int score = (result.IsCorrect) ? 10 : -10;
            int totalScore = _participantRepo.AddScore(result.ParticipantId, score);
            JObject jobject = new JObject();
            jobject["ParticipantId"] = result.ParticipantId;
            jobject["TotalScore"] = totalScore;
            await _socketService.SendDataToHost(question.QuizId,"/question/updateLeaderboard",JsonConvert.SerializeObject(jobject));
        }
        public bool AnswerQuestion(Result result)
        {
            var question= _questionRepo.FindById(result.QuestionId);
            if (question == null) 
                throw new RequestException("QuestionId "+result.QuestionId+" does not exist");
            if(!_socketService.quizSessions.ContainsKey(question.QuizId))
                throw new RequestException("Sorry, the quiz has been closed");
            result.IsCorrect=question.CorrectAnswer.Equals(result.ChoosedOption);
            SendScoreToHost(question, result);
            return result.IsCorrect;
        }
    }
}
