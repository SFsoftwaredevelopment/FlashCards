namespace WindowsFormsApplication1
{
    partial class DeckSummary
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.noOfCardsTB = new System.Windows.Forms.TextBox();
            this.descriptionTB = new System.Windows.Forms.TextBox();
            this.openDeck = new System.Windows.Forms.Button();
            this.openDeckD = new System.Windows.Forms.OpenFileDialog();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Number Of Cards:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Description";
            // 
            // noOfCardsTB
            // 
            this.noOfCardsTB.Location = new System.Drawing.Point(31, 74);
            this.noOfCardsTB.Name = "noOfCardsTB";
            this.noOfCardsTB.ReadOnly = true;
            this.noOfCardsTB.Size = new System.Drawing.Size(100, 20);
            this.noOfCardsTB.TabIndex = 2;
            // 
            // descriptionTB
            // 
            this.descriptionTB.Location = new System.Drawing.Point(31, 122);
            this.descriptionTB.Multiline = true;
            this.descriptionTB.Name = "descriptionTB";
            this.descriptionTB.ReadOnly = true;
            this.descriptionTB.Size = new System.Drawing.Size(348, 228);
            this.descriptionTB.TabIndex = 3;
            // 
            // openDeck
            // 
            this.openDeck.Location = new System.Drawing.Point(31, 13);
            this.openDeck.Name = "openDeck";
            this.openDeck.Size = new System.Drawing.Size(75, 23);
            this.openDeck.TabIndex = 4;
            this.openDeck.Text = "Open Deck";
            this.openDeck.UseVisualStyleBackColor = true;
            this.openDeck.Click += new System.EventHandler(this.openDeck_Click);
            // 
            // openDeckD
            // 
            this.openDeckD.FileOk += new System.ComponentModel.CancelEventHandler(this.openDeckD_FileOk);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(31, 357);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(348, 225);
            this.listBox1.TabIndex = 5;
            // 
            // DeckSummary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(413, 605);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.openDeck);
            this.Controls.Add(this.descriptionTB);
            this.Controls.Add(this.noOfCardsTB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "DeckSummary";
            this.Text = "DeckSummary";
            this.Load += new System.EventHandler(this.DeckSummary_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button openDeck;
        private System.Windows.Forms.OpenFileDialog openDeckD;
        public System.Windows.Forms.TextBox noOfCardsTB;
        public System.Windows.Forms.TextBox descriptionTB;
        public System.Windows.Forms.ListBox listBox1;
    }
}