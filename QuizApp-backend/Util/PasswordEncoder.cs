using System.Security.Cryptography;
using System.Text;

namespace QuizApp_backend.Util
{
    public class PasswordEncoder
    {

        public string encode(string password)
        {
            SHA256 sha256 = SHA256.Create();
            byte[] encryptBytes= sha256.ComputeHash(Encoding.ASCII.GetBytes(password));
            return Convert.ToBase64String(encryptBytes);
        }
    }
}
