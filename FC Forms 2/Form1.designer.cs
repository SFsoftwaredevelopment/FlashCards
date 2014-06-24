using System;
using System.IO;
namespace WindowsFormsApplication1
{
    partial class Form1
    {
        private const string FILE_NAME = "C:\\Cards\\Categories.txt";        
        
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
            
            string[] text = File.ReadAllLines(FILE_NAME);
            this.addButton = new System.Windows.Forms.Button();
            this.gb = new System.Windows.Forms.GroupBox();
            this.cb = new System.Windows.Forms.CheckBox[text.Length];
            //this.diffCB = new System.Windows.Forms.CheckBox[10];
            //this.gradeCB = new System.Windows.Forms.CheckBox[13];
            this.dif = new System.Windows.Forms.Label();
            this.gradeL = new System.Windows.Forms.Label();
            this.gradeCB = new System.Windows.Forms.ComboBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            gradeCB.Name = "gradeLevelComboBox";
            gradeCB.Size = new System.Drawing.Size(245, 45);

            for (int i = 0; i < cb.Length; i++)
            {
                cb[i] = new System.Windows.Forms.CheckBox();

                gb.Controls.Add(cb[i]);
               
                cb[i].Location = new System.Drawing.Point(6, ((20 * i) + 20));

                cb[i].Text = text[i];
            }
            /*for (int i = 0; i < diffCB.Length; i++)
            {
                diffCB[i] = new System.Windows.Forms.CheckBox();

                gb.Controls.Add(diffCB[i]);

                diffCB[i].Location = new System.Drawing.Point(330, ((20 * i) + 180));

                diffCB[i].Text = i.ToString();
            }*/
            //
            //numericUpDown1
            //
            this.numericUpDown1.Location = new System.Drawing.Point(328, 180);
            this.numericUpDown1.Maximum = new System.Decimal(new int[] {9,0,0,0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(50,60);
            this.numericUpDown1.TabIndex = 0;
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            gb.Controls.Add(numericUpDown1);
            /*for (int i = 0; i < gradeCB.Length; i++)
            {
                gradeCB[i] = new System.Windows.Forms.CheckBox();

                gb.Controls.Add(gradeCB[i]);

                gradeCB[i].Location = new System.Drawing.Point(330, ((20 * i) + 40));
            }*/
            
            this.gb.SuspendLayout();
            this.SuspendLayout();
            //
            //gb
            //
            //this.gb.BackColor = System.Drawing.SystemColors.WindowText;
            //
            //addButton
            //
            this.addButton.Text = "Add";
            this.addButton.Size = new System.Drawing.Size(88, 40);
            this.addButton.Location = new System.Drawing.Point(300, 300);
            this.addButton.Enabled = true;
            this.addButton.Visible = true;
            this.addButton.Click += new System.EventHandler(addButton_Click);

            gb.Controls.Add(addButton);
            gb.Controls.Add(dif);
            gb.Controls.Add(gradeL);

            this.gb.Location = new System.Drawing.Point(13, 12);
            this.gb.Size = new System.Drawing.Size(550, 350);
            this.gb.Text = "Categories";
            this.gb.TabIndex = 0;

            for (int i = 0; i < cb.Length; i++)
            {
                //cb[i].BackColor = System.Drawing.SystemColors.Window;
                //cb[i].ForeColor = System.Drawing.SystemColors.WindowText;
                    cb[i].Size = new System.Drawing.Size(231, 17);
                    cb[i].TabIndex = i + 1;
            }//tabindex?--> can't combine into loop up top

            /*for (int i = 0; i < diffCB.Length; i++)
            {
                diffCB[i].Size = new System.Drawing.Size(231, 17);
                diffCB[i].TabIndex = i + 1;
            }*/

            /*for (int i = 0; i < gradeCB.Length; i++)
            {
                gradeCB[i].Size = new System.Drawing.Size(231, 17);
                gradeCB[i].TabIndex = i + 1;
            }*/

            dif.Size = new System.Drawing.Size(231, 17);
            gradeL.Size = new System.Drawing.Size(231, 17);

            gradeL.Location = new System.Drawing.Point(325, 20);
                             
            dif.Location = new System.Drawing.Point(328, 165);

            dif.Text = "Difficulty";
                        
            gradeL.Text = "Grade";
            gradeCB.Location = new System.Drawing.Point(300, 45);
            gradeL.Size = new System.Drawing.Size(150, 17);
            gradeCB.Items.Add("Kindergarten");
            gradeCB.Items.Add("1st Grade");
            gradeCB.Items.Add("2nd Grade");
            gradeCB.Items.Add("3rd Grade");
            gradeCB.Items.Add("4th Grade");
            gradeCB.Items.Add("5th Grade");
            gradeCB.Items.Add("6th Grade");
            gradeCB.Items.Add("7th Grade");
            gradeCB.Items.Add("8th Grade");
            gradeCB.Items.Add("9th Grade");
            gradeCB.Items.Add("10th Grade");
            gradeCB.Items.Add("11th Grade");
            gradeCB.Items.Add("12th Grade");
            gb.Controls.Add(gradeCB);
            
            /*gradeCB[1].Text = "1st Grade";
            gradeCB[2].Text = "2nd Grade";
            gradeCB[3].Text = "3rd Grade";
            gradeCB[4].Text = "4th Grade";*/
            
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Text = "Add Categories";
            this.Controls.Add(this.gb);
            //this.Controls.Add(this.addButton);
            this.ClientSize = new System.Drawing.Size(600, 400);
            this.gb.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion
        public System.Windows.Forms.CheckBox[] cb;
        public System.Windows.Forms.Button addButton;
        private System.Windows.Forms.GroupBox gb;
        //public System.Windows.Forms.CheckBox[] diffCB;
        //public System.Windows.Forms.CheckBox[] gradeCB;
        private System.Windows.Forms.Label dif;
        private System.Windows.Forms.Label gradeL;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.ComboBox gradeCB;
    }
}

