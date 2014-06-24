using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;

namespace WindowsFormsApplication1
{
    public partial class CardList : Form
    {

        CreateCard createCard;
        EditCardsTeacher edTeach;
        EditCardsStudent edStud;
        PlayGameStudent playStud;
        CreateCardStudent scc;
        PlayGameTeacher playTeach;
        private string fname;
        //private const string FILE_NAME = "C:\\Users\\Kathy\\Documents\\Ben\\C#\\Save Files\\filename.txt";
        private string saveCards = "C:\\Cards\\Created Cards\\";
        private string saveDecks = "C:\\Cards\\Created Decks\\";
        private string saveCardsStudent = "C:\\Cards\\Student Cards\\";
        private string openAutoMath = "C:\\Cards\\Created Cards\\AutoMath\\";
        private string openAutoMathD = "C:\\Cards\\Created Decks\\AutoMath\\";
        private Mode currentMode;
        string nameOfDeck;

        enum Mode
        {
            addCardButton = 0,
            openCard,
            openDeck,
            studentPlayGame,
            createCardStudent,
            openDeckStudent,
            addCardButtonStudent,
            teacherPlayGame,
            teachCStudCard,
            openAutoMathCard
        };


        public CardList()
        {
            InitializeComponent();
        }

        //Teacher Card List Constructor to access student cards
        public CardList(CreateCard cretCard, string studentCardListcontructor)
        {
            InitializeComponent();
            createCard = cretCard;

            DirectoryInfo dir = new DirectoryInfo(saveCardsStudent);
            foreach(FileInfo f in dir.GetFiles("*.cd"))
            {
                checkedListBox1.Items.Add(f.Name);
            }
            /*string[] filepaths = Directory.GetFiles(saveCardsStudent);
            foreach (string file in filepaths)
            {
                checkedListBox1.Items.Add(file);

            }*/
            fillGlobalLBCards();
            currentMode = Mode.teachCStudCard;
        }

        public CardList(CreateCard cc)
        {
            InitializeComponent();
            createCard = cc;

            DirectoryInfo dir = new DirectoryInfo(saveCards);
            foreach (FileInfo f in dir.GetFiles("*.cd"))
            {
                checkedListBox1.Items.Add(f.Name);
            }

            /*string[] filepaths = Directory.GetFiles(saveCards);
            foreach (string file in filepaths)
            {
                checkedListBox1.Items.Add(file);

            }*/

            DirectoryInfo dir2 = new DirectoryInfo(openAutoMath);
            foreach (FileInfo f in dir2.GetFiles("*.cd"))
            {
                checkedListBox2.Items.Add(f.Name);
            }
            fillGlobalLBCards();
            currentMode = Mode.openCard;
        }

        //CreateCardStudent Constructor
        public CardList(CreateCardStudent scretCard)
        {
            InitializeComponent();
            scc = scretCard;

            DirectoryInfo dir = new DirectoryInfo(saveCardsStudent);
            foreach (FileInfo f in dir.GetFiles("*.cd"))
            {
                checkedListBox1.Items.Add(f.Name);
            }
            /*string[] filepaths = Directory.GetFiles(saveCardsStudent);
            foreach (string file in filepaths)
            {
                checkedListBox1.Items.Add(file);

            }*/
            fillGlobalLBCards();
            currentMode = Mode.createCardStudent;
        }

