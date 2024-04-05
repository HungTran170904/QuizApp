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
            label4 = new Label();
            txtname = new TextBox();
            btnnext = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.BackColor = Color.FromArgb(64, 64, 64);
            label1.Font = new Font("Microsoft Sans Serif", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ControlLightLight;
            label1.Location = new Point(41, 22);
            label1.Name = "label1";
            label1.Size = new Size(1254, 94);
            label1.TabIndex = 0;
            label1.Text = "QUIZ";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // label2
            // 
            label2.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label2.Location = new Point(558, 141);
            label2.Name = "label2";
            label2.Size = new Size(237, 62);
            label2.TabIndex = 1;
            label2.Text = "New Quiz";
            label2.TextAlign = ContentAlignment.TopCenter;
            // 
            // label4
            // 
            label4.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label4.Location = new Point(513, 302);
            label4.Name = "label4";
            label4.Size = new Size(298, 120);
            label4.TabIndex = 3;
            label4.Text = "Type quiz introduction";
            label4.TextAlign = ContentAlignment.TopCenter;
            // 
            // txtname
            // 
            txtname.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtname.ForeColor = SystemColors.InactiveCaption;
            txtname.Location = new Point(521, 490);
            txtname.Margin = new Padding(3, 4, 3, 4);
            txtname.Multiline = true;
            txtname.Name = "txtname";
            txtname.Size = new Size(326, 89);
            txtname.TabIndex = 4;
            txtname.Text = "Name";
            txtname.TextAlign = HorizontalAlignment.Center;
            txtname.TextChanged += txtname_TextChanged;
            txtname.Enter += txtname_Enter;
            txtname.Leave += txtname_Leave;
            // 
            // btnnext
            // 
            btnnext.BackColor = Color.Black;
            btnnext.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnnext.ForeColor = SystemColors.ButtonHighlight;
            btnnext.Location = new Point(587, 755);
            btnnext.Margin = new Padding(3, 4, 3, 4);
            btnnext.Name = "btnnext";
            btnnext.Size = new Size(182, 178);
            btnnext.TabIndex = 6;
            btnnext.Text = "Continue";
            btnnext.UseVisualStyleBackColor = false;
            btnnext.Click += btnnext_Click;
            // 
            // NameCategory
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Tomato;
            ClientSize = new Size(1324, 1040);
            Controls.Add(btnnext);
            Controls.Add(txtname);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(label1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "NameCategory";
            Text = "NameCategory";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtname;
        private System.Windows.Forms.Button btnnext;
    }
}