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

namespace QuizApp_frontend.FormNguoichoi
{
    public partial class FormAnwser : Form
    {
        private List<Question> questions;
        private Participant part;
        private int i;
        public FormAnwser(List<Question> questions, Participant participant)
        {
            InitializeComponent();
            this.questions = questions;
            this.part = participant;
            if(questions.Count > 0 )
            {
                i = 0;
                timer1.Stop();
                showQuestion();
            }
        }
        private void showQuestion()
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
        private void FormAnwser_Load(object sender, EventArgs e)
        {

        }

        private void Answer_Click(object sender, EventArgs e)
        {
            string target = ((RichTextBox)sender).Text;
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
                        BeginInvoke(() => MessageBox.Show("bạn trả lời đúng"));
                    else
                        BeginInvoke(() => MessageBox.Show("bạn trả lời sai"));

                }
                else BeginInvoke(() => MessageBox.Show("error" + payload));
            }
        );
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int timeOut = int.Parse(button1.Text)-1;
            if (timeOut == 0)
            {
                timer1.Stop();
                DialogResult rs= MessageBox.Show("Time out");
                if (rs == DialogResult.OK)
                {
                    i++;
                    if (i < questions.Count)
                        showQuestion();
                }
            }
            else button1.Text = timeOut.ToString();
        }
    }
}
