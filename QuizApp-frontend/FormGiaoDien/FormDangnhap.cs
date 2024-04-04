using QuizApp_frontend.API;
using QuizApp_frontend.Models;
using System.Linq.Expressions;
using Newtonsoft.Json;
namespace QuizApp_frontend
{
    public partial class FormDangnhap : Form
    {
        public static Account account = null;
        public FormDangnhap()
        {
            try
            {
                InitializeComponent();
            }
            catch
            {
                MessageBox.Show("error");
            }

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            FormDangKi form = new FormDangKi();
            form.ShowDialog();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            formJoin f=new formJoin();
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
            if(t=="success")
                f.ShowDialog();
        }
    }
}
