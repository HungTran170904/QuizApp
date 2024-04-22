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
using Newtonsoft.Json;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Newtonsoft.Json.Linq;

namespace QuizApp_frontend.FormNguoichoi
{
    public partial class FormAnwser : Form
    {
        private Action<Form, bool> switchChildForm;
        private List<Question> questions;
        private Participant part;
        private int i = 0;
        public FormAnwser(List<Question> questions, Participant participant, Action<Form, bool> switchChildForm)
        {
            InitializeComponent();
            this.switchChildForm = switchChildForm;
            this.questions = questions;
            this.part = participant;
            if (questions.Count > 0)
            {
                showQuestion(i);
            }
            APIConfig.AddTopic("/quiz/stopGameForPlayers", (jobject) =>
            {
                string status = (string)jobject["status"];
                string payload = (string)jobject["payload"];
                BeginInvoke(() =>
                {
                    if (status.Equals("success"))
                    {
                        JObject payloadObj = JsonConvert.DeserializeObject<JObject>(payload);
                        formPodidum podium=new formPodidum(switchChildForm,payloadObj);
                        switchChildForm(podium, false);
                    }
                    else MessageBox.Show("khong nhan dc ket qua");
                });
            });
        }
        private void showQuestion(int i)
        {
            richTextBox5.Text = questions[i].QuestionText;
            richTextBox1.Text = questions[i].Options[0];
            richTextBox2.Text = questions[i].Options[1];
            richTextBox3.Text = questions[i].Options[2];
            richTextBox4.Text = questions[i].Options[3];
            RichTextBox answer1 = (richTextBox1);
            RichTextBox answer2 = (richTextBox2);
            RichTextBox answer3 = (richTextBox3);
            RichTextBox answer4 = (richTextBox4);
            answer1.Click += Answer_Click;
            answer2.Click += Answer_Click;
            answer3.Click += Answer_Click;
            answer4.Click += Answer_Click;
            button1.Text = questions[i].TimeOut.ToString();
            timer1.Start();
        }

        private void Answer_Click(object sender, EventArgs e)
        {
            if (questions[i].CorrectAnswer != null) return;
            string target = ((RichTextBox)sender).Text;
            questions[i].CorrectAnswer = target;
            Result rs = new Result();
            rs.ParticipantId = part.Id;
            rs.QuestionId = questions[i].Id;
            rs.ChoosedOption = target;
            QuestionAPI.answerQuestion(rs, (jobject) =>
            {
                string status = (string)jobject["status"];
                string payload = (string)jobject["payload"];
                if (status == "success")
                {
                    bool IsCorrect = bool.Parse(payload);
                    if (IsCorrect)
                        BeginInvoke(() => {
                            timer1.Stop();
                            DialogResult rss = MessageBox.Show("ban da tra loi dung");
                            if (rss == DialogResult.OK)
                            {
                                i++;
                                if (i < questions.Count)
                                    showQuestion(i);
                                else if (i == questions.Count)
                                {
                                    showPoidum();
                                }
                            }
                        });
                    else
                        BeginInvoke(() =>
                        {
                            timer1.Stop();
                            DialogResult rss = MessageBox.Show("ban da tra loi sai");
                            if (rss == DialogResult.OK)
                            {
                                i++;
                                if (i < questions.Count)
                                    showQuestion(i);
                                else if (i == questions.Count)
                                {
                                    showPoidum();
                                }
                            }
                        });

                }
                else BeginInvoke(() => MessageBox.Show("error" + payload));
            }
        );
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int timeOut = int.Parse(button1.Text) - 1;
            if (timeOut == 0 && i != questions.Count)
            {
                timer1.Stop();
                DialogResult rs = MessageBox.Show("Time out");
                if (rs == DialogResult.OK)
                {
                    i++;
                    if (i < questions.Count)
                        showQuestion(i);
                }
            }
            else button1.Text = timeOut.ToString();
        }
        private void showPoidum()
        {
            formPodidum f3 = new formPodidum(switchChildForm,null);
            switchChildForm(f3, false);
        }
    }
}
