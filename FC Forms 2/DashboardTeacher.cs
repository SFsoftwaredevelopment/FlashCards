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
    public partial class DashboardTeacher : UserControl
    {
        PlayGameTeacher pgt;
        EditCardsTeacher tc;
        CreateCard cc;
        CardList cL;
        MixMatchTeacher mmt = new MixMatchTeacher();
        private string user = "";
        public DashboardTeacher(string usr)
        {
            InitializeComponent();                      
            user = usr;
            tc = new EditCardsTeacher("", usr, this);
            pgt = new PlayGameTeacher(this,user);
            //cc = new CreateCard("", usr,this,tc);
           // this.FormClosing += new FormClosingEventHandler(DashboardTeacher_FormClosing);
        }

      /*  void DashboardTeacher_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Application.Exit();
            }
        }*/

        //PlayGame Screen
        private void playGameB_Click(object sender, EventArgs e)
        {
            pgt = new PlayGameTeacher(this, user);
            cL = new CardList(pgt, user);
            Global.form.Controls.Add(pgt);
            this.Hide();
            
            //pgt.Show();
            cL.Show();
        }

        //EditCards Screen
        private void createCardsB_Click(object sender, EventArgs e)
        {
            tc = new EditCardsTeacher("",user,this);
            Global.form.Controls.Add(tc);
            this.Hide();
        }

        //CreateCards
        private void mixMatchB_Click(object sender, EventArgs e)
        {
            tc = new EditCardsTeacher("", user, this);
            cc = new CreateCard("", user, this, tc);
            Global.form.Controls.Add(cc);
            this.Hide();
        }

        private void TeacherDashboard_Load(object sender, EventArgs e)
        {
            label1.Text = user;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Login2 login = new Login2();
            Global.form.Controls.Add(login);
        }

        private void linkLabel1_LinkClicked(object sender, EventArgs e)
        {
            this.Hide();
            Login2 login = new Login2();
            Global.form.Controls.Add(login);
        }

        private void AutoMathB_Click(object sender, EventArgs e)
        {
            this.Hide();
            AutoMath autoMath = new AutoMath();
            Global.form.Controls.Add(autoMath);
        }

        //public event FormClosingEventHandler FormClosing;
    }
}
