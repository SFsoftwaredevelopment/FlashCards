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
    public partial class DashboardStudent : UserControl
    {
        EditCardsStudent sc;
        PlayGameStudent pg;
        CreateCardStudent scc;
        CardList cL;

        string user;
        public DashboardStudent(string usr)
        {
            InitializeComponent();
            user = usr;
            
            
        }

        private void playGameB_Click(object sender, EventArgs e)
        {
            pg = new PlayGameStudent(this, user);
            cL = new CardList(pg);
            this.Hide();
            Global.form.Controls.Add(pg);
            cL.Show();
            //openFileDialog1.ShowDialog();
        }

        private void createCardsB_Click(object sender, EventArgs e)
        {
            sc = new EditCardsStudent("", user, this);
            Global.form.Controls.Add(sc);
            this.Hide();
        }


        private void mixMatchB_Click(object sender, EventArgs e)
        {
            scc = new CreateCardStudent("", user, this, sc);
            this.Hide();
            Global.form.Controls.Add(scc);
        }

        private void exitP_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login2 login = new Login2();
            Global.form.Controls.Add(login);
        }

        private void DashboardStudent_Load(object sender, EventArgs e)
        {
            label3.Text = user;
        }

       }
}
