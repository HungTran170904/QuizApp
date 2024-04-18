using QuizApp_frontend.API;
using QuizApp_frontend.Models;
using System.Linq.Expressions;
using Newtonsoft.Json;
using QuizApp_frontend.FormHost;

namespace QuizApp_frontend
{
    public partial class FormDangnhap : Form
    {
        private Action<Form, bool> switchChildForm;
        public FormDangnhap()
        {
            InitializeComponent();
        }
        public FormDangnhap(Action<Form, bool> switchChildForm)
        {
            InitializeComponent();
            this.switchChildForm = switchChildForm;
        }
        private void pictureBox6_Click(object sender, EventArgs e)
        {
            try
            {
                FormDangKi f = new FormDangKi(switchChildForm);
                switchChildForm(f, true);
            }

            catch (Exception ex)
            {
                MessageBox.Show("invalid");
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Account account = new Account();
            try
            {
                AccountAPI.Login(richTextBox1.Text, richTextBox2.Tag.ToString(),
                (jobject) =>
                {
                    string status = (string)jobject["status"];
                    string payload = (string)jobject["payload"];
                    if (status == "success")
                    {
                        MainForm.account = JsonConvert.DeserializeObject<Account>(payload);
                        AllQuiz allQuiz = new AllQuiz(switchChildForm);
                        BeginInvoke(() => switchChildForm(allQuiz, false));
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
        }


        private void richTextBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar))
            {
                richTextBox2.Tag = e.KeyChar;
                richTextBox2.AppendText("*");
                e.Handled = true;
            }
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

            formJoin f = new formJoin(switchChildForm);
            switchChildForm(f, false);
        }
    }
}
