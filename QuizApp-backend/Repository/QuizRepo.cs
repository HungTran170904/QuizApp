using QuizApp_backend.Models;
using QuizApp_backend.Util;
using System.Data.SqlClient;

namespace QuizApp_backend.Repository
{
    public class QuizRepo
    {
        private readonly string connString;
        private readonly ReaderConverter _converter;
        public QuestionRepo(IConfiguration configuration,
                ReaderConverter converter)
        {
            connString = configuration["ConnectionStrings:DefaultConnection"];
            _converter = converter;
        }
        public void saveQuiz(Quiz quiz)
        {
            using(var conn=new SqlConnection(connString))
            {
                string query = "insert into Quiz(CreatorId,Title,CreatedAt,Code,Status) " +
                        "values (@CreatorId,@Title,@CreatedAt,@Code,@Status";
                SqlCommand sql_cmd = new SqlCommand(query, conn);
                sql_cmd.Parameters.AddWithValue("CreatorId", quiz.CreatorId);
                sql_cmd.Parameters.AddWithValue("Title", quiz.Title);
                sql_cmd.Parameters.AddWithValue("CreatedAt", quiz.CreatedAt);
                sql_cmd.Parameters.AddWithValue("Code", quiz.Code);
                sql_cmd.Parameters.AddWithValue("Status", quiz.Status);
                sql_cmd.ExecuteNonQuery();
            }
        }
    }
}
