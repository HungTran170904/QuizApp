using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using QuizApp_backend.Controllers;
using QuizApp_backend.Exceptions;
using QuizApp_backend.Util;
using System.Data;
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
        private readonly ParticipantController _partController;
        public Server(IConfiguration configuration,
                    AccountController accountController,
                    QuizController quizController,
                    QuestionController questionController,
                    ParticipantController partController)
        {
            ipaddress = IPAddress.Parse(configuration["ServerConfiguration:IpAddress"]);
            port = Int32.Parse(configuration["ServerConfiguration:Port"]);
            _accountController = accountController;
            _quizController = quizController;
            _questionController = questionController;
            _partController = partController;
        }

        public void Run()
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
                byte[] buffer = new byte[1024];
                string restData = ""; // the rest of data that is not fully streamed
                int bytesRead;
                while ((bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length)) > 0)
                {
                    string receivedChunk = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    string[] receivedData = receivedChunk.Split(Constraints.delimiter);
                    if (receivedData.Length > 0)
                    {
                        if (restData.Length > 0)
                        {
                            receivedData[0] = restData + receivedData[0];
                            restData = "";
                        }

                        // check if the last packet of receivedChunk is not fully streamed
                        if (!receivedChunk.EndsWith(Constraints.delimiter))
                            restData = receivedData[receivedData.Length - 1];

                        for (int i = 0; i < receivedData.Length - 1; i++)
                        {
                            string data = receivedData[i];
                            Console.WriteLine("Request: " + data);
                            string response = await HandlePacket(data, client);
                            Console.WriteLine("Response " + response);
                            byte[] resBytes = Encoding.UTF8.GetBytes(response + Constraints.delimiter);
                            await stream.WriteAsync(resBytes, 0, resBytes.Length);
                        }
                    }
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
            var returnedObject = new JObject();
            var jobject = JObject.Parse(jsonString);
            string url = (string)jobject["url"];
            returnedObject["topic"] = url;
            string accountId = (string)jobject["accountId"];
            string payload = (string)jobject["payload"];
            try
            {
                string result = "";
                if (url.StartsWith(_accountController.prefix))
                    result = _accountController.RouteRequests(url, payload);
                else if (url.StartsWith(_quizController.prefix))
                    result = _quizController.RouteRequests(url, accountId, payload, client);
                else if (url.StartsWith(_questionController.prefix))
                    result = _questionController.RouteRequests(url, payload);
                else if (url.StartsWith(_partController.prefix))
                    result = _partController.RouteRequests(url, payload, client);
                else throw new RequestException("The url " + url + " does not exists");
                returnedObject["payload"] = result;
                returnedObject["status"] = "success";
            }
            catch (RequestException rex)
            {
                returnedObject["payload"] = rex.Message;
                returnedObject["status"] = "error";
                Console.WriteLine(rex.StackTrace);
            }
            catch (Exception ex)
            {
                returnedObject["payload"] = "Unknown error";
                returnedObject["status"] = "error";
                Console.WriteLine(ex.ToString());
            }
            return JsonConvert.SerializeObject(returnedObject);
        }
    }
}
