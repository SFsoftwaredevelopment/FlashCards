namespace WindowsFormsApplication1
{
    partial class AutoMath
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AutoMath));
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.difficultySlider = new System.Windows.Forms.TrackBar();
            this.genP = new System.Windows.Forms.Panel();
            this.multP = new System.Windows.Forms.Panel();
            this.divideP = new System.Windows.Forms.Panel();
            this.subP = new System.Windows.Forms.Panel();
            this.addP = new System.Windows.Forms.Panel();
            this.homeP = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.difficultySlider)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(345, 437);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(174, 25);
            this.label2.TabIndex = 11;
            this.label2.Text = "Number of Cards";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label1.Location = new System.Drawing.Point(458, 256);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 26);
            this.label1.TabIndex = 10;
            this.label1.Text = "Difficulty";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDown1.Location = new System.Drawing.Point(589, 431);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(42, 31);
            this.numericUpDown1.TabIndex = 9;
            // 
            // difficultySlider
            // 
            this.difficultySlider.Location = new System.Drawing.Point(350, 294);
            this.difficultySlider.Maximum = 2;
            this.difficultySlider.Name = "difficultySlider";
            this.difficultySlider.Size = new System.Drawing.Size(319, 45);
            this.difficultySlider.TabIndex = 8;
            // 
            // genP
            // 
            this.genP.BackColor = System.Drawing.Color.Transparent;
            this.genP.Location = new System.Drawing.Point(292, 532);
            this.genP.Name = "genP";
            this.genP.Size = new System.Drawing.Size(409, 120);
            this.genP.TabIndex = 15;
            this.genP.Click += new System.EventHandler(this.generateButton_Click);
            // 
            // multP
            // 
            this.multP.BackColor = System.Drawing.Color.Transparent;
            this.multP.Location = new System.Drawing.Point(528, 33);
            this.multP.Name = "multP";
            this.multP.Size = new System.Drawing.Size(200, 185);
            this.multP.TabIndex = 16;
            this.multP.Click += new System.EventHandler(this.multButton_Click);
            // 
            // divideP
            // 
            this.divideP.BackColor = System.Drawing.Color.Transparent;
            this.divideP.Location = new System.Drawing.Point(778, 33);
            this.divideP.Name = "divideP";
            this.divideP.Size = new System.Drawing.Size(200, 185);
            this.divideP.TabIndex = 17;
            this.divideP.Click += new System.EventHandler(this.divButton_Click);
            // 
            // subP
            // 
            this.subP.BackColor = System.Drawing.Color.Transparent;
            this.subP.Location = new System.Drawing.Point(275, 33);
            this.subP.Name = "subP";
            this.subP.Size = new System.Drawing.Size(200, 185);
            this.subP.TabIndex = 18;
            this.subP.Click += new System.EventHandler(this.subButton_Click);
            // 
            // addP
            // 
            this.addP.BackColor = System.Drawing.Color.Transparent;
            this.addP.Location = new System.Drawing.Point(24, 33);
            this.addP.Name = "addP";
            this.addP.Size = new System.Drawing.Size(200, 176);
            this.addP.TabIndex = 19;
            this.addP.Click += new System.EventHandler(this.addButton_Click);
            // 
            // homeP
            // 
            this.homeP.BackColor = System.Drawing.Color.Transparent;
            this.homeP.Location = new System.Drawing.Point(902, 607);
            this.homeP.Name = "homeP";
            this.homeP.Size = new System.Drawing.Size(76, 71);
            this.homeP.TabIndex = 20;
            this.homeP.Click += new System.EventHandler(this.homeP_Click);
            // 
            // AutoMath
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.Controls.Add(this.homeP);
            this.Controls.Add(this.addP);
            this.Controls.Add(this.subP);
            this.Controls.Add(this.divideP);
            this.Controls.Add(this.multP);
            this.Controls.Add(this.genP);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.difficultySlider);
            this.Name = "AutoMath";
            this.Size = new System.Drawing.Size(1000, 700);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.difficultySlider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.TrackBar difficultySlider;
        private System.Windows.Forms.Panel genP;
        private System.Windows.Forms.Panel multP;
        private System.Windows.Forms.Panel divideP;
        private System.Windows.Forms.Panel subP;
        private System.Windows.Forms.Panel addP;
        private System.Windows.Forms.Panel homeP;
    }
}
