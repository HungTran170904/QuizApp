using Newtonsoft.Json;
using QuizApp_frontend.API;
using QuizApp_frontend.Models;

namespace QuizApp_frontend
{
    public partial class FormDangKi : Form
    {
        private Action<Form, bool> switchChildForm;
        public FormDangKi(Action<Form, bool> switchChildForm)
        {
            InitializeComponent();
            this.switchChildForm = switchChildForm;
        }

        private void FormDangKi_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            FormDangnhap f = new FormDangnhap(switchChildForm);
            Account account = new Account();
            account.Email = emailTb.Text;
            account.Password = passTb.Tag.ToString();
            account.Name = nameTb.Text;
            if (passTb.Text.Equals(confirmPassTb.Text))
            {
                AccountAPI.Register(account, (jobject) =>
                {
                    string status = (string)jobject["status"];
                    string payload = (string)jobject["payload"];
                    if (status.Equals("success"))
                    {
                        Account savedAccount = JsonConvert.DeserializeObject<Account>(payload);
                        MainForm.account = savedAccount;
                        BeginInvoke(() =>
                        {

                            DialogResult rs = MessageBox.Show("ban da dang ki thanh cong ");
                            if (rs == DialogResult.OK)
                            {   
                                switchChildForm(f, true);
                            }
                        }
                        );
                    }
                });
            }
            else
            {
                MessageBox.Show("wrong confirm password");
            }
        }
        private void passTb_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar))
            {
                passTb.Tag += e.KeyChar.ToString();
                passTb.AppendText("*");
                e.Handled = true;
            }
        }

        private void confirmPassTb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar))
            {
                confirmPassTb.AppendText("*");
                e.Handled = true;
            }

        }
    }
}
