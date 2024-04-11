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
        public static void AddParticipant(Participant participant, Action<JObject> callback)
        {
            APIConfig.AddTopic("/participant/addParticipant", (jobject) =>
            {
                callback(jobject);
            });
            APIConfig.SendData("/participant/addParticipant",
                JsonConvert.SerializeObject(participant));
        }
    }
}
