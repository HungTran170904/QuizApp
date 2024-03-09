using System.Net.Sockets;

namespace QuizApp_backend.Util
{
    public class QuizSession
    {
        public TcpClient Host { get; set; }
        public List<TcpClient> Players { get; set; }=new List<TcpClient>();
    }
}
