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
    public partial class Confirm : Form
    {
        public Confirm()
        {
            InitializeComponent();
           
        }
        
        public Confirm(string showListContent,string user, string category)
        {
            InitializeComponent();
            rtblist.Text = showListContent;
            txtcategory.Text = category;
            txtname.Text = user;
           
        }
        string _userName;
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form form1 = new Form1();
            form1.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtname_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtcategory_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnnext_Click(object sender, EventArgs e)
        {
          
            _userName = txtname.Text;
            AllQuiz form4 = new AllQuiz();

            form4.Show();
        }
    }
}
