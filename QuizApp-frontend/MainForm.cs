using Newtonsoft.Json;
using QuizApp_frontend.API;
using QuizApp_frontend.Models;

namespace QuizApp_frontend
{
    public partial class MainForm : Form
    {
        public static Account account = null;
        public MainForm()
        {
            try
            {
                Thread apiThread = new Thread(() => APIConfig.InitConnection());
                apiThread.Start();
                InitializeComponent();
            }
            catch
            {
                MessageBox.Show("There is error");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                AccountAPI.Login(emailTextbox.Text, passwordTextbox.Text,
                (jobject) =>
                {
                    string status = (string)jobject["status"];
                    string payload = (string)jobject["payload"];
                    if (status == "success")
                    {
                        account = JsonConvert.DeserializeObject<Account>(payload);
                        resultTextbox.BeginInvoke(() => resultTextbox.Text = "Name " + account.Name);
                    }
                    else BeginInvoke(() => MessageBox.Show("Error " + payload));
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message);
            }
        }
    }
}
