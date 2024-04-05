namespace QuizApp_frontend.FormHost
{
    partial class AllQuiz
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            flowLayoutPanel = new FlowLayoutPanel();
            addButton = new Button();
            backButton = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.BackColor = SystemColors.ActiveCaptionText;
            label1.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.HighlightText;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(1091, 84);
            label1.TabIndex = 0;
            label1.Text = "ALL QUIZZES";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // flowLayoutPanel
            // 
            flowLayoutPanel.AutoScroll = true;
            flowLayoutPanel.Location = new Point(41, 146);
            flowLayoutPanel.Name = "flowLayoutPanel";
            flowLayoutPanel.Size = new Size(1028, 432);
            flowLayoutPanel.TabIndex = 0;
            // 
            // addButton
            // 
            addButton.AutoSize = true;
            addButton.BackColor = Color.GreenYellow;
            addButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            addButton.ForeColor = Color.Black;
            addButton.Location = new Point(943, 96);
            addButton.Name = "addButton";
            addButton.Size = new Size(126, 38);
            addButton.TabIndex = 6;
            addButton.Text = "Add Quiz";
            addButton.UseVisualStyleBackColor = false;
            addButton.Click += addButton_Click;
            // 
            // backButton
            // 
            backButton.AutoSize = true;
            backButton.BackColor = Color.Navy;
            backButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            backButton.ForeColor = Color.White;
            backButton.Location = new Point(41, 96);
            backButton.Name = "backButton";
            backButton.Size = new Size(126, 38);
            backButton.TabIndex = 7;
            backButton.Text = "<< Back";
            backButton.UseVisualStyleBackColor = false;
            // 
            // AllQuiz
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLight;
            ClientSize = new Size(1137, 602);
            Controls.Add(backButton);
            Controls.Add(addButton);
            Controls.Add(flowLayoutPanel);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "AllQuiz";
            Text = "AllQuiz";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private FlowLayoutPanel flowLayoutPanel;
        private Button addButton;
        private Button backButton;
    }
}