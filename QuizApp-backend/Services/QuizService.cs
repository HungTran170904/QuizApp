using QuizApp_backend.Exceptions;
using QuizApp_backend.Models;
using QuizApp_backend.Repository;
using QuizApp_backend.Util;

namespace QuizApp_backend.Services
{
    public class QuizService
    {
        private readonly QuizRepo _quizRepo;
        private readonly QuestionRepo _questionRepo;
        public QuizService(QuizRepo quizRepo,
                    QuestionRepo questionRepo)
        {
            _quizRepo = quizRepo;
            _questionRepo = questionRepo;
        }
        public Quiz AddQuiz(Quiz quiz)
        {
            if (quiz.Title == null) throw new RequestException("Title is reuqired");
            quiz.Status = "pending";
            var savedQuiz=_quizRepo.SaveQuiz(quiz);
            var questions=_questionRepo.SaveQuestions(quiz.Questions);
            savedQuiz.Questions = questions;
            return savedQuiz;
        }
        public List<Quiz> GetQuizzes(string accountId)
        {
            return _quizRepo.FindByCreatorId(accountId);
        }
        public void startGame(string quizId)
        {

        }
    }
}
