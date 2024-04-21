using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using QuizApp_backend.Exceptions;
using QuizApp_backend.Models;
using QuizApp_backend.Util;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Numerics;
using System.Text;

namespace QuizApp_backend.Services
{
    public class SocketService
    {
        public Dictionary<string, QuizSession> quizSessions = new Dictionary<string, QuizSession>();
        public Dictionary<string,string> pinCodes = new Dictionary<string,string>();
        private Random random = new Random();
        private int maxPinCode = 10000;
        public string GetNewPinCode()
        {
            if (quizSessions.Count>= (maxPinCode/100))
                throw new RequestException("Unable to allocate new pin code!");
            while (true)
            {
                string pinCode=random.Next(0,maxPinCode).ToString();
                if (!pinCodes.ContainsKey(pinCode))
                    return pinCode;                   
            }
        }
        public string AddQuizSession(string quizId, TcpClient host)
        {
            if (quizSessions.ContainsKey(quizId))
            {
                quizSessions[quizId].Host = host;
                return quizSessions[quizId].PinCode;
            }
            else
            {
                var newPinCode=GetNewPinCode();
                QuizSession quizSession = new QuizSession()
                {
                    Host = host,
                    PinCode = newPinCode
                };
                pinCodes.Add(newPinCode,quizId);
                quizSessions.Add(quizId, quizSession);
                return newPinCode;
            }
        }
        public void RemoveQuizSession(string quizId)
        {
            if (quizSessions.ContainsKey(quizId))
            {
                pinCodes.Remove(quizSessions[quizId].PinCode);
                quizSessions.Remove(quizId);
            }
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
                    // Console.WriteLine("Send Data to host:" + response);
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
                //Console.WriteLine("Send Data to players:" + response);
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
                    //Console.WriteLine("Send Data to player"+partId+":"+ response);
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
