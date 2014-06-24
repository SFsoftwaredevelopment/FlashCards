namespace WindowsFormsApplication1
{
    partial class OpenWF
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
            this.cardB = new System.Windows.Forms.Button();
            this.DeckB = new System.Windows.Forms.Button();
            this.saveDeckD = new System.Windows.Forms.SaveFileDialog();
            this.saveCardsD = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // cardB
            // 
            this.cardB.Location = new System.Drawing.Point(3, 3);
            this.cardB.Name = "cardB";
            this.cardB.Size = new System.Drawing.Size(150, 43);
            this.cardB.TabIndex = 0;
            this.cardB.Text = "List of Cards";
            this.cardB.UseVisualStyleBackColor = true;
            this.cardB.Click += new System.EventHandler(this.button1_Click);
            // 
            // DeckB
            // 
            this.DeckB.Location = new System.Drawing.Point(159, 3);
            this.DeckB.Name = "DeckB";
            this.DeckB.Size = new System.Drawing.Size(150, 43);
            this.DeckB.TabIndex = 1;
            this.DeckB.Text = "Deck";
            this.DeckB.UseVisualStyleBackColor = true;
            this.DeckB.Click += new System.EventHandler(this.button2_Click);
            // 
            // OpenWF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(317, 50);
            this.Controls.Add(this.DeckB);
            this.Controls.Add(this.cardB);
            this.Name = "OpenWF";
            this.Text = "Save";
            this.Load += new System.EventHandler(this.OpenWF_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cardB;
        private System.Windows.Forms.Button DeckB;
        private System.Windows.Forms.SaveFileDialog saveDeckD;
        private System.Windows.Forms.SaveFileDialog saveCardsD;
    }
}