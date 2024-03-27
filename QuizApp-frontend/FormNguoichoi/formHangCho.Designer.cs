namespace QuizApp_frontend.FormNguoichoi
{
    partial class formHangCho
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
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.FromArgb(128, 255, 255);
            textBox1.Enabled = false;
            textBox1.Font = new Font("Segoe UI", 22.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox1.Location = new Point(118, 12);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(151, 60);
            textBox1.TabIndex = 1;
            textBox1.TextAlign = HorizontalAlignment.Center;
            // 
            // textBox2
            // 
            textBox2.BackColor = Color.FromArgb(128, 255, 255);
            textBox2.Enabled = false;
            textBox2.Font = new Font("Segoe UI", 22.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox2.Location = new Point(731, 12);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(267, 60);
            textBox2.TabIndex = 2;
            textBox2.TextAlign = HorizontalAlignment.Center;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // formHangCho
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.formHangcho;
            BackgroundImageLayout = ImageLayout.None;
            ClientSize = new Size(1031, 714);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "formHangCho";
            Text = "formHangCho";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox textBox1;
        private TextBox textBox2;
    }
}