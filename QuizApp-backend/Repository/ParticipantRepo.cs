using QuizApp_backend.Models;
using QuizApp_backend.Util;
using System.Data.SqlClient;

namespace QuizApp_backend.Repository
{
    public class ParticipantRepo
    {
        private readonly string connString;
        private readonly ReaderConverter _converter;
        public ParticipantRepo(IConfiguration configuration,
                ReaderConverter converter)
        {
            connString = configuration["ConnectionStrings:DefaultConnection"];
            _converter = converter;
        }
        public Participant AddParticipant(Participant participant)
        {
            using (var conn = new SqlConnection(connString))
            {
                conn.Open();
                string query = "insert into Participant(QuizId, Name,TotalScore,AttendedAt) output inserted.* values(@QuizId,@Name,@TotalScore,@AttendedAt)";
                SqlCommand sql_cmd = new SqlCommand(query, conn);
                sql_cmd.Parameters.AddWithValue("QuizId", participant.QuizId);
                sql_cmd.Parameters.AddWithValue("Name", participant.Name);
                sql_cmd.Parameters.AddWithValue("TotalScore", participant.TotalScore);
                sql_cmd.Parameters.AddWithValue("AttendedAt", participant.AttendedAt);
                SqlDataReader reader = sql_cmd.ExecuteReader();
                if (reader.Read()) return _converter.convertToParticipant(reader);
                else return null;
            }
        }
        public int AddScore(string participantId, int score)
        {
            using (var conn = new SqlConnection(connString))
            {
                conn.Open();
                string query = "update Participant set TotalScore=TotalScore+@Score output inserted.TotalScore where Id=@ParticipantId";
                SqlCommand sql_cmd = new SqlCommand(query, conn);
                sql_cmd.Parameters.AddWithValue("Score", score);
                sql_cmd.Parameters.AddWithValue("PaticipantId",participantId);
                SqlDataReader reader= sql_cmd.ExecuteReader();
                if (reader.Read()) return reader.GetInt32(0);
                else return -1;
            }
        }
    }
}
