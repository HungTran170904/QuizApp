using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using QuizApp_backend.Models;
using QuizApp_backend.Services;

namespace QuizApp_backend.Controllers
{
    public class AccountController
    {
        public string prefix = "/account";
        private readonly AccountService _accountService;
        public AccountController(AccountService accountService)
        {
            _accountService = accountService;
        }
        public string RouteRequests(string url, string payload)
        {
            url = url.Substring(prefix.Length);
            string result = "";
            if(url.Equals("/login")) 
                result=Login(payload);
            else if(url.Equals("/register")) 
               Register(payload);
            return result;
        }
        public string Login(string payload)
        {
              var jobject=JObject.Parse(payload);
              string email = (string) jobject["email"];
              string password = (string) jobject["password"];
              Account account= _accountService.Login(email, password);
              return JsonConvert.SerializeObject(account);
        }
        public void Register(string payload)
        {
            Account account = JsonConvert.DeserializeObject<Account>(payload);
            _accountService.register(account);
        }
    }
}
