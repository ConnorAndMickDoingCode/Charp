namespace MS_Milestone6
{
    partial class MainMenu
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
            this.MSHeading = new System.Windows.Forms.Label();
            this.radEasy = new System.Windows.Forms.RadioButton();
            this.radMed = new System.Windows.Forms.RadioButton();
            this.radHard = new System.Windows.Forms.RadioButton();
            this.radCustom = new System.Windows.Forms.RadioButton();
            this.WidthLabel = new System.Windows.Forms.Label();
            this.tbCol = new System.Windows.Forms.TextBox();
            this.HeightLabel = new System.Windows.Forms.Label();
            this.tbRow = new System.Windows.Forms.TextBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.lblPlayer = new System.Windows.Forms.Label();
            this.tbPlayer = new System.Windows.Forms.TextBox();
            this.HSBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // MSHeading
            // 
            this.MSHeading.AutoSize = true;
            this.MSHeading.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MSHeading.Location = new System.Drawing.Point(63, 26);
            this.MSHeading.Name = "MSHeading";
            this.MSHeading.Size = new System.Drawing.Size(218, 20);
            this.MSHeading.TabIndex = 0;
            this.MSHeading.Text = "Welcome to Minesweeper!";
            // 
            // radEasy
            // 
            this.radEasy.AutoSize = true;
            this.radEasy.Location = new System.Drawing.Point(45, 71);
            this.radEasy.Name = "radEasy";
            this.radEasy.Size = new System.Drawing.Size(89, 17);
            this.radEasy.TabIndex = 1;
            this.radEasy.TabStop = true;
            this.radEasy.Text = "Easy: 10 x 10";
            this.radEasy.UseVisualStyleBackColor = true;
            // 
            // radMed
            // 
            this.radMed.AutoSize = true;
            this.radMed.Location = new System.Drawing.Point(45, 103);
            this.radMed.Name = "radMed";
            this.radMed.Size = new System.Drawing.Size(103, 17);
            this.radMed.TabIndex = 2;
            this.radMed.TabStop = true;
            this.radMed.Text = "Medium: 15 x 15";
            this.radMed.UseVisualStyleBackColor = true;
            // 
            // radHard
            // 
            this.radHard.AutoSize = true;
            this.radHard.Location = new System.Drawing.Point(45, 136);
            this.radHard.Name = "radHard";
            this.radHard.Size = new System.Drawing.Size(89, 17);
            this.radHard.TabIndex = 3;
            this.radHard.TabStop = true;
            this.radHard.Text = "Hard: 20 x 20";
            this.radHard.UseVisualStyleBackColor = true;
            // 
            // radCustom
            // 
            this.radCustom.AutoSize = true;
            this.radCustom.Location = new System.Drawing.Point(45, 185);
            this.radCustom.Name = "radCustom";
            this.radCustom.Size = new System.Drawing.Size(110, 17);
            this.radCustom.TabIndex = 4;
            this.radCustom.TabStop = true;
            this.radCustom.Text = "Custom: [MAX 30]";
            this.radCustom.UseVisualStyleBackColor = true;
            // 
            // WidthLabel
            // 
            this.WidthLabel.AutoSize = true;
            this.WidthLabel.Location = new System.Drawing.Point(42, 225);
            this.WidthLabel.Name = "WidthLabel";
            this.WidthLabel.Size = new System.Drawing.Size(38, 13);
            this.WidthLabel.TabIndex = 5;
            this.WidthLabel.Text = "Width:";
            // 
            // tbCol
            // 
            this.tbCol.Location = new System.Drawing.Point(86, 222);
            this.tbCol.Name = "tbCol";
            this.tbCol.Size = new System.Drawing.Size(66, 20);
            this.tbCol.TabIndex = 6;
            // 
            // HeightLabel
            // 
            this.HeightLabel.AutoSize = true;
            this.HeightLabel.Location = new System.Drawing.Point(177, 225);
            this.HeightLabel.Name = "HeightLabel";
            this.HeightLabel.Size = new System.Drawing.Size(41, 13);
            this.HeightLabel.TabIndex = 7;
            this.HeightLabel.Text = "Height:";
            // 
            // tbRow
            // 
            this.tbRow.Location = new System.Drawing.Point(224, 222);
            this.tbRow.Name = "tbRow";
            this.tbRow.Size = new System.Drawing.Size(66, 20);
            this.tbRow.TabIndex = 8;
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnStart.Location = new System.Drawing.Point(126, 261);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 9;
            this.btnStart.Text = "Play Game";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lblPlayer
            // 
            this.lblPlayer.AutoSize = true;
            this.lblPlayer.Location = new System.Drawing.Point(197, 62);
            this.lblPlayer.Name = "lblPlayer";
            this.lblPlayer.Size = new System.Drawing.Size(75, 13);
            this.lblPlayer.TabIndex = 10;
            this.lblPlayer.Text = "Enter a Name:";
            // 
            // tbPlayer
            // 
            this.tbPlayer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.tbPlayer.Location = new System.Drawing.Point(190, 87);
            this.tbPlayer.MaxLength = 8;
            this.tbPlayer.Name = "tbPlayer";
            this.tbPlayer.Size = new System.Drawing.Size(100, 20);
            this.tbPlayer.TabIndex = 11;
            // 
            // HSBtn
            // 
            this.HSBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.HSBtn.Location = new System.Drawing.Point(185, 133);
            this.HSBtn.Name = "HSBtn";
            this.HSBtn.Size = new System.Drawing.Size(105, 23);
            this.HSBtn.TabIndex = 12;
            this.HSBtn.Text = "View Highscores";
            this.HSBtn.UseVisualStyleBackColor = false;
            this.HSBtn.Click += new System.EventHandler(this.HSBtn_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(334, 311);
            this.Controls.Add(this.HSBtn);
            this.Controls.Add(this.tbPlayer);
            this.Controls.Add(this.lblPlayer);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.tbRow);
            this.Controls.Add(this.HeightLabel);
            this.Controls.Add(this.tbCol);
            this.Controls.Add(this.WidthLabel);
            this.Controls.Add(this.radCustom);
            this.Controls.Add(this.radHard);
            this.Controls.Add(this.radMed);
            this.Controls.Add(this.radEasy);
            this.Controls.Add(this.MSHeading);
            this.Name = "MainMenu";
            this.Text = "MainMenu";
            this.Load += new System.EventHandler(this.MainMenu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label MSHeading;
        private System.Windows.Forms.RadioButton radEasy;
        private System.Windows.Forms.RadioButton radMed;
        private System.Windows.Forms.RadioButton radHard;
        private System.Windows.Forms.RadioButton radCustom;
        private System.Windows.Forms.Label WidthLabel;
        private System.Windows.Forms.TextBox tbCol;
        private System.Windows.Forms.Label HeightLabel;
        private System.Windows.Forms.TextBox tbRow;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label lblPlayer;
        private System.Windows.Forms.TextBox tbPlayer;
        private System.Windows.Forms.Button HSBtn;
    }
}