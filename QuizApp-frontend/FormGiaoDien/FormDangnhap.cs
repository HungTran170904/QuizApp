using QuizApp_frontend.API;
using QuizApp_frontend.Models;
using System.Linq.Expressions;
using Newtonsoft.Json;

namespace QuizApp_frontend
{
    public partial class FormDangnhap : Form
    {
        public FormDangnhap()
        {
            InitializeComponent();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            try
            {
                FormDangKi dki = new FormDangKi();
                dki.ShowDialog();
            }

            catch (Exception ex)
            {
                MessageBox.Show("invalid");
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Account account = new Account();
            formJoin f = new formJoin();
            try
            {
                AccountAPI.Login(richTextBox1.Text, richTextBox2.Text,
                (jobject) =>
                {
                    string status = (string)jobject["status"];
                    string payload = (string)jobject["payload"];
                    if (status == "success")
                    {
                        account = JsonConvert.DeserializeObject<Account>(payload);
                        textBox1.BeginInvoke(() => textBox1.Text = "success");
                    }
                    else
                    {
                        textBox1.BeginInvoke(() => textBox1.Text = "failed");
                        BeginInvoke(() => MessageBox.Show("Error " + payload));
                    }
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message);
            }
            string t = textBox1.Text;
            if (t == "success")
                f.ShowDialog();
        }
    }
}
