using Microsoft.Extensions.Configuration.EnvironmentVariables;
using QuizApp_backend.Models;
using QuizApp_backend.Util;
using System.Data.SqlClient;

namespace QuizApp_backend.Repository
{
    public class AccountRepo
    {
        private readonly string connString;
        private readonly ReaderConverter _converter;
        public AccountRepo(IConfiguration configuration,
            PasswordEncoder passwordEncoder,
            ReaderConverter converter) {
             connString= configuration["ConnectionStrings:DefaultConnection"];
            _converter= converter;
        }
        public Account Save(Account account)
        {
            using (var conn = new SqlConnection(connString))
            {
                conn.Open();
                var query = "insert into Account(Name,Email,Password) output inserted.* values(@Name,@Email,@Password)";
                SqlCommand smd = new SqlCommand(query, conn);
                smd.Parameters.AddWithValue("Name", account.Name);
                smd.Parameters.AddWithValue("Email", account.Email);
                smd.Parameters.AddWithValue("Password",account.Password);
                SqlDataReader reader = smd.ExecuteReader();
                if (reader.Read()) return _converter.convertToAccount(reader);
                else return null;
            }
        }
        public Account FindById(string Id)
        {
            using (var conn = new SqlConnection(connString))
            {
                conn.Open();
                var query = "select * from Account where Id=@Id";
                SqlCommand sql_cmd = new SqlCommand(query, conn);
                sql_cmd.Parameters.AddWithValue("Id", Id);
                SqlDataReader reader = sql_cmd.ExecuteReader();
                if (reader.Read()) return _converter.convertToAccount(reader);
                else return null;
            }
        }
        public Account FindByEmail(string Email)
        {
            using (var conn = new SqlConnection(connString))
            {
                conn.Open();
                var query = "select * from Account where Email=@Email";
                SqlCommand sql_cmd = new SqlCommand(query, conn);
                sql_cmd.Parameters.AddWithValue("Email", Email);
                SqlDataReader reader = sql_cmd.ExecuteReader();
                if (reader.Read()) return _converter.convertToAccount(reader);
                else return null;
            }
        }
    }
}
