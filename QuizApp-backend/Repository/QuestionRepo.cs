using QuizApp_backend.Util;

namespace QuizApp_backend.Repository
{
    public class QuestionRepo
    {
        private readonly string connString;
        private readonly PasswordEncoder _passwordEncoder;
        public QuestionRepo(IConfiguration configuration, PasswordEncoder passwordEncoder) {
             connString = configuration["ConnectionStrings:DefaultConnection"];
             _passwordEncoder = passwordEncoder;
         }

        public void findByQuizId(string QuizId)
        {

        }
    }
}
