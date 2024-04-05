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
                account=new Account();
                account.Id = "E14DF576-75E0-48CF-9E9A-1697E30C4742";
                /*Quiz quiz= new Quiz();
                quiz.Id = "125BDE14-69B6-48C5-91B7-92A7F10F8E48";
                quiz.Title = "Ko biet";*/
                curChildForm = new FormDangnhap();
                showChildForm();
            }
            catch(Exception ex) { }
        }
        private void showChildForm()
        {
            curChildForm.TopLevel = false;
            this.Controls.Add(curChildForm);
            curChildForm.FormBorderStyle = FormBorderStyle.None;
            this.Size =curChildForm.Size;
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
