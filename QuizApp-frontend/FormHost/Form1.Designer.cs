namespace QuizApp_frontend.FormHost
{
    partial class Form1
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
            txtname = new TextBox();
            SuspendLayout();
            // 
            // txtA
            // 
            txtA.BackColor = SystemColors.ButtonHighlight;
            txtA.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold);
            txtA.ForeColor = SystemColors.InactiveCaptionText;
            txtA.Location = new Point(43, 292);
            txtA.Margin = new Padding(3, 4, 3, 4);
            txtA.Multiline = true;
            txtA.Name = "txtA";
            txtA.Size = new Size(658, 61);
            txtA.TabIndex = 2;
            txtA.Text = "Answer A";
            txtA.Enter += txtA_Enter;
            txtA.Leave += txtA_Leave;
            // 
            // txtB
            // 
            txtB.BackColor = SystemColors.ButtonHighlight;
            txtB.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold);
            txtB.ForeColor = SystemColors.InactiveCaptionText;
            txtB.Location = new Point(888, 292);
            txtB.Margin = new Padding(3, 4, 3, 4);
            txtB.Multiline = true;
            txtB.Name = "txtB";
            txtB.Size = new Size(705, 61);
            txtB.TabIndex = 3;
            txtB.Text = "Answer B";
            txtB.Enter += txtB_Enter;
            txtB.Leave += txtB_Leave;
            // 
            // txtC
            // 
            txtC.BackColor = SystemColors.ButtonHighlight;
            txtC.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold);
            txtC.ForeColor = SystemColors.InactiveCaptionText;
            txtC.Location = new Point(43, 406);
            txtC.Margin = new Padding(3, 4, 3, 4);
            txtC.Multiline = true;
            txtC.Name = "txtC";
            txtC.Size = new Size(658, 61);
            txtC.TabIndex = 4;
            txtC.Text = "Answer C";
            txtC.Enter += txtC_Enter;
            txtC.Leave += txtC_Leave;
            // 
            // txtD
            // 
            txtD.BackColor = SystemColors.ButtonHighlight;
            txtD.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold);
            txtD.ForeColor = SystemColors.InactiveCaptionText;
            txtD.Location = new Point(891, 406);
            txtD.Margin = new Padding(3, 4, 3, 4);
            txtD.Multiline = true;
            txtD.Name = "txtD";
            txtD.Size = new Size(702, 61);
            txtD.TabIndex = 5;
            txtD.Text = "Answer D";
            txtD.Enter += txtD_Enter;
            txtD.Leave += txtD_Leave;
            // 
            // txtquestion
            // 
            txtquestion.BackColor = SystemColors.ScrollBar;
            txtquestion.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtquestion.ForeColor = SystemColors.InactiveCaptionText;
            txtquestion.Location = new Point(567, 183);
            txtquestion.Margin = new Padding(3, 4, 3, 4);
            txtquestion.Multiline = true;
            txtquestion.Name = "txtquestion";
            txtquestion.Size = new Size(488, 73);
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
            txttime.Location = new Point(1404, 751);
            txttime.Margin = new Padding(3, 4, 3, 4);
            txttime.Multiline = true;
            txttime.Name = "txttime";
            txttime.Size = new Size(192, 74);
            txttime.TabIndex = 7;
            txttime.Text = "Enter timeout here";
            txttime.TextChanged += txttime_TextChanged;
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
            comboBox1.Location = new Point(437, 503);
            comboBox1.Margin = new Padding(3, 4, 3, 4);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(264, 37);
            comboBox1.TabIndex = 8;
            comboBox1.Text = "Correct Answer";
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // btnadd
            // 
            btnadd.BackColor = SystemColors.ButtonHighlight;
            btnadd.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnadd.ForeColor = SystemColors.InfoText;
            btnadd.Location = new Point(888, 503);
            btnadd.Margin = new Padding(3, 4, 3, 4);
            btnadd.Name = "btnadd";
            btnadd.Size = new Size(321, 50);
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
            txtback.Location = new Point(591, 589);
            txtback.Margin = new Padding(3, 4, 3, 4);
            txtback.Name = "txtback";
            txtback.Size = new Size(170, 104);
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
            txtnext.Location = new Point(888, 589);
            txtnext.Margin = new Padding(3, 4, 3, 4);
            txtnext.Name = "txtnext";
            txtnext.Size = new Size(156, 104);
            txtnext.TabIndex = 11;
            txtnext.Text = "Continue";
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
            label1.Location = new Point(152, 676);
            label1.Name = "label1";
            label1.Size = new Size(181, 31);
            label1.TabIndex = 12;
            label1.Text = "List Questions";
            // 
            // rtbshowlist
            // 
            rtbshowlist.Location = new Point(323, 742);
            rtbshowlist.Margin = new Padding(3, 4, 3, 4);
            rtbshowlist.Name = "rtbshowlist";
            rtbshowlist.ScrollBars = RichTextBoxScrollBars.Vertical;
            rtbshowlist.Size = new Size(982, 378);
            rtbshowlist.TabIndex = 13;
            rtbshowlist.Text = "";
            rtbshowlist.TextChanged += rtbshowlist_TextChanged;
            // 
            // txtname
            // 
            txtname.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtname.ForeColor = SystemColors.InactiveCaption;
            txtname.Location = new Point(638, 13);
            txtname.Margin = new Padding(3, 4, 3, 4);
            txtname.Multiline = true;
            txtname.Name = "txtname";
            txtname.Size = new Size(352, 89);
            txtname.TabIndex = 14;
            txtname.Text = "Name Title";
            txtname.TextAlign = HorizontalAlignment.Center;
            txtname.TextChanged += txtname_TextChanged;
            txtname.Enter += txtname_Enter;
            txtname.Leave += txtname_Leave;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Tomato;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1678, 1154);
            Controls.Add(txtname);
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
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
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
        private TextBox txtname;
    }
}

