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
    public class QuestionAPI
    {
        public static void GetQuestions(string quizId, Action<JObject> callback)
        {
            APIClient.AddTopic("/question/getQuestions", (jobject) =>
            {
                callback(jobject);
                APIClient.RemoveTopic("/question/getQuestions");
            });
            APIClient.SendData("/question/getQuestions", quizId);
        }
        public static void GetQuestionsForPlay(string quizId, Action<JObject> callback)
        {
            APIClient.AddTopic("/question/getQuestionsForPlay", (jobject) =>
            {
                callback(jobject);
                APIClient.RemoveTopic("/question/getQuestionsForPlay");
            });
            APIClient.SendData("/question/getQuestionsForPlay", quizId);
        }
        public void Test()
        {
            APIClient.AddTopic("/quiz/stopGameForPlayers", jobject => {
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
        public static void answerQuestion(Result rs,Action<JObject> callback)
        {
            APIClient.AddTopic("/question/answerQuestion", (jobject) =>
            {
                callback(jobject);
                APIClient.RemoveTopic("/question/answerQuestion");
            });
            APIClient.SendData("/question/answerQuestion", JsonConvert.SerializeObject(rs));

        }
    }
}
