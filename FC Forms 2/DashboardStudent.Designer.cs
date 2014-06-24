namespace WindowsFormsApplication1
{
    partial class DashboardStudent
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DashboardStudent));
            this.label3 = new System.Windows.Forms.Label();
            this.playGameP = new System.Windows.Forms.Panel();
            this.createCardsP = new System.Windows.Forms.Panel();
            this.exitP = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 23F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(49, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 35);
            this.label3.TabIndex = 15;
            this.label3.Text = "label3";
            // 
            // playGameP
            // 
            this.playGameP.BackColor = System.Drawing.Color.Transparent;
            this.playGameP.Location = new System.Drawing.Point(23, 587);
            this.playGameP.Name = "playGameP";
            this.playGameP.Size = new System.Drawing.Size(234, 85);
            this.playGameP.TabIndex = 16;
            this.playGameP.Click += new System.EventHandler(this.playGameB_Click);
            // 
            // createCardsP
            // 
            this.createCardsP.BackColor = System.Drawing.Color.Transparent;
            this.createCardsP.Enabled = false;
            this.createCardsP.Location = new System.Drawing.Point(264, 587);
            this.createCardsP.Name = "createCardsP";
            this.createCardsP.Size = new System.Drawing.Size(475, 96);
            this.createCardsP.TabIndex = 17;
            this.createCardsP.Click += new System.EventHandler(this.createCardsB_Click);
            // 
            // exitP
            // 
            this.exitP.BackColor = System.Drawing.Color.Transparent;
            this.exitP.Location = new System.Drawing.Point(746, 587);
            this.exitP.Name = "exitP";
            this.exitP.Size = new System.Drawing.Size(232, 100);
            this.exitP.TabIndex = 18;
            this.exitP.Click += new System.EventHandler(this.exitP_Click);
            // 
            // DashboardStudent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.Controls.Add(this.exitP);
            this.Controls.Add(this.createCardsP);
            this.Controls.Add(this.playGameP);
            this.Controls.Add(this.label3);
            this.Name = "DashboardStudent";
            this.Size = new System.Drawing.Size(994, 672);
            this.Load += new System.EventHandler(this.DashboardStudent_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel playGameP;
        private System.Windows.Forms.Panel createCardsP;
        private System.Windows.Forms.Panel exitP;
    }
}