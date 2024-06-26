﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp_frontend.API
{
    public class APIClient
    {
        private static IPAddress ipaddress;
        private static TcpClient tcpClient=new TcpClient();
        private static Dictionary<string, Action<JObject>> topics=new Dictionary<string, Action<JObject>>();
        private static string delimiter = ";";
        public static void InitConnection()
        {
            ipaddress = IPAddress.Parse(GetLocalIPAddress());
            int port = 8080;
            tcpClient.Connect(ipaddress, port);
            byte[] resBuffer = new byte[1024];
            int byteReceived;
            Stream stream= tcpClient.GetStream();
            string restData = "";
            while ((byteReceived=stream.Read(resBuffer,0, resBuffer.Length))>0)
            {
                string receivedChunk=Encoding.UTF8.GetString(resBuffer,0,byteReceived);
                string[] receivedData = receivedChunk.Split(delimiter);
                if(receivedData.Length > 0)
                {
                    if (restData.Length > 0)
                    {
                        receivedData[0] = restData + receivedData[0];
                    }

                    if (!receivedData[receivedData.Length-1].EndsWith(delimiter))
                        restData = receivedData[receivedData.Length-1];

                    for(int i = 0; i < receivedData.Length-1; i++)
                    {
                        HandleData(receivedData[i]);
                    }
                }
            }
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
        public static void HandleData(string data)
        {
            JObject jobject = JsonConvert.DeserializeObject<JObject>(data);
            string topic = (string)jobject["topic"];

            if (topics.ContainsKey(topic))
            {
                topics[topic](jobject);
            }
        }

        public static void AddTopic(string topic, Action<JObject> action)
        {
            topics[topic]= action;
        }
        public static void RemoveTopic(string topic)
        {
            topics.Remove(topic);
        }

        public static void SendData(string url,string data)
        {
            JObject jobject=new JObject();
            jobject["url"] = url;
            jobject["payload"]=data;
            if(MainForm.account!=null) jobject["accountId"]= MainForm.account.Id;
            byte[] sendBytes=Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(jobject)+delimiter);
            Stream stream=tcpClient.GetStream();
            stream.WriteAsync(sendBytes);
            stream.FlushAsync();
        }
    }
}
