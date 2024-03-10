using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using QuizApp_backend.Util;
using System.Net.Sockets;
using System.Text;

namespace QuizApp_backend.Services
{
    public class SocketService
    {
        public Dictionary<string, QuizSession> quizSessions;

        public void AddQuizSession(string quizId, TcpClient host)
        {
            QuizSession quizSession=new QuizSession();
            quizSession.Host = host;
            quizSessions.Add(quizId, quizSession);
        }
        public void RemoveQuizSession(string quizId)
        {
            quizSessions.Remove(quizId);
        }
        public void AddPlayer(string quizId,TcpClient player)
        {
            var quizSession = quizSessions[quizId];
            if (quizSession != null) quizSession.Players.Add(player);
        }
        public async Task SendDataToHost(string quizId,string topic, string payload)
        {
            try
            {
                var quizSession = quizSessions[quizId];
                if (quizSession == null) throw new Exception("Session QuizId does not exists");
                var host = quizSession.Host;
                var jobject=new JObject();
                jobject["topic"]=topic;
                jobject["status"] = "success";
                jobject["payload"] = payload;
                if (host.Connected)
                {
                    NetworkStream stream = host.GetStream();
                    byte[] resBytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(jobject));
                    await stream.WriteAsync(resBytes, 0, resBytes.Length);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public async Task SendDataToPlayers(string quizId, string topic, string payload)
        {
            try
            {
                var quizSession = quizSessions[quizId];
                if (quizSession == null) throw new Exception("Session QuizId does not exists");
                var jobject = new JObject();
                jobject["topic"] = topic;
                jobject["status"] = "success";
                jobject["payload"] = payload;
                string response=JsonConvert.SerializeObject(jobject);
                foreach (var player in quizSession.Players)
                {
                    if (player.Connected)
                    {
                        NetworkStream stream = player.GetStream();
                        byte[] resBytes = Encoding.UTF8.GetBytes(response);
                        await stream.WriteAsync(resBytes, 0, resBytes.Length);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
