namespace WindowsFormsApplication1
{
    partial class MixMatchTeacher
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MixMatchTeacher));
            this.HomeB = new System.Windows.Forms.Button();
            this.SaveB = new System.Windows.Forms.Button();
            this.SaveD = new System.Windows.Forms.SaveFileDialog();
            this.OpenB = new System.Windows.Forms.Button();
            this.OpenD = new System.Windows.Forms.OpenFileDialog();
            this.DeleteB = new System.Windows.Forms.Button();
            this.AddB = new System.Windows.Forms.Button();
            this.currentL = new System.Windows.Forms.Label();
            this.PreviousThumbB = new System.Windows.Forms.Button();
            this.nextThumbB = new System.Windows.Forms.Button();
            this.thumb3 = new System.Windows.Forms.Panel();
            this.thumb4 = new System.Windows.Forms.Panel();
            this.thumb5 = new System.Windows.Forms.Panel();
            this.thumb2 = new System.Windows.Forms.Panel();
            this.thumb1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.nextThumbButton = new System.Windows.Forms.Button();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.newL = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // HomeB
            // 
            this.HomeB.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("HomeB.BackgroundImage")));
            this.HomeB.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.HomeB.Location = new System.Drawing.Point(650, 5);
            this.HomeB.Name = "HomeB";
            this.HomeB.Size = new System.Drawing.Size(36, 36);
            this.HomeB.TabIndex = 30;
            this.HomeB.UseVisualStyleBackColor = true;
            this.HomeB.Click += new System.EventHandler(this.HomeB_Click);
            // 
            // SaveB
            // 
            this.SaveB.Location = new System.Drawing.Point(228, 159);
            this.SaveB.Name = "SaveB";
            this.SaveB.Size = new System.Drawing.Size(144, 39);
            this.SaveB.TabIndex = 28;
            this.SaveB.Text = "Save New Deck";
            this.SaveB.UseVisualStyleBackColor = true;
            // 
            // OpenB
            // 
            this.OpenB.Location = new System.Drawing.Point(529, 159);
            this.OpenB.Name = "OpenB";
            this.OpenB.Size = new System.Drawing.Size(157, 39);
            this.OpenB.TabIndex = 29;
            this.OpenB.Text = "Open Different Deck";
            this.OpenB.UseVisualStyleBackColor = true;
            // 
            // OpenD
            // 
            this.OpenD.FileName = "OpenD";
            // 
            // DeleteB
            // 
            this.DeleteB.Location = new System.Drawing.Point(378, 159);
            this.DeleteB.Name = "DeleteB";
            this.DeleteB.Size = new System.Drawing.Size(145, 39);
            this.DeleteB.TabIndex = 25;
            this.DeleteB.Text = "Delete Current Card";
            this.DeleteB.UseVisualStyleBackColor = true;
            // 
            // AddB
            // 
            this.AddB.Location = new System.Drawing.Point(68, 159);
            this.AddB.Name = "AddB";
            this.AddB.Size = new System.Drawing.Size(154, 39);
            this.AddB.TabIndex = 22;
            this.AddB.Text = "Add to New Deck";
            this.AddB.UseVisualStyleBackColor = true;
            // 
            // currentL
            // 
            this.currentL.AutoSize = true;
            this.currentL.Location = new System.Drawing.Point(330, 19);
            this.currentL.Name = "currentL";
            this.currentL.Size = new System.Drawing.Size(70, 13);
            this.currentL.TabIndex = 18;
            this.currentL.Text = "Current Deck";
            // 
            // PreviousThumbB
            // 
            this.PreviousThumbB.BackColor = System.Drawing.SystemColors.ControlDark;
            this.PreviousThumbB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PreviousThumbB.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.PreviousThumbB.Location = new System.Drawing.Point(3, 246);
            this.PreviousThumbB.Name = "PreviousThumbB";
            this.PreviousThumbB.Size = new System.Drawing.Size(33, 101);
            this.PreviousThumbB.TabIndex = 45;
            this.PreviousThumbB.Text = "<<";
            this.PreviousThumbB.UseVisualStyleBackColor = false;
            // 
            // nextThumbB
            // 
            this.nextThumbB.BackColor = System.Drawing.SystemColors.ControlDark;
            this.nextThumbB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.nextThumbB.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.nextThumbB.Location = new System.Drawing.Point(695, 246);
            this.nextThumbB.Name = "nextThumbB";
            this.nextThumbB.Size = new System.Drawing.Size(33, 101);
            this.nextThumbB.TabIndex = 44;
            this.nextThumbB.Text = ">>";
            this.nextThumbB.UseVisualStyleBackColor = false;
            // 
            // thumb3
            // 
            this.thumb3.AutoSize = true;
            this.thumb3.BackColor = System.Drawing.Color.White;
            this.thumb3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.thumb3.Location = new System.Drawing.Point(305, 246);
            this.thumb3.Name = "thumb3";
            this.thumb3.Size = new System.Drawing.Size(124, 81);
            this.thumb3.TabIndex = 43;
            // 
            // thumb4
            // 
            this.thumb4.AutoSize = true;
            this.thumb4.BackColor = System.Drawing.Color.White;
            this.thumb4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.thumb4.Location = new System.Drawing.Point(435, 246);
            this.thumb4.Name = "thumb4";
            this.thumb4.Size = new System.Drawing.Size(124, 81);
            this.thumb4.TabIndex = 42;
            // 
            // thumb5
            // 
            this.thumb5.AutoSize = true;
            this.thumb5.BackColor = System.Drawing.Color.White;
            this.thumb5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.thumb5.Location = new System.Drawing.Point(565, 246);
            this.thumb5.Name = "thumb5";
            this.thumb5.Size = new System.Drawing.Size(124, 81);
            this.thumb5.TabIndex = 41;
            // 
            // thumb2
            // 
            this.thumb2.AutoSize = true;
            this.thumb2.BackColor = System.Drawing.Color.White;
            this.thumb2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.thumb2.Location = new System.Drawing.Point(172, 246);
            this.thumb2.Name = "thumb2";
            this.thumb2.Size = new System.Drawing.Size(124, 81);
            this.thumb2.TabIndex = 40;
            // 
            // thumb1
            // 
            this.thumb1.AutoSize = true;
            this.thumb1.BackColor = System.Drawing.Color.White;
            this.thumb1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.thumb1.Location = new System.Drawing.Point(42, 246);
            this.thumb1.Name = "thumb1";
            this.thumb1.Size = new System.Drawing.Size(124, 81);
            this.thumb1.TabIndex = 39;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.button1.Location = new System.Drawing.Point(3, 47);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(33, 100);
            this.button1.TabIndex = 52;
            this.button1.Text = "<<";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // nextThumbButton
            // 
            this.nextThumbButton.BackColor = System.Drawing.SystemColors.ControlDark;
            this.nextThumbButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.nextThumbButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.nextThumbButton.Location = new System.Drawing.Point(695, 47);
            this.nextThumbButton.Name = "nextThumbButton";
            this.nextThumbButton.Size = new System.Drawing.Size(33, 100);
            this.nextThumbButton.TabIndex = 51;
            this.nextThumbButton.Text = ">>";
            this.nextThumbButton.UseVisualStyleBackColor = false;
            // 
            // panel7
            // 
            this.panel7.AutoSize = true;
            this.panel7.BackColor = System.Drawing.Color.White;
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel7.Location = new System.Drawing.Point(305, 47);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(124, 81);
            this.panel7.TabIndex = 50;
            // 
            // panel6
            // 
            this.panel6.AutoSize = true;
            this.panel6.BackColor = System.Drawing.Color.White;
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Location = new System.Drawing.Point(435, 47);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(124, 81);
            this.panel6.TabIndex = 49;
            // 
            // panel5
            // 
            this.panel5.AutoSize = true;
            this.panel5.BackColor = System.Drawing.Color.White;
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Location = new System.Drawing.Point(565, 47);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(124, 81);
            this.panel5.TabIndex = 48;
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(172, 47);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(124, 81);
            this.panel1.TabIndex = 47;
            // 
            // panel2
            // 
            this.panel2.AutoSize = true;
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Location = new System.Drawing.Point(42, 47);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(124, 81);
            this.panel2.TabIndex = 46;
            // 
            // newL
            // 
            this.newL.AutoSize = true;
            this.newL.Location = new System.Drawing.Point(330, 216);
            this.newL.Name = "newL";
            this.newL.Size = new System.Drawing.Size(58, 13);
            this.newL.TabIndex = 53;
            this.newL.Text = "New Deck";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 135);
            this.label1.MaximumSize = new System.Drawing.Size(121, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 54;
            this.label1.Text = "Standard";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(172, 135);
            this.label2.MaximumSize = new System.Drawing.Size(121, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 55;
            this.label2.Text = "Standard";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(302, 135);
            this.label3.MaximumSize = new System.Drawing.Size(121, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 56;
            this.label3.Text = "Standard";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(435, 134);
            this.label4.MaximumSize = new System.Drawing.Size(121, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 57;
            this.label4.Text = "Standard";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(562, 134);
            this.label5.MaximumSize = new System.Drawing.Size(121, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 58;
            this.label5.Text = "Standard";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(42, 334);
            this.label6.MaximumSize = new System.Drawing.Size(121, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 13);
            this.label6.TabIndex = 59;
            this.label6.Text = "Standard";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(175, 334);
            this.label7.MaximumSize = new System.Drawing.Size(121, 13);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 13);
            this.label7.TabIndex = 60;
            this.label7.Text = "Standard";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(305, 334);
            this.label8.MaximumSize = new System.Drawing.Size(121, 13);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 13);
            this.label8.TabIndex = 61;
            this.label8.Text = "Standard";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(435, 334);
            this.label9.MaximumSize = new System.Drawing.Size(121, 13);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(50, 13);
            this.label9.TabIndex = 62;
            this.label9.Text = "Standard";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(565, 334);
            this.label10.MaximumSize = new System.Drawing.Size(121, 13);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(50, 13);
            this.label10.TabIndex = 63;
            this.label10.Text = "Standard";
            // 
            // MixMatchTeacher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(743, 363);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.newL);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.nextThumbButton);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.PreviousThumbB);
            this.Controls.Add(this.nextThumbB);
            this.Controls.Add(this.thumb3);
            this.Controls.Add(this.thumb4);
            this.Controls.Add(this.thumb5);
            this.Controls.Add(this.thumb2);
            this.Controls.Add(this.thumb1);
            this.Controls.Add(this.HomeB);
            this.Controls.Add(this.SaveB);
            this.Controls.Add(this.OpenB);
            this.Controls.Add(this.DeleteB);
            this.Controls.Add(this.AddB);
            this.Controls.Add(this.currentL);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MixMatchTeacher";
            this.Text = "Mix and Match";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button HomeB;
        private System.Windows.Forms.Button SaveB;
        private System.Windows.Forms.SaveFileDialog SaveD;
        private System.Windows.Forms.Button OpenB;
        private System.Windows.Forms.OpenFileDialog OpenD;
        private System.Windows.Forms.Button DeleteB;
        private System.Windows.Forms.Button AddB;
        private System.Windows.Forms.Label currentL;
        private System.Windows.Forms.Button PreviousThumbB;
        private System.Windows.Forms.Button nextThumbB;
        private System.Windows.Forms.Panel thumb3;
        private System.Windows.Forms.Panel thumb4;
        private System.Windows.Forms.Panel thumb5;
        private System.Windows.Forms.Panel thumb2;
        private System.Windows.Forms.Panel thumb1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button nextThumbButton;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label newL;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
    }
}