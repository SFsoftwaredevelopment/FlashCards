namespace WindowsFormsApplication1
{
    partial class CreateCardStudent
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateCardStudent));
            this.openCardB = new System.Windows.Forms.Button();
            this.addCategoriesB = new System.Windows.Forms.Button();
            this.saveCardB = new System.Windows.Forms.Button();
            this.frontPanel = new System.Windows.Forms.Panel();
            this.clearFrontB = new System.Windows.Forms.Button();
            this.BackPanel = new System.Windows.Forms.Panel();
            this.clearBackB = new System.Windows.Forms.Button();
            this.createNewCardButton = new System.Windows.Forms.Button();
            this.toggleButton = new System.Windows.Forms.Button();
            this.GradeableCB = new System.Windows.Forms.CheckBox();
            this.DifficultyL = new System.Windows.Forms.Label();
            this.StandardsL = new System.Windows.Forms.Label();
            this.gradeL = new System.Windows.Forms.Label();
            this.homeB = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.colorB = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.frontPanel.SuspendLayout();
            this.BackPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // openCardB
            // 
            this.openCardB.Image = ((System.Drawing.Image)(resources.GetObject("openCardB.Image")));
            this.openCardB.Location = new System.Drawing.Point(12, 13);
            this.openCardB.Name = "openCardB";
            this.openCardB.Size = new System.Drawing.Size(58, 58);
            this.openCardB.TabIndex = 0;
            this.toolTip.SetToolTip(this.openCardB, "Open Card");
            this.openCardB.UseVisualStyleBackColor = true;
            this.openCardB.Click += new System.EventHandler(this.openCardB_Click);
            // 
            // addCategoriesB
            // 
            this.addCategoriesB.Enabled = false;
            this.addCategoriesB.Image = ((System.Drawing.Image)(resources.GetObject("addCategoriesB.Image")));
            this.addCategoriesB.Location = new System.Drawing.Point(205, 12);
            this.addCategoriesB.Name = "addCategoriesB";
            this.addCategoriesB.Size = new System.Drawing.Size(58, 58);
            this.addCategoriesB.TabIndex = 1;
            this.toolTip.SetToolTip(this.addCategoriesB, "Categories");
            this.addCategoriesB.UseVisualStyleBackColor = true;
            this.addCategoriesB.Visible = false;
            this.addCategoriesB.Click += new System.EventHandler(this.addCategoriesB_Click);
            // 
            // saveCardB
            // 
            this.saveCardB.Image = ((System.Drawing.Image)(resources.GetObject("saveCardB.Image")));
            this.saveCardB.Location = new System.Drawing.Point(77, 12);
            this.saveCardB.Name = "saveCardB";
            this.saveCardB.Size = new System.Drawing.Size(58, 58);
            this.saveCardB.TabIndex = 2;
            this.toolTip.SetToolTip(this.saveCardB, "Save Card");
            this.saveCardB.UseVisualStyleBackColor = true;
            this.saveCardB.Click += new System.EventHandler(this.saveCardB_Click);
            // 
            // frontPanel
            // 
            this.frontPanel.BackColor = System.Drawing.Color.White;
            this.frontPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.frontPanel.Controls.Add(this.clearFrontB);
            this.frontPanel.Location = new System.Drawing.Point(18, 95);
            this.frontPanel.Name = "frontPanel";
            this.frontPanel.Size = new System.Drawing.Size(315, 208);
            this.frontPanel.TabIndex = 3;
            // 
            // clearFrontB
            // 
            this.clearFrontB.BackColor = System.Drawing.Color.White;
            this.clearFrontB.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.clearFrontB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clearFrontB.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clearFrontB.Image = ((System.Drawing.Image)(resources.GetObject("clearFrontB.Image")));
            this.clearFrontB.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.clearFrontB.Location = new System.Drawing.Point(272, 3);
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
            this.BackPanel.Location = new System.Drawing.Point(344, 95);
            this.BackPanel.Name = "BackPanel";
            this.BackPanel.Size = new System.Drawing.Size(315, 208);
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
            // createNewCardButton
            // 
            this.createNewCardButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.createNewCardButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createNewCardButton.Location = new System.Drawing.Point(183, 309);
            this.createNewCardButton.MinimumSize = new System.Drawing.Size(150, 30);
            this.createNewCardButton.Name = "createNewCardButton";
            this.createNewCardButton.Size = new System.Drawing.Size(150, 30);
            this.createNewCardButton.TabIndex = 38;
            this.createNewCardButton.Text = "CREATE NEW CARD";
            this.createNewCardButton.UseVisualStyleBackColor = false;
            this.createNewCardButton.Click += new System.EventHandler(this.createNewCardButton_Click);
            // 
            // toggleButton
            // 
            this.toggleButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.toggleButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toggleButton.Image = ((System.Drawing.Image)(resources.GetObject("toggleButton.Image")));
            this.toggleButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toggleButton.Location = new System.Drawing.Point(344, 309);
            this.toggleButton.MinimumSize = new System.Drawing.Size(150, 30);
            this.toggleButton.Name = "toggleButton";
            this.toggleButton.Size = new System.Drawing.Size(150, 30);
            this.toggleButton.TabIndex = 41;
            this.toggleButton.Tag = "CLEAR";
            this.toggleButton.Text = "Toggle Erase Mode";
            this.toggleButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toggleButton.UseVisualStyleBackColor = false;
            this.toggleButton.Click += new System.EventHandler(this.toggleButton_Click);
            // 
            // GradeableCB
            // 
            this.GradeableCB.AutoSize = true;
            this.GradeableCB.BackColor = System.Drawing.Color.Transparent;
            this.GradeableCB.Checked = true;
            this.GradeableCB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.GradeableCB.Enabled = false;
            this.GradeableCB.Location = new System.Drawing.Point(584, 316);
            this.GradeableCB.Name = "GradeableCB";
            this.GradeableCB.Size = new System.Drawing.Size(75, 17);
            this.GradeableCB.TabIndex = 71;
            this.GradeableCB.Text = "Gradeable";
            this.GradeableCB.UseVisualStyleBackColor = false;
            this.GradeableCB.Visible = false;
            // 
            // DifficultyL
            // 
            this.DifficultyL.AutoSize = true;
            this.DifficultyL.BackColor = System.Drawing.Color.Transparent;
            this.DifficultyL.Location = new System.Drawing.Point(15, 309);
            this.DifficultyL.Name = "DifficultyL";
            this.DifficultyL.Size = new System.Drawing.Size(47, 13);
            this.DifficultyL.TabIndex = 72;
            this.DifficultyL.Text = "Difficulty";
            this.DifficultyL.Visible = false;
            // 
            // StandardsL
            // 
            this.StandardsL.AutoSize = true;
            this.StandardsL.BackColor = System.Drawing.Color.Transparent;
            this.StandardsL.Location = new System.Drawing.Point(15, 339);
            this.StandardsL.Name = "StandardsL";
            this.StandardsL.Size = new System.Drawing.Size(55, 13);
            this.StandardsL.TabIndex = 73;
            this.StandardsL.Text = "Standards";
            this.StandardsL.Visible = false;
            // 
            // gradeL
            // 
            this.gradeL.AutoSize = true;
            this.gradeL.BackColor = System.Drawing.Color.Transparent;
            this.gradeL.Location = new System.Drawing.Point(15, 324);
            this.gradeL.Name = "gradeL";
            this.gradeL.Size = new System.Drawing.Size(36, 13);
            this.gradeL.TabIndex = 74;
            this.gradeL.Text = "Grade";
            this.gradeL.Visible = false;
            // 
            // homeB
            // 
            this.homeB.Image = ((System.Drawing.Image)(resources.GetObject("homeB.Image")));
            this.homeB.Location = new System.Drawing.Point(601, 13);
            this.homeB.Name = "homeB";
            this.homeB.Size = new System.Drawing.Size(58, 58);
            this.homeB.TabIndex = 76;
            this.toolTip.SetToolTip(this.homeB, "Home");
            this.homeB.UseVisualStyleBackColor = true;
            this.homeB.Click += new System.EventHandler(this.homeB_Click);
            // 
            // colorB
            // 
            this.colorB.Location = new System.Drawing.Point(141, 13);
            this.colorB.Name = "colorB";
            this.colorB.Size = new System.Drawing.Size(58, 58);
            this.colorB.TabIndex = 77;
            this.colorB.Text = "COLOR";
            this.colorB.UseVisualStyleBackColor = true;
            this.colorB.Click += new System.EventHandler(this.colorB_Click);
            // 
            // CreateCardStudent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(994, 672);
            this.Controls.Add(this.colorB);
            this.Controls.Add(this.homeB);
            this.Controls.Add(this.gradeL);
            this.Controls.Add(this.StandardsL);
            this.Controls.Add(this.DifficultyL);
            this.Controls.Add(this.GradeableCB);
            this.Controls.Add(this.toggleButton);
            this.Controls.Add(this.createNewCardButton);
            this.Controls.Add(this.BackPanel);
            this.Controls.Add(this.frontPanel);
            this.Controls.Add(this.saveCardB);
            this.Controls.Add(this.addCategoriesB);
            this.Controls.Add(this.openCardB);
            //this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "CreateCardStudent";
            this.Text = "Create Card";
            this.Load += new System.EventHandler(this.CreateCardStudent_Load);
            this.frontPanel.ResumeLayout(false);
            this.BackPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button openCardB;
        private System.Windows.Forms.Button addCategoriesB;
        private System.Windows.Forms.Button saveCardB;
        private System.Windows.Forms.Panel frontPanel;
        private System.Windows.Forms.Panel BackPanel;
        private System.Windows.Forms.Button clearFrontB;
        private System.Windows.Forms.Button clearBackB;
        private System.Windows.Forms.Button createNewCardButton;
        private System.Windows.Forms.Button toggleButton;
        private System.Windows.Forms.CheckBox GradeableCB;
        public System.Windows.Forms.Label DifficultyL;
        public System.Windows.Forms.Label StandardsL;
        public System.Windows.Forms.Label gradeL;
        private System.Windows.Forms.Button homeB;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Button colorB;
        private System.Windows.Forms.ColorDialog colorDialog1;
    }
}

