using Json.Net;
using QuizApp_backend.Models;
using QuizApp_backend.Util;
using System.Data;
using System.Data.SqlClient;

namespace QuizApp_backend.Repository
{
    public class QuestionRepo
    {
        private readonly string connString;
        private readonly ReaderConverter _converter;
        public QuestionRepo(IConfiguration configuration, 
                ReaderConverter converter) {
             connString = configuration["ConnectionStrings:DefaultConnection"];
            _converter = converter;
         }
        public Question SaveQuestion(Question question) { 
            using(SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                string query= "insert into Question(QuizId,QuestionText,QuestionType,CorrectAnswer,TimeOut,Options) output inserted.*"
                        + "values(@QuizId,@QuestionText,@QuestionType,@CorrectAnswer,@TimeOut,@Options)";
                SqlCommand sql_cmd = new SqlCommand(query, conn);
                sql_cmd.Parameters.AddWithValue("QuizId", question.QuizId);
                sql_cmd.Parameters.AddWithValue("QuestionText", question.QuestionText);
                sql_cmd.Parameters.AddWithValue("Options", JsonNet.Serialize(question.Options));
                sql_cmd.Parameters.AddWithValue("CorrectAnswer", question.CorrectAnswer);
                sql_cmd.Parameters.AddWithValue("TimeOut", question.TimeOut);
                SqlDataReader reader = sql_cmd.ExecuteReader();
                if (reader.Read()) return _converter.convertToQuestion(reader);
                else return null;

            }
        }
        public List<Question> SaveQuestions(List<Question> questions)
        {
            DataTable dt = new DataTable();
            foreach (var question in questions)
            {
                DataRow dr = dt.NewRow();
                dr["QuizId"] = question.QuizId;
                dr["QuestionText"] = question.QuestionText;
                dr["CorrectAnswer"] = question.CorrectAnswer;
                dr["TimeOut"] = question.TimeOut;
                dr["Options"] = JsonNet.Serialize(question.Options);
                dt.Rows.Add(dr);
            }
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                using (SqlBulkCopy bulkCopy = new SqlBulkCopy(conn))
                {
                    bulkCopy.DestinationTableName = "Question";
                    bulkCopy.WriteToServer(dt);

                    var sql_cmd = new SqlCommand("Select Id from Question where @@ROWCOUNT>0", conn);
                    int rowIndex = 0;
                    SqlDataReader reader= sql_cmd.ExecuteReader();    
                    while(reader.Read())
                    {
                        questions[rowIndex].Id = reader.GetGuid(0).ToString();
                        rowIndex++;
                    }
                }
            }
            return questions;
        }
        public List<Question> FindByQuizId(string QuizId)
        {
            using(var conn=new SqlConnection(connString))
            {
                conn.Open();
                List<Question> questions = new List<Question>();
                string query = "select * from Question q where q.QuizId=@QuizId";
                SqlCommand sql_cmd= new SqlCommand(query, conn);
                SqlDataReader reader = sql_cmd.ExecuteReader();
                while(reader.Read())
                {
                    questions.Add(_converter.convertToQuestion(reader));   
                }
                return questions;
            }
        }
        public Question FindById(string QuestionId)
        {
            using (var conn = new SqlConnection(connString))
            {
                conn.Open();
                string query = "select * from Question where Id=@Id";
                SqlCommand sql_cmd = new SqlCommand(query, conn);
                sql_cmd.Parameters.AddWithValue("Id", QuestionId);
                SqlDataReader reader = sql_cmd.ExecuteReader();
                if (reader.Read()) return _converter.convertToQuestion(reader);
                else return null;
            }
        }
    }
}
