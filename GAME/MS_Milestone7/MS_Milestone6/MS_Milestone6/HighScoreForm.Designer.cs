namespace MS_Milestone6
{
    partial class HighScoreForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlHS = new System.Windows.Forms.Panel();
            this.HSdatagv = new System.Windows.Forms.DataGridView();
            this.pnlHSMenu = new System.Windows.Forms.Panel();
            this.hardBtn = new System.Windows.Forms.Button();
            this.medBtn = new System.Windows.Forms.Button();
            this.easyBtn = new System.Windows.Forms.Button();
            this.mainMenuBtn = new System.Windows.Forms.Button();
            this.pnlHS.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HSdatagv)).BeginInit();
            this.pnlHSMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHS
            // 
            this.pnlHS.Controls.Add(this.HSdatagv);
            this.pnlHS.Location = new System.Drawing.Point(12, 91);
            this.pnlHS.Name = "pnlHS";
            this.pnlHS.Size = new System.Drawing.Size(410, 308);
            this.pnlHS.TabIndex = 0;
            // 
            // HSdatagv
            // 
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.HSdatagv.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.HSdatagv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.HSdatagv.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.HSdatagv.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.HSdatagv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.HSdatagv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.HSdatagv.DefaultCellStyle = dataGridViewCellStyle3;
            this.HSdatagv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HSdatagv.Enabled = false;
            this.HSdatagv.Location = new System.Drawing.Point(0, 0);
            this.HSdatagv.Name = "HSdatagv";
            this.HSdatagv.RowHeadersVisible = false;
            this.HSdatagv.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.HSdatagv.ShowCellErrors = false;
            this.HSdatagv.ShowCellToolTips = false;
            this.HSdatagv.ShowEditingIcon = false;
            this.HSdatagv.ShowRowErrors = false;
            this.HSdatagv.Size = new System.Drawing.Size(410, 308);
            this.HSdatagv.TabIndex = 0;
            // 
            // pnlHSMenu
            // 
            this.pnlHSMenu.Controls.Add(this.hardBtn);
            this.pnlHSMenu.Controls.Add(this.medBtn);
            this.pnlHSMenu.Controls.Add(this.easyBtn);
            this.pnlHSMenu.Controls.Add(this.mainMenuBtn);
            this.pnlHSMenu.Location = new System.Drawing.Point(12, 12);
            this.pnlHSMenu.Name = "pnlHSMenu";
            this.pnlHSMenu.Size = new System.Drawing.Size(410, 73);
            this.pnlHSMenu.TabIndex = 1;
            // 
            // hardBtn
            // 
            this.hardBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.hardBtn.Location = new System.Drawing.Point(317, 15);
            this.hardBtn.Name = "hardBtn";
            this.hardBtn.Size = new System.Drawing.Size(75, 47);
            this.hardBtn.TabIndex = 3;
            this.hardBtn.Text = "Hard";
            this.hardBtn.UseVisualStyleBackColor = false;
            this.hardBtn.Click += new System.EventHandler(this.hardBtn_Click);
            // 
            // medBtn
            // 
            this.medBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.medBtn.Location = new System.Drawing.Point(236, 15);
            this.medBtn.Name = "medBtn";
            this.medBtn.Size = new System.Drawing.Size(75, 47);
            this.medBtn.TabIndex = 2;
            this.medBtn.Text = "Medium";
            this.medBtn.UseVisualStyleBackColor = false;
            this.medBtn.Click += new System.EventHandler(this.medBtn_Click);
            // 
            // easyBtn
            // 
            this.easyBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.easyBtn.Location = new System.Drawing.Point(155, 15);
            this.easyBtn.Name = "easyBtn";
            this.easyBtn.Size = new System.Drawing.Size(75, 47);
            this.easyBtn.TabIndex = 1;
            this.easyBtn.Text = "Easy";
            this.easyBtn.UseVisualStyleBackColor = false;
            this.easyBtn.Click += new System.EventHandler(this.easyBtn_Click);
            // 
            // mainMenuBtn
            // 
            this.mainMenuBtn.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.mainMenuBtn.Location = new System.Drawing.Point(19, 15);
            this.mainMenuBtn.Name = "mainMenuBtn";
            this.mainMenuBtn.Size = new System.Drawing.Size(75, 47);
            this.mainMenuBtn.TabIndex = 0;
            this.mainMenuBtn.Text = "Main Menu";
            this.mainMenuBtn.UseVisualStyleBackColor = false;
            this.mainMenuBtn.Click += new System.EventHandler(this.mainMenuBtn_Click);
            // 
            // HighScoreForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 411);
            this.Controls.Add(this.pnlHSMenu);
            this.Controls.Add(this.pnlHS);
            this.Name = "HighScoreForm";
            this.Text = "HighScoreForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.HighScoreForm_FormClosed);
            this.pnlHS.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.HSdatagv)).EndInit();
            this.pnlHSMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHS;
        private System.Windows.Forms.DataGridView HSdatagv;
        private System.Windows.Forms.Panel pnlHSMenu;
        private System.Windows.Forms.Button hardBtn;
        private System.Windows.Forms.Button medBtn;
        private System.Windows.Forms.Button easyBtn;
        private System.Windows.Forms.Button mainMenuBtn;
    }
}