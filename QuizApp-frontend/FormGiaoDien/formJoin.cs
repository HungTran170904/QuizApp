using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using QuizApp_frontend.API;
using QuizApp_frontend.FormNguoichoi;
using QuizApp_frontend.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuizApp_frontend
{
    public partial class formJoin : Form
    {
        private Action<Form, bool> switchChildForm;
        public formJoin(Action<Form, bool> switchChildForm)
        {
            InitializeComponent();
            this.switchChildForm = switchChildForm;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (nameTb.Text == "" || pinCodeTb.Text == "")
            {
                MessageBox.Show("Please enter both name and pin code of the quiz");
            }
            ParticipantAPI.AddParticipant(nameTb.Text,pinCodeTb.Text, (jobject) =>
            {
                string status = (string)jobject["status"];
                string payload = (string)jobject["payload"];
                if (status.Equals("success"))
                {
                    JObject resObj = JsonConvert.DeserializeObject<JObject>(payload);
                    Participant part = JsonConvert.DeserializeObject<Participant>(resObj["participant"].ToString());
                    Quiz quizz = JsonConvert.DeserializeObject<Quiz>(resObj["quiz"].ToString());
                    BeginInvoke(() =>
                    {
                        if (quizz.Status.Equals("host"))
                        {
                            formHangCho f = new formHangCho(part, pinCodeTb.Text, switchChildForm);
                            switchChildForm(f, false);
                        }
                        else if (quizz.Status.Equals("play"))
                        {
                            QuestionAPI.GetQuestionsForPlay(quizz.Id, (jobject) =>
                            {
                                string status = (string)jobject["status"];
                                string payload = (string)jobject["payload"];
                                if (status.Equals("success"))
                                {
                                    List<Question> list = JsonConvert.DeserializeObject<List<Question>>(payload);
                                    BeginInvoke(() =>
                                    {
                                        FormAnwser f2 = new FormAnwser(list, part, switchChildForm);
                                        switchChildForm(f2, false);
                                    });
                                }
                            });
                          }
                    });
                }
                else BeginInvoke(() => MessageBox.Show(payload));
            });
        }


        private void pinCodeTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox4_DoubleClick(object sender, EventArgs e)
        {

        }


        private void pictureBox5_Click(object sender, EventArgs e)
        {
            FormDangnhap f = new FormDangnhap(switchChildForm);
            switchChildForm(f, false);
        }
    }
}
