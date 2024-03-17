namespace QuizApp_frontend
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            emailTextbox = new TextBox();
            passwordTextbox = new TextBox();
            label2 = new Label();
            button1 = new Button();
            resultTextbox = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(64, 55);
            label1.Name = "label1";
            label1.Size = new Size(46, 20);
            label1.TabIndex = 0;
            label1.Text = "Email";
            // 
            // emailTextbox
            // 
            emailTextbox.Location = new Point(155, 55);
            emailTextbox.Name = "emailTextbox";
            emailTextbox.Size = new Size(203, 27);
            emailTextbox.TabIndex = 1;
            // 
            // passwordTextbox
            // 
            passwordTextbox.Location = new Point(155, 113);
            passwordTextbox.Name = "passwordTextbox";
            passwordTextbox.Size = new Size(203, 27);
            passwordTextbox.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(64, 113);
            label2.Name = "label2";
            label2.Size = new Size(70, 20);
            label2.TabIndex = 2;
            label2.Text = "Password";
            // 
            // button1
            // 
            button1.Location = new Point(64, 176);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 4;
            button1.Text = "Submit";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // resultTextbox
            // 
            resultTextbox.Location = new Point(198, 178);
            resultTextbox.Multiline = true;
            resultTextbox.Name = "resultTextbox";
            resultTextbox.Size = new Size(398, 129);
            resultTextbox.TabIndex = 5;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(887, 491);
            Controls.Add(resultTextbox);
            Controls.Add(button1);
            Controls.Add(passwordTextbox);
            Controls.Add(label2);
            Controls.Add(emailTextbox);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox emailTextbox;
        private TextBox passwordTextbox;
        private Label label2;
        private Button button1;
        private TextBox resultTextbox;
    }
}
