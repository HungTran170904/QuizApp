using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp_frontend.API
{
    public class QuestionAPI
    {
        public static void GetQuestions(string quizId, Action<JObject> callback)
        {
            APIConfig.AddTopic("/question/getQuestions", (jobject) =>
            {
                callback(jobject);
                APIConfig.RemoveTopic("/question/getQuestions");
            });
            APIConfig.SendData("/question/getQuestions", quizId);
        }
        public static void GetQuestionsForPlay(string quizId, Action<JObject> callback)
        {
            APIConfig.AddTopic("/question/getQuestionsForPlay", (jobject) =>
            {
                callback(jobject);
                APIConfig.RemoveTopic("/question/getQuestionsForPlay");
            });
            APIConfig.SendData("/question/getQuestionsForPlay", quizId);
        }
        public void Test()
        {
            APIConfig.AddTopic("/quiz/stopGameForPlayers", jobject => {
                string status = (string)jobject["status"];
                string payload = (string)jobject["payload"];
                if (status.Equals("success"))
                {
                    JObject payloadObj = JsonConvert.DeserializeObject<JObject>(payload);
                    int totalScore = (int)payloadObj["totalScore"];
                    int rank = (int) payloadObj["rank"];
                }
            });
        }
    }
}
