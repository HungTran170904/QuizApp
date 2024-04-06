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
        public string AddParticipant(Participant participant, TcpClient client)
        {
            Quiz quiz = _quizRepo.FindById(participant.QuizId);
            if(quiz==null)
                throw new RequestException("QuizId "+participant.QuizId+" does not exists");
            if (quiz.IsBlocked)
                throw new RequestException("The quiz has been blocked");
            var savedParticipant=_participantRepo.AddParticipant(participant);
            string participantJson = JsonConvert.SerializeObject(savedParticipant);
            Task.Run(() =>
            {
                _socketService.SendDataToHost(participant.QuizId,"/partcipant/addParticipant",participantJson);
                _socketService.AddPlayer(participant.QuizId, savedParticipant.Id,client);
            });
            JObject jobject=new JObject();
            jobject["partipant"] = participantJson;
            jobject["quiz"]= JsonConvert.SerializeObject(_quizRepo.FindById(participant.QuizId));
            return JsonConvert.SerializeObject(jobject);
        }
    }
}
