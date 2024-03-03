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
        public void saveQuestions(List<Question> questions)
        {
            DataTable dt = new DataTable();
            foreach (var question in questions)
            {
                DataRow dr = dt.NewRow();
                dr["QuizId"] = question.QuizId;
                dr["QuestionText"] = question.QuestionText;
                dr["QuestionType"] = question.QuestionText;
                dr["CorrectAnswer"] = question.CorrectAnswer;
                dr["TimeOut"] = question.TimeOut;
                dr["Options"] = JsonNet.Serialize(question.Options);
                dt.Rows.Add(dr);
            }
            using (SqlConnection connection = new SqlConnection(connString))
            {
                connection.Open();
                using (SqlBulkCopy bulkCopy = new SqlBulkCopy(connection))
                {
                    bulkCopy.DestinationTableName = "Question";
                    bulkCopy.WriteToServer(dt);
                }
            }
        }
        public List<Question> findByQuizId(string QuizId)
        {
            using(var conn=new SqlConnection(connString))
            {
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
    }
}
