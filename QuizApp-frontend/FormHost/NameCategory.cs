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

namespace QuizApp_frontend.FormHost
{
    public partial class NameCategory : Form
    {
        private Quiz quiz=new Quiz();
        Action<Form> switchChildForm;
        public NameCategory()
        {
            InitializeComponent();
        }
       public NameCategory(Quiz quiz)
        {
            InitializeComponent();
            this.quiz = quiz;
            txtname.Text = quiz.Title;
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

            quiz.Title=txtname.Text;
            

           this.Hide();
            Form form1 = new Form1(quiz,switchChildForm);
            form1.Show();
        }

        private void txtname_TextChanged(object sender, EventArgs e)
        {

        }
    }
    public class FormData
    {
        public string UserName { get; set; }
        
    }

}
