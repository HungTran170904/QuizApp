using QuizApp_backend.Exceptions;
using QuizApp_backend.Models;
using QuizApp_backend.Repository;
using QuizApp_backend.Util;

namespace QuizApp_backend.Services
{
    public class AccountService
    {
        private readonly AccountRepo _accountRepo;
        private readonly PasswordEncoder _passwordEncoder;
        public AccountService(AccountRepo accountRepo,
                             PasswordEncoder passwordEncoder) {
            _accountRepo = accountRepo;
            _passwordEncoder = passwordEncoder;
        }
        public Account Login(string email, string password)
        {
            Account acc= _accountRepo.FindByEmail(email);
            if (acc == null) throw new RequestException("The email " + email + " does not exists");
            if (!acc.Password.Equals(_passwordEncoder.encode(password)))
                throw new RequestException("Password is incorrect");
            acc.Password = null;
            return acc;
        }
        public void register(Account acc)
        {
            if (acc.Email == null) throw new RequestException("Email is required");
            if (acc.Password == null || acc.Password.Trim().Length == 0)
                throw new RequestException("Password is required");
            acc.Password= _passwordEncoder.encode(acc.Password);
            _accountRepo.Save(acc);
        }
    }
}
