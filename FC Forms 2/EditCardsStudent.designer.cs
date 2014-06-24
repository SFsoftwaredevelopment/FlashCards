namespace WindowsFormsApplication1
{
    partial class EditCardsStudent
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditCardsStudent));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.open = new System.Windows.Forms.ToolStripMenuItem();
            this.openCard = new System.Windows.Forms.ToolStripMenuItem();
            this.openDeck = new System.Windows.Forms.ToolStripMenuItem();
            this.save = new System.Windows.Forms.ToolStripMenuItem();
            this.saveCard = new System.Windows.Forms.ToolStripMenuItem();
            this.saveDeck = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.findToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deckSummaryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inkColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.standardsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.insertImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.insertToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.soundToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.insertToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.insertGraphToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.insertToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.openDeckD = new System.Windows.Forms.OpenFileDialog();
            this.saveDeckD = new System.Windows.Forms.SaveFileDialog();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.thumb1 = new System.Windows.Forms.Panel();
            this.thumb2 = new System.Windows.Forms.Panel();
            this.thumb5 = new System.Windows.Forms.Panel();
            this.thumb4 = new System.Windows.Forms.Panel();
            this.thumb3 = new System.Windows.Forms.Panel();
            this.nextThumbButton = new System.Windows.Forms.Button();
            this.deleteCardButton = new System.Windows.Forms.Button();
            this.createNewCardButton = new System.Windows.Forms.Button();
            this.saveCurrentButton = new System.Windows.Forms.Button();
            this.prevThumbButton = new System.Windows.Forms.Button();
            this.insertBar = new System.Windows.Forms.Panel();
            this.FrontPanel = new System.Windows.Forms.Panel();
            this.BackPanel = new System.Windows.Forms.Panel();
            this.openImageD = new System.Windows.Forms.OpenFileDialog();
            this.saveCardD = new System.Windows.Forms.SaveFileDialog();
            this.openCardD = new System.Windows.Forms.OpenFileDialog();
            this.standardsL = new System.Windows.Forms.Label();
            this.DifficultyL = new System.Windows.Forms.Label();
            this.HomeB = new System.Windows.Forms.Button();
            this.toggleButton = new System.Windows.Forms.Button();
            this.noOfCardsL = new System.Windows.Forms.Label();
            this.gradeL = new System.Windows.Forms.Label();
            this.GradeableCB = new System.Windows.Forms.CheckBox();
            this.OpenDeckB = new System.Windows.Forms.Button();
            this.SaveDeckB = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.inkColorToolStripMenuItem,
            this.standardsToolStripMenuItem,
            this.editToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(769, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.Visible = false;
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.open,
            this.save,
            this.undoToolStripMenuItem,
            this.redoToolStripMenuItem,
            this.aboutToolStripMenuItem,
            this.findToolStripMenuItem,
            this.deckSummaryToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // open
            // 
            this.open.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openCard,
            this.openDeck});
            this.open.Name = "open";
            this.open.Size = new System.Drawing.Size(154, 22);
            this.open.Text = "Open";
            // 
            // openCard
            // 
            this.openCard.Name = "openCard";
            this.openCard.Size = new System.Drawing.Size(100, 22);
            this.openCard.Text = "Card";
            this.openCard.Click += new System.EventHandler(this.openCard_Click);
            // 
            // openDeck
            // 
            this.openDeck.Name = "openDeck";
            this.openDeck.Size = new System.Drawing.Size(100, 22);
            this.openDeck.Text = "Deck";
            this.openDeck.Click += new System.EventHandler(this.loadDeck_Click_1);
            // 
            // save
            // 
            this.save.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveCard,
            this.saveDeck});
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(154, 22);
            this.save.Text = "Save";
            // 
            // saveCard
            // 
            this.saveCard.Name = "saveCard";
            this.saveCard.Size = new System.Drawing.Size(100, 22);
            this.saveCard.Text = "Card";
            this.saveCard.Click += new System.EventHandler(this.saveCard_Click);
            // 
            // saveDeck
            // 
            this.saveDeck.Name = "saveDeck";
            this.saveDeck.Size = new System.Drawing.Size(100, 22);
            this.saveDeck.Text = "Deck";
            this.saveDeck.Click += new System.EventHandler(this.saveDeck_Click_1);
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.undoToolStripMenuItem.Text = "Undo";
            // 
            // redoToolStripMenuItem
            // 
            this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            this.redoToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.redoToolStripMenuItem.Text = "Redo";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // findToolStripMenuItem
            // 
            this.findToolStripMenuItem.Name = "findToolStripMenuItem";
            this.findToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.findToolStripMenuItem.Text = "Find";
            // 
            // deckSummaryToolStripMenuItem
            // 
            this.deckSummaryToolStripMenuItem.Name = "deckSummaryToolStripMenuItem";
            this.deckSummaryToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.deckSummaryToolStripMenuItem.Text = "Deck Summary";
            // 
            // inkColorToolStripMenuItem
            // 
            this.inkColorToolStripMenuItem.Name = "inkColorToolStripMenuItem";
            this.inkColorToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.inkColorToolStripMenuItem.Text = "Ink Color";
            this.inkColorToolStripMenuItem.Click += new System.EventHandler(this.inkColorToolStripMenuItem_Click);
            // 
            // standardsToolStripMenuItem
            // 
            this.standardsToolStripMenuItem.Name = "standardsToolStripMenuItem";
            this.standardsToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
            this.standardsToolStripMenuItem.Text = "Categories";
            this.standardsToolStripMenuItem.Click += new System.EventHandler(this.standardsToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.insertImageToolStripMenuItem,
            this.soundToolStripMenuItem,
            this.insertGraphToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.editToolStripMenuItem.Text = "Options";
            // 
            // insertImageToolStripMenuItem
            // 
            this.insertImageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.insertToolStripMenuItem1,
            this.deleteToolStripMenuItem1});
            this.insertImageToolStripMenuItem.Name = "insertImageToolStripMenuItem";
            this.insertImageToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.insertImageToolStripMenuItem.Text = "Image";
            this.insertImageToolStripMenuItem.Click += new System.EventHandler(this.insertImageToolStripMenuItem_Click);
            // 
            // insertToolStripMenuItem1
            // 
            this.insertToolStripMenuItem1.Name = "insertToolStripMenuItem1";
            this.insertToolStripMenuItem1.Size = new System.Drawing.Size(107, 22);
            this.insertToolStripMenuItem1.Text = "Insert";
            // 
            // deleteToolStripMenuItem1
            // 
            this.deleteToolStripMenuItem1.Name = "deleteToolStripMenuItem1";
            this.deleteToolStripMenuItem1.Size = new System.Drawing.Size(107, 22);
            this.deleteToolStripMenuItem1.Text = "Delete";
            // 
            // soundToolStripMenuItem
            // 
            this.soundToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.insertToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.recordToolStripMenuItem});
            this.soundToolStripMenuItem.Name = "soundToolStripMenuItem";
            this.soundToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.soundToolStripMenuItem.Text = "Sound";
            // 
            // insertToolStripMenuItem
            // 
            this.insertToolStripMenuItem.Name = "insertToolStripMenuItem";
            this.insertToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.insertToolStripMenuItem.Text = "Insert";
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
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
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // openDeckD
            // 
            this.openDeckD.Filter = "Flash Decks|*.fc|All Files|*.*";
            this.openDeckD.FileOk += new System.ComponentModel.CancelEventHandler(this.openDeckD_FileOk);
            // 
            // saveDeckD
            // 
            this.saveDeckD.DefaultExt = "fc";
            this.saveDeckD.FileName = ".fc";
            this.saveDeckD.FileOk += new System.ComponentModel.CancelEventHandler(this.saveDeckD_FileOk);
            // 
            // thumb1
            // 
            this.thumb1.AutoSize = true;
            this.thumb1.BackColor = System.Drawing.Color.White;
            this.thumb1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.thumb1.Location = new System.Drawing.Point(61, 75);
            this.thumb1.Name = "thumb1";
            this.thumb1.Size = new System.Drawing.Size(124, 81);
            this.thumb1.TabIndex = 17;
            this.thumb1.TabStop = true;
            this.thumb1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.thumb1_MouseClick);
            // 
            // thumb2
            // 
            this.thumb2.AutoSize = true;
            this.thumb2.BackColor = System.Drawing.Color.White;
            this.thumb2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.thumb2.Location = new System.Drawing.Point(191, 75);
            this.thumb2.Name = "thumb2";
            this.thumb2.Size = new System.Drawing.Size(124, 81);
            this.thumb2.TabIndex = 18;
            this.thumb2.TabStop = true;
            this.thumb2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.thumb2_MouseClick);
            // 
            // thumb5
            // 
            this.thumb5.AutoSize = true;
            this.thumb5.BackColor = System.Drawing.Color.White;
            this.thumb5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.thumb5.Location = new System.Drawing.Point(584, 75);
            this.thumb5.Name = "thumb5";
            this.thumb5.Size = new System.Drawing.Size(124, 81);
            this.thumb5.TabIndex = 20;
            this.thumb5.TabStop = true;
            this.thumb5.MouseClick += new System.Windows.Forms.MouseEventHandler(this.thumb5_MouseClick);
            // 
            // thumb4
            // 
            this.thumb4.AutoSize = true;
            this.thumb4.BackColor = System.Drawing.Color.White;
            this.thumb4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.thumb4.Location = new System.Drawing.Point(454, 75);
            this.thumb4.Name = "thumb4";
            this.thumb4.Size = new System.Drawing.Size(124, 81);
            this.thumb4.TabIndex = 21;
            this.thumb4.TabStop = true;
            this.thumb4.MouseClick += new System.Windows.Forms.MouseEventHandler(this.thumb4_MouseClick);
            // 
            // thumb3
            // 
            this.thumb3.AutoSize = true;
            this.thumb3.BackColor = System.Drawing.Color.White;
            this.thumb3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.thumb3.Location = new System.Drawing.Point(324, 75);
            this.thumb3.Name = "thumb3";
            this.thumb3.Size = new System.Drawing.Size(124, 81);
            this.thumb3.TabIndex = 22;
            this.thumb3.TabStop = true;
            this.thumb3.MouseClick += new System.Windows.Forms.MouseEventHandler(this.thumb3_MouseClick);
            // 
            // nextThumbButton
            // 
            this.nextThumbButton.BackColor = System.Drawing.SystemColors.ControlDark;
            this.nextThumbButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.nextThumbButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.nextThumbButton.Location = new System.Drawing.Point(714, 75);
            this.nextThumbButton.Name = "nextThumbButton";
            this.nextThumbButton.Size = new System.Drawing.Size(33, 81);
            this.nextThumbButton.TabIndex = 23;
            this.nextThumbButton.Text = ">>";
            this.toolTip.SetToolTip(this.nextThumbButton, "Show Next Card");
            this.nextThumbButton.UseVisualStyleBackColor = false;
            this.nextThumbButton.Click += new System.EventHandler(this.nextThumb_Click);
            // 
            // deleteCardButton
            // 
            this.deleteCardButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.deleteCardButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteCardButton.Location = new System.Drawing.Point(504, 420);
            this.deleteCardButton.MinimumSize = new System.Drawing.Size(150, 30);
            this.deleteCardButton.Name = "deleteCardButton";
            this.deleteCardButton.Size = new System.Drawing.Size(150, 30);
            this.deleteCardButton.TabIndex = 37;
            this.deleteCardButton.Text = "REMOVE CARD";
            this.deleteCardButton.UseVisualStyleBackColor = false;
            this.deleteCardButton.Click += new System.EventHandler(this.deleteCard_Click);
            // 
            // createNewCardButton
            // 
            this.createNewCardButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.createNewCardButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createNewCardButton.Location = new System.Drawing.Point(504, 377);
            this.createNewCardButton.MinimumSize = new System.Drawing.Size(150, 30);
            this.createNewCardButton.Name = "createNewCardButton";
            this.createNewCardButton.Size = new System.Drawing.Size(150, 30);
            this.createNewCardButton.TabIndex = 36;
            this.createNewCardButton.Text = "CREATE CARD";
            this.createNewCardButton.UseVisualStyleBackColor = false;
            this.createNewCardButton.Click += new System.EventHandler(this.createNewCard_Click);
            // 
            // saveCurrentButton
            // 
            this.saveCurrentButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.saveCurrentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveCurrentButton.Location = new System.Drawing.Point(324, 420);
            this.saveCurrentButton.MinimumSize = new System.Drawing.Size(150, 30);
            this.saveCurrentButton.Name = "saveCurrentButton";
            this.saveCurrentButton.Size = new System.Drawing.Size(150, 30);
            this.saveCurrentButton.TabIndex = 35;
            this.saveCurrentButton.Text = "EDIT CARD";
            this.saveCurrentButton.UseVisualStyleBackColor = false;
            this.saveCurrentButton.Click += new System.EventHandler(this.saveCurrentButton_Click);
            // 
            // prevThumbButton
            // 
            this.prevThumbButton.BackColor = System.Drawing.SystemColors.ControlDark;
            this.prevThumbButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.prevThumbButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.prevThumbButton.Location = new System.Drawing.Point(22, 74);
            this.prevThumbButton.Name = "prevThumbButton";
            this.prevThumbButton.Size = new System.Drawing.Size(33, 81);
            this.prevThumbButton.TabIndex = 38;
            this.prevThumbButton.Text = "<<";
            this.toolTip.SetToolTip(this.prevThumbButton, "Show Previous Card");
            this.prevThumbButton.UseVisualStyleBackColor = false;
            this.prevThumbButton.Click += new System.EventHandler(this.prevThumb_Click);
            // 
            // insertBar
            // 
            this.insertBar.BackColor = System.Drawing.SystemColors.ControlText;
            this.insertBar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.insertBar.Location = new System.Drawing.Point(56, 71);
            this.insertBar.Name = "insertBar";
            this.insertBar.Size = new System.Drawing.Size(3, 84);
            this.insertBar.TabIndex = 60;
            this.insertBar.Visible = false;
            // 
            // FrontPanel
            // 
            this.FrontPanel.BackColor = System.Drawing.Color.White;
            this.FrontPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FrontPanel.Enabled = false;
            this.FrontPanel.Location = new System.Drawing.Point(56, 163);
            this.FrontPanel.Name = "FrontPanel";
            this.FrontPanel.Size = new System.Drawing.Size(321, 208);
            this.FrontPanel.TabIndex = 61;
            this.FrontPanel.DragDrop += new System.Windows.Forms.DragEventHandler(this.Panel_DragDrop);
            this.FrontPanel.DragEnter += new System.Windows.Forms.DragEventHandler(this.Panel_DragEnter);
            this.FrontPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.FrontPanel_Paint);
            // 
            // BackPanel
            // 
            this.BackPanel.BackColor = System.Drawing.Color.White;
            this.BackPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BackPanel.Enabled = false;
            this.BackPanel.Location = new System.Drawing.Point(393, 163);
            this.BackPanel.Name = "BackPanel";
            this.BackPanel.Size = new System.Drawing.Size(315, 208);
            this.BackPanel.TabIndex = 62;
            this.BackPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.BackPanel_Paint);
            // 
            // openImageD
            // 
            this.openImageD.FileName = "       ";
            this.openImageD.Filter = "Image files|(*.jpg;*.gif;*.bmp;*.png;*.jpeg)|All files (*.*)|*.*";
            // 
            // saveCardD
            // 
            this.saveCardD.DefaultExt = "cd";
            this.saveCardD.FileOk += new System.ComponentModel.CancelEventHandler(this.saveCardD_FileOk);
            // 
            // openCardD
            // 
            this.openCardD.Filter = "Flash Cards|*.cd|All Files|*.*";
            this.openCardD.FileOk += new System.ComponentModel.CancelEventHandler(this.openCardD_FileOk);
            // 
            // standardsL
            // 
            this.standardsL.AutoSize = true;
            this.standardsL.BackColor = System.Drawing.Color.Transparent;
            this.standardsL.Location = new System.Drawing.Point(53, 408);
            this.standardsL.Name = "standardsL";
            this.standardsL.Size = new System.Drawing.Size(55, 13);
            this.standardsL.TabIndex = 63;
            this.standardsL.Text = "Standards";
            // 
            // DifficultyL
            // 
            this.DifficultyL.AutoSize = true;
            this.DifficultyL.BackColor = System.Drawing.Color.Transparent;
            this.DifficultyL.Location = new System.Drawing.Point(53, 377);
            this.DifficultyL.Name = "DifficultyL";
            this.DifficultyL.Size = new System.Drawing.Size(47, 13);
            this.DifficultyL.TabIndex = 64;
            this.DifficultyL.Text = "Difficulty";
            // 
            // HomeB
            // 
            this.HomeB.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("HomeB.BackgroundImage")));
            this.HomeB.Image = ((System.Drawing.Image)(resources.GetObject("HomeB.Image")));
            this.HomeB.Location = new System.Drawing.Point(689, 6);
            this.HomeB.Name = "HomeB";
            this.HomeB.Size = new System.Drawing.Size(58, 58);
            this.HomeB.TabIndex = 41;
            this.toolTip.SetToolTip(this.HomeB, "Home");
            this.HomeB.UseVisualStyleBackColor = true;
            this.HomeB.Click += new System.EventHandler(this.HomeB_Click);
            // 
            // toggleButton
            // 
            this.toggleButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.toggleButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toggleButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toggleButton.Location = new System.Drawing.Point(324, 377);
            this.toggleButton.MinimumSize = new System.Drawing.Size(150, 30);
            this.toggleButton.Name = "toggleButton";
            this.toggleButton.Size = new System.Drawing.Size(150, 30);
            this.toggleButton.TabIndex = 39;
            this.toggleButton.Tag = "CLEAR";
            this.toggleButton.Text = "ADD CARD";
            this.toggleButton.UseVisualStyleBackColor = false;
            this.toggleButton.Click += new System.EventHandler(this.clearBothButton_Click);
            // 
            // noOfCardsL
            // 
            this.noOfCardsL.AutoSize = true;
            this.noOfCardsL.BackColor = System.Drawing.Color.Transparent;
            this.noOfCardsL.Location = new System.Drawing.Point(581, 59);
            this.noOfCardsL.Name = "noOfCardsL";
            this.noOfCardsL.Size = new System.Drawing.Size(86, 13);
            this.noOfCardsL.TabIndex = 67;
            this.noOfCardsL.Text = "Number of Cards";
            // 
            // gradeL
            // 
            this.gradeL.AutoSize = true;
            this.gradeL.BackColor = System.Drawing.Color.Transparent;
            this.gradeL.Location = new System.Drawing.Point(53, 392);
            this.gradeL.Name = "gradeL";
            this.gradeL.Size = new System.Drawing.Size(36, 13);
            this.gradeL.TabIndex = 68;
            this.gradeL.Text = "Grade";
            // 
            // GradeableCB
            // 
            this.GradeableCB.AutoSize = true;
            this.GradeableCB.BackColor = System.Drawing.Color.Transparent;
            this.GradeableCB.Checked = true;
            this.GradeableCB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.GradeableCB.Enabled = false;
            this.GradeableCB.Location = new System.Drawing.Point(661, 405);
            this.GradeableCB.Name = "GradeableCB";
            this.GradeableCB.Size = new System.Drawing.Size(75, 17);
            this.GradeableCB.TabIndex = 69;
            this.GradeableCB.Text = "Gradeable";
            this.GradeableCB.UseVisualStyleBackColor = false;
            // 
            // OpenDeckB
            // 
            this.OpenDeckB.Image = ((System.Drawing.Image)(resources.GetObject("OpenDeckB.Image")));
            this.OpenDeckB.Location = new System.Drawing.Point(22, 6);
            this.OpenDeckB.Name = "OpenDeckB";
            this.OpenDeckB.Size = new System.Drawing.Size(58, 58);
            this.OpenDeckB.TabIndex = 70;
            this.toolTip.SetToolTip(this.OpenDeckB, "Open Deck");
            this.OpenDeckB.UseVisualStyleBackColor = true;
            this.OpenDeckB.Click += new System.EventHandler(this.loadDeck_Click_1);
            // 
            // SaveDeckB
            // 
            this.SaveDeckB.Image = ((System.Drawing.Image)(resources.GetObject("SaveDeckB.Image")));
            this.SaveDeckB.Location = new System.Drawing.Point(87, 6);
            this.SaveDeckB.Name = "SaveDeckB";
            this.SaveDeckB.Size = new System.Drawing.Size(58, 58);
            this.SaveDeckB.TabIndex = 71;
            this.toolTip.SetToolTip(this.SaveDeckB, "Save Deck");
            this.SaveDeckB.UseVisualStyleBackColor = true;
            this.SaveDeckB.Click += new System.EventHandler(this.saveDeck_Click_1);
            // 
            // EditCardsStudent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(769, 460);
            this.Controls.Add(this.SaveDeckB);
            this.Controls.Add(this.OpenDeckB);
            this.Controls.Add(this.GradeableCB);
            this.Controls.Add(this.gradeL);
            this.Controls.Add(this.noOfCardsL);
            this.Controls.Add(this.DifficultyL);
            this.Controls.Add(this.standardsL);
            this.Controls.Add(this.BackPanel);
            this.Controls.Add(this.FrontPanel);
            this.Controls.Add(this.insertBar);
            this.Controls.Add(this.HomeB);
            this.Controls.Add(this.toggleButton);
            this.Controls.Add(this.prevThumbButton);
            this.Controls.Add(this.deleteCardButton);
            this.Controls.Add(this.createNewCardButton);
            this.Controls.Add(this.saveCurrentButton);
            this.Controls.Add(this.nextThumbButton);
            this.Controls.Add(this.thumb3);
            this.Controls.Add(this.thumb4);
            this.Controls.Add(this.thumb5);
            this.Controls.Add(this.thumb2);
            this.Controls.Add(this.thumb1);
            this.Controls.Add(this.menuStrip1);
            //this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            //this.MainMenuStrip = this.menuStrip1;
            this.Name = "EditCardsStudent";
            this.Text = "Create Deck";
            this.Load += new System.EventHandler(this.EditCardsStudent_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem insertImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem insertGraphToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem standardsToolStripMenuItem;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem open;
        private System.Windows.Forms.ToolStripMenuItem save;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inkColorToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openDeckD;
        private System.Windows.Forms.SaveFileDialog saveDeckD;
        private System.Windows.Forms.Panel thumb1;
        private System.Windows.Forms.Panel thumb2;
        private System.Windows.Forms.Panel thumb5;
        private System.Windows.Forms.Panel thumb4;
        private System.Windows.Forms.Panel thumb3;
        private System.Windows.Forms.Button nextThumbButton;
        private System.Windows.Forms.Button deleteCardButton;
        private System.Windows.Forms.Button createNewCardButton;
        private System.Windows.Forms.Button saveCurrentButton;
        private System.Windows.Forms.Button prevThumbButton;
        private System.Windows.Forms.Button toggleButton;
        private System.Windows.Forms.Button HomeB;
        private System.Windows.Forms.ToolStripMenuItem insertToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem soundToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem insertToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem recordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem insertToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem2;
        private System.Windows.Forms.Panel insertBar;
        private System.Windows.Forms.OpenFileDialog openImageD;
        private System.Windows.Forms.ToolStripMenuItem openCard;
        private System.Windows.Forms.ToolStripMenuItem openDeck;
        private System.Windows.Forms.ToolStripMenuItem saveCard;
        private System.Windows.Forms.ToolStripMenuItem saveDeck;
        private System.Windows.Forms.OpenFileDialog openCardD;
        public System.Windows.Forms.SaveFileDialog saveCardD;
        private System.Windows.Forms.ToolStripMenuItem findToolStripMenuItem;
        public System.Windows.Forms.Panel FrontPanel;
        public System.Windows.Forms.Panel BackPanel;
        public System.Windows.Forms.Label standardsL;
        public System.Windows.Forms.Label DifficultyL;
        private System.Windows.Forms.Label noOfCardsL;
        public System.Windows.Forms.Label gradeL;
        private System.Windows.Forms.ToolStripMenuItem deckSummaryToolStripMenuItem;
        private System.Windows.Forms.CheckBox GradeableCB;
        private System.Windows.Forms.Button OpenDeckB;
        private System.Windows.Forms.Button SaveDeckB;
        public System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.ToolTip toolTip;
    }
}