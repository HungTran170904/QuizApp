using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using QuizApp_frontend.Models;

namespace QuizApp_frontend.API
{
    public class AccountAPI
    {
        public static void Login(string email, string password,Action<JObject> callback)
        {
            APIConfig.AddTopic("/account/login", (jobject) =>
            {
                callback(jobject);
                APIConfig.RemoveTopic("/account/login");
            });
            JObject jobject=new JObject();
            jobject["email"]=email;
            jobject["password"]=password;
            APIConfig.SendData("/account/login", JsonConvert.SerializeObject(jobject));
        }
        public static void Register(Account account, Action<JObject> callback)
        {
            APIConfig.AddTopic("/account/register", (jobject) =>
            {
                callback(jobject);
                APIConfig.RemoveTopic("/account/register");
            });
            APIConfig.SendData("/account/register", JsonConvert.SerializeObject(account));
        }
    }
}
