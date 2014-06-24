using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace WindowsFormsApplication1
{
    public partial class OpenWF : Form
    {

        public int clickedB;
        public Card card;
        public OpenWF()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //openCardD.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            clickedB = 1;
        }

        private void openCardD_FileOk(object sender, CancelEventArgs e)
        {
            //card = BinaryDeserializeCard(openCardD.FileName);
        }

        private static Card BinaryDeserializeCard(String filename)
        {
            //compatability issue
            //ArrayList temp = null;
            object obj = null;

            Card savedCard = null;

            using (FileStream str = File.OpenRead(filename))
            {
                BinaryFormatter bf = new BinaryFormatter();
                obj = bf.Deserialize(str);
                str.Close();
            }

            try
            {
                savedCard = (Card)obj;
            }
            catch (InvalidCastException)
            {
                //temp = (ArrayList)obj;
                savedCard = new Card();
                MessageBox.Show("Program unable to open file.  File may be corrupt.");
            }

            return savedCard;
        }

        private void OpenWF_Load(object sender, EventArgs e)
        {

        }
    }
}
