﻿using Microsoft.AspNetCore.Hosting.Server;
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
        private readonly ResultRepo _resultRepo;
        public QuestionService(QuestionRepo questionRepo,
                            ParticipantRepo participantRepo,
                            SocketService socketService,
                            ResultRepo resultRepo)
        {
            _socketService = socketService;
            _questionRepo = questionRepo;
            _participantRepo = participantRepo;
            _resultRepo = resultRepo;
        }
        public List<Question> GetQuestions(string QuizId)
        {
            return _questionRepo.FindByQuizId(QuizId,true);
        }
        public List<Question> GetQuestionsForPlay(string QuizId)
        {
            return _questionRepo.FindByQuizId(QuizId,false);
        }
        private void SendScoreToHost(Question question, Result result)
        {
            int score = (result.IsCorrect) ? 10 :0;
            int totalScore = _participantRepo.AddScoreAndFinishedTime(result.ParticipantId, score,DateTime.Now);
            JObject jobject = new JObject();
            jobject["participantId"] = result.ParticipantId;
            jobject["totalScore"] = totalScore;
            _socketService.SendDataToHost(question.QuizId, "/question/updateLeaderboard", JsonConvert.SerializeObject(jobject));
        }
        public bool AnswerQuestion(Result result)
        {
            var question= _questionRepo.FindById(result.QuestionId);
            if (question == null) 
                throw new RequestException("QuestionId "+result.QuestionId+" does not exist");
            if(!_socketService.quizSessions.ContainsKey(question.QuizId))
                throw new RequestException("Sorry, the quiz has been closed");
            result.IsCorrect=question.CorrectAnswer.Equals(result.ChoosedOption);
            _resultRepo.addResult(result);
            Task.Run(()=>SendScoreToHost(question, result));
            return result.IsCorrect;
        }
    }
}
