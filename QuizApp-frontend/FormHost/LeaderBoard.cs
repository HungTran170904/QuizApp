﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using QuizApp_frontend.API;
using QuizApp_frontend.Models;

namespace QuizApp_frontend.FormHost
{
    public partial class LeaderBoard : Form
    {
        private Dictionary<string, Participant> participants;
        private Quiz quiz;
        private Action<Form, bool> switchChildForm;
        private QuizReview quizReview;
        public LeaderBoard(QuizReview quizReview, Action<Form, bool> switchChildForm, Dictionary<string, Participant> participants, Quiz quiz)
        {
            InitializeComponent();
            this.quizReview = quizReview;
            this.participants = participants;
            this.quiz = quiz;
            this.switchChildForm = switchChildForm;
            foreach (var pair in participants)
            {
                flowLayoutPanel.Controls.Add(createNewLabel(pair.Value));
            }
            APIClient.AddTopic("/question/updateLeaderboard", (jobject) =>
            {
                string status = (string)jobject["status"];
                string payload = (string)jobject["payload"];
                if (status.Equals("success"))
                {
                    JObject obj = JsonConvert.DeserializeObject<JObject>(payload);
                    string partId = (string)obj["participantId"];
                    int newScore = (int)obj["totalScore"];
                    if (participants.ContainsKey(partId))
                    {
                        var part = participants[partId];
                        part.TotalScore = newScore;
                        BeginInvoke(() => changeLabelInOrder(part));
                    }
                }
            });
        }
        private Label createNewLabel(Participant part)
        {
            Label label = new Label();
            label.Name = part.Id;
            label.Text = $"{part.Name}: {part.TotalScore}";

            label.BackColor = SystemColors.Window;
            label.BorderStyle = BorderStyle.FixedSingle;
            label.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label.Location = new Point(3, 43);
            label.Size = new Size(445, 43);
            label.TabIndex = 1;
            label.TextAlign = ContentAlignment.MiddleCenter;

            return label;
        }
        private void changeLabelInOrder(Participant part)
        {
            int currPosition = -1;
            int newPosition = -1;
            for (int i = flowLayoutPanel.Controls.Count - 1; i >= 0; i--)
            {
                var label = flowLayoutPanel.Controls[i];
                if (currPosition == -1 && part.Id.Equals(label.Name))
                    currPosition = i;
                if (newPosition == -1 && participants[label.Name].TotalScore >= part.TotalScore)
                    newPosition = i;
            }
            if (newPosition > -1 && currPosition > -1)
            {
                var label = flowLayoutPanel.Controls[currPosition];
                if (newPosition != currPosition)
                    flowLayoutPanel.Controls.SetChildIndex(label, newPosition);
                label.Text = $"{part.Name}: {part.TotalScore}";
            }
        }
        private void endButton_Click(object sender, EventArgs e)
        {
            QuizAPI.StopGame(quiz.Id, (jobject) =>
            {
                string status = (string)jobject["status"];
                string payload = (string)jobject["payload"];
                if (status.Equals("success"))
                {
                    var top3 = JsonConvert.DeserializeObject<List<Participant>>(payload);
                    Podium podium = new Podium(quizReview, quiz.Title, top3, switchChildForm);
                    BeginInvoke(() => switchChildForm(podium, false));
                }
                else BeginInvoke(() => MessageBox.Show("Error" + payload));
            });
        }

        private void LeaderBoard_FormClosing(object sender, FormClosingEventArgs e)
        {
            APIClient.RemoveTopic("/question/updateLeaderboard");
        }
    }
}
