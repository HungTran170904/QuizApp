using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using QuizApp_backend.Exceptions;
using QuizApp_backend.Models;
using QuizApp_backend.Repository;
using QuizApp_backend.Util;
using System.Net.Sockets;
using System.Transactions;

namespace QuizApp_backend.Services
{
    public class QuizService
    {
        private readonly QuizRepo _quizRepo;
        private readonly QuestionRepo _questionRepo;
        private readonly SocketService _socketService;
        private readonly ParticipantRepo _participantRepo;
        public QuizService(QuizRepo quizRepo,
                    QuestionRepo questionRepo,
                    ParticipantRepo participantRepo,
                    SocketService socketService)
        {
            _socketService=socketService;
            _quizRepo = quizRepo;
            _questionRepo = questionRepo;
            _participantRepo = participantRepo;
        }
        public Quiz AddQuiz(Quiz quiz)
        {
            if (quiz.Title == null) throw new RequestException("Title is reuqired");
            quiz.Status = "stop";
            quiz.CreatedAt = DateTime.Now;
            using(var tx=new TransactionScope())
            {
                var savedQuiz = _quizRepo.SaveQuiz(quiz);
                if (quiz.Questions != null)
                {
                    var questions = _questionRepo.SaveQuestions(quiz.Questions, savedQuiz.Id);
                    savedQuiz.Questions = questions;
                }
                tx.Complete();
                return savedQuiz;
            }
        }
        public List<Quiz> GetQuizzes(string accountId)
        {
            return _quizRepo.FindByCreatorId(accountId);
        }
        public void HostGame(string accountId,string quizId, TcpClient client)
        {
            string creatorId=_quizRepo.GetCreatorId(quizId);
            if (creatorId == null || !creatorId.Equals(accountId, StringComparison.OrdinalIgnoreCase))
                throw new RequestException("You do not have permission to host this game");
            _quizRepo.UpdateStatus(quizId,Constraints.host);
            _socketService.AddQuizSession(quizId, client);
        }
        public void StartGame(string accountId, string quizId)
        {
            string creatorId = _quizRepo.GetCreatorId(quizId);
            if (creatorId == null || !creatorId.Equals(accountId, StringComparison.OrdinalIgnoreCase))
                throw new RequestException("You do not have permission to start this game");
            _quizRepo.UpdateStatus(quizId,Constraints.play);
            List<Question> questions=_questionRepo.FindByQuizId(quizId, false);
            JObject jobject = new JObject();
            jobject["quizId"] = quizId;
            jobject["questions"] = JsonConvert.SerializeObject(questions);
            _socketService.SendDataToPlayers(quizId, "/quiz/startGameForPlayers", 
                    JsonConvert.SerializeObject(jobject));
        }
        public void StopGame(string accountId, string quizId)
        {
            Quiz quiz=_quizRepo.FindById(quizId);
            if (quiz.CreatorId == null || !quiz.CreatorId.Equals(accountId, StringComparison.OrdinalIgnoreCase))
                throw new RequestException("You do not have permission to end this game");
            _quizRepo.UpdateStatus(quizId,Constraints.stop);
            Task.Run(() =>
            {
                if (quiz.Status.Equals(Constraints.play))
                {
                    var players = _socketService.quizSessions[quiz.Id].Players;
                    List<Participant> participants = _participantRepo.FindByIdsAndQuizId(players.Keys.ToList(),quizId);
                    participants.Sort((player1, player2) =>
                    {
                        if (player1.TotalScore != player2.TotalScore)
                            return player1.TotalScore - player2.TotalScore;
                        else if (player1.FinishedAt == null) return -1;
                        else if (player2.FinishedAt == null) return 1;
                        else return (player1.FinishedAt < player2.FinishedAt) ? -1 : 1;
                    });
                    for (int i = 0; i < participants.Count; i++)
                    {
                        JObject jobject = new JObject();
                        jobject["totalScore"] = participants[i].TotalScore;
                        jobject["rank"] = i + 1;
                        _socketService.SendDataToPlayer(quizId, participants[i].Id,
                            "/quiz/stopGameForPlayers", JsonConvert.SerializeObject(jobject));
                    }
                }
                _socketService.RemoveQuizSession(quizId);
            });
        }
        public void UpdateBlock(string accountId, string quizId, bool IsBlocked) 
        {
            string creatorId = _quizRepo.GetCreatorId(quizId);
            if (creatorId == null || !creatorId.Equals(accountId, StringComparison.OrdinalIgnoreCase))
                throw new RequestException("You do not have permission to end this game");
            _quizRepo.UpdateBlock(quizId, IsBlocked);
        }
    }
}
