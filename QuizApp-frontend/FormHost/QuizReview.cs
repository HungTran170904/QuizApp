using Newtonsoft.Json;
using QuizApp_frontend.API;
using QuizApp_frontend.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuizApp_frontend.FormHost
{
    public partial class QuizReview : Form
    {
        private Action<Form> switchChildForm;
        private Quiz quiz;
        public QuizReview(Quiz quiz, Action<Form> switchChildForm)
        {
            InitializeComponent();
            this.quiz = quiz;
            this.switchChildForm = switchChildForm;
            QuestionAPI.GetQuestionsForPlay(quiz.Id, (jobject) =>
            {
            string status = (string)jobject["status"];
            string payload = (string)jobject["payload"];
            if (status.Equals("success"))
            {
                BeginInvoke(() =>{
                    headerLb.Text = quiz.Title;
                    List<Question> questions = JsonConvert.DeserializeObject<List<Question>>(payload);
                    for (int i = 0; i < questions.Count; i++)
                    {
                        var question = questions[i];
                        richTb.AppendText($"Question {i}:{question.QuestionText}\r\n");
                        for (int j = 0; j < question.Options.Count; j++)
                        {
                            char optionName = (char)('A' + j);
                            richTb.AppendText($"{optionName}.{question.Options[j]}\r\n");
                        }
                        richTb.AppendText("\r\n");
                    }
                });
                }
                else BeginInvoke(() => MessageBox.Show("Error:" + payload));
            });
        }

        private void hostButton_Click(object sender, EventArgs e)
        {
            QuizAPI.HostGame(quiz.Id, (jobject) =>
            {
                string status = (string)jobject["status"];
                if (status.Equals("success"))
                {
                    WaitingRoom waitingRoom = new WaitingRoom(quiz, switchChildForm);
                    BeginInvoke(() => switchChildForm(waitingRoom));
                }
                else BeginInvoke(() => MessageBox.Show("Error:" + jobject["payload"].ToString()));
            });
        }
    }
}
