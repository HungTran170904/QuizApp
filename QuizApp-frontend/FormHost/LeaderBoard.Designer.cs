namespace QuizApp_frontend.FormHost
{
    partial class LeaderBoard
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
            flowLayoutPanel = new FlowLayoutPanel();
            label2 = new Label();
            nextButton = new Button();
            endButton = new Button();
            SuspendLayout();
            // 
            // flowLayoutPanel
            // 
            flowLayoutPanel.AutoScroll = true;
            flowLayoutPanel.Location = new Point(239, 94);
            flowLayoutPanel.Name = "flowLayoutPanel";
            flowLayoutPanel.Size = new Size(461, 446);
            flowLayoutPanel.TabIndex = 0;
            // 
            // label2
            // 
            label2.BackColor = SystemColors.Window;
            label2.BorderStyle = BorderStyle.FixedSingle;
            label2.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            label2.Location = new Point(-1, -1);
            label2.Name = "label2";
            label2.Size = new Size(975, 63);
            label2.TabIndex = 2;
            label2.Text = "Leader Board";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // nextButton
            // 
            nextButton.BackColor = Color.FromArgb(128, 255, 255);
            nextButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            nextButton.Location = new Point(794, 150);
            nextButton.Name = "nextButton";
            nextButton.Size = new Size(114, 35);
            nextButton.TabIndex = 3;
            nextButton.Text = "Next";
            nextButton.UseVisualStyleBackColor = false;
            nextButton.Click += nextButton_Click;
            // 
            // endButton
            // 
            endButton.BackColor = Color.FromArgb(128, 255, 255);
            endButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            endButton.Location = new Point(794, 94);
            endButton.Name = "endButton";
            endButton.Size = new Size(114, 35);
            endButton.TabIndex = 4;
            endButton.Text = "End Game";
            endButton.UseVisualStyleBackColor = false;
            endButton.Click += endButton_Click;
            // 
            // LeaderBoard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.BlueViolet;
            BackgroundImageLayout = ImageLayout.None;
            ClientSize = new Size(973, 552);
            ControlBox = false;
            Controls.Add(endButton);
            Controls.Add(nextButton);
            Controls.Add(flowLayoutPanel);
            Controls.Add(label2);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            Name = "LeaderBoard";
            Text = "LeaderBoard";
            ResumeLayout(false);
        }

        #endregion
        private FlowLayoutPanel flowLayoutPanel;
        private Label label2;
        private Button nextButton;
        private Button endButton;
    }
}