namespace WindowsFormsApplication1
{
    partial class PlayGameTeacher
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlayGameTeacher));
            this.frontPanel = new System.Windows.Forms.Panel();
            this.startGameB = new System.Windows.Forms.Button();
            this.backPanel = new System.Windows.Forms.Panel();
            this.clearP = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.inkColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.insertImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.insertToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.insertToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.recordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.insertGraphToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.insertToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label2 = new System.Windows.Forms.Label();
            this.answerPanel = new System.Windows.Forms.PictureBox();
            this.accuracyLabel = new System.Windows.Forms.Label();
            this.randomizeButton = new System.Windows.Forms.RadioButton();
            this.originalButton = new System.Windows.Forms.RadioButton();
            this.scoreLabel = new System.Windows.Forms.Label();
            this.cardProg = new System.Windows.Forms.Label();
            this.submitP = new System.Windows.Forms.Panel();
            this.QuitP = new System.Windows.Forms.Panel();
            this.ReplayP = new System.Windows.Forms.Panel();
            this.ToggleEraseP = new System.Windows.Forms.Panel();
            this.startP = new System.Windows.Forms.Panel();
            this.OverrideP = new System.Windows.Forms.Panel();
            this.inkToggleP = new System.Windows.Forms.Panel();
            this.yourAnswerL = new System.Windows.Forms.Label();
            this.frontPanel.SuspendLayout();
            this.backPanel.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.answerPanel)).BeginInit();
            this.SuspendLayout();
            // 
            // frontPanel
            // 
            this.frontPanel.BackColor = System.Drawing.Color.White;
            this.frontPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.frontPanel.Controls.Add(this.startGameB);
            this.frontPanel.Enabled = false;
            this.frontPanel.Location = new System.Drawing.Point(35, 16);
            this.frontPanel.Name = "frontPanel";
            this.frontPanel.Size = new System.Drawing.Size(411, 254);
            this.frontPanel.TabIndex = 5;
            // 
            // startGameB
            // 
            this.startGameB.Location = new System.Drawing.Point(-33, 230);
            this.startGameB.Name = "startGameB";
            this.startGameB.Size = new System.Drawing.Size(183, 23);
            this.startGameB.TabIndex = 0;
            this.startGameB.Text = "button1";
            this.startGameB.UseVisualStyleBackColor = true;
            // 
            // backPanel
            // 
            this.backPanel.BackColor = System.Drawing.Color.White;
            this.backPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.backPanel.Controls.Add(this.clearP);
            this.backPanel.Location = new System.Drawing.Point(520, 16);
            this.backPanel.Name = "backPanel";
            this.backPanel.Size = new System.Drawing.Size(434, 254);
            this.backPanel.TabIndex = 4;
            // 
            // clearP
            // 
            this.clearP.Location = new System.Drawing.Point(7, 4);
            this.clearP.Name = "clearP";
            this.clearP.Size = new System.Drawing.Size(24, 24);
            this.clearP.TabIndex = 0;
            this.clearP.Text = "button1";
            this.clearP.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.inkColorToolStripMenuItem,
            this.editToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(742, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.Visible = false;
            // 
            // inkColorToolStripMenuItem
            // 
            this.inkColorToolStripMenuItem.Name = "inkColorToolStripMenuItem";
            this.inkColorToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.inkColorToolStripMenuItem.Text = "Ink Color";
            this.inkColorToolStripMenuItem.Click += new System.EventHandler(this.inkColorToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.insertImageToolStripMenuItem,
            this.deleteImageToolStripMenuItem,
            this.insertGraphToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.editToolStripMenuItem.Text = "Options";
            // 
            // insertImageToolStripMenuItem
            // 
            this.insertImageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.insertToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.insertImageToolStripMenuItem.Name = "insertImageToolStripMenuItem";
            this.insertImageToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.insertImageToolStripMenuItem.Text = "Image";
            this.insertImageToolStripMenuItem.Click += new System.EventHandler(this.insertImageToolStripMenuItem_Click);
            // 
            // insertToolStripMenuItem
            // 
            this.insertToolStripMenuItem.Name = "insertToolStripMenuItem";
            this.insertToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.insertToolStripMenuItem.Text = "Insert";
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            // 
            // deleteImageToolStripMenuItem
            // 
            this.deleteImageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.insertToolStripMenuItem1,
            this.deleteToolStripMenuItem1,
            this.recordToolStripMenuItem});
            this.deleteImageToolStripMenuItem.Name = "deleteImageToolStripMenuItem";
            this.deleteImageToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.deleteImageToolStripMenuItem.Text = "Sound";
            // 
            // insertToolStripMenuItem1
            // 
            this.insertToolStripMenuItem1.Name = "insertToolStripMenuItem1";
            this.insertToolStripMenuItem1.Size = new System.Drawing.Size(111, 22);
            this.insertToolStripMenuItem1.Text = "Insert";
            // 
            // deleteToolStripMenuItem1
            // 
            this.deleteToolStripMenuItem1.Name = "deleteToolStripMenuItem1";
            this.deleteToolStripMenuItem1.Size = new System.Drawing.Size(111, 22);
            this.deleteToolStripMenuItem1.Text = "Delete";
            // 
            // recordToolStripMenuItem
            // 
            this.recordToolStripMenuItem.Name = "recordToolStripMenuItem";
            this.recordToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.recordToolStripMenuItem.Text = "Record";
            // 
            // insertGraphToolStripMenuItem
            // 
            this.insertGraphToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.insertToolStripMenuItem2,
            this.deleteToolStripMenuItem2});
            this.insertGraphToolStripMenuItem.Name = "insertGraphToolStripMenuItem";
            this.insertGraphToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.insertGraphToolStripMenuItem.Text = "Graph";
            // 
            // insertToolStripMenuItem2
            // 
            this.insertToolStripMenuItem2.Name = "insertToolStripMenuItem2";
            this.insertToolStripMenuItem2.Size = new System.Drawing.Size(107, 22);
            this.insertToolStripMenuItem2.Text = "Insert";
            // 
            // deleteToolStripMenuItem2
            // 
            this.deleteToolStripMenuItem2.Name = "deleteToolStripMenuItem2";
            this.deleteToolStripMenuItem2.Size = new System.Drawing.Size(107, 22);
            this.deleteToolStripMenuItem2.Text = "Delete";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(715, 622);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "ACTUAL ANSWER";
            // 
            // answerPanel
            // 
            this.answerPanel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.answerPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.answerPanel.Location = new System.Drawing.Point(627, 419);
            this.answerPanel.Name = "answerPanel";
            this.answerPanel.Size = new System.Drawing.Size(272, 200);
            this.answerPanel.TabIndex = 17;
            this.answerPanel.TabStop = false;
            // 
            // accuracyLabel
            // 
            this.accuracyLabel.AutoSize = true;
            this.accuracyLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.accuracyLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.accuracyLabel.Location = new System.Drawing.Point(278, 517);
            this.accuracyLabel.MinimumSize = new System.Drawing.Size(0, 40);
            this.accuracyLabel.Name = "accuracyLabel";
            this.accuracyLabel.Size = new System.Drawing.Size(76, 40);
            this.accuracyLabel.TabIndex = 26;
            this.accuracyLabel.Text = "Accuracy";
            // 
            // randomizeButton
            // 
            this.randomizeButton.AutoSize = true;
            this.randomizeButton.BackColor = System.Drawing.Color.Lime;
            this.randomizeButton.Checked = true;
            this.randomizeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold);
            this.randomizeButton.Location = new System.Drawing.Point(528, 638);
            this.randomizeButton.Name = "randomizeButton";
            this.randomizeButton.Size = new System.Drawing.Size(116, 16);
            this.randomizeButton.TabIndex = 49;
            this.randomizeButton.TabStop = true;
            this.randomizeButton.Text = "Randomized Order";
            this.randomizeButton.UseVisualStyleBackColor = false;
            // 
            // originalButton
            // 
            this.originalButton.AutoSize = true;
            this.originalButton.BackColor = System.Drawing.Color.Transparent;
            this.originalButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold);
            this.originalButton.Location = new System.Drawing.Point(528, 612);
            this.originalButton.Name = "originalButton";
            this.originalButton.Size = new System.Drawing.Size(93, 16);
            this.originalButton.TabIndex = 48;
            this.originalButton.TabStop = true;
            this.originalButton.Text = "Original Order";
            this.originalButton.UseVisualStyleBackColor = false;
            //this.originalButton.CheckedChanged += new System.EventHandler(this.originalButton_CheckedChanged);
            // 
            // scoreLabel
            // 
            this.scoreLabel.AutoSize = true;
            this.scoreLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.scoreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scoreLabel.Location = new System.Drawing.Point(35, 517);
            this.scoreLabel.MinimumSize = new System.Drawing.Size(0, 40);
            this.scoreLabel.Name = "scoreLabel";
            this.scoreLabel.Size = new System.Drawing.Size(53, 40);
            this.scoreLabel.TabIndex = 50;
            this.scoreLabel.Text = "Score";
            // 
            // cardProg
            // 
            this.cardProg.AutoSize = true;
            this.cardProg.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cardProg.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cardProg.Location = new System.Drawing.Point(201, 608);
            this.cardProg.MinimumSize = new System.Drawing.Size(0, 40);
            this.cardProg.Name = "cardProg";
            this.cardProg.Size = new System.Drawing.Size(105, 40);
            this.cardProg.TabIndex = 54;
            this.cardProg.Text = "Card Position";
            // 
            // submitP
            // 
            this.submitP.BackColor = System.Drawing.Color.Transparent;
            this.submitP.Location = new System.Drawing.Point(528, 300);
            this.submitP.Name = "submitP";
            this.submitP.Size = new System.Drawing.Size(191, 89);
            this.submitP.TabIndex = 55;
            this.submitP.Click += new System.EventHandler(this.submitB_Click);
            // 
            // QuitP
            // 
            this.QuitP.BackColor = System.Drawing.Color.Transparent;
            this.QuitP.Location = new System.Drawing.Point(211, 305);
            this.QuitP.Name = "QuitP";
            this.QuitP.Size = new System.Drawing.Size(184, 84);
            this.QuitP.TabIndex = 56;
            this.QuitP.Click += new System.EventHandler(this.button1_Click);
            // 
            // ReplayP
            // 
            this.ReplayP.BackColor = System.Drawing.Color.Transparent;
            this.ReplayP.Location = new System.Drawing.Point(217, 395);
            this.ReplayP.Name = "ReplayP";
            this.ReplayP.Size = new System.Drawing.Size(186, 95);
            this.ReplayP.TabIndex = 57;
            this.ReplayP.Click += new System.EventHandler(this.replayB_Click_1);
            // 
            // ToggleEraseP
            // 
            this.ToggleEraseP.BackColor = System.Drawing.Color.Transparent;
            this.ToggleEraseP.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ToggleEraseP.BackgroundImage")));
            this.ToggleEraseP.Location = new System.Drawing.Point(12, 395);
            this.ToggleEraseP.Name = "ToggleEraseP";
            this.ToggleEraseP.Size = new System.Drawing.Size(199, 95);
            this.ToggleEraseP.TabIndex = 58;
            // 
            // startP
            // 
            this.startP.BackColor = System.Drawing.Color.Transparent;
            this.startP.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("startP.BackgroundImage")));
            this.startP.Location = new System.Drawing.Point(3, 300);
            this.startP.Name = "startP";
            this.startP.Size = new System.Drawing.Size(190, 89);
            this.startP.TabIndex = 59;
            this.startP.Click += new System.EventHandler(this.startGameButton_Click);
            // 
            // OverrideP
            // 
            this.OverrideP.BackColor = System.Drawing.Color.Transparent;
            this.OverrideP.Location = new System.Drawing.Point(810, 305);
            this.OverrideP.Name = "OverrideP";
            this.OverrideP.Size = new System.Drawing.Size(170, 84);
            this.OverrideP.TabIndex = 60;
            this.OverrideP.Click += new System.EventHandler(this.overrideB_Click);
            // 
            // inkToggleP
            // 
            this.inkToggleP.BackColor = System.Drawing.Color.Transparent;
            this.inkToggleP.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("inkToggleP.BackgroundImage")));
            this.inkToggleP.Location = new System.Drawing.Point(409, 343);
            this.inkToggleP.Name = "inkToggleP";
            this.inkToggleP.Size = new System.Drawing.Size(113, 103);
            this.inkToggleP.TabIndex = 61;
            this.inkToggleP.Click += new System.EventHandler(this.clearB_Click);
            // 
            // yourAnswerL
            // 
            this.yourAnswerL.AutoSize = true;
            this.yourAnswerL.BackColor = System.Drawing.Color.Transparent;
            this.yourAnswerL.Location = new System.Drawing.Point(520, 277);
            this.yourAnswerL.Name = "yourAnswerL";
            this.yourAnswerL.Size = new System.Drawing.Size(73, 13);
            this.yourAnswerL.TabIndex = 62;
            this.yourAnswerL.Text = "Your Answer: ";
            // 
            // PlayGameTeacher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.Controls.Add(this.yourAnswerL);
            this.Controls.Add(this.inkToggleP);
            this.Controls.Add(this.OverrideP);
            this.Controls.Add(this.startP);
            this.Controls.Add(this.ToggleEraseP);
            this.Controls.Add(this.ReplayP);
            this.Controls.Add(this.QuitP);
            this.Controls.Add(this.submitP);
            this.Controls.Add(this.cardProg);
            this.Controls.Add(this.scoreLabel);
            this.Controls.Add(this.randomizeButton);
            this.Controls.Add(this.originalButton);
            this.Controls.Add(this.accuracyLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.answerPanel);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.frontPanel);
            this.Controls.Add(this.backPanel);
            this.Name = "PlayGameTeacher";
            this.Size = new System.Drawing.Size(1000, 700);
            this.Load += new System.EventHandler(this.PlayGame_Load);
            this.frontPanel.ResumeLayout(false);
            this.backPanel.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.answerPanel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel frontPanel;
        private System.Windows.Forms.Panel backPanel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem inkColorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem insertImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem insertGraphToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteImageToolStripMenuItem;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox answerPanel;
        private System.Windows.Forms.Label accuracyLabel;
        private System.Windows.Forms.RadioButton randomizeButton;
        private System.Windows.Forms.RadioButton originalButton;
        private System.Windows.Forms.Label scoreLabel;
        private System.Windows.Forms.ToolStripMenuItem insertToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem insertToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem recordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem insertToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem2;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
        private System.Windows.Forms.Label cardProg;
        private System.Windows.Forms.Panel submitP;
        private System.Windows.Forms.Panel QuitP;
        private System.Windows.Forms.Panel ReplayP;
        private System.Windows.Forms.Panel ToggleEraseP;
        private System.Windows.Forms.Panel startP;
        private System.Windows.Forms.Panel OverrideP;
        private System.Windows.Forms.Panel inkToggleP;
        private System.Windows.Forms.Button clearP;
        private System.Windows.Forms.Button startGameB;
        private System.Windows.Forms.Label yourAnswerL;
    }
}