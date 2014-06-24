using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections;
using System.IO;

namespace WindowsFormsApplication1
{
    public partial class DeckSummary : Form
    {
        Deck deck = Deck.getDeck();
        public DeckSummary()
        {
            InitializeComponent();
        }

        private void DeckSummary_Load(object sender, EventArgs e)
        {

        }
        private void openDeck_Click(object sender, EventArgs e)
        {
            openDeckD.ShowDialog();           
        }
        private void openDeckD_FileOk(object sender, CancelEventArgs e)
        {
            deck.cards = BinaryDeserialize(openDeckD.FileName);
            noOfCardsTB.Text = deck.numberOfCards.ToString();
            descriptionTB.Text = deck.description;
        }

        public List<Card> BinaryDeserialize(string filename)
        {
            //compatability issue
            ArrayList temp = null;
            object obj = null;

            List<Card> savedCards = null;

            using (FileStream str = File.OpenRead(filename))
            {
                BinaryFormatter bf = new BinaryFormatter();
                obj = bf.Deserialize(str);
                str.Close();
            }

            try
            {
                savedCards = (List<Card>)obj;
            }
            catch (InvalidCastException)
            {
                temp = (ArrayList)obj;
                savedCards = new List<Card>();
                foreach (Card card in temp)
                {
                    savedCards.Add(card);
                }
            }

            return savedCards;
        }

        

        
    }
}
