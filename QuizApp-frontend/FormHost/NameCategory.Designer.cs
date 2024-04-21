namespace QuizApp_frontend.FormHost
{
    partial class NameCategory
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
            label2 = new Label();
            txtname = new TextBox();
            btnnext = new Button();
            backButton = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.BackColor = Color.FromArgb(64, 64, 64);
            label1.Font = new Font("Microsoft Sans Serif", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ControlLightLight;
            label1.Location = new Point(33, 18);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(1003, 75);
            label1.TabIndex = 0;
            label1.Text = "QUIZ";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // label2
            // 
            label2.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label2.Location = new Point(446, 113);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(190, 50);
            label2.TabIndex = 1;
            label2.Text = "New Quiz";
            label2.TextAlign = ContentAlignment.TopCenter;
            // 
            // txtname
            // 
            txtname.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtname.ForeColor = SystemColors.InactiveCaption;
            txtname.Location = new Point(412, 223);
            txtname.Margin = new Padding(2, 3, 2, 3);
            txtname.Multiline = true;
            txtname.Name = "txtname";
            txtname.Size = new Size(262, 72);
            txtname.TabIndex = 4;
            txtname.Text = "Name";
            txtname.TextAlign = HorizontalAlignment.Center;
            txtname.Enter += txtname_Enter;
            txtname.Leave += txtname_Leave;
            // 
            // btnnext
            // 
            btnnext.BackColor = Color.Black;
            btnnext.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnnext.ForeColor = SystemColors.ButtonHighlight;
            btnnext.Location = new Point(469, 387);
            btnnext.Margin = new Padding(2, 3, 2, 3);
            btnnext.Name = "btnnext";
            btnnext.Size = new Size(146, 142);
            btnnext.TabIndex = 6;
            btnnext.Text = "Continue";
            btnnext.UseVisualStyleBackColor = false;
            btnnext.Click += btnnext_Click;
            // 
            // backButton
            // 
            backButton.AutoSize = true;
            backButton.BackColor = Color.Gray;
            backButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            backButton.ForeColor = Color.White;
            backButton.Location = new Point(33, 113);
            backButton.Name = "backButton";
            backButton.Size = new Size(126, 38);
            backButton.TabIndex = 8;
            backButton.Text = "<< Back";
            backButton.UseVisualStyleBackColor = false;
            backButton.Click += backButton_Click;
            // 
            // NameCategory
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Tomato;
            ClientSize = new Size(1059, 613);
            Controls.Add(backButton);
            Controls.Add(btnnext);
            Controls.Add(txtname);
            Controls.Add(label2);
            Controls.Add(label1);
            Margin = new Padding(2, 3, 2, 3);
            Name = "NameCategory";
            Text = "NameCategory";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtname;
        private System.Windows.Forms.Button btnnext;
        private Button backButton;
    }
}