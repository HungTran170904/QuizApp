namespace QuizApp_frontend.FormHost
{
    partial class WaitingRoom
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
            headerLb = new Label();
            numberLb = new Label();
            startButton = new Button();
            listView = new ListView();
            blockButton = new Button();
            pinCodeTb = new TextBox();
            pinCodeLb = new Label();
            endButton = new Button();
            SuspendLayout();
            // 
            // headerLb
            // 
            headerLb.BackColor = SystemColors.Window;
            headerLb.BorderStyle = BorderStyle.FixedSingle;
            headerLb.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            headerLb.Location = new Point(27, 9);
            headerLb.Name = "headerLb";
            headerLb.Size = new Size(1123, 53);
            headerLb.TabIndex = 3;
            headerLb.Text = "Quiz: Toan Hoc";
            headerLb.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // numberLb
            // 
            numberLb.AutoSize = true;
            numberLb.BackColor = Color.FromArgb(0, 192, 192);
            numberLb.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            numberLb.ForeColor = Color.White;
            numberLb.Location = new Point(27, 147);
            numberLb.Name = "numberLb";
            numberLb.Size = new Size(98, 28);
            numberLb.TabIndex = 5;
            numberLb.Text = "0 players";
            numberLb.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // startButton
            // 
            startButton.AutoSize = true;
            startButton.BackColor = Color.FromArgb(128, 255, 255);
            startButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            startButton.ForeColor = Color.Black;
            startButton.Location = new Point(971, 82);
            startButton.Name = "startButton";
            startButton.Size = new Size(114, 42);
            startButton.TabIndex = 6;
            startButton.Text = "Start";
            startButton.UseVisualStyleBackColor = false;
            startButton.Click += startButton_Click;
            // 
            // listView
            // 
            listView.BackColor = Color.FromArgb(0, 192, 192);
            listView.BorderStyle = BorderStyle.None;
            listView.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            listView.ForeColor = SystemColors.InactiveBorder;
            listView.Location = new Point(144, 147);
            listView.Name = "listView";
            listView.RightToLeft = RightToLeft.No;
            listView.ShowGroups = false;
            listView.Size = new Size(941, 453);
            listView.TabIndex = 4;
            listView.TileSize = new Size(100, 100);
            listView.UseCompatibleStateImageBehavior = false;
            listView.View = View.Tile;
            // 
            // blockButton
            // 
            blockButton.AutoSize = true;
            blockButton.BackColor = Color.Gray;
            blockButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            blockButton.ForeColor = Color.Black;
            blockButton.Location = new Point(814, 82);
            blockButton.Name = "blockButton";
            blockButton.Size = new Size(155, 42);
            blockButton.TabIndex = 7;
            blockButton.Text = "Block room";
            blockButton.UseVisualStyleBackColor = false;
            blockButton.Click += blockButton_Click;
            // 
            // pinCodeTb
            // 
            pinCodeTb.BackColor = Color.White;
            pinCodeTb.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            pinCodeTb.Location = new Point(543, 82);
            pinCodeTb.Name = "pinCodeTb";
            pinCodeTb.ReadOnly = true;
            pinCodeTb.Size = new Size(160, 41);
            pinCodeTb.TabIndex = 8;
            pinCodeTb.TextAlign = HorizontalAlignment.Center;
            // 
            // pinCodeLb
            // 
            pinCodeLb.AutoSize = true;
            pinCodeLb.BackColor = SystemColors.Window;
            pinCodeLb.BorderStyle = BorderStyle.FixedSingle;
            pinCodeLb.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            pinCodeLb.Location = new Point(401, 82);
            pinCodeLb.Name = "pinCodeLb";
            pinCodeLb.Size = new Size(124, 37);
            pinCodeLb.TabIndex = 9;
            pinCodeLb.Text = "Pin code:";
            pinCodeLb.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // endButton
            // 
            endButton.AutoSize = true;
            endButton.BackColor = Color.OrangeRed;
            endButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            endButton.ForeColor = Color.White;
            endButton.Location = new Point(27, 78);
            endButton.Name = "endButton";
            endButton.Size = new Size(114, 42);
            endButton.TabIndex = 10;
            endButton.Text = "End";
            endButton.UseVisualStyleBackColor = false;
            endButton.Click += end_Click;
            // 
            // WaitingRoom
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(0, 192, 192);
            ClientSize = new Size(1174, 612);
            Controls.Add(endButton);
            Controls.Add(pinCodeLb);
            Controls.Add(pinCodeTb);
            Controls.Add(blockButton);
            Controls.Add(startButton);
            Controls.Add(numberLb);
            Controls.Add(listView);
            Controls.Add(headerLb);
            FormBorderStyle = FormBorderStyle.None;
            Name = "WaitingRoom";
            Text = "WaitingRoom";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label headerLb;
        private Label numberLb;
        private Button startButton;
        private ListView listView;
        private Button blockButton;
        private TextBox pinCodeTb;
        private Label pinCodeLb;
        private Button endButton;
    }
}