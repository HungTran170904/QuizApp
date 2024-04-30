using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using QuizApp_frontend.Models;

namespace QuizApp_frontend.API
{
    public class QuizAPI
    {
        public static void AddQuiz(Quiz quiz, Action<JObject> callback)
        {
            APIClient.AddTopic("/quiz/addQuiz", (jobject) =>
            {
                callback(jobject);
                APIClient.RemoveTopic("/quiz/addQuiz");
            });
            string payload=JsonConvert.SerializeObject(quiz);
            APIClient.SendData("/quiz/addQuiz", payload);
        }
        public static void GetQuizzes(string quizId, Action<JObject> callback)
        {
            APIClient.AddTopic("/quiz/getQuizzes", (jobject) =>
            {
                callback(jobject);
                APIClient.RemoveTopic("/quiz/getQuizzes");
            });
            APIClient.SendData("/quiz/getQuizzes", quizId);
        }
        public static void HostGame(string quizId, Action<JObject> callback)
        {
            APIClient.AddTopic("/quiz/hostGame", (jobject) =>
            {
                callback(jobject);
                APIClient.RemoveTopic("/quiz/hostGame");
            });
            APIClient.SendData("/quiz/hostGame", quizId);
        }
        public static void StartGame(string quizId, Action<JObject> callback)
        {
            APIClient.AddTopic("/quiz/startGame", (jobject) =>
            {
                callback(jobject);
                APIClient.RemoveTopic("/quiz/startGame");
            });
            APIClient.SendData("/quiz/startGame", quizId);
        }
        public static void StopGame(string quizId, Action<JObject> callback)
        {
            APIClient.AddTopic("/quiz/stopGame", (jobject) =>
            {
                callback(jobject);
                APIClient.RemoveTopic("/quiz/stopGame");
            });
            APIClient.SendData("/quiz/stopGame", quizId);
        }
        public static void UpdateBlock(string quizId, bool isBlocked, Action<JObject> callback)
        {
            APIClient.AddTopic("/quiz/updateBlock", (jobject) =>
            {
                callback(jobject);
                APIClient.RemoveTopic("/quiz/updateBlock");
            });
            JObject jobject = new JObject();
            jobject["quizId"] = quizId;
            jobject["isBlocked"]=isBlocked;
            APIClient.SendData("/quiz/updateBlock",JsonConvert.SerializeObject(jobject));
        }
        public static void GetQuizReport(string quizId,Action<JObject> callback)
        {
            APIClient.AddTopic("/quiz/getQuizReport", jobject =>
            {
                callback(jobject);
                APIClient.RemoveTopic("/quiz/getQuizReport");
            });
            APIClient.SendData("/quiz/getQuizReport", quizId);
        }
    }
}
