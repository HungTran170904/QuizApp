﻿using QuizApp_backend.Models;
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
                string query = "insert into Quiz(CreatorId,Title,CreatedAt,Status,IsBlocked) output inserted.*" +
                        "values (@CreatorId,@Title,@CreatedAt,@Status,@IsBlocked)";
                SqlCommand sql_cmd = new SqlCommand(query, conn);
                sql_cmd.Parameters.AddWithValue("CreatorId", quiz.CreatorId);
                sql_cmd.Parameters.AddWithValue("Title", quiz.Title);
                sql_cmd.Parameters.AddWithValue("CreatedAt", quiz.CreatedAt);
                sql_cmd.Parameters.AddWithValue("Status", quiz.Status);
                sql_cmd.Parameters.AddWithValue("IsBlocked", quiz.IsBlocked);
                SqlDataReader reader=sql_cmd.ExecuteReader();
                if (reader.Read()) return _converter.convertToQuiz(reader);
                else return null;
            }
        }
        public void UpdateStatus(string QuizId, string status)
        {
            using(var conn=new SqlConnection(connString))
            {
                conn.Open();
                string query = "update Quiz set Status=@Status where Id=@Id";
                SqlCommand sql_cmd = new SqlCommand(query, conn);
                sql_cmd.Parameters.AddWithValue("Status", status);
                sql_cmd.Parameters.AddWithValue("Id", QuizId);
                sql_cmd.ExecuteNonQuery();
            }
        }
        public void UpdateBlock(string QuizId, bool IsBlocked)
        {
            using (var conn = new SqlConnection(connString))
            {
                conn.Open();
                string query = "update Quiz set IsBlocked=@IsBlocked where Id=@Id";
                SqlCommand sql_cmd = new SqlCommand(query, conn);
                sql_cmd.Parameters.AddWithValue("Id", QuizId);
                sql_cmd.Parameters.AddWithValue("IsBlocked", IsBlocked);
                sql_cmd.ExecuteNonQuery();
            }
        }

        public List<Quiz> FindByCreatorId(string AccountId)
        {
            using (var conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlCommand sql_cmd = new SqlCommand("select * from Quiz where CreatorId=@CreatorId", conn);
                sql_cmd.Parameters.AddWithValue("CreatorId", AccountId);
                SqlDataReader reader = sql_cmd.ExecuteReader();
                List<Quiz> quizzes = new List<Quiz>();
                while (reader.Read())
                {
                    quizzes.Add(_converter.convertToQuiz(reader));
                }
                return quizzes;
            }
        }
        public string GetCreatorId(string QuizId)
        {
            using (var conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlCommand sql_cmd = new SqlCommand("select CreatorId from Quiz where Id=@Id", conn);
                sql_cmd.Parameters.AddWithValue("Id", QuizId);
                SqlDataReader reader = sql_cmd.ExecuteReader();
                if (reader.Read()) return reader.GetGuid(0).ToString();
                else return null;
            }
        }
        public Quiz FindById(string Id)
        {
            using (var conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlCommand sql_cmd = new SqlCommand("select * from Quiz where Id=@Id", conn);
                sql_cmd.Parameters.AddWithValue("Id", Id);
                SqlDataReader reader = sql_cmd.ExecuteReader();
                if (reader.Read()) return _converter.convertToQuiz(reader);
                else return null;
            }
        }
    }
}
