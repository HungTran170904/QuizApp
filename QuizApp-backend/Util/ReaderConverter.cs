using Json.Net;
using QuizApp_backend.Models;
using System.Data;
using System.Data.SqlClient;
using System.Numerics;

namespace QuizApp_backend.Util
{
    public class ReaderConverter
    {
        public Account convertToAccount(SqlDataReader reader)
        {
            Account account=new Account();
            account.Id=reader.GetFieldValue<Guid>("Id").ToString();
            account.Name=reader.GetFieldValue<string>("Name");
            account.Email = reader.GetFieldValue<string>("Email");
            account.Password = reader.GetFieldValue<string>("Password");
            return account;
        }
        public Question convertToQuestion(SqlDataReader reader)
        {
            Question question = new Question();
            question.Id = reader.GetFieldValue<Guid>("Id").ToString();
            question.QuizId = reader.GetFieldValue<Guid>("QuizId").ToString();
            question.QuestionText = reader.GetFieldValue<string>("QuestionText");
            question.TimeOut = reader.GetFieldValue<int>("TimeOut");
            string jsonOptions = reader.GetFieldValue<string>("Options");
            question.Options = JsonNet.Deserialize<List<string>>(jsonOptions);
            question.CorrectAnswer = reader.GetFieldValue<string>("CorrectAnswer");
            return question;
        }
        public Quiz convertToQuiz(SqlDataReader reader)
        {
            Quiz quiz = new Quiz();
            quiz.Id = reader.GetFieldValue<Guid>("Id").ToString();
            quiz.CreatorId= reader.GetFieldValue<Guid>("CreatorId").ToString();
            quiz.Title = reader.GetFieldValue<string>("Title");
            quiz.Status= reader.GetFieldValue<string>("Status");
            quiz.CreatedAt= reader.GetFieldValue<DateTime>("CreatedAt");
            return quiz;
        }
        public Participant convertToParticipant(SqlDataReader reader)
        {
            Participant participant = new Participant();
            participant.Id= reader.GetFieldValue<Guid>("Id").ToString();
            participant.QuizId= reader.GetFieldValue<Guid>("QuizId").ToString();
            participant.Name= reader.GetFieldValue<string>("Name");
            if (!reader.IsDBNull(reader.GetOrdinal("TotalScore")))
                participant.TotalScore= reader.GetFieldValue<int>("TotalScore");
            participant.AttendedAt= reader.GetFieldValue<DateTime>("AttendedAt");
            if(!reader.IsDBNull(reader.GetOrdinal("FinishedAt")))
                participant.FinishedAt= reader.GetFieldValue<DateTime>("FinishedAt");
            return participant;
        }
        public Result convertToResult(SqlDataReader reader)
        {
            Result result = new Result();
            //result.ParticipantId= reader.GetFieldValue<Guid>("ParticipantId").ToString();
            result.QuestionId= reader.GetFieldValue<Guid>("QuestionId").ToString();
            result.ChoosedOption= reader.GetFieldValue<string>("ChoosedOption");
            result.IsCorrect= reader.GetFieldValue<bool>("IsCorrect");
            return result;
        }
    }
}
