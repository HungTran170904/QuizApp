using Newtonsoft.Json;
using QuizApp_frontend.API;
using QuizApp_frontend.Models;

namespace QuizApp_frontend
{
    public partial class FormDangKi : Form
    {
        public FormDangKi()
        {
            InitializeComponent();
        }

        private void FormDangKi_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Account account = new Account();
            account.Email=emailTb.Text;
            account.Password=passTb.Text;
            account.Name=nameTb.Text;
            AccountAPI.Register(account, (jobject) =>
            {
                string status = (string)jobject["status"];
                string payload = (string)jobject["payload"];
                if (status.Equals("success"))
                {
                    Account savedAccount=JsonConvert.DeserializeObject<Account>(payload);
                    MainForm.account = savedAccount;
                }
            });
        }
    }
}
