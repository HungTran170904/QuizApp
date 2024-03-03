using QuizApp_backend.Models;
using QuizApp_backend.Repository;

namespace QuizApp_backend
{
    public class Server
    {
        public readonly AccountRepo _accountRepo;
        public Server(AccountRepo accountRepo)
        {
            _accountRepo = accountRepo;
        }
        public void Run()
        {
            Account account = new Account();
            account.Email = "22520527@gmail.com";
            account.Name = "Teo";
            account.Password = "password";
            _accountRepo.Save(account);
        }
    }
}
