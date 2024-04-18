﻿using Newtonsoft.Json;
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
            Participant part = new Participant();
            part.Name = nameTb.Text;
            part.QuizId = pinCodeTb.Text;
            part.AttendedAt = DateTime.Now;
            ParticipantAPI.AddParticipant(part, (jobject) =>
            {
                string status = (string)jobject["status"];
                string payload = (string)jobject["payload"];
                JObject resObj = JsonConvert.DeserializeObject<JObject>(payload);
                if (status.Equals("success"))
                {
                    Participant partt = JsonConvert.DeserializeObject<Participant>(resObj["participant"].ToString());
                    Quiz quizz = JsonConvert.DeserializeObject<Quiz>(resObj["quiz"].ToString());
                    BeginInvoke(() =>
                {
                    if (quizz.Status.Equals("host"))
                    {
                        FormNguoichoi.formHangCho f = new FormNguoichoi.formHangCho(partt, pinCodeTb.Text, switchChildForm);
                        switchChildForm(f, false);
                    }
                    else if (quizz.Status.Equals("play"))
                    {
                        QuestionAPI.GetQuestionsForPlay(pinCodeTb.Text, (jobject) =>
                        {
                            string status = (string)jobject["status"];
                            string payload = (string)jobject["payload"];
                            if (status.Equals("success"))
                            {
                                List<Question> list = JsonConvert.DeserializeObject<List<Question>>(payload);
                                FormAnwser f2 = new FormAnwser(list, partt, switchChildForm);
                                switchChildForm(f2, false);
                            }
                        });

                    }
                });
                }
                else BeginInvoke(() => MessageBox.Show("Error:"));
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
