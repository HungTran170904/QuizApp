using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using QuizApp_frontend.API;
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
    public partial class formPodidum : Form
    {
        private Action<Form, bool> switchChildForm;
        public formPodidum(Action<Form, bool> switchChildForm, JObject data)
        {
            InitializeComponent();
            this.switchChildForm = switchChildForm;
            if(data==null)
                APIConfig.AddTopic("/quiz/stopGameForPlayers", (jobject) =>
                {
                    string status = (string)jobject["status"];
                    string payload = (string)jobject["payload"];
                    if (status.Equals("success"))
                    {
                        JObject payloadObj = JsonConvert.DeserializeObject<JObject>(payload);
                        BeginInvoke(() =>showScore(payloadObj));
                    }
                    else BeginInvoke(() => MessageBox.Show("khong nhan dc ket qua"));
                });
            else showScore(data);
        }
        private void showScore(JObject data)
        {
            int totalScore = (int)data["totalScore"];
            int rank = (int)data["rank"];
            Waiting.Visible = false;
            Rank.Visible = true;
            Point.Visible = true;
            Rank.Text = "Rank :" + rank.ToString();
            Point.Text = "Point: " + totalScore.ToString();
        }
        private void backButton_Click(object sender, EventArgs e)
        {
            formJoin fj = new formJoin(switchChildForm);
            switchChildForm(fj, false);
        }
    }
}
