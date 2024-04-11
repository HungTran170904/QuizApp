namespace QuizApp_frontend.FormNguoichoi
{
    partial class formPodidum
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
            Rank = new Button();
            button4 = new Button();
            Point = new Button();
            button3 = new Button();
            Waiting = new Button();
            SuspendLayout();
            // 
            // Rank
            // 
            Rank.BackColor = Color.FromArgb(0, 0, 64);
            Rank.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Rank.Location = new Point(14, 422);
            Rank.Margin = new Padding(5);
            Rank.Name = "Rank";
            Rank.Size = new Size(202, 95);
            Rank.TabIndex = 1;
            Rank.Text = "Rank";
            Rank.UseVisualStyleBackColor = false;
            Rank.Visible = false;
            // 
            // button4
            // 
            button4.BackColor = Color.LightSkyBlue;
            button4.Location = new Point(506, 398);
            button4.Margin = new Padding(5);
            button4.Name = "button4";
            button4.Size = new Size(143, 92);
            button4.TabIndex = 3;
            button4.Text = "Your Rank";
            button4.UseVisualStyleBackColor = false;
            // 
            // Point
            // 
            Point.BackColor = Color.LightSkyBlue;
            Point.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Point.Location = new Point(270, 422);
            Point.Margin = new Padding(5);
            Point.Name = "Point";
            Point.Size = new Size(212, 95);
            Point.TabIndex = 4;
            Point.Text = "Point";
            Point.UseVisualStyleBackColor = false;
            Point.Visible = false;
            // 
            // button3
            // 
            button3.BackColor = Color.LightSkyBlue;
            button3.Location = new Point(506, 213);
            button3.Margin = new Padding(5);
            button3.Name = "button3";
            button3.Size = new Size(143, 92);
            button3.TabIndex = 5;
            button3.Text = "Your Rank";
            button3.UseVisualStyleBackColor = false;
            // 
            // Waiting
            // 
            Waiting.BackColor = Color.FromArgb(0, 0, 64);
            Waiting.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Waiting.Location = new Point(41, 422);
            Waiting.Margin = new Padding(5);
            Waiting.Name = "Waiting";
            Waiting.Size = new Size(410, 95);
            Waiting.TabIndex = 6;
            Waiting.Text = "Waiting for host ....";
            Waiting.UseVisualStyleBackColor = false;
            // 
            // formPodidum
            // 
            AutoScaleDimensions = new SizeF(13F, 31F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            BackgroundImage = Properties.Resources.congratulate;
            ClientSize = new Size(497, 531);
            Controls.Add(Waiting);
            Controls.Add(button3);
            Controls.Add(Point);
            Controls.Add(button4);
            Controls.Add(Rank);
            Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ForeColor = Color.White;
            Margin = new Padding(5);
            Name = "formPodidum";
            Text = "formPodidum";
            ResumeLayout(false);
        }

        #endregion
        private Button Rank;
        private Button button4;
        private Button Point;
        private Button button3;
        private Button Waiting;
    }
}