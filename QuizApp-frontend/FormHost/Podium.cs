﻿using QuizApp_frontend.Models;

namespace QuizApp_frontend.FormHost
{
    public partial class Podium : Form
    {
        private Action<Form, bool> switchChildForm;
        private QuizReview quizReview;
        public Podium(QuizReview quizReview,string quizTitle, List<Participant> top3, Action<Form, bool> switchChildForm)
        {
            InitializeComponent();
            this.switchChildForm = switchChildForm;
            this.quizReview = quizReview;
            headerLb.Text = quizTitle;
            if (top3.Count > 0)
            {
                goldenLb.Text = $"{top3[0].TotalScore} points\r\nRank:1st";
                goldenPlayerLb.Text = top3[0].Name;
            }
            if(top3.Count > 1) 
            {
                silverLb.Text = $"{top3[1].TotalScore} points\r\nRank:2st";
                silverPlayerLb.Text = top3[1].Name;
            }
            if (top3.Count > 2)
            {
                copperLb.Text = $"{top3[2].TotalScore} points\r\nRank:3st";
                copperPlayerLb.Text = top3[2].Name;
            }
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            switchChildForm(quizReview, false);
        }
    }
}
