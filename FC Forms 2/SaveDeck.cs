using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections;
using System.Net;

//textbox2 was replaced woth noOfCardL


namespace WindowsFormsApplication1
{
    public partial class SaveDeck : Form
    {
        string filename;
        Deck deck = Deck.getDeck();

        //Do I need this?
        DashboardTeacher tdOriginal;
        private string user = "";
        string saveDecks, saveCards, saveDecksAutoMath;
        EditCardsTeacher edTeach;
        EditCardsStudent edStud;
        DashboardTeacher dashTeach;
        DashboardStudent dashStud;
        AutoMath autoMath;
        NextScreen currentMode;
        bool autoM = false;
        bool wordD = false;
        enum NextScreen
        {
            edTeach = 0,
            dashTeach,
            edStud,
            dashStud,
            autoMath
        };

        private void openCardD_FileOk(object sender, CancelEventArgs e)
        {
            int insertPosition = 0;
            Card card = BinaryDeserializeCard(openCardD.FileName);
            filename = openCardD.FileName;
            listBox1.Items.Add(card.cardname);
            deck.cards.Insert(insertPosition, card);
            insertPosition = insertPosition + 1;
            filename = card.cardname;
        }



        private void button2_Click(object sender, EventArgs e)
        {
            openCardD.ShowDialog();
        }

        private static void BinarySerialize(Deck deck, string filename)
        {
            using (FileStream str = File.Create(filename))
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(str, deck);
                str.Close();
            }
        }

        public Card BinaryDeserializeCard(String filename)
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

        // Deserialize an ArrayList object from a binary file.
        public List<Card> BinaryDeserialize(string filename)
        {
            //compatability issue
            ArrayList temp = null;
            object obj = null;

            List<Card> savedCards = null;
            Deck savedDeck = Deck.getDeck();
            deck = Deck.getDeck();

            using (FileStream str = File.OpenRead(filename))
            {
                BinaryFormatter bf = new BinaryFormatter();
                obj = bf.Deserialize(str);
                str.Close();
            }

            try
            {
                savedDeck = (Deck)obj;
                //MessageBox.Show("Deck has been cast.");
            }
            catch (InvalidCastException ex)
            {
                MessageBox.Show("This deck file appears to be corrupt.");
                return new List<Card> { };
            }

            MessageBox.Show("savedDeck has " + savedDeck.cardNames.Count + " cards in it.");

            savedCards = new List<Card> { };

            for (int i = 0; i < savedDeck.cardNames.Count; i++)
            {
                MessageBox.Show("Card " + i + ": " + savedDeck.cardNames[i]);
                MessageBox.Show(saveCards + savedDeck.cardNames[i] + ".cd");
                savedCards.Insert(i, BinaryDeserializeCard(saveCards + savedDeck.cardNames[i] + ".cd"));
                deck.cards.Insert(i, savedCards[i]);

            }
            return savedCards;
        }

        private string setDeckName()
        {
            //"HH" is military time while "hh" is civilian time.
            return user + " " + DateTime.Now.ToString("hh mm tt") + " " + deckName.Text;
        }

