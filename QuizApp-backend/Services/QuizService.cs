﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using QuizApp_backend.Exceptions;
using QuizApp_backend.Models;
using QuizApp_backend.Repository;
using QuizApp_backend.Util;
using System.Net.Sockets;

namespace QuizApp_backend.Services
{
    public class QuizService
    {
        private readonly QuizRepo _quizRepo;
        private readonly QuestionRepo _questionRepo;
        private readonly SocketService _socketService;
        public QuizService(QuizRepo quizRepo,
                    QuestionRepo questionRepo,
                    SocketService socketService)
        {
            _socketService=socketService;
            _quizRepo = quizRepo;
            _questionRepo = questionRepo;
        }
        public Quiz AddQuiz(Quiz quiz)
        {
            if (quiz.Title == null) throw new RequestException("Title is reuqired");
            quiz.Status = "stop";
            var savedQuiz=_quizRepo.SaveQuiz(quiz);
            var questions=_questionRepo.SaveQuestions(quiz.Questions);
            savedQuiz.Questions = questions;
            return savedQuiz;
        }
        public List<Quiz> GetQuizzes(string accountId)
        {
            return _quizRepo.FindByCreatorId(accountId);
        }
        public void HostGame(string accountId,string quizId, TcpClient client)
        {
            string creatorId=_quizRepo.GetCreatorId(accountId);
            if (creatorId == null || !creatorId.Equals(accountId))
                throw new RequestException("You do not have permission to host this game");
            _quizRepo.UpdateStatus(quizId, "host");
            _socketService.AddQuizSession(quizId, client);
        }
        public void StartGame(string accountId, string quizId)
        {
            string creatorId = _quizRepo.GetCreatorId(quizId);
            if (creatorId == null || !creatorId.Equals(accountId))
                throw new RequestException("You do not have permission to start this game");
            _quizRepo.UpdateStatus(quizId, "play");
            List<Question> questions=_questionRepo.FindByQuizId(quizId);
            JObject jobject=new JObject();
            jobject["quizId"]=quizId;
            jobject["questions"]=JsonConvert.SerializeObject(questions);
            _socketService.SendDataToPlayers(quizId,"/quiz/startGame", JsonConvert.SerializeObject(jobject));
        }
        public void StopGame(string accountId, string quizId)
        {
            string creatorId = _quizRepo.GetCreatorId(accountId);
            if (creatorId == null || !creatorId.Equals(accountId))
                throw new RequestException("You do not have permission to end this game");
            _quizRepo.UpdateStatus(quizId, "stop");
            _socketService.RemoveQuizSession(quizId);
            _socketService.SendDataToPlayers(quizId, "/quiz/stopGame", quizId);
        }
        public void UpdateBlock(string accountId, string quizId, bool IsBlocked) 
        {
            string creatorId = _quizRepo.GetCreatorId(accountId);
            if (creatorId == null || !creatorId.Equals(accountId))
                throw new RequestException("You do not have permission to end this game");
            _quizRepo.UpdateBlock(quizId, IsBlocked);
        }
    }
}
