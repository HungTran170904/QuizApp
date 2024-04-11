using Newtonsoft.Json;
using QuizApp_frontend.API;
using QuizApp_frontend.FormHost;
using QuizApp_frontend.Models;

namespace QuizApp_frontend
{
    public partial class MainForm : Form
    {
        public static Account account = null;
        private Form curChildForm;
        public MainForm()
        {
            try
            {
                Thread apiThread = new Thread(() => APIConfig.InitConnection());
                apiThread.IsBackground = true;
                apiThread.Start();
                InitializeComponent();
                curChildForm = new formJoin();
                showChildForm();
            }
            catch(Exception ex) { }
        }
        private void showChildForm()
        {
            curChildForm.TopLevel = false;
            this.Controls.Add(curChildForm);
            curChildForm.FormBorderStyle = FormBorderStyle.None;
            this.ClientSize =curChildForm.Size;
            curChildForm.Show();
        }

        public void switchChildForm(Form newForm,bool isSaved)
        {
            if (curChildForm != null)
            {
                this.Controls.Remove(curChildForm);
                if (isSaved) curChildForm.Hide();
                else curChildForm.Dispose();
            }
            curChildForm= newForm;
            showChildForm();
        }
    }
}
