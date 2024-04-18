using Newtonsoft.Json;
using QuizApp_frontend.API;
using QuizApp_frontend.Models;

namespace QuizApp_frontend.FormHost
{
    public partial class QuizReview : Form
    {
        private Action<Form, bool> switchChildForm;
        private Quiz quiz;
        private Form allQuiz;
        public QuizReview(Quiz quiz, Form allQuiz, Action<Form, bool> switchChildForm)
        {
            InitializeComponent();
            this.quiz = quiz;
            this.switchChildForm = switchChildForm;
            this.allQuiz = allQuiz;
            if (quiz.Questions != null) showQuizDetail();
            else QuestionAPI.GetQuestions(quiz.Id, (jobject) =>
                {
                    string status = (string)jobject["status"];
                    string payload = (string)jobject["payload"];
                    if (status.Equals("success"))
                    {
                        BeginInvoke(() =>
                        {
                            quiz.Questions = JsonConvert.DeserializeObject<List<Question>>(payload);
                            showQuizDetail();
                        });
                    }
                    else BeginInvoke(() => MessageBox.Show("Error:" + payload));
                });
        }
        private void showQuizDetail()
        {
            headerLb.Text = quiz.Title;
            var questions = quiz.Questions;
            for (int i = 0; i < questions.Count; i++)
            {
                var question = questions[i];
                richTb.AppendText($"Question {i+1}:{question.QuestionText}\r\n");
                for (int j = 0; j < question.Options.Count; j++)
                {
                    char optionName = (char)('A' + j);
                    richTb.AppendText($"{optionName}.{question.Options[j]}\r\n");
                }
                richTb.AppendText($"Correct Answer: {question.CorrectAnswer}\r\n");
                richTb.AppendText("\r\n");
            }
        }
        private void hostButton_Click(object sender, EventArgs e)
        {
            QuizAPI.HostGame(quiz.Id, (jobject) =>
            {
                string status = (string)jobject["status"];
                if (status.Equals("success"))
                {
                    WaitingRoom waitingRoom = new WaitingRoom(quiz, this, switchChildForm);
                    BeginInvoke(() => switchChildForm(waitingRoom, true));
                }
                else BeginInvoke(() => MessageBox.Show("Error:" + jobject["payload"].ToString()));
            });
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            switchChildForm(this.allQuiz, false);
        }

        private void downloadButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel File|*.xlsx";
            if(sfd.ShowDialog() == DialogResult.OK)
            {
                string filePath = sfd.FileName;
                QuizAPI.GetQuizReport(quiz.Id, jobject =>
                {
                    string status = (string)jobject["status"];
                    string payload = (string)jobject["payload"];
                    if (status.Equals("success"))
                    {
                        Task.Run(() =>
                        {
                            byte[] data = Convert.FromBase64String(payload);
                            using (FileStream fs = new FileStream(filePath, FileMode.Create))
                            {
                                fs.Write(data, 0, data.Length);
                            }
                        });
                    }
                });
            }
        }
    }
}
