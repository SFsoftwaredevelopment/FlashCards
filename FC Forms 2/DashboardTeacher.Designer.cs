namespace WindowsFormsApplication1
{
    partial class DashboardTeacher
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DashboardTeacher));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.playGameP = new System.Windows.Forms.Panel();
            this.createCardsP = new System.Windows.Forms.Panel();
            this.mixMatchP = new System.Windows.Forms.Panel();
            this.exitP = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "Testing.fc";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(35, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 31);
            this.label1.TabIndex = 16;
            this.label1.Text = "label1";
            // 
            // playGameP
            // 
            this.playGameP.BackColor = System.Drawing.Color.Transparent;
            this.playGameP.Location = new System.Drawing.Point(26, 590);
            this.playGameP.Name = "playGameP";
            this.playGameP.Size = new System.Drawing.Size(228, 99);
            this.playGameP.TabIndex = 17;
            this.playGameP.Click += new System.EventHandler(this.playGameB_Click);
            // 
            // createCardsP
            // 
            this.createCardsP.BackColor = System.Drawing.Color.Transparent;
            this.createCardsP.Location = new System.Drawing.Point(260, 590);
            this.createCardsP.Name = "createCardsP";
            this.createCardsP.Size = new System.Drawing.Size(234, 99);
            this.createCardsP.TabIndex = 18;
            this.createCardsP.Click += new System.EventHandler(this.createCardsB_Click);
            // 
            // mixMatchP
            // 
            this.mixMatchP.BackColor = System.Drawing.Color.Transparent;
            this.mixMatchP.Location = new System.Drawing.Point(511, 590);
            this.mixMatchP.Name = "mixMatchP";
            this.mixMatchP.Size = new System.Drawing.Size(227, 99);
            this.mixMatchP.TabIndex = 19;
            this.mixMatchP.Click += new System.EventHandler(this.mixMatchB_Click);
            // 
            // exitP
            // 
            this.exitP.BackColor = System.Drawing.Color.Transparent;
            this.exitP.Location = new System.Drawing.Point(744, 590);
            this.exitP.Name = "exitP";
            this.exitP.Size = new System.Drawing.Size(237, 99);
            this.exitP.TabIndex = 20;
            this.exitP.Click += new System.EventHandler(this.linkLabel1_LinkClicked);
            // 
            // DashboardTeacher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.Controls.Add(this.exitP);
            this.Controls.Add(this.mixMatchP);
            this.Controls.Add(this.createCardsP);
            this.Controls.Add(this.playGameP);
            this.Controls.Add(this.label1);
            this.Name = "DashboardTeacher";
            this.Size = new System.Drawing.Size(1000, 700);
            this.Load += new System.EventHandler(this.TeacherDashboard_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel playGameP;
        private System.Windows.Forms.Panel createCardsP;
        private System.Windows.Forms.Panel mixMatchP;
        private System.Windows.Forms.Panel exitP;
    }
}