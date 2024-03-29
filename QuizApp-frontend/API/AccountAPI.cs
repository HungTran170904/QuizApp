using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using QuizApp_frontend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            APIConfig.AddTopic("/account/registry", (jobject) =>
            {
                callback(jobject);
                APIConfig.RemoveTopic("/account/login");
            });
            APIConfig.SendData("/account/registry", JsonConvert.SerializeObject(account));
        }
    }
}
