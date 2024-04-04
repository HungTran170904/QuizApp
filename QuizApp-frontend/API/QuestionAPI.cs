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
            APIConfig.AddTopic("/question/getQuestions", (jobject) =>
            {
                callback(jobject);
                APIConfig.RemoveTopic("/question/getQuestions");
            });
            APIConfig.SendData("/question/getQuestions", quizId);
        }
        public static void GetQuestionsForPlay(string quizId,Action<JObject> callback)
        {
            APIConfig.AddTopic("/question/getQuestionsForPlay", (jobject) =>
            {
                callback(jobject);
                APIConfig.RemoveTopic("/question/getQuestionsForPlay");
            });
            APIConfig.SendData("/question/getQuestionsForPlay", quizId);
        }
        public static void Answer(Result rs, Action<JObject> callback)
        {
            APIConfig.AddTopic("/question/answerQuestion", (jobject) =>
            {
                callback(jobject);
                APIConfig.RemoveTopic("/question/answerQuestion");
            });
            APIConfig.SendData("/question/answerQuestion", JsonConvert.SerializeObject(rs));
        }
    }
}
