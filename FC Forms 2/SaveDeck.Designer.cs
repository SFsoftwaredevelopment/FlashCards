using System.Windows.Forms;
namespace WindowsFormsApplication1
{
    partial class SaveDeck
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
            this.saveB = new System.Windows.Forms.Button();
            this.openCardD = new System.Windows.Forms.OpenFileDialog();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.saveDeckD = new System.Windows.Forms.SaveFileDialog();
            this.deckName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.openDeckD = new System.Windows.Forms.OpenFileDialog();
            this.saveDeckFolderD = new System.Windows.Forms.FolderBrowserDialog();
            this.noOfCardsL = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // saveB
            // 
            this.saveB.Location = new System.Drawing.Point(130, 306);
            this.saveB.Name = "saveB";
            this.saveB.Size = new System.Drawing.Size(111, 58);
            this.saveB.TabIndex = 0;
            this.saveB.Text = "SaveDeck";
            this.saveB.UseVisualStyleBackColor = true;
            this.saveB.Click += new System.EventHandler(this.button1_Click);
            // 
            // openCardD
            // 
            this.openCardD.Filter = "Flash Cards|*.cd|All Files|*.*";
            this.openCardD.Multiselect = true;
            this.openCardD.FileOk += new System.ComponentModel.CancelEventHandler(this.openCardD_FileOk);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(28, 42);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(369, 212);
            this.listBox1.TabIndex = 3;
            this.listBox1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBox1_MouseClick);
            // 
            // saveDeckD
            // 
            this.saveDeckD.DefaultExt = "fc";
            this.saveDeckD.FileName = ".fc";
            this.saveDeckD.FileOk += new System.ComponentModel.CancelEventHandler(this.saveDeckD_FileOk);
            // 
            // deckName
            // 
            this.deckName.Location = new System.Drawing.Point(106, 260);
            this.deckName.Name = "deckName";
            this.deckName.Size = new System.Drawing.Size(200, 20);
            this.deckName.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 267);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Deck Name:";
            // 
            // openDeckD
            // 
            this.openDeckD.Filter = "Flash Decks|*.fc|All Files|*.*";
            this.openDeckD.FileOk += new System.ComponentModel.CancelEventHandler(this.openDeckD_FileOk);
            // 
            // saveDeckFolderD
            // 
            this.saveDeckFolderD.SelectedPath = "C:\\Users\\Kathy\\Documents\\Ben";
            this.saveDeckFolderD.HelpRequest += new System.EventHandler(this.saveDeckFolderD_HelpRequest);
            // 
            // noOfCardsL
            // 
            this.noOfCardsL.AutoSize = true;
            this.noOfCardsL.Location = new System.Drawing.Point(317, 18);
            this.noOfCardsL.Name = "noOfCardsL";
            this.noOfCardsL.Size = new System.Drawing.Size(88, 13);
            this.noOfCardsL.TabIndex = 9;
            this.noOfCardsL.Text = "Number Of Cards";
            // 
            // SaveDeck
            // 
            this.AcceptButton = this.saveB;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 398);
            this.Controls.Add(this.noOfCardsL);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.deckName);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.saveB);
            this.Name = "SaveDeck";
            this.Text = "Save Deck";
            this.Load += new System.EventHandler(this.SaveDeck_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button saveB;
        private System.Windows.Forms.OpenFileDialog openCardD;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.SaveFileDialog saveDeckD;
        private System.Windows.Forms.TextBox deckName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog openDeckD;
        private System.EventHandler listBox1_Click;
        private FolderBrowserDialog saveDeckFolderD;
        private Label noOfCardsL;
    }
}