using Microsoft.VisualBasic.ApplicationServices;
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

namespace QuizApp_frontend.FormHost
{
    public partial class Confirm : Form
    {
        private Action<Form,bool> switchChildForm;
        private Quiz quiz;
        private Form1 form1;
        private List<Quiz> quizzes;
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
        public Confirm(List<Quiz> quizzes,Quiz quiz,Form1 form1, Action<Form,bool> switchChildForm)
        {
            InitializeComponent();
            this.quiz = quiz;
            this.quizzes = quizzes;
            this.switchChildForm = switchChildForm;

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
            switchChildForm(form1, false);
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
            QuizAPI.AddQuiz(quiz, (jobject) =>
            {
                string status = (string)jobject["status"];
                if (status.Equals("success"))
                {
                    Quiz savedQuiz = JsonConvert.DeserializeObject<Quiz>(jobject["payload"].ToString());
                    quizzes.Add(savedQuiz);
                    AllQuiz allQuiz = new AllQuiz(quizzes, switchChildForm);
                    BeginInvoke(() => switchChildForm(allQuiz,false));
                }
                else BeginInvoke(() => MessageBox.Show("Error:" + jobject["payload"].ToString()));
           });         
        }
    }
}
