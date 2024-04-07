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

namespace QuizApp_frontend.FormNguoichoi
{
    public partial class formHangCho : Form
    {
        public formHangCho()
        {
            InitializeComponent();
        }
        public formHangCho(string t, string s)
        {
            InitializeComponent();
            textBox1.Text = s;
            textBox2.Text = t;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            APIConfig.AddTopic("/Participant/addParticipant", (jobject) =>
            {

                string status = (string)jobject["status"];
                string quiz = (string)jobject["quiz"];
                if (status == "success")
                {
                    Quiz quizz = JsonConvert.DeserializeObject<Quiz>(quiz);
                    if (quizz.Status == "play")
                        button1.BeginInvoke(() => button1.Text = "play");
                }
            });
            if (button1.Text == "play") {
                FormAnwser form = new FormAnwser(textBox1.Text);
                form.ShowDialog();
            }
        }
    }
}
