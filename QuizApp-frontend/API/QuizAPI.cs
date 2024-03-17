using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using QuizApp_frontend.Models;

namespace QuizApp_frontend.API
{
    public class QuizAPI
    {
        public static void AddQuiz(Quiz quiz, Action<JObject> callback)
        {
            APIConfig.AddTopic("/quiz/addQuiz", (jobject) =>
            {
                callback(jobject);
                APIConfig.RemoveTopic("/quiz/addQuiz");
            });
            string payload=JsonConvert.SerializeObject(quiz);
            APIConfig.SendData("/quiz/addQuiz", payload);
        }
    }
}
