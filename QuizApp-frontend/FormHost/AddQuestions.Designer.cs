namespace QuizApp_frontend.FormHost
{
    partial class AddQuestions
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
            txtA = new TextBox();
            txtB = new TextBox();
            txtC = new TextBox();
            txtD = new TextBox();
            txtquestion = new TextBox();
            txttime = new TextBox();
            comboBox1 = new ComboBox();
            btnadd = new Button();
            txtback = new Button();
            txtnext = new Button();
            label1 = new Label();
            rtbshowlist = new RichTextBox();
            quizLb = new Label();
            SuspendLayout();
            // 
            // txtA
            // 
            txtA.BackColor = SystemColors.ButtonHighlight;
            txtA.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold);
            txtA.ForeColor = Color.Silver;
            txtA.Location = new Point(34, 234);
            txtA.Margin = new Padding(2, 3, 2, 3);
            txtA.Multiline = true;
            txtA.Name = "txtA";
            txtA.Size = new Size(527, 50);
            txtA.TabIndex = 2;
            txtA.Text = "Answer A";
            txtA.Enter += txtA_Enter;
            txtA.Leave += txtA_Leave;
            // 
            // txtB
            // 
            txtB.BackColor = SystemColors.ButtonHighlight;
            txtB.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold);
            txtB.ForeColor = Color.Silver;
            txtB.Location = new Point(710, 234);
            txtB.Margin = new Padding(2, 3, 2, 3);
            txtB.Multiline = true;
            txtB.Name = "txtB";
            txtB.Size = new Size(565, 50);
            txtB.TabIndex = 3;
            txtB.Text = "Answer B";
            txtB.Enter += txtB_Enter;
            txtB.Leave += txtB_Leave;
            // 
            // txtC
            // 
            txtC.BackColor = SystemColors.ButtonHighlight;
            txtC.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold);
            txtC.ForeColor = Color.Silver;
            txtC.Location = new Point(34, 325);
            txtC.Margin = new Padding(2, 3, 2, 3);
            txtC.Multiline = true;
            txtC.Name = "txtC";
            txtC.Size = new Size(527, 50);
            txtC.TabIndex = 4;
            txtC.Text = "Answer C";
            txtC.Enter += txtC_Enter;
            txtC.Leave += txtC_Leave;
            // 
            // txtD
            // 
            txtD.BackColor = SystemColors.ButtonHighlight;
            txtD.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold);
            txtD.ForeColor = Color.Silver;
            txtD.Location = new Point(713, 325);
            txtD.Margin = new Padding(2, 3, 2, 3);
            txtD.Multiline = true;
            txtD.Name = "txtD";
            txtD.Size = new Size(562, 50);
            txtD.TabIndex = 5;
            txtD.Text = "Answer D";
            txtD.Enter += txtD_Enter;
            txtD.Leave += txtD_Leave;
            // 
            // txtquestion
            // 
            txtquestion.BackColor = Color.White;
            txtquestion.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtquestion.ForeColor = Color.Silver;
            txtquestion.Location = new Point(378, 146);
            txtquestion.Margin = new Padding(2, 3, 2, 3);
            txtquestion.Multiline = true;
            txtquestion.Name = "txtquestion";
            txtquestion.Size = new Size(495, 59);
            txtquestion.TabIndex = 6;
            txtquestion.Text = "Type question here";
            txtquestion.TextAlign = HorizontalAlignment.Center;
            txtquestion.Enter += txtquestion_Enter;
            txtquestion.Leave += txtquestion_Leave;
            // 
            // txttime
            // 
            txttime.BackColor = Color.Thistle;
            txttime.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            txttime.ForeColor = SystemColors.InactiveCaptionText;
            txttime.Location = new Point(1123, 601);
            txttime.Margin = new Padding(2, 3, 2, 3);
            txttime.Multiline = true;
            txttime.Name = "txttime";
            txttime.Size = new Size(154, 60);
            txttime.TabIndex = 7;
            txttime.Text = "Enter timeout here";
            txttime.Enter += textBox1_Enter;
            txttime.KeyPress += txttime_KeyPress;
            txttime.Leave += txttime_Leave;
            // 
            // comboBox1
            // 
            comboBox1.BackColor = SystemColors.ButtonHighlight;
            comboBox1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            comboBox1.ForeColor = SystemColors.InfoText;
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "A", "B", "C", "D" });
            comboBox1.Location = new Point(350, 402);
            comboBox1.Margin = new Padding(2, 3, 2, 3);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(212, 33);
            comboBox1.TabIndex = 8;
            comboBox1.Text = "Correct Answer";
            // 
            // btnadd
            // 
            btnadd.BackColor = SystemColors.ButtonHighlight;
            btnadd.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnadd.ForeColor = SystemColors.InfoText;
            btnadd.Location = new Point(710, 402);
            btnadd.Margin = new Padding(2, 3, 2, 3);
            btnadd.Name = "btnadd";
            btnadd.Size = new Size(257, 40);
            btnadd.TabIndex = 9;
            btnadd.Text = "ADD QUESTION";
            btnadd.UseVisualStyleBackColor = false;
            btnadd.Click += btnadd_Click;
            // 
            // txtback
            // 
            txtback.BackColor = Color.Red;
            txtback.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            txtback.ForeColor = SystemColors.InactiveCaptionText;
            txtback.Location = new Point(473, 471);
            txtback.Margin = new Padding(2, 3, 2, 3);
            txtback.Name = "txtback";
            txtback.Size = new Size(136, 83);
            txtback.TabIndex = 10;
            txtback.Text = "Back";
            txtback.UseVisualStyleBackColor = false;
            txtback.Click += txtback_Click;
            // 
            // txtnext
            // 
            txtnext.BackColor = Color.MediumSeaGreen;
            txtnext.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            txtnext.ForeColor = SystemColors.InactiveCaptionText;
            txtnext.Location = new Point(710, 471);
            txtnext.Margin = new Padding(2, 3, 2, 3);
            txtnext.Name = "txtnext";
            txtnext.Size = new Size(125, 83);
            txtnext.TabIndex = 11;
            txtnext.Text = "Confirm";
            txtnext.UseVisualStyleBackColor = false;
            txtnext.Click += txtnext_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.ButtonHighlight;
            label1.BorderStyle = BorderStyle.Fixed3D;
            label1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.InactiveCaptionText;
            label1.Location = new Point(122, 541);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(152, 27);
            label1.TabIndex = 12;
            label1.Text = "List Questions";
            // 
            // rtbshowlist
            // 
            rtbshowlist.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            rtbshowlist.Location = new Point(258, 594);
            rtbshowlist.Margin = new Padding(2, 3, 2, 3);
            rtbshowlist.Name = "rtbshowlist";
            rtbshowlist.ScrollBars = RichTextBoxScrollBars.Vertical;
            rtbshowlist.Size = new Size(786, 303);
            rtbshowlist.TabIndex = 13;
            rtbshowlist.Text = "";
            // 
            // quizLb
            // 
            quizLb.BackColor = Color.FromArgb(64, 64, 64);
            quizLb.Font = new Font("Microsoft Sans Serif", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            quizLb.ForeColor = SystemColors.ControlLightLight;
            quizLb.Location = new Point(103, 9);
            quizLb.Margin = new Padding(2, 0, 2, 0);
            quizLb.Name = "quizLb";
            quizLb.Size = new Size(1003, 75);
            quizLb.TabIndex = 14;
            quizLb.Text = "QUIZ";
            quizLb.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // AddQuestions
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Tomato;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1342, 844);
            Controls.Add(quizLb);
            Controls.Add(rtbshowlist);
            Controls.Add(label1);
            Controls.Add(txtnext);
            Controls.Add(txtback);
            Controls.Add(btnadd);
            Controls.Add(comboBox1);
            Controls.Add(txttime);
            Controls.Add(txtquestion);
            Controls.Add(txtD);
            Controls.Add(txtC);
            Controls.Add(txtB);
            Controls.Add(txtA);
            Margin = new Padding(2, 3, 2, 3);
            Name = "AddQuestions";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.TextBox txtA;
        private System.Windows.Forms.TextBox txtB;
        private System.Windows.Forms.TextBox txtC;
        private System.Windows.Forms.TextBox txtD;
        private System.Windows.Forms.TextBox txtquestion;
        private System.Windows.Forms.TextBox txttime;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button btnadd;
        private System.Windows.Forms.Button txtback;
        private System.Windows.Forms.Button txtnext;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox rtbshowlist;
        private Label quizLb;
    }
}

