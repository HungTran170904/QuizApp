using Newtonsoft.Json;
using QuizApp_frontend.API;
using QuizApp_frontend.FormNguoichoi;
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

namespace QuizApp_frontend
{
    public partial class formJoin : Form
    {
        public formJoin()
        {
            InitializeComponent();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            
            Participant part=new Participant();
            part.Name = nameTb.Text;
            part.QuizId=pinCodeTb.Text;
            part.AttendedAt=DateTime.Now;
            ParticipantAPI.AddParticipant(part, (jobject) =>
            {
                string status = (string)jobject["status"];
                string payload = (string)jobject["payload"];
                if (status.Equals("success"))
                {
                    Participant part=JsonConvert.DeserializeObject<Participant>(payload);
                    textBox1.BeginInvoke(()=>textBox1.Text = status);

                }
                else BeginInvoke(() => MessageBox.Show("Error:" + payload));
            });
            if (textBox1.Text.Equals("success"))
            {
                FormNguoichoi.formHangCho f1 = new FormNguoichoi.formHangCho(nameTb.Text, pinCodeTb.Text);
                f1.ShowDialog();
            }
        }
    }
}
