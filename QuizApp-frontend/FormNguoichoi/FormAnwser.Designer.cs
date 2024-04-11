namespace QuizApp_frontend.FormNguoichoi
{
    partial class FormAnwser
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
            components = new System.ComponentModel.Container();
            richTextBox1 = new RichTextBox();
            richTextBox2 = new RichTextBox();
            richTextBox3 = new RichTextBox();
            richTextBox4 = new RichTextBox();
            button1 = new Button();
            timer1 = new System.Windows.Forms.Timer(components);
            richTextBox5 = new RichTextBox();
            SuspendLayout();
            // 
            // richTextBox1
            // 
            richTextBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            richTextBox1.BackColor = Color.Red;
            richTextBox1.BorderStyle = BorderStyle.None;
            richTextBox1.Font = new Font("Times New Roman", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            richTextBox1.ForeColor = Color.White;
            richTextBox1.Location = new Point(52, 334);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(439, 58);
            richTextBox1.TabIndex = 0;
            richTextBox1.Text = "dap an a";
            // 
            // richTextBox2
            // 
            richTextBox2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            richTextBox2.BackColor = Color.Blue;
            richTextBox2.BorderStyle = BorderStyle.None;
            richTextBox2.Font = new Font("Times New Roman", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            richTextBox2.ForeColor = Color.White;
            richTextBox2.Location = new Point(581, 334);
            richTextBox2.Name = "richTextBox2";
            richTextBox2.Size = new Size(439, 58);
            richTextBox2.TabIndex = 1;
            richTextBox2.Text = "dap an a";
            // 
            // richTextBox3
            // 
            richTextBox3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            richTextBox3.BackColor = Color.Orange;
            richTextBox3.BorderStyle = BorderStyle.None;
            richTextBox3.Font = new Font("Times New Roman", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            richTextBox3.ForeColor = Color.White;
            richTextBox3.Location = new Point(52, 441);
            richTextBox3.Name = "richTextBox3";
            richTextBox3.Size = new Size(439, 58);
            richTextBox3.TabIndex = 2;
            richTextBox3.Text = "dap an a";
            // 
            // richTextBox4
            // 
            richTextBox4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            richTextBox4.BackColor = Color.Green;
            richTextBox4.BorderStyle = BorderStyle.None;
            richTextBox4.Font = new Font("Times New Roman", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            richTextBox4.ForeColor = Color.White;
            richTextBox4.Location = new Point(581, 441);
            richTextBox4.Name = "richTextBox4";
            richTextBox4.Size = new Size(439, 58);
            richTextBox4.TabIndex = 3;
            richTextBox4.Text = "dap an a";
            // 
            // button1
            // 
            button1.BackColor = Color.MidnightBlue;
            button1.FlatAppearance.BorderColor = Color.MidnightBlue;
            button1.FlatStyle = FlatStyle.Flat;
            button1.ForeColor = Color.White;
            button1.Location = new Point(22, 95);
            button1.Name = "button1";
            button1.Size = new Size(51, 44);
            button1.TabIndex = 5;
            button1.Text = "0";
            button1.UseVisualStyleBackColor = false;
            // 
            // timer1
            // 
            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;
            // 
            // richTextBox5
            // 
            richTextBox5.Location = new Point(206, 23);
            richTextBox5.Name = "richTextBox5";
            richTextBox5.Size = new Size(729, 248);
            richTextBox5.TabIndex = 6;
            richTextBox5.Text = "";
            // 
            // FormAnwser
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.FormDapan;
            ClientSize = new Size(1032, 578);
            Controls.Add(richTextBox5);
            Controls.Add(button1);
            Controls.Add(richTextBox4);
            Controls.Add(richTextBox3);
            Controls.Add(richTextBox2);
            Controls.Add(richTextBox1);
            Name = "FormAnwser";
            Text = "FormAnwser";
            Load += FormAnwser_Load;
            ResumeLayout(false);
        }

        #endregion

        private RichTextBox richTextBox1;
        private RichTextBox richTextBox2;
        private RichTextBox richTextBox3;
        private RichTextBox richTextBox4;
        private Button button1;
        private System.Windows.Forms.Timer timer1;
        private RichTextBox richTextBox5;
    }
}