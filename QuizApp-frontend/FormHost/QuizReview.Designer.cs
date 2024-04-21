namespace QuizApp_frontend.FormHost
{
    partial class QuizReview
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
            headerLb = new Label();
            richTb = new RichTextBox();
            hostButton = new Button();
            backButton = new Button();
            downloadButton = new Button();
            SuspendLayout();
            // 
            // headerLb
            // 
            headerLb.BackColor = Color.Black;
            headerLb.BorderStyle = BorderStyle.FixedSingle;
            headerLb.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            headerLb.ForeColor = Color.White;
            headerLb.Location = new Point(0, -2);
            headerLb.Name = "headerLb";
            headerLb.Size = new Size(975, 63);
            headerLb.TabIndex = 3;
            headerLb.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // richTb
            // 
            richTb.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            richTb.Location = new Point(161, 89);
            richTb.Name = "richTb";
            richTb.ReadOnly = true;
            richTb.Size = new Size(742, 488);
            richTb.TabIndex = 4;
            richTb.Text = "";
            // 
            // hostButton
            // 
            hostButton.AutoSize = true;
            hostButton.BackColor = Color.MediumSlateBlue;
            hostButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            hostButton.ForeColor = Color.White;
            hostButton.Location = new Point(12, 89);
            hostButton.Name = "hostButton";
            hostButton.Size = new Size(126, 38);
            hostButton.TabIndex = 5;
            hostButton.Text = "Host Game";
            hostButton.UseVisualStyleBackColor = false;
            hostButton.Click += hostButton_Click;
            // 
            // backButton
            // 
            backButton.AutoSize = true;
            backButton.BackColor = Color.Navy;
            backButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            backButton.ForeColor = Color.White;
            backButton.Location = new Point(12, 146);
            backButton.Name = "backButton";
            backButton.Size = new Size(126, 38);
            backButton.TabIndex = 6;
            backButton.Text = "<< Back";
            backButton.UseVisualStyleBackColor = false;
            backButton.Click += backButton_Click;
            // 
            // downloadButton
            // 
            downloadButton.BackColor = Color.MediumSeaGreen;
            downloadButton.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            downloadButton.ForeColor = Color.White;
            downloadButton.Location = new Point(12, 205);
            downloadButton.Name = "downloadButton";
            downloadButton.Size = new Size(126, 58);
            downloadButton.TabIndex = 7;
            downloadButton.Text = "Download report";
            downloadButton.UseVisualStyleBackColor = false;
            downloadButton.Click += downloadButton_Click;
            // 
            // QuizReview
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(975, 589);
            Controls.Add(downloadButton);
            Controls.Add(backButton);
            Controls.Add(hostButton);
            Controls.Add(richTb);
            Controls.Add(headerLb);
            FormBorderStyle = FormBorderStyle.None;
            Name = "QuizReview";
            Text = "QuizReview";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label headerLb;
        private RichTextBox richTb;
        private Button hostButton;
        private Button backButton;
        private Button downloadButton;
    }
}