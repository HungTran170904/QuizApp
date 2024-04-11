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
        public Participant part;
        public formHangCho(Participant part,string t)
        {
            InitializeComponent();
            textBox1.Text = t;
            textBox2.Text=part.Name;
            APIConfig.AddTopic("/quiz/startGameForPlayers", (jobect) =>
            {
                string status = (string)jobect["status"];
                string payload = (string)jobect["payload"];
                if (status.Equals("success"))
                {
                    List<Question> ans =JsonConvert.DeserializeObject<List<Question>>(payload);
                    BeginInvoke(() =>
                    {
                        FormAnwser f = new FormAnwser(ans,part);
                        f.ShowDialog();
                    });
                }
            });
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
       
        }
    }
}
