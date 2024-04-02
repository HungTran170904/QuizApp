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
namespace QuizApp_frontend.FormNguoichoi
{
    public partial class FormAnwser : Form
    {
        public FormAnwser(string t)
        {

            InitializeComponent();
            this.Tag = t;

        }

        private void FormAnwser_Load(object sender, EventArgs e)
        {
            Participant participant = new Participant();
            participant.Id = Tag.ToString();
            QuestionAPI.GetQuestionsForPlay(participant.Id,
                (jobject) =>
                {
                    string status = (string)jobject["status"];
                    string payload = (string)jobject["payload"];
                    if (status == "success")
                    {
                        List<Question> questions = JsonConvert.DeserializeObject<List<Question>>(payload);
                        BeginInvoke(() => MessageBox.Show("connected"));
                    }
                    else
                        MessageBox.Show("Error");
                });
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
           
        }
    }
}
