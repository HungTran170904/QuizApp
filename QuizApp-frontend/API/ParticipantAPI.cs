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
    public class ParticipantAPI
    {
        public static void AddParticipant(string name, string pinCode, Action<JObject> callback)
        {
            APIConfig.AddTopic("/participant/addParticipant", (jobject) =>
            {
                callback(jobject);
                APIConfig.RemoveTopic("/participant/addParticipant");
            });
            JObject reqObj = new JObject();
            reqObj["name"] = name;
            reqObj["pinCode"] = pinCode;
            APIConfig.SendData("/participant/addParticipant",
                JsonConvert.SerializeObject(reqObj));
        }
    }
}
