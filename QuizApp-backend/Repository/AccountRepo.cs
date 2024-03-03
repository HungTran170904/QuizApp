using Microsoft.Extensions.Configuration.EnvironmentVariables;
using QuizApp_backend.Models;
using QuizApp_backend.Util;
using System.Data;
using System.Data.SqlClient;

namespace QuizApp_backend.Repository
{
    public class AccountRepo
    {
        private readonly string connString;
        private readonly PasswordEncoder _passwordEncoder;
        public AccountRepo(IConfiguration configuration, PasswordEncoder passwordEncoder) {
             connString= configuration["ConnectionStrings:DefaultConnection"];
            _passwordEncoder= passwordEncoder;
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
                smd.Parameters.AddWithValue("Password", _passwordEncoder.encode(account.Password));
                SqlDataReader reader = smd.ExecuteReader();
                if (reader.Read()) return (Account) reader.GetValue(0);
                else return null;
            }
        }
        public Account FindById(string Id)
        {
            using (var conn = new SqlConnection(connString))
            {
                conn.Open();
                var query = "select * from Account where Id=@Id";
                SqlCommand smd = new SqlCommand(query, conn);
                smd.Parameters.AddWithValue("Id", Id);
                SqlDataReader reader = smd.ExecuteReader();
                if (reader.Read())
                {
                    var account =new Account(reader.GetGuid(0).ToString(),reader.GetString(1), 
                            reader.GetString(2), reader.GetString(3));
                    return account;
                }
                else return null;
            }
        }
        public bool existsByEmailAndPassword(string Email, string enteredPassword)
        {
            using (var conn = new SqlConnection(connString))
            {
                conn.Open();
                var query = "select password from Account where Id=@Email";
                SqlCommand smd = new SqlCommand(query, conn);
                smd.Parameters.AddWithValue("Email",Email);
                SqlDataReader reader = smd.ExecuteReader();
                if (reader.Read())
                {
                    var password = reader.GetString(0);
                    return password.Equals(_passwordEncoder.encode(enteredPassword));
                }
                else return false;
            }
        }
    }
}
