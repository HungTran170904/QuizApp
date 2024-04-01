using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using QuizApp_backend.Models;
using QuizApp_backend.Services;
using System.Net.Sockets;

namespace QuizApp_backend.Controllers
{
    public class ParticipantController
    {
        public string prefix = "/participant";
        private readonly ParticipantService _participantService;
        public ParticipantController(ParticipantService participantService) 
        { 
            _participantService = participantService;
        }
        public string RouteRequests(string url,string payload,TcpClient client)
        {
            url=url.Substring(prefix.Length);
            string result = "";
            if(url.Equals("/addParticipant"))
                result=AddParticipant(payload, client);
            return result;
        }
        public string AddParticipant(string payload, TcpClient client)
        {
            var participant = JsonConvert.DeserializeObject<Participant>(payload); 
            return _participantService.AddParticipant(participant, client);
        }
    }
}
