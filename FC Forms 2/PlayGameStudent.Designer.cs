namespace WindowsFormsApplication1
{
    partial class PlayGameStudent
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlayGameStudent));
            this.backPanel = new System.Windows.Forms.Panel();
            this.scratchWorkB = new System.Windows.Forms.Button();
            this.clearB = new System.Windows.Forms.Button();
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
            this.accuracyLabel = new System.Windows.Forms.Label();
            this.originalButton = new System.Windows.Forms.RadioButton();
            this.scoreLabel = new System.Windows.Forms.Label();
            this.cardProg = new System.Windows.Forms.Label();
            this.quitP = new System.Windows.Forms.Panel();
            this.replayP = new System.Windows.Forms.Panel();
            this.startP = new System.Windows.Forms.Panel();
            this.startGameB = new System.Windows.Forms.Button();
            this.toginkP = new System.Windows.Forms.Panel();
            this.submitP = new System.Windows.Forms.Panel();
            this.overrideP = new System.Windows.Forms.Panel();
            this.answerPanel = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.frontPanel = new System.Windows.Forms.PictureBox();
            this.picZoomPanel = new System.Windows.Forms.Panel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.backPanel.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.startP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.answerPanel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.frontPanel)).BeginInit();
            this.SuspendLayout();
            // 
            // backPanel
            // 
            this.backPanel.BackColor = System.Drawing.Color.White;
            this.backPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.backPanel.Controls.Add(this.scratchWorkB);
            this.backPanel.Controls.Add(this.clearB);
            this.backPanel.Location = new System.Drawing.Point(502, 16);
            this.backPanel.Name = "backPanel";
            this.backPanel.Size = new System.Drawing.Size(471, 267);
            this.backPanel.TabIndex = 4;
            // 
            // scratchWorkB
            // 
            this.scratchWorkB.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("scratchWorkB.BackgroundImage")));
            this.scratchWorkB.Location = new System.Drawing.Point(3, 3);
            this.scratchWorkB.Name = "scratchWorkB";
            this.scratchWorkB.Size = new System.Drawing.Size(35, 35);
            this.scratchWorkB.TabIndex = 62;
            this.toolTip1.SetToolTip(this.scratchWorkB, "Scratch Work");
            this.scratchWorkB.UseVisualStyleBackColor = true;
            this.scratchWorkB.Click += new System.EventHandler(this.scratchWorkB_Click);
            // 
            // clearB
            // 
            this.clearB.Location = new System.Drawing.Point(84, 3);
            this.clearB.Name = "clearB";
            this.clearB.Size = new System.Drawing.Size(24, 23);
            this.clearB.TabIndex = 61;
            this.clearB.Text = "button1";
            this.clearB.UseVisualStyleBackColor = true;
            this.clearB.Visible = false;
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
            this.label2.Location = new System.Drawing.Point(544, 457);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "ACTUAL ANSWER";
            // 
            // accuracyLabel
            // 
            this.accuracyLabel.AutoSize = true;
            this.accuracyLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.accuracyLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.accuracyLabel.Location = new System.Drawing.Point(282, 518);
            this.accuracyLabel.MinimumSize = new System.Drawing.Size(0, 40);
            this.accuracyLabel.Name = "accuracyLabel";
            this.accuracyLabel.Size = new System.Drawing.Size(76, 40);
            this.accuracyLabel.TabIndex = 26;
            this.accuracyLabel.Text = "Accuracy";
            // 
            // originalButton
            // 
            this.originalButton.AutoSize = true;
            this.originalButton.BackColor = System.Drawing.Color.Transparent;
            this.originalButton.Checked = true;
            this.originalButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold);
            this.originalButton.Location = new System.Drawing.Point(25, 428);
            this.originalButton.Name = "originalButton";
            this.originalButton.Size = new System.Drawing.Size(93, 16);
            this.originalButton.TabIndex = 48;
            this.originalButton.TabStop = true;
            this.originalButton.Text = "Original Order";
            this.originalButton.UseVisualStyleBackColor = false;
            this.originalButton.CheckedChanged += new System.EventHandler(this.originalButton_CheckedChanged);
            // 
            // scoreLabel
            // 
            this.scoreLabel.AutoSize = true;
            this.scoreLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.scoreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scoreLabel.Location = new System.Drawing.Point(180, 605);
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
            this.cardProg.Location = new System.Drawing.Point(25, 518);
            this.cardProg.MinimumSize = new System.Drawing.Size(0, 40);
            this.cardProg.Name = "cardProg";
            this.cardProg.Size = new System.Drawing.Size(105, 40);
            this.cardProg.TabIndex = 53;
            this.cardProg.Text = "Card Position";
            this.cardProg.Click += new System.EventHandler(this.cardProg_Click);
            // 
            // quitP
            // 
            this.quitP.BackColor = System.Drawing.Color.Transparent;
            this.quitP.Location = new System.Drawing.Point(208, 300);
            this.quitP.Name = "quitP";
            this.quitP.Size = new System.Drawing.Size(194, 87);
            this.quitP.TabIndex = 54;
            this.quitP.Click += new System.EventHandler(this.button1_Click);
            // 
            // replayP
            // 
            this.replayP.BackColor = System.Drawing.Color.Transparent;
            this.replayP.Location = new System.Drawing.Point(219, 393);
            this.replayP.Name = "replayP";
            this.replayP.Size = new System.Drawing.Size(183, 91);
            this.replayP.TabIndex = 55;
            this.replayP.Click += new System.EventHandler(this.replayB_Click_1);
            // 
            // startP
            // 
            this.startP.BackColor = System.Drawing.Color.Transparent;
            this.startP.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("startP.BackgroundImage")));
            this.startP.Controls.Add(this.startGameB);
            this.startP.Location = new System.Drawing.Point(3, 300);
            this.startP.Name = "startP";
            this.startP.Size = new System.Drawing.Size(199, 87);
            this.startP.TabIndex = 56;
            this.startP.Click += new System.EventHandler(this.startGameButton_Click);
            // 
            // startGameB
            // 
            this.startGameB.Location = new System.Drawing.Point(4, 19);
            this.startGameB.Name = "startGameB";
            this.startGameB.Size = new System.Drawing.Size(192, 23);
            this.startGameB.TabIndex = 0;
            this.startGameB.Text = "button1";
            this.startGameB.UseVisualStyleBackColor = true;
            // 
            // toginkP
            // 
            this.toginkP.BackColor = System.Drawing.Color.Transparent;
            this.toginkP.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("toginkP.BackgroundImage")));
            this.toginkP.Location = new System.Drawing.Point(408, 342);
            this.toginkP.Name = "toginkP";
            this.toginkP.Size = new System.Drawing.Size(118, 102);
            this.toginkP.TabIndex = 57;
            this.toginkP.Click += new System.EventHandler(this.clearB_Click);
            // 
            // submitP
            // 
            this.submitP.BackColor = System.Drawing.Color.Transparent;
            this.submitP.Location = new System.Drawing.Point(534, 300);
            this.submitP.Name = "submitP";
            this.submitP.Size = new System.Drawing.Size(185, 87);
            this.submitP.TabIndex = 59;
            this.submitP.Click += new System.EventHandler(this.submitB_Click);
            // 
            // overrideP
            // 
            this.overrideP.BackColor = System.Drawing.Color.Transparent;
            this.overrideP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.overrideP.Location = new System.Drawing.Point(801, 300);
            this.overrideP.Name = "overrideP";
            this.overrideP.Size = new System.Drawing.Size(190, 87);
            this.overrideP.TabIndex = 60;
            this.overrideP.Click += new System.EventHandler(this.overrideB_Click);
            // 
            // answerPanel
            // 
            this.answerPanel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.answerPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.answerPanel.Location = new System.Drawing.Point(650, 428);
            this.answerPanel.Name = "answerPanel";
            this.answerPanel.Size = new System.Drawing.Size(272, 200);
            this.answerPanel.TabIndex = 17;
            this.answerPanel.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(79, 64);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(131, 121);
            this.pictureBox1.TabIndex = 62;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // frontPanel
            // 
            this.frontPanel.BackColor = System.Drawing.Color.White;
            this.frontPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.frontPanel.Enabled = false;
            this.frontPanel.Location = new System.Drawing.Point(25, 16);
            this.frontPanel.Name = "frontPanel";
            this.frontPanel.Size = new System.Drawing.Size(471, 267);
            this.frontPanel.TabIndex = 61;
            this.frontPanel.TabStop = false;
            // 
            // picZoomPanel
            // 
            this.picZoomPanel.BackColor = System.Drawing.Color.Transparent;
            this.picZoomPanel.Location = new System.Drawing.Point(25, 16);
            this.picZoomPanel.Name = "picZoomPanel";
            this.picZoomPanel.Size = new System.Drawing.Size(508, 414);
            this.picZoomPanel.TabIndex = 63;
            this.picZoomPanel.Visible = false;
            this.picZoomPanel.Click += new System.EventHandler(this.picZoomPanel_Click);
            // 
            // PlayGameStudent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.Controls.Add(this.picZoomPanel);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.frontPanel);
            this.Controls.Add(this.overrideP);
            this.Controls.Add(this.submitP);
            this.Controls.Add(this.toginkP);
            this.Controls.Add(this.startP);
            this.Controls.Add(this.replayP);
            this.Controls.Add(this.quitP);
            this.Controls.Add(this.cardProg);
            this.Controls.Add(this.scoreLabel);
            this.Controls.Add(this.originalButton);
            this.Controls.Add(this.accuracyLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.answerPanel);
            this.Controls.Add(this.backPanel);
            this.Controls.Add(this.menuStrip1);
            this.Name = "PlayGameStudent";
            this.Size = new System.Drawing.Size(994, 672);
            this.Load += new System.EventHandler(this.PlayGame_Load);
            this.backPanel.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.startP.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.answerPanel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.frontPanel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

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
        private System.Windows.Forms.Label accuracyLabel;
        private System.Windows.Forms.RadioButton originalButton;
        private System.Windows.Forms.Label scoreLabel;
        private System.Windows.Forms.ToolStripMenuItem insertToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem insertToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem recordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem insertToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem2;
        private System.Windows.Forms.Label cardProg;
        private System.Windows.Forms.Panel quitP;
        private System.Windows.Forms.Panel replayP;
        private System.Windows.Forms.Panel startP;
        private System.Windows.Forms.Panel toginkP;
        private System.Windows.Forms.Panel submitP;
        private System.Windows.Forms.Panel overrideP;
        private System.Windows.Forms.Button clearB;
        private System.Windows.Forms.Button startGameB;
        private System.Windows.Forms.PictureBox answerPanel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox frontPanel;
        private System.Windows.Forms.Panel picZoomPanel;
        private System.Windows.Forms.Button scratchWorkB;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}