using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Ink;

namespace WindowsFormsApplication1
{
    public partial class ScratchPanel : Form
    {
        InkOverlay scratchPanel;

        public ScratchPanel()
        {
            InitializeComponent();
            scratchPanel = new InkOverlay(panel1.Handle);
            scratchPanel.Enabled = true;
        }

        private void ScratchPanel_Load(object sender, EventArgs e)
        {

        }

        private void ScratchPanel_SizeChanged(object sender, EventArgs e)
        {
            panel1.Size = new System.Drawing.Size(this.Width, this.Height);
        }

        bool ink = true;
        private void panel2_Click(object sender, EventArgs e)
        {
            try
            {
                ink = !ink;
                if (!ink)
                {
                    scratchPanel.EditingMode = InkOverlayEditingMode.Delete;
                    panel2.BackgroundImage = new Bitmap(Image.FromFile("C:\\Cards\\Images\\button.toggleerase.png"));
                }

                if (ink)
                {
                    scratchPanel.EditingMode = InkOverlayEditingMode.Ink;
                    panel2.BackgroundImage = new Bitmap(Image.FromFile("C:\\Cards\\Images\\button.toggleink.png"));
                }
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("We are sorry for the error.  \nPlease restart the program, we are working on a fix.", "Invalid Operation Exception");
            }
        
        }

    }
}
