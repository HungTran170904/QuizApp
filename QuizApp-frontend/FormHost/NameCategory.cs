using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuizApp_frontend.FormHost
{
    public partial class NameCategory : Form
    {
        private AllQuiz allQuiz;
        private Action<Form,bool> switchChildForm;
        public NameCategory(AllQuiz allQuiz, Action<Form, bool> switchChildForm)
        {
            InitializeComponent();
            this.allQuiz = allQuiz;
            this.switchChildForm = switchChildForm;
        }

        private void txtname_Enter(object sender, EventArgs e)
        {
            if (txtname.Text == "Name")
            {
                txtname.Text = "";
            }
            txtname.ForeColor = Color.Black;
        }

        private void txtname_Leave(object sender, EventArgs e)
        {
            if (txtname.Text == "")
            {
                txtname.Text = "Name";
                txtname.ForeColor = Color.Silver;
            }
        }

        private void btnnext_Click(object sender, EventArgs e)
        {
            if (txtname.Text.Trim().Length == 0)
            {
                MessageBox.Show("Please fill in the quiz name");
                return;
            }
            AddQuestions addQuestions = new AddQuestions(txtname.Text,allQuiz,switchChildForm);
            switchChildForm(addQuestions, false);

        }
    }
}
