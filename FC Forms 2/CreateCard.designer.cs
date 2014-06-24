using System;
namespace WindowsFormsApplication1
{
    partial class CreateCard
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateCard));
            this.frontPanel = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.clearFrontB = new System.Windows.Forms.Button();
            this.BackPanel = new System.Windows.Forms.Panel();
            this.clearBackB = new System.Windows.Forms.Button();
            this.GradeableCB = new System.Windows.Forms.CheckBox();
            this.DifficultyL = new System.Windows.Forms.Label();
            this.StandardsL = new System.Windows.Forms.Label();
            this.gradeL = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.oF = new System.Windows.Forms.OpenFileDialog();
            this.openP = new System.Windows.Forms.Panel();
            this.saveP = new System.Windows.Forms.Panel();
            this.groupsP = new System.Windows.Forms.Panel();
            this.studentCardP = new System.Windows.Forms.Panel();
            this.colorP = new System.Windows.Forms.Panel();
            this.homeP = new System.Windows.Forms.Panel();
            this.newCardP = new System.Windows.Forms.Panel();
            this.toggleP = new System.Windows.Forms.Panel();
            this.addPic = new System.Windows.Forms.Panel();
            this.picZoomPanel = new System.Windows.Forms.Panel();
            this.frontPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.BackPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // frontPanel
            // 
            this.frontPanel.BackColor = System.Drawing.Color.White;
            this.frontPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.frontPanel.Controls.Add(this.pictureBox1);
            this.frontPanel.Controls.Add(this.clearFrontB);
            this.frontPanel.Location = new System.Drawing.Point(45, 131);
            this.frontPanel.Name = "frontPanel";
            this.frontPanel.Size = new System.Drawing.Size(453, 366);
            this.frontPanel.TabIndex = 3;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Enabled = false;
            this.pictureBox1.Location = new System.Drawing.Point(57, 56);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(191, 181);
            this.pictureBox1.TabIndex = 44;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // clearFrontB
            // 
            this.clearFrontB.BackColor = System.Drawing.Color.White;
            this.clearFrontB.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.clearFrontB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clearFrontB.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clearFrontB.Image = ((System.Drawing.Image)(resources.GetObject("clearFrontB.Image")));
            this.clearFrontB.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.clearFrontB.Location = new System.Drawing.Point(410, 3);
            this.clearFrontB.Name = "clearFrontB";
            this.clearFrontB.Size = new System.Drawing.Size(38, 36);
            this.clearFrontB.TabIndex = 43;
            this.clearFrontB.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip.SetToolTip(this.clearFrontB, "Erase Front Panel");
            this.clearFrontB.UseVisualStyleBackColor = false;
            this.clearFrontB.Click += new System.EventHandler(this.clearFrontB_Click);
            // 
            // BackPanel
            // 
            this.BackPanel.BackColor = System.Drawing.Color.White;
            this.BackPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BackPanel.Controls.Add(this.clearBackB);
            this.BackPanel.Location = new System.Drawing.Point(504, 131);
            this.BackPanel.Name = "BackPanel";
            this.BackPanel.Size = new System.Drawing.Size(453, 366);
            this.BackPanel.TabIndex = 4;
            // 
            // clearBackB
            // 
            this.clearBackB.BackColor = System.Drawing.Color.White;
            this.clearBackB.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.clearBackB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clearBackB.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clearBackB.Image = ((System.Drawing.Image)(resources.GetObject("clearBackB.Image")));
            this.clearBackB.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.clearBackB.Location = new System.Drawing.Point(3, 3);
            this.clearBackB.Name = "clearBackB";
            this.clearBackB.Size = new System.Drawing.Size(38, 36);
            this.clearBackB.TabIndex = 43;
            this.clearBackB.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip.SetToolTip(this.clearBackB, "Erase Back Panel");
            this.clearBackB.UseVisualStyleBackColor = false;
            this.clearBackB.Click += new System.EventHandler(this.clearBackB_Click);
            // 
            // GradeableCB
            // 
            this.GradeableCB.AutoSize = true;
            this.GradeableCB.BackColor = System.Drawing.Color.Transparent;
            this.GradeableCB.Checked = true;
            this.GradeableCB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.GradeableCB.Location = new System.Drawing.Point(676, 517);
            this.GradeableCB.Name = "GradeableCB";
            this.GradeableCB.Size = new System.Drawing.Size(75, 17);
            this.GradeableCB.TabIndex = 71;
            this.GradeableCB.Text = "Gradeable";
            this.GradeableCB.UseVisualStyleBackColor = false;
            // 
            // DifficultyL
            // 
            this.DifficultyL.AutoSize = true;
            this.DifficultyL.BackColor = System.Drawing.Color.Transparent;
            this.DifficultyL.Location = new System.Drawing.Point(523, 517);
            this.DifficultyL.Name = "DifficultyL";
            this.DifficultyL.Size = new System.Drawing.Size(47, 13);
            this.DifficultyL.TabIndex = 72;
            this.DifficultyL.Text = "Difficulty";
            // 
            // StandardsL
            // 
            this.StandardsL.AutoSize = true;
            this.StandardsL.BackColor = System.Drawing.Color.Transparent;
            this.StandardsL.Location = new System.Drawing.Point(211, 517);
            this.StandardsL.Name = "StandardsL";
            this.StandardsL.Size = new System.Drawing.Size(55, 13);
            this.StandardsL.TabIndex = 73;
            this.StandardsL.Text = "Standards";
            // 
            // gradeL
            // 
            this.gradeL.AutoSize = true;
            this.gradeL.BackColor = System.Drawing.Color.Transparent;
            this.gradeL.Location = new System.Drawing.Point(359, 517);
            this.gradeL.Name = "gradeL";
            this.gradeL.Size = new System.Drawing.Size(36, 13);
            this.gradeL.TabIndex = 74;
            this.gradeL.Text = "Grade";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(540, 114);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 79;
            this.label1.Text = "Text: ";
            // 
            // oF
            // 
            this.oF.FileName = "openFileDialog1";
            // 
            // openP
            // 
            this.openP.BackColor = System.Drawing.Color.Transparent;
            this.openP.Location = new System.Drawing.Point(38, 9);
            this.openP.Name = "openP";
            this.openP.Size = new System.Drawing.Size(101, 94);
            this.openP.TabIndex = 83;
            this.openP.Click += new System.EventHandler(this.openCardB_Click);
            // 
            // saveP
            // 
            this.saveP.BackColor = System.Drawing.Color.Transparent;
            this.saveP.Location = new System.Drawing.Point(149, 9);
            this.saveP.Name = "saveP";
            this.saveP.Size = new System.Drawing.Size(102, 94);
            this.saveP.TabIndex = 84;
            this.saveP.Click += new System.EventHandler(this.saveCardB_Click);
            // 
            // groupsP
            // 
            this.groupsP.BackColor = System.Drawing.Color.Transparent;
            this.groupsP.Location = new System.Drawing.Point(496, 7);
            this.groupsP.Name = "groupsP";
            this.groupsP.Size = new System.Drawing.Size(101, 94);
            this.groupsP.TabIndex = 85;
            this.groupsP.Click += new System.EventHandler(this.addCategoriesB_Click);
            // 
            // studentCardP
            // 
            this.studentCardP.BackColor = System.Drawing.Color.Transparent;
            this.studentCardP.Location = new System.Drawing.Point(381, 6);
            this.studentCardP.Name = "studentCardP";
            this.studentCardP.Size = new System.Drawing.Size(101, 94);
            this.studentCardP.TabIndex = 86;
            this.studentCardP.Click += new System.EventHandler(this.studentCardListB_Click);
            // 
            // colorP
            // 
            this.colorP.BackColor = System.Drawing.Color.Transparent;
            this.colorP.Location = new System.Drawing.Point(734, 585);
            this.colorP.Name = "colorP";
            this.colorP.Size = new System.Drawing.Size(106, 94);
            this.colorP.TabIndex = 87;
            this.colorP.Click += new System.EventHandler(this.button1_Click);
            // 
            // homeP
            // 
            this.homeP.BackColor = System.Drawing.Color.Transparent;
            this.homeP.Location = new System.Drawing.Point(872, 9);
            this.homeP.Name = "homeP";
            this.homeP.Size = new System.Drawing.Size(101, 94);
            this.homeP.TabIndex = 88;
            this.homeP.Click += new System.EventHandler(this.homeB_Click);
            // 
            // newCardP
            // 
            this.newCardP.BackColor = System.Drawing.Color.Transparent;
            this.newCardP.Location = new System.Drawing.Point(41, 585);
            this.newCardP.Name = "newCardP";
            this.newCardP.Size = new System.Drawing.Size(253, 102);
            this.newCardP.TabIndex = 89;
            this.newCardP.Click += new System.EventHandler(this.createNewCardButton_Click);
            // 
            // toggleP
            // 
            this.toggleP.BackColor = System.Drawing.Color.Transparent;
            this.toggleP.Location = new System.Drawing.Point(862, 587);
            this.toggleP.Name = "toggleP";
            this.toggleP.Size = new System.Drawing.Size(106, 94);
            this.toggleP.TabIndex = 93;
            this.toggleP.Click += new System.EventHandler(this.toggleButton_Click);
            // 
            // addPic
            // 
            this.addPic.BackColor = System.Drawing.Color.Transparent;
            this.addPic.Location = new System.Drawing.Point(262, 8);
            this.addPic.Name = "addPic";
            this.addPic.Size = new System.Drawing.Size(102, 94);
            this.addPic.TabIndex = 94;
            this.addPic.Click += new System.EventHandler(this.addPic_Click);
            // 
            // picZoomPanel
            // 
            this.picZoomPanel.BackColor = System.Drawing.Color.Transparent;
            this.picZoomPanel.Location = new System.Drawing.Point(38, 114);
            this.picZoomPanel.Name = "picZoomPanel";
            this.picZoomPanel.Size = new System.Drawing.Size(508, 414);
            this.picZoomPanel.TabIndex = 95;
            this.picZoomPanel.Visible = false;
            this.picZoomPanel.Click += new System.EventHandler(this.picZoomPanel_Click);
            // 
            // CreateCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.Controls.Add(this.picZoomPanel);
            this.Controls.Add(this.addPic);
            this.Controls.Add(this.toggleP);
            this.Controls.Add(this.colorP);
            this.Controls.Add(this.newCardP);
            this.Controls.Add(this.homeP);
            this.Controls.Add(this.studentCardP);
            this.Controls.Add(this.groupsP);
            this.Controls.Add(this.saveP);
            this.Controls.Add(this.openP);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gradeL);
            this.Controls.Add(this.StandardsL);
            this.Controls.Add(this.DifficultyL);
            this.Controls.Add(this.GradeableCB);
            this.Controls.Add(this.BackPanel);
            this.Controls.Add(this.frontPanel);
            this.Name = "CreateCard";
            this.Size = new System.Drawing.Size(1000, 700);
            this.Load += new System.EventHandler(this.CreateCard_Load);
            this.Click += new System.EventHandler(this.audioP);
            this.frontPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.BackPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel frontPanel;
        private System.Windows.Forms.Panel BackPanel;
        private System.Windows.Forms.Button clearFrontB;
        private System.Windows.Forms.Button clearBackB;
        private System.Windows.Forms.CheckBox GradeableCB;
        public System.Windows.Forms.Label DifficultyL;
        public System.Windows.Forms.Label StandardsL;
        public System.Windows.Forms.Label gradeL;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog oF;
        private System.Windows.Forms.Panel openP;
        private System.Windows.Forms.Panel saveP;
        private System.Windows.Forms.Panel groupsP;
        private System.Windows.Forms.Panel studentCardP;
        private System.Windows.Forms.Panel colorP;
        private System.Windows.Forms.Panel homeP;
        private System.Windows.Forms.Panel newCardP;
        private System.Windows.Forms.Panel toggleP;
        private System.Windows.Forms.Panel addPic;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel picZoomPanel;
    }
}

