using QuizApp_backend.Models;
using QuizApp_backend.Util;
using System.Data.SqlClient;

namespace QuizApp_backend.Repository
{
    public class QuizRepo
    {
        private readonly string connString;
        private readonly ReaderConverter _converter;
        public QuizRepo(IConfiguration configuration,
                ReaderConverter converter)
        {
            connString = configuration["ConnectionStrings:DefaultConnection"];
            _converter = converter;
        }
        public Quiz SaveQuiz(Quiz quiz)
        {
            using(var conn=new SqlConnection(connString))
            {
                conn.Open();
                string query = "insert into Quiz(CreatorId,Title,CreatedAt,Status) output inserted.*" +
                        "values (@CreatorId,@Title,@CreatedAt,@Status)";
                SqlCommand sql_cmd = new SqlCommand(query, conn);
                sql_cmd.Parameters.AddWithValue("CreatorId", quiz.CreatorId);
                sql_cmd.Parameters.AddWithValue("Title", quiz.Title);
                sql_cmd.Parameters.AddWithValue("CreatedAt", quiz.CreatedAt);
                sql_cmd.Parameters.AddWithValue("Status", quiz.Status);
                SqlDataReader reader=sql_cmd.ExecuteReader();
                if (reader.Read()) return _converter.convertToQuiz(reader);
                else return null;
            }
        }

        public List<Quiz> FindByCreatorId(string accountId)
        {
            using (var conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlCommand sql_cmd = new SqlCommand("select * from Quiz where CreatorId=@CreatorId", conn);
                List<Quiz> quizzes = new List<Quiz>();
                SqlDataReader reader = sql_cmd.ExecuteReader();
                while (reader.Read())
                {
                    quizzes.Add(_converter.convertToQuiz(reader));
                }
                return quizzes;
            }
        }
    }
}
