namespace QuizApp_frontend.FormHost
{
    partial class Podium
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Podium));
            silverLb = new Label();
            imageList = new ImageList(components);
            goldenLb = new Label();
            copperLb = new Label();
            silverPlayerLb = new Label();
            goldenPlayerLb = new Label();
            copperPlayerLb = new Label();
            headerLb = new Label();
            backButton = new Button();
            SuspendLayout();
            // 
            // silverLb
            // 
            silverLb.BackColor = Color.MediumPurple;
            silverLb.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            silverLb.ImageAlign = ContentAlignment.TopCenter;
            silverLb.ImageIndex = 0;
            silverLb.ImageList = imageList;
            silverLb.Location = new Point(268, 231);
            silverLb.Name = "silverLb";
            silverLb.Size = new Size(113, 282);
            silverLb.TabIndex = 0;
            silverLb.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // imageList
            // 
            imageList.ColorDepth = ColorDepth.Depth32Bit;
            imageList.ImageStream = (ImageListStreamer)resources.GetObject("imageList.ImageStream");
            imageList.TransparentColor = Color.Transparent;
            imageList.Images.SetKeyName(0, "silverMedal.jpg");
            imageList.Images.SetKeyName(1, "goldenMedal.jpg");
            imageList.Images.SetKeyName(2, "copperMedal.jpg");
            // 
            // goldenLb
            // 
            goldenLb.BackColor = Color.MediumPurple;
            goldenLb.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            goldenLb.ImageAlign = ContentAlignment.TopCenter;
            goldenLb.ImageIndex = 1;
            goldenLb.ImageList = imageList;
            goldenLb.Location = new Point(414, 153);
            goldenLb.Name = "goldenLb";
            goldenLb.Size = new Size(113, 360);
            goldenLb.TabIndex = 2;
            goldenLb.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // copperLb
            // 
            copperLb.BackColor = Color.MediumPurple;
            copperLb.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            copperLb.ImageAlign = ContentAlignment.TopCenter;
            copperLb.ImageIndex = 2;
            copperLb.ImageList = imageList;
            copperLb.Location = new Point(558, 266);
            copperLb.Name = "copperLb";
            copperLb.Size = new Size(113, 247);
            copperLb.TabIndex = 3;
            copperLb.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // silverPlayerLb
            // 
            silverPlayerLb.AutoSize = true;
            silverPlayerLb.BackColor = Color.Indigo;
            silverPlayerLb.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            silverPlayerLb.ForeColor = Color.White;
            silverPlayerLb.Location = new Point(290, 189);
            silverPlayerLb.Name = "silverPlayerLb";
            silverPlayerLb.Size = new Size(0, 28);
            silverPlayerLb.TabIndex = 4;
            silverPlayerLb.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // goldenPlayerLb
            // 
            goldenPlayerLb.AutoSize = true;
            goldenPlayerLb.BackColor = Color.Indigo;
            goldenPlayerLb.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            goldenPlayerLb.ForeColor = Color.White;
            goldenPlayerLb.Location = new Point(439, 111);
            goldenPlayerLb.Name = "goldenPlayerLb";
            goldenPlayerLb.Size = new Size(0, 28);
            goldenPlayerLb.TabIndex = 5;
            goldenPlayerLb.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // copperPlayerLb
            // 
            copperPlayerLb.AutoSize = true;
            copperPlayerLb.BackColor = Color.Indigo;
            copperPlayerLb.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            copperPlayerLb.ForeColor = Color.White;
            copperPlayerLb.Location = new Point(583, 231);
            copperPlayerLb.Name = "copperPlayerLb";
            copperPlayerLb.Size = new Size(0, 28);
            copperPlayerLb.TabIndex = 6;
            copperPlayerLb.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // headerLb
            // 
            headerLb.BackColor = Color.White;
            headerLb.BorderStyle = BorderStyle.FixedSingle;
            headerLb.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
            headerLb.ForeColor = Color.Black;
            headerLb.Location = new Point(64, 9);
            headerLb.Name = "headerLb";
            headerLb.Size = new Size(834, 63);
            headerLb.TabIndex = 7;
            headerLb.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // backButton
            // 
            backButton.AutoSize = true;
            backButton.BackColor = Color.Blue;
            backButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            backButton.ForeColor = Color.White;
            backButton.Location = new Point(772, 111);
            backButton.Name = "backButton";
            backButton.Size = new Size(126, 38);
            backButton.TabIndex = 8;
            backButton.Text = "Next";
            backButton.UseVisualStyleBackColor = false;
            backButton.Click += backButton_Click;
            // 
            // Podium
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkBlue;
            ClientSize = new Size(943, 522);
            Controls.Add(backButton);
            Controls.Add(headerLb);
            Controls.Add(copperPlayerLb);
            Controls.Add(goldenPlayerLb);
            Controls.Add(silverPlayerLb);
            Controls.Add(copperLb);
            Controls.Add(goldenLb);
            Controls.Add(silverLb);
            Name = "Podium";
            Text = "podium";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label silverLb;
        private Label goldenLb;
        private ImageList imageList;
        private Label copperLb;
        private Label silverPlayerLb;
        private Label goldenPlayerLb;
        private Label copperPlayerLb;
        private Label headerLb;
        private Button backButton;
    }
}