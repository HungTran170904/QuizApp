using Microsoft.AspNetCore.Server.HttpSys;
using QuizApp_backend.Models;
using QuizApp_backend.Util;
using System.Data;
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
        public int AddScoreAndFinishedTime(string participantId, int score,DateTime finishedAt)
        {
            using (var conn = new SqlConnection(connString))
            {
                conn.Open();
                string query = "update Participant set TotalScore=TotalScore+@Score, FinishedAt=@FinishedAt " +
                    "output inserted.TotalScore where Id=@ParticipantId";
                SqlCommand sql_cmd = new SqlCommand(query, conn);
                sql_cmd.Parameters.AddWithValue("ParticipantId", participantId);
                sql_cmd.Parameters.AddWithValue("Score", score);
                sql_cmd.Parameters.AddWithValue("FinishedAt", finishedAt);
                SqlDataReader reader= sql_cmd.ExecuteReader();
                if (reader.Read()) return reader.GetInt32(0);
                else return -1;
            }
        }
        public List<Participant> FindByIdsAndQuizId(List<string> IdList,string QuizId)
        {
            using (var conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlCommand sql_cmd = new SqlCommand("GetParticipantsByIdList", conn);
                sql_cmd.CommandType=CommandType.StoredProcedure;
                DataTable idTable = new DataTable();
                idTable.Columns.Add("Id", typeof(Guid));
                foreach(string id in IdList)
                {
                    idTable.Rows.Add(new Guid(id));
                }
                SqlParameter parameter = new SqlParameter
                {
                    ParameterName = "IdList",
                    SqlDbType = SqlDbType.Structured,
                    TypeName = "dbo.IdListType",
                    Value = idTable
                };
                sql_cmd.Parameters.Add(parameter);
                sql_cmd.Parameters.AddWithValue("QuizId",new Guid(QuizId));
                SqlDataReader reader = sql_cmd.ExecuteReader();
                List<Participant> participants = new List<Participant>();
                while (reader.Read())
                {
                    Participant participant = _converter.convertToParticipant(reader);
                    participants.Add(participant);
                }
                idTable.Dispose();
                return participants;
            }
        }
        public List<Participant> FindWithResultsByQuizId(string QuizId)
        {
            using (var conn = new SqlConnection(connString))
            {
                conn.Open();
                string query = "select * from Participant p " +
                                "left join Result r on r.ParticipantId=p.Id " +
                                "where p.QuizId=@QuizId";
                SqlCommand sql_cmd = new SqlCommand(query, conn);
                sql_cmd.Parameters.AddWithValue("QuizId", QuizId);
                SqlDataReader reader = sql_cmd.ExecuteReader();
                Dictionary<string, Participant> dictionary=new Dictionary<string, Participant>();
                while (reader.Read())
                {
                    if (reader.IsDBNull(reader.GetOrdinal("ParticipantId")))
                    {
                        Participant p = _converter.convertToParticipant(reader);
                        dictionary[p.Id] = p;
                    }
                    else
                    {
                        string participantId = reader.GetFieldValue<Guid>("ParticipantId").ToString();
                        Result r = _converter.convertToResult(reader);
                        if (dictionary.ContainsKey(participantId))
                        {
                            dictionary[participantId].Results.Add(r);
                        }
                        else
                        {
                            Participant p = _converter.convertToParticipant(reader);
                            p.Results.Add(r);
                            dictionary[participantId] = p;
                        }
                    }
                }
                return dictionary.Values.ToList();
            }
        }
    }
}
