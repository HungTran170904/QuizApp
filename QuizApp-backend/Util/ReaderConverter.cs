using Json.Net;
using QuizApp_backend.Models;
using System.Data;
using System.Data.SqlClient;

namespace QuizApp_backend.Util
{
    public class ReaderConverter
    {
        public Account convertToAccount(SqlDataReader reader)
        {
            Account account=new Account();
            account.Id=reader.GetFieldValue<Guid>("Id").ToString();
            account.Email = reader.GetFieldValue<string>("Email");
            return account;
        }
        public Question convertToQuestion(SqlDataReader reader)
        {
            Question question = new Question();
            question.Id = reader.GetFieldValue<Guid>("Id").ToString();
            question.QuestionText = reader.GetFieldValue<string>("QuestionText");
            question.QuestionType = reader.GetFieldValue<string>("QuestionType");
            question.TimeOut = reader.GetFieldValue<int>("TimeOut");
            question.QuizId = reader.GetFieldValue<Guid>("QuizId").ToString();
            string jsonOptions = reader.GetFieldValue<string>("QuestionType");
            question.Options = JsonNet.Deserialize<List<string>>(jsonOptions);
            return question;
        }
        
    }
}