        //Add Card Student List Constructor
        public CardList(EditCardsStudent sT)
        {
            InitializeComponent();
            edStud = sT;

            DirectoryInfo dir = new DirectoryInfo(saveCards);
            foreach (FileInfo f in dir.GetFiles("*.cd"))
            {
                checkedListBox1.Items.Add(f.Name);
            }

            /*string[] filepaths = Directory.GetFiles(saveCards);
            foreach (string file in filepaths)
            {
                checkedListBox1.Items.Add(file);

            }*/
            fillGlobalLBCards();
            currentMode = Mode.addCardButtonStudent;
        }
        //Add Card List Constructor
        public CardList(EditCardsTeacher eT)
        {
            InitializeComponent();
            edTeach = eT;

            DirectoryInfo dir = new DirectoryInfo(saveCards);
            foreach (FileInfo f in dir.GetFiles("*.cd"))
            {
                checkedListBox1.Items.Add(f.Name);
            }

            /*string[] filepaths = Directory.GetFiles(saveCards);
            foreach (string file in filepaths)
            {
                checkedListBox1.Items.Add(file);

            }*/

            DirectoryInfo dir2 = new DirectoryInfo(openAutoMath);
            foreach (FileInfo f in dir.GetFiles("*.cd"))
            {
                checkedListBox2.Items.Add(f.Name);
            }
            fillGlobalLBCards();
            currentMode = Mode.addCardButton;
        }

        //Student Deck List Contsructor
        public CardList(EditCardsStudent sT, string deckListConstructor)
        {
            InitializeComponent();
            edStud = sT;

            DirectoryInfo dir = new DirectoryInfo(saveDecks);
            foreach (FileInfo f in dir.GetFiles("*.fc"))
            {
                checkedListBox1.Items.Add(f.Name);
            }

            /*string[] filepaths = Directory.GetFiles(saveDecks);
            foreach (string file in filepaths)
            {
                checkedListBox1.Items.Add(file);

            }*/
            fillGlobalLBDecks();
            currentMode = Mode.openDeckStudent;
        }
        //Deck List Contructor
        public CardList(EditCardsTeacher eT, string deckListConstructor)
        {
            InitializeComponent();
            edTeach = eT;

            DirectoryInfo dir = new DirectoryInfo(saveDecks);
            foreach (FileInfo f in dir.GetFiles("*.fc"))
            {
                checkedListBox1.Items.Add(f.Name);
            }
            /*
            string[] filepaths = Directory.GetFiles(saveDecks);
            foreach (string file in filepaths)
            {
                checkedListBox1.Items.Add(file);

            }*/
            fillGlobalLBDecks();
            DirectoryInfo dir2 = new DirectoryInfo(openAutoMathD);
            foreach (FileInfo f in dir2.GetFiles("*.fc"))
            {
                checkedListBox2.Items.Add(f.Name);
            }

            currentMode = Mode.openDeck;
        }

        public CardList(PlayGameTeacher pgT, string usr)
        {
            InitializeComponent();
            playTeach = pgT;

            DirectoryInfo dir = new DirectoryInfo(saveDecks);
            foreach (FileInfo f in dir.GetFiles("*.fc"))
            {
                checkedListBox1.Items.Add(f.Name);
            }
            /*
            string[] filepaths = Directory.GetFiles(saveDecks);
            foreach (string file in filepaths)
            {
                checkedListBox1.Items.Add(file);

            }*/
            fillGlobalLBDecks();
            currentMode = Mode.teacherPlayGame;
        }
        public CardList(PlayGameStudent pgS)
        {
            InitializeComponent();
            playStud = pgS;

            DirectoryInfo dir = new DirectoryInfo(saveDecks);
            foreach (FileInfo f in dir.GetFiles("*.fc"))
            {
                checkedListBox1.Items.Add(f.Name);
            }

            /*string[] filepaths = Directory.GetFiles(saveDecks);
            foreach (string file in filepaths)
            {
                checkedListBox1.Items.Add(file);

            }*/
            
            DirectoryInfo dir2 = new DirectoryInfo(openAutoMathD);
            foreach (FileInfo f in dir2.GetFiles("*.fc"))
            {
                checkedListBox2.Items.Add(f.Name);
            }
            fillGlobalLBDecks();
            currentMode = Mode.studentPlayGame;
        }

        private void CardList_Load(object sender, EventArgs e)
        {                        
            
        }

