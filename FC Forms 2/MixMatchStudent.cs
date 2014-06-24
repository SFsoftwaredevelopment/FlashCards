using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class MixMatchStudent : Form
    {
        private DashboardStudent sdOriginal;
        public MixMatchStudent(DashboardStudent sOrig)
        {
            InitializeComponent();
            sdOriginal =sOrig;

        }

        private void SaveB_Click(object sender, EventArgs e)
        {
            SaveD.ShowDialog();
        }

        private void OpenB_Click(object sender, EventArgs e)
        {
            OpenD.ShowDialog();
        }

        private void HomeB_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            sdOriginal.Show();
        }
    }
}
