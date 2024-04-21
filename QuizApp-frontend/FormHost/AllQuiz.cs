using Newtonsoft.Json;
using QuizApp_frontend.API;
using QuizApp_frontend.Models;

namespace QuizApp_frontend.FormHost
{
    public partial class AllQuiz : Form
    {
        private List<Quiz> quizzes;
        private Action<Form, bool> switchChildForm;
        public AllQuiz(Action<Form, bool> switchChildForm)
        {
            InitializeComponent();
            this.switchChildForm = switchChildForm;
            if (MainForm.account != null)
                QuizAPI.GetQuizzes(MainForm.account.Id, jobject =>
                {
                    string status = (string)jobject["status"];
                    string payload = (string)jobject["payload"];
                    if (status.Equals("success"))
                    {
                        quizzes = JsonConvert.DeserializeObject<List<Quiz>>(payload);
                        BeginInvoke(() => addButtonFromQuizzes());
                    }
                    else BeginInvoke(() => MessageBox.Show("Error:" + payload));
                });
        }
        public void AddQuiz(Quiz quiz)
        {
            quizzes.Add(quiz);
            Button btn = new Button();
            btn.Name = quiz.Id;
            btn.Text = quiz.Title;
            btn.Click += btn_onClick;

            btn.BackColor = Color.Black;
            btn.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btn.ForeColor = Color.White;
            btn.Size = new Size(140, 140);
            btn.UseVisualStyleBackColor = false;

            flowLayoutPanel.Controls.Add(btn);
        }
        private void addButtonFromQuizzes()
        {
            if (quizzes != null)
                foreach (var quiz in quizzes)
                {
                    Button btn = new Button();
                    btn.Name = quiz.Id;
                    btn.Text = quiz.Title;
                    btn.Click += btn_onClick;

                    btn.BackColor = Color.Black;
                    btn.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                    btn.ForeColor = Color.White;
                    btn.Size = new Size(140, 140);
                    btn.UseVisualStyleBackColor = false;

                    flowLayoutPanel.Controls.Add(btn);
                }
        }
        private void btn_onClick(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            Quiz quiz = quizzes.Find(q => q.Id.Equals(btn.Name));
            if (quiz != null)
            {
                QuizReview quizReview = new QuizReview(quiz, this, switchChildForm);
                switchChildForm(quizReview, true);
            }
            else MessageBox.Show("Sorry!Cann't open this quiz");
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            NameCategory nameCategory = new NameCategory(this, switchChildForm);
            switchChildForm(nameCategory, true);
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            FormDangnhap formDangNhap = new FormDangnhap(switchChildForm);
            switchChildForm(formDangNhap, false);
        }
    }
}
