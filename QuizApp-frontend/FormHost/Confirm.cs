using Microsoft.VisualBasic.ApplicationServices;
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

namespace QuizApp_frontend.FormHost
{
    public partial class Confirm : Form
    {
        private Action<Form> switchChildForm;
        private Quiz quiz;
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
        public Confirm(Quiz quiz, Action<Form> switchChildForm)
        {
            InitializeComponent();
            this.quiz = quiz;

            for (int i = 0; i < quiz.Questions.Count; i++)
            {
                var question = quiz.Questions[i];
                rtblist.AppendText($"Question {i + 1}:{question.QuestionText}  Answer: {question.CorrectAnswer}\r\n");


            }
            txtname.Text = quiz.Title;
            this.switchChildForm = switchChildForm;
        }
        string _userName;
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form form1 = new Form1(quiz,switchChildForm);
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

        //private void btnnext_Click(object sender, EventArgs e)
        //{
        //    _userName = quiz.Title;
        //    QuizAPI.AddQuiz(quiz, (jobject) =>
        //    {
        //        string status = (string)jobject["status"];
        //        if (status.Equals("success"))
        //        {
        //            AllQuiz form4 = new AllQuiz(quiz, switchChildForm);
        //            BeginInvoke(() => switchChildForm(form4));
        //        }
        //        else BeginInvoke(() => MessageBox.Show("Error:" + jobject["payload"].ToString()));
        //    });
         
         //   AllQuiz form4 = new AllQuiz(quiz,switchChildForm);

          //  form4.Show();
        }
    }
}
