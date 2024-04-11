namespace QuizApp_frontend
{
    partial class formJoin
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
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            pictureBox6 = new PictureBox();
            pictureBox3 = new PictureBox();
            pictureBox4 = new PictureBox();
            nameTb = new RichTextBox();
            pinCodeTb = new RichTextBox();
            textBox1 = new TextBox();
            pictureBox5 = new PictureBox();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Image = Properties.Resources.username;
            pictureBox1.Location = new Point(61, 64);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(195, 84);
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.Transparent;
            pictureBox2.Image = Properties.Resources.pincode;
            pictureBox2.Location = new Point(63, 198);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(193, 84);
            pictureBox2.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox2.TabIndex = 5;
            pictureBox2.TabStop = false;
            // 
            // pictureBox6
            // 
            pictureBox6.BackColor = Color.Transparent;
            pictureBox6.Image = Properties.Resources.blank;
            pictureBox6.Location = new Point(285, 64);
            pictureBox6.Name = "pictureBox6";
            pictureBox6.Size = new Size(334, 93);
            pictureBox6.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox6.TabIndex = 8;
            pictureBox6.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.BackColor = Color.Transparent;
            pictureBox3.Image = Properties.Resources.blank;
            pictureBox3.Location = new Point(285, 189);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(348, 93);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 9;
            pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            pictureBox4.BackColor = Color.Transparent;
            pictureBox4.Image = Properties.Resources.enter;
            pictureBox4.Location = new Point(455, 298);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(211, 129);
            pictureBox4.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox4.TabIndex = 10;
            pictureBox4.TabStop = false;
            pictureBox4.Click += pictureBox4_Click;
            pictureBox4.DoubleClick += pictureBox4_DoubleClick;
            // 
            // nameTb
            // 
            nameTb.BorderStyle = BorderStyle.None;
            nameTb.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            nameTb.Location = new Point(315, 87);
            nameTb.Name = "nameTb";
            nameTb.Size = new Size(257, 29);
            nameTb.TabIndex = 11;
            nameTb.Text = "";
            // 
            // pinCodeTb
            // 
            pinCodeTb.BorderStyle = BorderStyle.None;
            pinCodeTb.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            pinCodeTb.Location = new Point(315, 223);
            pinCodeTb.Name = "pinCodeTb";
            pinCodeTb.Size = new Size(257, 30);
            pinCodeTb.TabIndex = 12;
            pinCodeTb.Text = "";
            pinCodeTb.TextChanged += pinCodeTb_TextChanged;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(0, 0);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(125, 27);
            textBox1.TabIndex = 13;
            textBox1.Visible = false;
            // 
            // pictureBox5
            // 
            pictureBox5.BackColor = Color.Transparent;
            pictureBox5.Image = Properties.Resources.enter;
            pictureBox5.Location = new Point(175, 298);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(211, 129);
            pictureBox5.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox5.TabIndex = 14;
            pictureBox5.TabStop = false;
            // 
            // button1
            // 
            button1.BackColor = Color.Firebrick;
            button1.FlatAppearance.BorderColor = Color.Firebrick;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.White;
            button1.Location = new Point(205, 325);
            button1.Name = "button1";
            button1.Size = new Size(138, 71);
            button1.TabIndex = 15;
            button1.Text = "Return";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // formJoin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.joinBackground;
            ClientSize = new Size(800, 450);
            Controls.Add(button1);
            Controls.Add(pictureBox5);
            Controls.Add(textBox1);
            Controls.Add(pinCodeTb);
            Controls.Add(nameTb);
            Controls.Add(pictureBox4);
            Controls.Add(pictureBox3);
            Controls.Add(pictureBox6);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Name = "formJoin";
            Text = "formJoin";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox6;
        private PictureBox pictureBox3;
        private PictureBox pictureBox4;
        private RichTextBox nameTb;
        private RichTextBox pinCodeTb;
        private TextBox textBox1;
        private PictureBox pictureBox5;
        private Button button1;
    }
}