        string serverPathCards = @"ftp://www.benkenawell.net/Cards/";
        string serverPathDecks = @"ftp://www.benkenawell.net/Decks/";
        string localPathCards = @"C:\Cards\Created Cards\";
        string localPathDecks = @"C:\Cards\Created Decks\";
        string tempPath = @"C:\Cards\temp\";

        private void fillGlobalLBDecks()
        {
            WebClient client = new WebClient();
            client.Credentials = new NetworkCredential("flashcard", "flashcard");

            client.DownloadFile(serverPathDecks + "deckNames.txt", tempPath + "deckNames.txt");

            string[] files = File.ReadAllLines(tempPath + "deckNames.txt");
            globalLB.Items.AddRange(files);
            

            File.Delete(tempPath + "deckNames.txt");
        }

        private void fillGlobalLBCards()
        {
            WebClient client = new WebClient();
            client.Credentials = new NetworkCredential("flashcard", "flashcard");

            client.DownloadFile(serverPathCards + "cardNames.txt", tempPath + "cardNames.txt");

            string[] files = File.ReadAllLines(tempPath + "cardNames.txt");
            globalLB.Items.AddRange(files);


            File.Delete(tempPath + "cardNames.txt");
        }

        private void downloadDeck(string deckDownloadPath, string cardDownloadPath, string item)
        {
            WebClient client = new WebClient();
            client.Credentials = new NetworkCredential("flashcard", "flashcard");
            
            MessageBox.Show(item);
            client.DownloadFile(serverPathDecks + item, deckDownloadPath + item);

            string[] cards = BinaryDeserialize(item);
            downloadCards(cards, cardDownloadPath);
        }

        private void downloadCards(string[] cards, string downloadPath)
        {
            try
            {
                WebClient client = new WebClient();
                NetworkCredential nc = new NetworkCredential("flashcard", "flashcard");

                client.Credentials = nc;
                for (int i = 0; i < cards.Length; i++)
                {
                    client.DownloadFile(serverPathCards + cards[i] + ".cd", downloadPath + cards[i] + ".cd");
                }
            }

            catch (Exception e1)
            {
                MessageBox.Show(e1.ToString() + "\n" + e1.Message);//just in case something goes wrong
            }
        }

