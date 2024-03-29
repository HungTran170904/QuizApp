﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using QuizApp_backend.Controllers;
using QuizApp_backend.Exceptions;
using System.Net;
using System.Net.Sockets;
using System.Text;
namespace QuizApp_backend
{
    public class Server
    {
        private readonly IPAddress ipaddress;
        private readonly int port;

        private readonly AccountController _accountController;
        private readonly QuizController _quizController;
        private readonly QuestionController _questionController;
        public Server(IConfiguration configuration,
                    AccountController accountController,
                    QuizController quizController,
                    QuestionController questionController)
        {
            ipaddress = IPAddress.Parse(GetLocalIPAddress());
            port = Int32.Parse(configuration["ServerConfiguration:Port"]);
            _accountController = accountController;
            _quizController = quizController;
            _questionController = questionController;
        }

        private static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }
        public async Task Run()
        {
            TcpListener listener = new TcpListener(ipaddress, port);
            listener.Start();
            Console.WriteLine($"Server starting at {ipaddress}:{port}");
            while (true)
            {
                TcpClient client = listener.AcceptTcpClient();
                _ = HandleClientAsync(client);
            }
        }
        private async Task HandleClientAsync(TcpClient client)
        {
            try
            {
                NetworkStream stream = client.GetStream();
                byte[] buffer = new byte[2048];
                int bytesRead;
                while ((bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length)) > 0)
                {
                    string data = Encoding.UTF8.GetString(buffer);
                    Console.WriteLine("Request: "+data);
                    string response=await HandlePacket(data, client);
                    Console.WriteLine("Response "+response);
                    byte[] resBytes = Encoding.UTF8.GetBytes(response);
                    await stream.WriteAsync(resBytes, 0, resBytes.Length);
                }
                client.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                client.Close();
            }
        }
        private async Task<string> HandlePacket(string jsonString, TcpClient client)
        {
            var returnedObject=new JObject();
            var jobject = JObject.Parse(jsonString);
            string url = (string)jobject["url"];
            string accountId = (string)jobject["accountId"];
            string payload = (string)jobject["payload"];
            try
            {
                string result = "";
                if (url.StartsWith(_accountController.prefix))
                    result=_accountController.RouteRequests(url,payload);
                else if(url.StartsWith(_quizController.prefix))
                    result=_quizController.RouteRequests(url,accountId,payload, client);
                else if(url.StartsWith(_questionController.prefix))
                    result=_questionController.RouteRequests(url, payload);
                returnedObject["topic"] = url;
                returnedObject["payload"] = result;
                returnedObject["status"] = "success";
            }
            catch (RequestException rex)
            {
                returnedObject["topic"] = url;
                returnedObject["payload"] = rex.Message;
                returnedObject["status"] = "error";
                Console.WriteLine(rex.StackTrace);
            }
            catch(Exception ex)
            {
                returnedObject["payload"] = "Unknown error";
                returnedObject["status"] = "error";
                Console.WriteLine(ex.ToString());
            }
            return JsonConvert.SerializeObject(returnedObject);
        }
    }
}
