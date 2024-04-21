using Newtonsoft.Json;
using QuizApp_frontend.API;
using QuizApp_frontend.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QuizApp_frontend.FormHost
{
    public partial class AddQuestions : Form
    {
        private Action<Form,bool> switchChildForm;
        private Quiz quiz;
        private AllQuiz allQuiz;
        private int dem = 1;

        public AddQuestions(string quizName, AllQuiz allQuiz, Action<Form, bool> switchChildForm)
        {
            InitializeComponent();
            this.allQuiz = allQuiz;
            this.quiz = new Quiz();
            quiz.CreatorId = MainForm.account.Id;
            quiz.Title = quizName;
            this.switchChildForm = switchChildForm;
            quizLb.Text= quizName;
        }
        public string ShowListContent
        {
            get { return rtbshowlist.Text; }
        }

        private void txtA_Enter(object sender, EventArgs e)
        {
            if (txtA.Text == "Answer A")
            {
                txtA.Text = "";
                txtA.ForeColor=Color.Black;
            }
        }
        private void txtA_Leave(object sender, EventArgs e)
        {
            if (txtA.Text == "")
            {
                txtA.Text = "Answer A";
                txtA.ForeColor = Color.Silver;
            }
        }


        private void txtB_Enter(object sender, EventArgs e)
        {
            if (txtB.Text == "Answer B")
            {
                txtB.Text = "";
                txtB.ForeColor = Color.Black;
            }
        }

        private void txtB_Leave(object sender, EventArgs e)
        {
            if (txtB.Text == "")
            {
                txtB.Text = "Answer B";
                txtB.ForeColor = Color.Silver;
            }
        }

        private void txtC_Enter(object sender, EventArgs e)
        {
            if (txtC.Text == "Answer C")
            {
                txtC.Text = "";
                txtC.ForeColor = Color.Black;
            }
        }

        private void txtC_Leave(object sender, EventArgs e)
        {
            if (txtC.Text == "")
            {
                txtC.Text = "Answer C";
                txtC.ForeColor = Color.Silver;
            }
        }

        private void txtD_Enter(object sender, EventArgs e)
        {
            if (txtD.Text == "Answer D")
            {
                txtD.Text = "";
                txtD.ForeColor = Color.Black;
            }
        }

        private void txtD_Leave(object sender, EventArgs e)
        {
            if (txtD.Text == "")
            {
                txtD.Text = "Answer D";
                txtD.ForeColor = Color.Silver;
            }
        }

        private void txtquestion_Enter(object sender, EventArgs e)
        {
            if (txtquestion.Text == "Type question here")
            {
                txtquestion.Text = "";
                txtquestion.ForeColor = Color.Black;
            }
        }

        private void txtquestion_Leave(object sender, EventArgs e)
        {
            if (txtquestion.Text == "")
            {
                txtquestion.Text = "Type question here";
                txtquestion.ForeColor = Color.Silver;
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (txttime.Text == "Enter timeout here")
            {
                txttime.Text = "";
            }
        }

        private void txttime_Leave(object sender, EventArgs e)
        {
            if (txttime.Text == "")
            {
                txttime.Text = "Enter timeout here";
            }
        }

        private void txttime_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtback_Click(object sender, EventArgs e)
        {
            NameCategory nameCategory=new NameCategory(allQuiz,switchChildForm);
            switchChildForm(nameCategory, false);
        }

        private void txtnext_Click(object sender, EventArgs e)
        {
            QuizAPI.AddQuiz(quiz, (jobject) =>
            {
                string status = (string)jobject["status"];
                if (status.Equals("success"))
                {
                    Quiz savedQuiz = JsonConvert.DeserializeObject<Quiz>(jobject["payload"].ToString());
                    allQuiz.BeginInvoke(()=>allQuiz.AddQuiz(savedQuiz));
                    BeginInvoke(() => switchChildForm(allQuiz, false));
                }
                else BeginInvoke(() => MessageBox.Show("Error:" + jobject["payload"].ToString()));
            });
        }
        private void btnadd_Click(object sender, EventArgs e)
        {
            try
            {

                // Lấy câu hỏi từ TextBox
                string questionText = txtquestion.Text;

                // Lấy đáp án từ ComboBox
                string answer = comboBox1.SelectedItem.ToString();
                Question question = new Question();
                question.QuestionText = questionText;
                if (!string.IsNullOrEmpty(questionText) && !string.IsNullOrEmpty(answer))
                {
                    if (answer == "A") question.CorrectAnswer = txtA.Text;
                    if (answer == "B") question.CorrectAnswer = txtB.Text;
                    if (answer == "C") question.CorrectAnswer = txtC.Text;
                    if (answer == "D") question.CorrectAnswer = txtD.Text;
                    question.Options = new List<string>() { txtA.Text, txtB.Text, txtC.Text, txtD.Text };
                    question.TimeOut = Int32.Parse(txttime.Text);
                    quiz.Questions.Add(question);

                    // Kiểm tra xem câu hỏi và đáp án có được nhập đầy đủ hay không

                    // Tạo chuỗi mới chứa câu hỏi và đáp án
                    string newQuestion = $"Question:{dem}\r\n{question.QuestionText} Answer: {question.CorrectAnswer}\r\n";

                    // Thêm chuỗi mới vào RichTextBox
                    rtbshowlist.AppendText(newQuestion);

                    // Xóa nội dung trong TextBox và ComboBox sau khi đã thêm vào RichTextBox
                    txtquestion.Text = "Type question here";
                    txtA.Text = "Answer A";
                    txtB.Text = "Answer B";
                    txtC.Text = "Answer C";
                    txtD.Text = "Answer D";
                    comboBox1.SelectedIndex = -1; // Reset ComboBox về trạng thái không chọn
                    dem++;
                }
            }
            catch (Exception ex)
            {
                // Hiển thị thông báo yêu cầu nhập đầy đủ thông tin
                MessageBox.Show("Please fill in all fields.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}