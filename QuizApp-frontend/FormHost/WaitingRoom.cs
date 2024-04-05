using Newtonsoft.Json;
using QuizApp_frontend.API;
using QuizApp_frontend.Models;

namespace QuizApp_frontend.FormHost
{
    public partial class WaitingRoom : Form
    {
        private Quiz quiz;
        private Action<Form, bool> switchChildForm;
        private Form quizReview;
        private Dictionary<string, Participant> participants;
        public WaitingRoom(Quiz quiz, Form quizReview, Action<Form, bool> switchChildForm)
        {
            InitializeComponent();
            this.switchChildForm = switchChildForm;
            this.quiz = quiz;
            this.quizReview = quizReview;
            participants = new Dictionary<string, Participant>();
            APIConfig.AddTopic("/partcipant/addParticipant",
            (jobject) =>
            {
                string status = (string)jobject["status"];
                string payload = (string)jobject["payload"];
                if (status.Equals("success"))
                {
                    Participant part = JsonConvert.DeserializeObject<Participant>(payload);
                    participants.Add(part.Id, part);
                    listView.Items.Add(part.Name);
                    numberLb.Text = $"{participants.Count} players";
                }
            });
            this.switchChildForm = switchChildForm;

            headerLb.Text = $"Quiz: {quiz.Title}";
            pinCodeTb.Text = quiz.Id;
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            QuizAPI.StartGame(quiz.Id, (jobject) =>
            {
                string status = (string)jobject["status"];
                if (status.Equals("success"))
                {
                    LeaderBoard leaderBoard = new LeaderBoard(switchChildForm,participants, quiz);
                    BeginInvoke(() => switchChildForm(leaderBoard,false));
                }
            });
        }

        private void blockButton_Click(object sender, EventArgs e)
        {
            bool isBlocked = blockButton.Text.Equals("Block room");

            QuizAPI.UpdateBlock(quiz.Id, isBlocked, (jobject) =>
            {
                string status = (string)jobject["status"];
                string payload = (string)jobject["payload"];
                if (status.Equals("success"))
                    BeginInvoke(() => blockButton.Text = isBlocked ? "Unblock room" : "Block room");
                else MessageBox.Show(payload);
            });
        }

        private void end_Click(object sender, EventArgs e)
        {
            switchChildForm(this.quizReview,false);
        }
    }
}
