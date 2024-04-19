using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using QuizApp_backend.Exceptions;
using QuizApp_backend.Models;
using QuizApp_backend.Repository;
using System.Net.Sockets;

namespace QuizApp_backend.Services
{
    public class ParticipantService
    {
        private readonly ParticipantRepo _participantRepo;
        private readonly SocketService _socketService;
        private QuizRepo _quizRepo;
        public ParticipantService(ParticipantRepo participantRepo,
                            SocketService socketService,
                            QuizRepo quizRepo) 
        {
            _participantRepo = participantRepo;
            _socketService = socketService;
            _quizRepo= quizRepo;
        }
        public string AddParticipant(string partName,string pinCode, TcpClient client)
        {
            if (!_socketService.pinCodes.ContainsKey(pinCode))
                throw new RequestException("The pin code you enter does not exists");
            Participant participant = new Participant()
            {
                Name = partName,
                QuizId = _socketService.pinCodes[pinCode],
                AttendedAt= DateTime.Now,
                FinishedAt = DateTime.Now
            };
            var savedParticipant=_participantRepo.AddParticipant(participant);
            string participantJson = JsonConvert.SerializeObject(savedParticipant);
            Task.Run(() =>
            {
                _socketService.SendDataToHost(savedParticipant.QuizId,"/partcipant/addParticipant",participantJson);
                _socketService.AddPlayer(savedParticipant.QuizId, savedParticipant.Id,client);
            });
            JObject jobject=new JObject();
            jobject["participant"] = participantJson;
            jobject["quiz"]= JsonConvert.SerializeObject(_quizRepo.FindById(participant.QuizId));
            return JsonConvert.SerializeObject(jobject);
        }
    }
}
