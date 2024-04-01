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
                curChildForm = new FormDangKi();
                showChildForm();
            }
            catch(Exception ex) { }
        }
        private void showChildForm()
        {
            curChildForm.TopLevel = false;
            this.Controls.Add(curChildForm);
            curChildForm.Show();
        }
        public void switchChildForm(Form newForm)
        {
            if (curChildForm != null)
            {
                this.Controls.Remove(curChildForm);
                curChildForm.Dispose();
            }
            curChildForm= newForm;
            showChildForm();
        }
    }
}
