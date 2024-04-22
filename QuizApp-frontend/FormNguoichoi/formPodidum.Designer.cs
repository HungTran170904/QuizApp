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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formPodidum));
            Rank = new Button();
            Point = new Button();
            Waiting = new Button();
            backButton = new Button();
            SuspendLayout();
            // 
            // Rank
            // 
            Rank.BackColor = Color.FromArgb(0, 0, 64);
            Rank.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Rank.Location = new Point(139, 300);
            Rank.Margin = new Padding(5);
            Rank.Name = "Rank";
            Rank.Size = new Size(202, 95);
            Rank.TabIndex = 1;
            Rank.Text = "Rank";
            Rank.UseVisualStyleBackColor = false;
            Rank.Visible = false;
            // 
            // Point
            // 
            Point.BackColor = Color.LightSkyBlue;
            Point.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Point.Location = new Point(660, 300);
            Point.Margin = new Padding(5);
            Point.Name = "Point";
            Point.Size = new Size(212, 95);
            Point.TabIndex = 4;
            Point.Text = "Point";
            Point.UseVisualStyleBackColor = false;
            Point.Visible = false;
            // 
            // Waiting
            // 
            Waiting.BackColor = Color.FromArgb(0, 0, 64);
            Waiting.BackgroundImageLayout = ImageLayout.Zoom;
            Waiting.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Waiting.Location = new Point(308, 455);
            Waiting.Margin = new Padding(5);
            Waiting.Name = "Waiting";
            Waiting.Size = new Size(410, 95);
            Waiting.TabIndex = 6;
            Waiting.Text = "Waiting for host ....";
            Waiting.UseVisualStyleBackColor = false;
            // 
            // backButton
            // 
            backButton.BackColor = Color.Black;
            backButton.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            backButton.Location = new Point(826, 24);
            backButton.Margin = new Padding(5);
            backButton.Name = "backButton";
            backButton.Size = new Size(147, 51);
            backButton.TabIndex = 7;
            backButton.Text = "Home >>";
            backButton.UseVisualStyleBackColor = false;
            backButton.Click += backButton_Click;
            // 
            // formPodidum
            // 
            AutoScaleDimensions = new SizeF(15F, 38F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1028, 643);
            Controls.Add(backButton);
            Controls.Add(Waiting);
            Controls.Add(Point);
            Controls.Add(Rank);
            DoubleBuffered = true;
            Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ForeColor = Color.White;
            Margin = new Padding(5);
            Name = "formPodidum";
            Text = "formPodidum";
            ResumeLayout(false);
        }

        #endregion
        private Button Rank;
        private Button Point;
        private Button Waiting;
        private Button backButton;
    }
}