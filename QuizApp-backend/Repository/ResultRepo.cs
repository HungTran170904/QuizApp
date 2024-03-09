using QuizApp_backend.Models;
using QuizApp_backend.Util;
using System.Data.SqlClient;

namespace QuizApp_backend.Repository
{
    public class ResultRepo
    {
        private readonly string connString;
        private readonly ReaderConverter _converter;
        public ResultRepo(IConfiguration configuration,
                ReaderConverter converter)
        {
            connString = configuration["ConnectionStrings:DefaultConnection"];
            _converter = converter;
        }
        public void addResult(Result result)
        {
            using (var conn = new SqlConnection(connString))
            {
                conn.Open();
                string query = "insert into Result(ParticipantId,QuestionId,ChoosedOption,IsCorrect) " +
                    "values(@ParticipantId,@QuestionId,@ChoosedOption,@IsCorrect)";
                SqlCommand sql_cmd = new SqlCommand(query, conn);
                sql_cmd.Parameters.AddWithValue("ParticipantId", result.ParticipantId);
                sql_cmd.Parameters.AddWithValue("QuestionId", result.QuestionId);
                sql_cmd.Parameters.AddWithValue("ChoosedOption", result.ChoosedOption);
                sql_cmd.Parameters.AddWithValue("IsCorrect", result.IsCorrect);
                sql_cmd.ExecuteNonQuery();
            }
        }
    }
}
