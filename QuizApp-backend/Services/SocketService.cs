using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using QuizApp_backend.Util;
using System.IO;
using System.Net.Sockets;
using System.Numerics;
using System.Text;

namespace QuizApp_backend.Services
{
    public class SocketService
    {
        public Dictionary<string, QuizSession> quizSessions = new Dictionary<string, QuizSession>();

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
        public void AddPlayer(string quizId,string partId,TcpClient player)
        {
            var quizSession = quizSessions[quizId];
            if (quizSession != null) quizSession.Players.Add(partId, player);
        }
        private string GetResponse(string topic, string payload)
        {
            var jobject = new JObject();
            jobject["topic"] = topic;
            jobject["status"] = "success";
            jobject["payload"] = payload;
            return JsonConvert.SerializeObject(jobject);
        }
        private async Task SendData(string response,TcpClient player)
        {
            NetworkStream stream = player.GetStream();
            byte[] resBytes = Encoding.UTF8.GetBytes(response + Constraints.delimiter);
            await stream.WriteAsync(resBytes, 0, resBytes.Length);
        }
        public void SendDataToHost(string quizId,string topic, string payload)
        {
            try
            {
                var quizSession = quizSessions[quizId];
                var host = quizSession.Host;
                if (host.Connected)
                {
                    string response = GetResponse(topic, payload);
                    Console.WriteLine("Send Data to host:" + response);
                    _=SendData(response, host);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public void SendDataToPlayers(string quizId, string topic, string payload)
        {
            try
            {
                var quizSession = quizSessions[quizId];
                string response = GetResponse(topic, payload);
                Console.WriteLine("Send Data to players:" + response);
                foreach (var pair in quizSession.Players)
                {
                    TcpClient player = pair.Value;
                    if (player.Connected)
                        _=SendData(response,player);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public void SendDataToPlayer(string quizId,string partId, string topic, string payload)
        {
            try
            {
                var quizSession = quizSessions[quizId];
                TcpClient player= quizSession.Players[partId];
                if (player.Connected)
                {
                    string response = GetResponse(topic, payload);
                    Console.WriteLine("Send Data to player"+partId+":"+ response);
                    _ =SendData(response,player);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
