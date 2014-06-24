using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace WindowsFormsApplication1
{
    public partial class Find : Form
    {
        public EditCardsTeacher tec;
        Deck deck = Deck.getDeck();
        Card card = new Card();
        public Find()
        {
            InitializeComponent();
            listBox1.MouseDoubleClick += new MouseEventHandler(listBox1_DoubleClick);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] filepaths = Directory.GetFiles(@"C:\10th Grade\Internship\", "*.cd", SearchOption.AllDirectories);
            string getText = textBox1.Text;
            //MessageBox.Show(getText);

            /*for (int i = 0; i < filepaths.Length; i++)
            {
                //MessageBox.Show(file.Substring(58));
                if (filepaths[i].Substring(58).Contains(getText))
                {
                    listBox1.Items.Add(filepaths[i].Substring(58));
                }

                else if(!filepaths[i].Substring(58).Contains(getText))
                {
                    MessageBox.Show("No such file exists");
                }


            }*/

            
        }

        private void listBox1_DoubleClick(object sender, MouseEventArgs e)
        {
            
            int index = this.listBox1.IndexFromPoint(e.Location);
            if (index != System.Windows.Forms.ListBox.NoMatches)
            {
                MessageBox.Show(listBox1.SelectedItem.ToString());
            }
        }

        private void Find_Load(object sender, EventArgs e)
        {

        }

    }
}