        public List<string> getcardNames()
        {
            for (int i = 0; i < deck.cardNames.Count; i++)
            {
                MessageBox.Show(deck.cardNames[i]);
            }
            return deck.cardNames;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //setDeckName();
            //for (int i = 0; i < /*listBox1.Items.Count*/5; i++)
            //{
            //for(int i = 0; i < listBox1.Items.Count; i++)
            //    MessageBox.Show(listBox1.Items[i].ToString());
            try
            {
                for (int i = 0; i < listBox1.Items.Count; i++)
                {
                    deck.cardNames.Insert(i, listBox1.Items[i].ToString());
                }
            }

            catch (ArgumentOutOfRangeException ex) { MessageBox.Show("Argument Out Of Range Error: \n" + ex.Message); }
            //}
            if (autoM == false)
            {
                string deckPath = saveDecks + setDeckName() + ".fc";
                BinarySerialize(deck, deckPath);

                if (MessageBox.Show("Would you like to save this deck to the cloud?", "Uploading", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    uploadDeck(deckPath);
                }
            }

            if (autoM == true)
            {
                BinarySerialize(deck, saveDecksAutoMath + setDeckName() + ".fc");
            }

            deck.cards = new List<Card>();
            deck.cardNames = new List<string>();
            /*int numberOfElementsInCardsBeforeClearing = deck.cards.Count + 1;
            MessageBox.Show(numberOfElementsInCardsBeforeClearing.ToString());
            for (int i = 0; i <= numberOfElementsInCardsBeforeClearing; i++)
            {
                deck.cards.RemoveAt(i);
                //clearThumb(i);
                //initThumbs(i, getThumbPanel(i));
            }*/



            //saveDeckD.ShowDialog();
            //saveDeckFolderD.ShowDialog(); 
            if (currentMode == NextScreen.edTeach)
            {
                /*
                if (wordD == true)
                {
                    edTeach = new EditCardsTeacher(saveDecks + setDeckName() + ".fc", user, tdOriginal);
                    edTeach.OpenDeckB_loadCard(saveDecks + setDeckName() + ".fc", false);
                    Global.form.Controls.Clear();
                    this.Close();
                    Global.form.Controls.Add(edTeach);

                }

                else
                    */
                    edTeach.saveDeck_close();
            }
            if (currentMode == NextScreen.edStud)
            {

                edStud.saveDeck_close();
            }

            this.Close();

            if (currentMode == NextScreen.dashTeach)
                dashTeach.Show();
            if (currentMode == NextScreen.dashStud)
                dashStud.Show();
            if (currentMode == NextScreen.autoMath)
            {
                Global.form.Controls.Clear();
                autoMath = new AutoMath();
                Global.form.Controls.Add(autoMath);
            }

        }

        private void uploadDeck(string deckPath)
        {
            string[] cards = BinaryDeserializeForUpload(deckPath);
            uploadCards(cards);

            WebClient client = new WebClient();
            client.Credentials = new NetworkCredential("flashcard", "flashcard");

            Uri file = new Uri(deckPath);
            string[] path = file.LocalPath.Split('\\');//splits the string into each folder/file name so I can use the file name
            //MessageBox.Show(path[path.Length - 1]);//shows the files string
            string deckName = path[path.Length - 1];

            Uri address = new Uri(@"ftp://www.benkenawell.net/Decks/" + deckName);//sends the file to ftp://benkenawell.net with the given name.
            try
            {
                byte[] arrReturn = client.UploadFile(address, null, deckPath);
            }
            catch (Exception e1)
            {
                MessageBox.Show(deckPath + "\n" + deckName + "\n" + e1.ToString());
            }
            client.DownloadFile(@"ftp://benkenawell.net/Decks/deckNames.txt", @"C:\Cards\temp\deckNames.txt");

            StreamReader fileReader = new StreamReader(@"C:\Cards\temp\deckNames.txt", true);

            string text = "";
            while (true)
            {
                if (text.Equals(deck))
                {
                    fileReader.Close();
                    return;
                }
                else
                    if (fileReader.EndOfStream)
                    {
                        fileReader.Close();
                        break;
                    }
                    else
                        text = fileReader.ReadLine();
            }

            using (System.IO.StreamWriter fileWriter = new System.IO.StreamWriter(@"C:\Cards\temp/deckNames.txt", true))
            {
                fileWriter.WriteLine(deckName);
                fileWriter.Close();
            }

            client.UploadFile(@"ftp://benkenawell.net/Decks/deckNames.txt", @"C:\Cards\temp\deckNames.txt");
            File.Delete(@"C:\Cards\temp\deckNames.txt");
        }

        public string[] BinaryDeserializeForUpload(string filename)
        {

            object obj = null;

            List<string> savedCards = null;
            Deck savedDeck = Deck.getDeck();
            Deck deck = Deck.getDeck();
            MessageBox.Show(filename);
            using (FileStream str = File.OpenRead(filename))
            {
                BinaryFormatter bf = new BinaryFormatter();
                obj = bf.Deserialize(str);
                str.Close();
            }

            try
            {
                savedDeck = (Deck)obj;
            }
            catch (InvalidCastException)
            {
                MessageBox.Show("This deck file appears to be corrupt.");
                return new string[] { };
            }

            savedCards = new List<string> { };

            for (int i = 0; i < savedDeck.cardNames.Count; i++)
            {
                savedCards.Add(savedDeck.cardNames[i]);
            }
            return savedCards.ToArray();
        }

        private void uploadCards(string[] cards)
        {
            WebClient client = new WebClient();
            NetworkCredential nc = new NetworkCredential("flashcard", "flashcard");//username and password needed to upload to ftp server
            client.Credentials = nc;



            for (int i = 0; i < cards.Length; i++)
            {
                uploadCard(cards[i], client);
            }
        }

        private void uploadCard(string card, WebClient client)
        {


            Uri address = new Uri(@"ftp://www.benkenawell.net/Cards/" + card + ".cd");//sends the file to ftp://benkenawell.net with the given name.
            try
            {
                byte[] arrReturn = client.UploadFile(address, null, @"C:\Cards\Created Cards\" + card + ".cd");
            }
            catch (Exception e1)
            {
                MessageBox.Show(@"C:\Cards\Created Cards\" + card + ".cd");
            }
            client.DownloadFile(@"ftp://benkenawell.net/Cards/cardNames.txt", @"C:\Cards\temp\cardNames.txt");

            StreamReader fileReader = new StreamReader(@"C:\Cards\temp\cardNames.txt", true);

            string text = "";
            while (true)
            {
                if (text.Equals(card + ".cd"))
                {
                    fileReader.Close();
                    return;
                }
                else
                    if (fileReader.EndOfStream)
                    {
                        //MessageBox.Show("End of Stream");
                        fileReader.Close();
                        break;
                    }
                    else
                        text = fileReader.ReadLine();
            }

            using (System.IO.StreamWriter fileWriter = new System.IO.StreamWriter(@"C:\Cards\temp\cardNames.txt", true))
            {

                //MessageBox.Show("Writing Line");
                fileWriter.WriteLine(card + ".cd");
                fileWriter.Close();

            }

            client.UploadFile(@"ftp://benkenawell.net/Cards/cardNames.txt", @"C:\Cards\temp\cardNames.txt");
            File.Delete(@"C:\Cards\temp\cardNames.txt");
        }

        //Can we skip this step automatically? Or make it so they can't change the name?
        //Maybe we could make saveDeckFolderD.selectedPath then use the savedialog, but never show it?
        private void saveDeckD_FileOk(object sender, CancelEventArgs e)
        {


            BinarySerialize(deck, saveDeckD.FileName);

        }

        private void listBox1_MouseClick(object sender, MouseEventArgs e)
        {

            int index = this.listBox1.IndexFromPoint(e.Location);
            if (index != System.Windows.Forms.ListBox.NoMatches)
            {
                MessageBox.Show(listBox1.SelectedItem.ToString());
            }
        }

        private void SaveDeck_Load(object sender, EventArgs e)
        {

        }

        private void openDeckD_FileOk(object sender, CancelEventArgs e)
        {
            deck.cards = BinaryDeserialize(openDeckD.FileName);
            MessageBox.Show(deck.deckName + deck.description);
            for (int i = 0; i < deck.cards.Count; i++) // Loop through List with for
            {
                try
                {

                    listBox1.Items.Add(deck.cards[i].cardname);
                }
                catch (ArgumentNullException)
                {
                    MessageBox.Show("Not all cards in the deck have a card name set");
                }
            }
            //textBox1.Text = deck.description;
            //deck.description = textBox1.Text;
            //textBox2.Text = deck.cards.Count.ToString();
            deckName.Text = deck.deckName;
            //deck.deckName = deckName.Text;
        }

        private void openDeck_Click(object sender, EventArgs e)
        {
            openDeckD.ShowDialog();

        }
        //SaveDeckB Student Constructor
        public SaveDeck(string usr, List<string> cardNames, EditCardsStudent form)
        {
            InitializeComponent();
            user = usr;
            deck.deckName = deckName.Text;
            //deck.description = textBox1.Text;
            for (int i = 0; i < cardNames.Count; i++)
            {
                listBox1.Items.Add(cardNames[i]);
            }
            saveDecks = "C:\\Cards\\Created Decks\\";
            saveCards = "C:\\Cards\\Created Cards\\";
            edStud = form;
            currentMode = NextScreen.edStud;
        }
        //SaveDeckB Constructor
        public SaveDeck(string usr, List<String> cardNames, EditCardsTeacher form, bool wordDeck)
        {
            InitializeComponent();
            user = usr;
            wordD = wordDeck;
            deck.deckName = deckName.Text;
            //deck.description = textBox1.Text;str
            for (int i = 0; i < cardNames.Count; i++)
            {
                listBox1.Items.Add(cardNames[i]);
            }
            saveDecks = "C:\\Cards\\Created Decks\\";
            saveCards = "C:\\Cards\\Created Cards\\";
            edTeach = form;
            currentMode = NextScreen.edTeach;
        }

        //AutoMath Constructor
        public SaveDeck(string usr, List<String> cardNames, AutoMath am)
        {
            InitializeComponent();
            user = usr;
            deck.deckName = deckName.Text;

            for (int i = 0; i < cardNames.Count; i++)
            {
                listBox1.Items.Add(cardNames[i]);
            }
            saveDecksAutoMath = "C:\\Cards\\Created Decks\\AutoMath\\";
            autoMath = am;
            autoM = true;
            currentMode = NextScreen.autoMath;

        }


        //HomeB Student constructor
        public SaveDeck(string usr, List<string> cardNames, DashboardStudent sT)
        {
            InitializeComponent();
            user = usr;
            deck.deckName = deckName.Text;
            //deck.description = textBox1.Text;
            for (int i = 0; i < cardNames.Count; i++)
            {
                listBox1.Items.Add(cardNames[i]);
            }
            saveDecks = "C:\\Cards\\Created Decks\\";
            saveCards = "C:\\Cards\\Created Cards\\";
            dashStud = sT;
            currentMode = NextScreen.dashStud;
        }
        //HomeB constructor
        public SaveDeck(string usr, List<string> cardNames, DashboardTeacher dT)
        {
            InitializeComponent();
            user = usr;
            deck.deckName = deckName.Text;
            //deck.description = textBox1.Text;
            for (int i = 0; i < cardNames.Count; i++)
            {
                listBox1.Items.Add(cardNames[i]);
            }
            saveDecks = "C:\\Cards\\Created Decks\\";
            saveCards = "C:\\Cards\\Created Cards\\";
            dashTeach = dT;
            currentMode = NextScreen.dashTeach;
        }

        public string setName()
        {
            return deckName.Text;
        }
        //should be a "get" method


        private void saveDeckFolderD_HelpRequest(object sender, EventArgs e)
        {
            BinarySerialize(deck, saveDeckD.FileName);
        }


    }
}
