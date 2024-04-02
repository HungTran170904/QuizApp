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
            this.txtA = new System.Windows.Forms.TextBox();
            this.txtB = new System.Windows.Forms.TextBox();
            this.txtC = new System.Windows.Forms.TextBox();
            this.txtD = new System.Windows.Forms.TextBox();
            this.txtquestion = new System.Windows.Forms.TextBox();
            this.txttime = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btnadd = new System.Windows.Forms.Button();
            this.txtback = new System.Windows.Forms.Button();
            this.txtnext = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.rtbshowlist = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // txtA
            // 
            this.txtA.BackColor = System.Drawing.Color.Thistle;
            this.txtA.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtA.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.txtA.Location = new System.Drawing.Point(39, 105);
            this.txtA.Multiline = true;
            this.txtA.Name = "txtA";
            this.txtA.Size = new System.Drawing.Size(646, 60);
            this.txtA.TabIndex = 2;
            this.txtA.Text = "Answer A";
            this.txtA.Enter += new System.EventHandler(this.txtA_Enter);
            this.txtA.Leave += new System.EventHandler(this.txtA_Leave);
            // 
            // txtB
            // 
            this.txtB.BackColor = System.Drawing.Color.Thistle;
            this.txtB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtB.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.txtB.Location = new System.Drawing.Point(802, 105);
            this.txtB.Multiline = true;
            this.txtB.Name = "txtB";
            this.txtB.Size = new System.Drawing.Size(688, 60);
            this.txtB.TabIndex = 3;
            this.txtB.Text = "Answer B";
            this.txtB.Enter += new System.EventHandler(this.txtB_Enter);
            this.txtB.Leave += new System.EventHandler(this.txtB_Leave);
            // 
            // txtC
            // 
            this.txtC.BackColor = System.Drawing.Color.Thistle;
            this.txtC.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtC.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.txtC.Location = new System.Drawing.Point(39, 250);
            this.txtC.Multiline = true;
            this.txtC.Name = "txtC";
            this.txtC.Size = new System.Drawing.Size(646, 60);
            this.txtC.TabIndex = 4;
            this.txtC.Text = "Answer C";
            this.txtC.Enter += new System.EventHandler(this.txtC_Enter);
            this.txtC.Leave += new System.EventHandler(this.txtC_Leave);
            // 
            // txtD
            // 
            this.txtD.BackColor = System.Drawing.Color.Thistle;
            this.txtD.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtD.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.txtD.Location = new System.Drawing.Point(802, 250);
            this.txtD.Multiline = true;
            this.txtD.Name = "txtD";
            this.txtD.Size = new System.Drawing.Size(688, 60);
            this.txtD.TabIndex = 5;
            this.txtD.Text = "Answer D";
            this.txtD.Enter += new System.EventHandler(this.txtD_Enter);
            this.txtD.Leave += new System.EventHandler(this.txtD_Leave);
            // 
            // txtquestion
            // 
            this.txtquestion.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.txtquestion.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtquestion.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.txtquestion.Location = new System.Drawing.Point(499, 12);
            this.txtquestion.Multiline = true;
            this.txtquestion.Name = "txtquestion";
            this.txtquestion.Size = new System.Drawing.Size(440, 59);
            this.txtquestion.TabIndex = 6;
            this.txtquestion.Text = "Type question here";
            this.txtquestion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtquestion.Enter += new System.EventHandler(this.txtquestion_Enter);
            this.txtquestion.Leave += new System.EventHandler(this.txtquestion_Leave);
            // 
            // txttime
            // 
            this.txttime.BackColor = System.Drawing.Color.Thistle;
            this.txttime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txttime.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.txttime.Location = new System.Drawing.Point(39, 837);
            this.txttime.Multiline = true;
            this.txttime.Name = "txttime";
            this.txttime.Size = new System.Drawing.Size(173, 60);
            this.txttime.TabIndex = 7;
            this.txttime.Text = "Enter timeout here";
            this.txttime.TextChanged += new System.EventHandler(this.txttime_TextChanged);
            this.txttime.Enter += new System.EventHandler(this.textBox1_Enter);
            this.txttime.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txttime_KeyPress);
            this.txttime.Leave += new System.EventHandler(this.txttime_Leave);
            // 
            // comboBox1
            // 
            this.comboBox1.BackColor = System.Drawing.Color.Thistle;
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "A",
            "B",
            "C",
            "D"});
            this.comboBox1.Location = new System.Drawing.Point(447, 342);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(238, 37);
            this.comboBox1.TabIndex = 8;
            this.comboBox1.Text = "Correct Answer";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // btnadd
            // 
            this.btnadd.BackColor = System.Drawing.Color.Thistle;
            this.btnadd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnadd.ForeColor = System.Drawing.SystemColors.InfoText;
            this.btnadd.Location = new System.Drawing.Point(802, 342);
            this.btnadd.Name = "btnadd";
            this.btnadd.Size = new System.Drawing.Size(289, 40);
            this.btnadd.TabIndex = 9;
            this.btnadd.Text = "ADD QUESTION";
            this.btnadd.UseVisualStyleBackColor = false;
            this.btnadd.Click += new System.EventHandler(this.btnadd_Click);
            // 
            // txtback
            // 
            this.txtback.BackColor = System.Drawing.Color.Thistle;
            this.txtback.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtback.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.txtback.Location = new System.Drawing.Point(532, 471);
            this.txtback.Name = "txtback";
            this.txtback.Size = new System.Drawing.Size(153, 83);
            this.txtback.TabIndex = 10;
            this.txtback.Text = "Back";
            this.txtback.UseVisualStyleBackColor = false;
            this.txtback.Click += new System.EventHandler(this.txtback_Click);
            // 
            // txtnext
            // 
            this.txtnext.BackColor = System.Drawing.Color.Thistle;
            this.txtnext.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtnext.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.txtnext.Location = new System.Drawing.Point(799, 471);
            this.txtnext.Name = "txtnext";
            this.txtnext.Size = new System.Drawing.Size(140, 83);
            this.txtnext.TabIndex = 11;
            this.txtnext.Text = "Continue";
            this.txtnext.UseVisualStyleBackColor = false;
            this.txtnext.Click += new System.EventHandler(this.txtnext_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Thistle;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.label1.Location = new System.Drawing.Point(137, 541);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(181, 31);
            this.label1.TabIndex = 12;
            this.label1.Text = "List Questions";
            // 
            // rtbshowlist
            // 
            this.rtbshowlist.Location = new System.Drawing.Point(291, 594);
            this.rtbshowlist.Name = "rtbshowlist";
            this.rtbshowlist.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.rtbshowlist.Size = new System.Drawing.Size(884, 303);
            this.rtbshowlist.TabIndex = 13;
            this.rtbshowlist.Text = "";
            this.rtbshowlist.TextChanged += new System.EventHandler(this.rtbshowlist_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::QuizApp_frontend.Properties.Resources.QuestionBox;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1510, 923);
            this.Controls.Add(this.rtbshowlist);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtnext);
            this.Controls.Add(this.txtback);
            this.Controls.Add(this.btnadd);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.txttime);
            this.Controls.Add(this.txtquestion);
            this.Controls.Add(this.txtD);
            this.Controls.Add(this.txtC);
            this.Controls.Add(this.txtB);
            this.Controls.Add(this.txtA);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

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
    }
}

