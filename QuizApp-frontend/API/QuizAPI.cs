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
        public static void GetQuizzes(string quizId, Action<JObject> callback)
        {
            APIConfig.AddTopic("/quiz/getQuizzes", (jobject) =>
            {
                callback(jobject);
                APIConfig.RemoveTopic("/quiz/getQuizzes");
            });
            APIConfig.SendData("/quiz/getQuizzes", quizId);
        }
        public static void HostGame(string quizId, Action<JObject> callback)
        {
            APIConfig.AddTopic("/quiz/hostGame", (jobject) =>
            {
                callback(jobject);
                APIConfig.RemoveTopic("/quiz/hostGame");
            });
            APIConfig.SendData("/quiz/hostGame", quizId);
        }
        public static void StartGame(string quizId, Action<JObject> callback)
        {
            APIConfig.AddTopic("/quiz/startGame", (jobject) =>
            {
                callback(jobject);
                APIConfig.RemoveTopic("/quiz/startGame");
            });
            APIConfig.SendData("/quiz/startGame", quizId);
        }
        public static void EndGame(string quizId, Action<JObject> callback)
        {
            APIConfig.AddTopic("/quiz/endGame", (jobject) =>
            {
                callback(jobject);
                APIConfig.RemoveTopic("/quiz/endGame");
            });
            APIConfig.SendData("/quiz/endGame", quizId);
        }
        public static void UpdateBlock(string quizId, bool isBlocked, Action<JObject> callback)
        {
            APIConfig.AddTopic("/quiz/updateBlock", (jobject) =>
            {
                callback(jobject);
                APIConfig.RemoveTopic("/quiz/updateBlock");
            });
            JObject jobject = new JObject();
            jobject["quizId"] = quizId;
            jobject["isBlocked"]=isBlocked;
            APIConfig.SendData("/quiz/updateBlock",JsonConvert.SerializeObject(jobject));
        }
    }
}