        // Deserialize a string array from a binary file.
        public string[] BinaryDeserialize(string filename)
        {

            object obj = null;

            List<string> savedCards = null;
            Deck savedDeck = Deck.getDeck();
            Deck deck = Deck.getDeck();

            using (FileStream str = File.OpenRead("C:\\Cards\\Created Decks\\" + filename))
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

        private void downloadCard(string downloadPath, string item)
        {
            try
            {
                WebClient client = new WebClient();
                NetworkCredential nc = new NetworkCredential("flashcard", "flashcard");

                client.Credentials = nc;
                
                    client.DownloadFile(serverPathCards + item, downloadPath + item);
            }

            catch (Exception e1)
            {
                MessageBox.Show(e1.ToString() + "\n" + e1.Message);//just in case something goes wrong
            }
        }

        private void openB_Click(object sender, EventArgs e)
        {
            //sw = new StreamWriter();
            //string[] filepaths = Directory.GetFiles("C:\\Users\\Kathy\\Documents\\Ben\\C#\\Save Files\\Cards\\");


            if ((checkedListBox1.CheckedItems.Count > 1 || checkedListBox2.CheckedItems.Count > 1 || globalLB.CheckedItems.Count > 1) || (checkedListBox1.CheckedItems.Count >= 1 && checkedListBox2.CheckedItems.Count >= 1) ||
                (checkedListBox1.CheckedItems.Count >= 1 && globalLB.CheckedItems.Count >= 1)  || (globalLB.CheckedItems.Count >= 1 && checkedListBox2.CheckedItems.Count >= 1))
            {

                MessageBox.Show("Please only check one card to open.");
            }

            else if (checkedListBox1.CheckedItems.Count == 1)
            {
                //string cardName;
                    foreach (string item in checkedListBox1.CheckedItems)
                    {
                        //createCard = new CreateCard(item);
                        /*if(File.Exists(FILE_NAME))
                        {
                            File.Delete(FILE_NAME);
                        }
                        StreamWriter file = new StreamWriter("C:\\Users\\Kathy\\Documents\\Ben\\C#\\Save Files\\filename.txt", true);
                        file.WriteLine(item);
                        file.Close();*/

                        //cardName = item;
                        //MessageBox.Show(item);
                        nameOfDeck = item;
                        if (currentMode == Mode.addCardButton)
                            edTeach.getAddCard(saveCards + item);
                        if (currentMode == Mode.openCard)
                            createCard.getCard(saveCards + item);
                        if (currentMode == Mode.openDeck)
                            edTeach.OpenDeckB_loadCard(saveDecks + item,false);
                        if (currentMode == Mode.studentPlayGame)
                            playStud.openDeck(saveDecks+ item, nameOfDeck,false);
                        if (currentMode == Mode.createCardStudent)
                            scc.getCard(saveCardsStudent + item);
                        if (currentMode == Mode.openDeckStudent)
                            edStud.OpenDeckB_loadCard(saveDecks + item);
                        if (currentMode == Mode.addCardButtonStudent)
                            edStud.getAddCard(saveCards + item);
                        if (currentMode == Mode.teacherPlayGame)
                            playTeach.openDeck(saveDecks + item);
                        if (currentMode == Mode.teachCStudCard)
                            createCard.getCard(saveCardsStudent + item);
                    }


            }

            else if (checkedListBox2.CheckedItems.Count == 1)
            {
                foreach (string item in checkedListBox2.CheckedItems)
                {
                    nameOfDeck = item;
                    if (currentMode == Mode.openCard)
                        createCard.getCard(openAutoMath + item);
                    if (currentMode == Mode.openDeck)
                        edTeach.OpenDeckB_loadCard(openAutoMathD + item,true);
                    if (currentMode == Mode.studentPlayGame)
                        playStud.openDeck(openAutoMathD + item, nameOfDeck,true);
                    
                }
            }


            else if (globalLB.CheckedItems.Count == 1)
            {
                foreach (string item in globalLB.CheckedItems)
                {
                    nameOfDeck = item;
                    if (currentMode == Mode.addCardButton)
                    {
                        downloadCard(saveCards, item);
                        edTeach.getAddCard(saveCards + item);
                    }
                    if (currentMode == Mode.openCard)
                    {
                        downloadCard(saveCards, item);
                        createCard.getCard(saveCards + item);
                    }
                    if (currentMode == Mode.openDeck)
                    {
                        downloadDeck(saveDecks, saveCards, item);
                        edTeach.OpenDeckB_loadCard(saveDecks + item, false);
                    }
                    if (currentMode == Mode.studentPlayGame)
                    {
                        downloadDeck(saveDecks, saveCards,  item);
                        playStud.openDeck(saveDecks + item, nameOfDeck, false);
                    }
                    if (currentMode == Mode.createCardStudent)
                    {
                        downloadCard(saveCardsStudent, item);
                        scc.getCard(saveCardsStudent + item);
                    }
                    if (currentMode == Mode.openDeckStudent)
                    {
                        downloadDeck(saveDecks, saveCards, item);
                        edStud.OpenDeckB_loadCard(saveDecks + item);
                    }
                    if (currentMode == Mode.addCardButtonStudent)
                    {
                        downloadCard(saveCards, item);
                        edStud.getAddCard(saveCards + item);
                    }
                    if (currentMode == Mode.teacherPlayGame)
                    {
                        downloadDeck(saveDecks, saveCards, item);
                        playTeach.openDeck(saveDecks + item);
                    }
                    if (currentMode == Mode.teachCStudCard)
                    {
                        downloadCard(saveCardsStudent, item);
                        createCard.getCard(saveCardsStudent + item);
                    }
                }
            }
            //edTeach.getAddCard(saveCards +);

            this.Hide();
        }

              
    }
}
