using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using System.Diagnostics;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        Hashtable hashTable = new Hashtable();
        EditCardsTeacher tec;
        CreateCard cc;
        CreateCardStudent scc;
        private int length = File.ReadAllLines(FILE_NAME).Length;

        public Form1(CreateCardStudent scretCard)
        {
            InitializeComponent();
            scc = scretCard;
        }
        public Form1(CreateCard cretCard)
        {
            InitializeComponent();
            /*try
            {
                tec = (EditCardsTeacher)edTeach;
            }
            catch (Exception)
            {*/
                cc = cretCard;
            //}
                LinkLabel editStan = new LinkLabel();
                editStan.Text = "Edit Categories";
                editStan.Location = new Point(20, 375);
                this.Controls.Add(editStan);
                editStan.Click += new EventHandler(editStan_Click);
        }

        void editStan_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("This will open up Notepad.  Please save the file in Notepad when done, then reload this screen.") == DialogResult.OK)
                Process.Start("notepad.exe", FILE_NAME);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            /*int[] key = new int[cb.Length];

            for (int i = 0; i < cb.Length; i++)
            {

                key[i] = cb[i].GetHashCode();

            }


            for (int i = 0; i < cb.Length; i++)
            {

                hashTable.Add(key[i], cb[i]);

            }*/
            //tec.sLabel.Text = "hello";
            this.Hide();

        }

        private void addButton_Click(object sender, EventArgs e)
        {
            /*try
            {
                tec.DifficultyL.Text = difficulty();
                tec.gradeL.Text = grade();
                standards();
                string labelText = "";
                for (int i = 0; i < stan.Length; i++)
                {
                    if (stan[i] != "")
                    {
                        labelText = labelText + stan[i] + "\n";
                        //globalLabelText = labelText;
                    }
                }
                tec.standardsL.Text = labelText;
            }
            catch(Exception)
            {*/
                cc.DifficultyL.Text = difficulty();
                cc.gradeL.Text = grade();
                standards();
                string labelText = "";
                for (int i = 0; i < stan.Length; i++)
                {
                    if (stan[i] != "")
                    {
                        labelText = labelText + stan[i] + "\n";
                        //globalLabelText = labelText;
                    }
                }
                cc.StandardsL.Text = labelText;
            //}
           /* for (int i = 0; i < diffCB.Length; i++)
            {

                if (diffCB[i].Checked)
                {
                    tec.diff = diffCB[i].Text;

                    for (int a = 0; a < cb.Length; a++)
                    {

                        if (cb[a].Checked)
                        {
                            tec.standards[a] = cb[a].Text;
                        }

                    }
                }
                if (tec.diff.Equals(""))
            }*/
            
            this.Hide();
        }
        public string difficulty()
        {
            //MessageBox.Show(numericUpDown1.Value.ToString());
            return numericUpDown1.Value.ToString();

            if (numericUpDown1.ToString() == "-1")
            {
                NullReferenceException e = new NullReferenceException();
                throw e;
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        public string[] stan = new string[File.ReadAllLines(FILE_NAME).Length];
        public string[] standards()
        {
            
            for (int i = 0; i < cb.Length; i++)
            {

                if (cb[i].Checked)
                {
                    stan[i] = cb[i].Text;
                    
                }
                else if (!cb[i].Checked)
                {
                    stan[i] = "";
                }
            }
            bool noStans = true;
            for (int i = 0; i < stan.Length; i++)
            {
                if (stan[i] == "")
                    noStans = true;
                else
                {
                    noStans = false;
                    break;
                }
            }
            if(noStans)
            {
                ArgumentException e = new ArgumentException();
                throw e;
            }
            return stan;
        }

        //public string[] grad = new string[5];
        public string grad = "";
        public string grade()
        {
            /*for (int i = 0; i < gradeCB.Length; i++)
            {
                if (gradeCB[i].Checked)
                {
                    grad = gradeCB[i].Text;
                    return grad;
                }
            }*/

            if (gradeCB.SelectedIndex != 0)
                return gradeCB.SelectedItem.ToString();
            else
            {
                FileLoadException e = new FileLoadException();
                throw e;
            }
             
        }

    }
}

