using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using QuizApp_frontend.Models;

namespace QuizApp_frontend.API
{
    public class AccountAPI
    {
        public static void Login(string email, string password,Action<JObject> callback)
        {
            APIClient.AddTopic("/account/login", (jobject) =>
            {
                callback(jobject);
                APIClient.RemoveTopic("/account/login");
            });
            JObject jobject=new JObject();
            jobject["email"]=email;
            jobject["password"]=password;
            APIClient.SendData("/account/login", JsonConvert.SerializeObject(jobject));
        }
        public static void Register(Account account, Action<JObject> callback)
        {
            APIClient.AddTopic("/account/register", (jobject) =>
            {
                callback(jobject);
                APIClient.RemoveTopic("/account/register");
            });
            APIClient.SendData("/account/register", JsonConvert.SerializeObject(account));
        }
    }
}
