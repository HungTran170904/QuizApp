using System.Net.Sockets;

namespace QuizApp_backend.Util
{
    public class QuizSession
    {
        public string PinCode { get; set; }
        public TcpClient Host { get; set; }
        public Dictionary<string,TcpClient> Players { get; set; }=new Dictionary<string,TcpClient>();
    }
}
