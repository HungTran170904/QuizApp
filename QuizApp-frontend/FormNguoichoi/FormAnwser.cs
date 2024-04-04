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
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Drawing.Text;
using System.Diagnostics.CodeAnalysis;
namespace QuizApp_frontend.FormNguoichoi
{
    public partial class FormAnwser : Form
    {
        public FormAnwser(string t)
        {

            InitializeComponent();
            this.Tag = t;

        }

        public void FormAnwser_Load(object sender, EventArgs e)
        {
            Participant participant = new Participant();
            participant.Id = Tag.ToString();
            int seconds = 0;
            QuestionAPI.GetQuestionsForPlay(participant.Id,
                (jobject) =>
                {
                    string status = (string)jobject["status"];
                    string payload = (string)jobject["payload"];
                    if (status == "success")
                    {
                        List<Question> questions = JsonConvert.DeserializeObject<List<Question>>(payload);
                        textBox1.Text = questions[0].Id.ToString();
                        foreach (Question question in questions)
                        {
                            richTextBox5.BeginInvoke(() => richTextBox5.Text = question.QuestionText);
                            richTextBox1.BeginInvoke(() => richTextBox1.Text = question.Options[0]);
                            richTextBox2.BeginInvoke(() => richTextBox2.Text = question.Options[1]);
                            richTextBox3.BeginInvoke(() => richTextBox3.Text = question.Options[2]);
                            richTextBox4.BeginInvoke(() => richTextBox4.Text = question.Options[3]);
                            RichTextBox answer1 = (richTextBox1);
                            RichTextBox answer2 = (richTextBox1);
                            RichTextBox answer3 = (richTextBox1);
                            RichTextBox answer4 = (richTextBox1);
                            answer1.Click += Answer_Click;
                            answer1.Click += Answer_Click;
                            answer1.Click += Answer_Click;
                            answer1.Click += Answer_Click;
                            int i = timer1.Interval = question.TimeOut;
                            for (int j = 0; j <= timer1.Interval; j++)
                            {
                                if (answer1.Focused)
                                    break;
                                button1.Text = i.ToString();
                                i--;
                                Thread.Sleep(1000);
                                if (i == 0)
                                    timer1.Stop();
                            }
                        }
                    }
                    else
                        MessageBox.Show("Error");
                });
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int i = timer1.Interval;

        }
        private void Answer_Click(object sender, EventArgs e)
        {
            /* string target = ((RichTextBox)sender).Text;
               Result rs=new Result();
               rs.ParticipantId = Tag.ToString();
               rs.QuestionId = textBox1.Text;
               rs.ChoosedOption = target;
               QuestionAPI.Answer(rs, (jobject) =>
               {
                   string status = (string)jobject["status"];
                   string payload = (string)jobject["payload"];
                   if (status == "success")
                   {
                       Result rss = JsonConvert.DeserializeObject<Result>(payload);
                       if (rss.IsCorrect)
                           BeginInvoke(() => MessageBox.Show("bạn trả lời đúng"));
                       else
                           BeginInvoke(() => MessageBox.Show("bạn trả lời sai"));
                   }
                   else BeginInvoke(() => MessageBox.Show("error" + payload));
               }
           );
            */
            string target = ((RichTextBox)sender).Name;
            MessageBox.Show("bạn đã chọn đáp an");
        }
    }
}
