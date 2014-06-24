using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Microsoft.Ink;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Drawing.Drawing2D;
using System.Media;
using System.Resources;


namespace WindowsFormsApplication1
{
    public partial class PlayGameTeacher : UserControl
    {


        //Form initFlashCards;

        Deck deck;
        ScoreBoard scores;
        ArrayList subdeck;

        //Group based priority queue implementation
        int[] groupcounts;
        ScoreBoard scoregroup1;
        ScoreBoard scoregroup2;
        ScoreBoard scoregroup3;

        private InkOverlay[] myInkOverlays = new InkOverlay[3];
        int i;                 // how many cards been played so far
        Card currentCard;
        Score currentScore;
        int currentIndex;
        int totalCorrect;
        int subset;            // number of lowest-scored cards to choose from

        int maxCards;          // maximum number of cards to play
        int numLeft;           // number of cards left to play 

        bool randomize = true;

        private const int FRONT = 0;
        private const int BACK = 1;
        private const int ANSWER = 2;
        int win = 0;
        int overrideCount = 0;
        Random r = new Random();
        

        string file;

        DashboardTeacher td;
        private string username;
        //CardList cL;
               
       
        public PlayGameTeacher(DashboardTeacher tOrig, string user)
        {
            td = tOrig;
            username = user;
            InitializeComponent();

            if (currentIndex == maxCards)
            {
                //startP.BackgroundImage = 
                //startGameB.Text = "Finish";//change to picture
                //startP.BackgroundImage = new Bitmap("C:\\Cards\\Images\\button.finish.png");
                startP.Enabled = true;
            }

            myInkOverlays[FRONT] = new InkOverlay(frontPanel.Handle, true);
            myInkOverlays[BACK] = new InkOverlay(backPanel.Handle, true);
            myInkOverlays[ANSWER] = new InkOverlay(answerPanel.Handle, false);

            //openFileDialog1.ShowDialog();
            //cL = new CardList(this);
            //cL.Show();
            file = openFileDialog1.FileName;

            myInkOverlays[BACK].Stroke += new InkCollectorStrokeEventHandler(PlayGameTeacher_Stroke);
        }

        void PlayGameTeacher_Stroke(object sender, InkCollectorStrokeEventArgs e)
        {
            yourAnswerL.Text = "Your Answer: " + myInkOverlays[BACK].Ink.Strokes.ToString();
        }

                       
        private void inkColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
        }

        private void insertImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void PlayGame_Load(object sender, EventArgs e)
        {
            ReplayP.Enabled = false;
            submitP.Enabled = false;
            OverrideP.Enabled = false;
                       
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //axWindowsMediaPlayer1.Ctlcontrols.stop();

            DialogResult dr;

            if (currentIndex != maxCards)
            {
                dr = MessageBox.Show("Are you sure you want to quit? All your hard work will be lost!", "Play or Exit", MessageBoxButtons.YesNo);

                if (dr == System.Windows.Forms.DialogResult.Yes)
                {
                    //axWindowsMediaPlayer1.Ctlcontrols.stop();
                    this.Dispose();
                    td.Show();
                }

                if (dr == System.Windows.Forms.DialogResult.No)
                {
                    return;
                }
                this.Dispose();
                td.Show();

            }
        }

        

        private int startGameBClicked = 0;
        private int index;
        private int cardP = 1;
        private void startGameButton_Click(object sender, EventArgs e)
        {
            startGameBClicked++;
            int randomIndex = r.Next(deck.cards.Count);

            cardProg.Text = "Card: " + " " + cardP + " " + "of" + " " + deck.cards.Count.ToString();
            cardP++;

            if (startGameBClicked <= 1)
            {
                if (originalButton.Checked)
                {
                    //axWindowsMediaPlayer1.URL = @"C:\Users\Kathy\Documents\Ben\C#\Jeopardy (Think Song).mp3";
                    //axWindowsMediaPlayer1.settings.setMode("loop", true);
                    startP.Enabled = false;
                    OverrideP.Enabled = false;
                    startGameB.Text = "Show New Card";//Change to Picture
                    startP.BackgroundImage = new Bitmap(Properties.Resources.button_newcard);
                    index = 0;

                    currentCard = nextCard(index);


                    myInkOverlays[FRONT].Enabled = false;
                    myInkOverlays[FRONT].Ink.Dispose();
                    myInkOverlays[FRONT].Ink = new Ink();
                    myInkOverlays[FRONT].Ink.Load(currentCard.frontInk);
                    myInkOverlays[FRONT].Enabled = true;
                    frontPanel.Refresh();

                    myInkOverlays[BACK].Enabled = true;
                    submitP.Enabled = true;
                    index = 1;
                    originalButton.Enabled = false;
                    randomizeButton.Enabled = false;
                }

                if (randomizeButton.Checked)
                {
                    //MessageBox.Show("Random checked");
                    //axWindowsMediaPlayer1.URL = @"C:\Users\Kathy\Documents\Ben\C#\Jeopardy (Think Song).mp3";
                    //axWindowsMediaPlayer1.settings.setMode("loop", true);
                    startP.Enabled = false;
                    OverrideP.Enabled = false;
                    startGameB.Text = "Show New Card";//Change to Picture
                    startP.BackgroundImage = new Bitmap("C:\\Cards\\Images\\button.newcard.png");
                    currentCard = nextCard(randomIndex);
                    
                    
                    myInkOverlays[FRONT].Enabled = false;
                    myInkOverlays[FRONT].Ink.Dispose();
                    myInkOverlays[FRONT].Ink = new Ink();
                    //check if the card's ink is null or not.  If it is, add a label and add the text to the label.
                    if (currentCard.frontInk == null)
                    {
                        Label frontLabel = new Label();
                        frontLabel.Location = new Point(40, 20);
                        frontLabel.Text = currentCard.question;
                        this.Controls.Add(frontLabel);
                    }
                    else if (currentCard.frontInk != null)
                    {
                        myInkOverlays[FRONT].Ink.Load(currentCard.frontInk);
                    }
                    myInkOverlays[FRONT].Enabled = true;
                    frontPanel.Refresh();

                    myInkOverlays[BACK].Enabled = true;
                    submitP.Enabled = true;
                    randomizeButton.Enabled = false;
                    originalButton.Enabled = false;
                }
            }

            if (startGameBClicked > 1 && startGameBClicked <= deck.cards.Count)
            {
                if (originalButton.Checked)
                {
                    startP.Enabled = false;
                    //MessageBox.Show("index: " + index);
                    currentCard = nextCard(index);
                    index++;

                    myInkOverlays[FRONT].Enabled = false;
                    myInkOverlays[FRONT].Ink.Dispose();
                    myInkOverlays[FRONT].Ink = new Ink();
                    myInkOverlays[FRONT].Ink.Load(currentCard.frontInk);
                    myInkOverlays[FRONT].Enabled = true;

                    myInkOverlays[ANSWER].Ink.DeleteStrokes();
                    //myInkOverlays[ANSWER].Ink.Dispose();
                    myInkOverlays[ANSWER].Ink = new Ink();

                    myInkOverlays[BACK].Ink.DeleteStrokes();
                    myInkOverlays[BACK].Ink = new Ink();

                    /*myInkOverlays[FRONT].Ink.DeleteStrokes();
                    myInkOverlays[FRONT].Ink.Load(currentCard.frontInk);*/
                    Refresh();


                    myInkOverlays[BACK].Enabled = true;
                    submitP.Enabled = true;
                    originalButton.Enabled = false;
                    randomizeButton.Enabled = false;
                }

                if (randomizeButton.Checked)
                {
                    startP.Enabled = false;
                    //MessageBox.Show("index: " + index);
                    currentCard = nextCard(randomIndex);
                    index++;

                    myInkOverlays[FRONT].Enabled = false;
                    myInkOverlays[FRONT].Ink.Dispose();
                    myInkOverlays[FRONT].Ink = new Ink();
                    myInkOverlays[FRONT].Ink.Load(currentCard.frontInk);
                    myInkOverlays[FRONT].Enabled = true;

                    myInkOverlays[ANSWER].Ink.DeleteStrokes();
                    //myInkOverlays[ANSWER].Ink.Dispose();
                    myInkOverlays[ANSWER].Ink = new Ink();

                    myInkOverlays[BACK].Ink.DeleteStrokes();
                    myInkOverlays[BACK].Ink = new Ink();

                    /*myInkOverlays[FRONT].Ink.DeleteStrokes();
                    myInkOverlays[FRONT].Ink.Load(currentCard.frontInk);*/
                    Refresh();


                    myInkOverlays[BACK].Enabled = true;
                    submitP.Enabled = true;
                    randomizeButton.Enabled = false;
                    originalButton.Enabled = false;
                }

            }

                  

            if (startGameBClicked > deck.cards.Count)
            {
                QuitP.Enabled = false;
                submitP.Enabled = false;
                clearP.Enabled = false;

                this.Dispose();
                td.Show();
            }

            int count = myInkOverlays[ANSWER].Ink.Strokes.Count;
            if (index == deck.cards.Count && count != 0)
            {
                //MessageBox.Show("Entered if");
                //MessageBox.Show("Collection count: " + count);
                string FILE_NAME = @"C:\Cards\Student Results\" + username + " " + file.Substring(52) + " " + DateTime.Now.ToString("hh mm tt") + ".txt";
                StreamWriter file2 = new StreamWriter(FILE_NAME);
                file2.WriteLine(scoreLabel.Text + "\n");
                file2.WriteLine("Override Count: " + overrideCount);
                file2.WriteLine("Accuracy: " + (currentIndex/maxCards) + "%");
                for (int u = 0; u < deck.cards.Count; u++)
                {
                    file2.WriteLine("\n" + deck.cards[u].cardname);
                }
                file2.Close();
            }


                //not my code
                if (deck.cards.Count == 0)
                {
                    return;
                }
                if (i < maxCards)
                {
                    //Console.WriteLine("before myAnswer");
                    // erase the user answer panel(right, big panel) strokes
                    //myAnswer_Click(sender, e);  // call clear button

                    // delete the actual answer panel strokes
                    myInkOverlays[ANSWER].Enabled = false;
                    myInkOverlays[ANSWER].Ink.DeleteStrokes(myInkOverlays[ANSWER].Ink.Strokes);

                    //Console.WriteLine("before Refresh");
                    Refresh();

                    if (subdeck.Count == 0)
                    {
                        //genSubSet();
                        //leitner();
                        //Console.WriteLine("Subdeck regenerated!\n\n");

                    }

                    //Console.WriteLine("before chooseCard");
                    //chooseCard();  // currentCard and currentIndex updated to the new card

                    // load the next card on the left panel           
                    myInkOverlays[FRONT].Enabled = false;
                    myInkOverlays[FRONT].Ink.Dispose();
                    myInkOverlays[FRONT].Ink = new Ink();

                    // change here in the future to allow card flipping 
                    myInkOverlays[FRONT].Ink.Load(currentCard.frontInk);

                    if (currentCard.panelBackground != null)
                    {
                        Card.FitImage(frontPanel, currentCard.panelBackground);
                    }

                    /*//Console.WriteLine("before Image stuff");
                    if (currentCard.frontImage != null && currentCard.frontImage.Length > 0)
                    {
                        Card.FitImage(frontPanel, Image.FromStream(new MemoryStream(Convert.FromBase64String(currentCard.frontImage))));
                    }
                    else
                    {
                        if (deck.backgroundImage == null || deck.backgroundImage.Length == 0)
                        {
                            //frontPanel.Image = null;
                        }
                        else
                        {
                            Card.FitImage(frontPanel, Image.FromStream(new MemoryStream(Convert.FromBase64String(deck.backgroundImage))));
                        }
                    
                }

                /*if (startGameBClicked > deck.cards.Count)
                {
                    startGameButton.Text = "Finish";
                }*/
            }

                yourAnswerL.Text = "Your Answer:";    
        }

        public void playAgain()
        {
            
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

            //MessageBox.Show("savedDeck has " + savedDeck.cardNames.Count + " cards in it.");

            savedCards = new List<Card> { };

            for (int i = 0; i < savedDeck.cardNames.Count; i++)
            {
                //MessageBox.Show("Card " + i + ": " + savedDeck.cardNames[i]);
                //MessageBox.Show(saveCards + savedDeck.cardNames[i] + ".cd");
                savedCards.Insert(i, BinaryDeserializeCard(@"C:\Cards\Created Cards\" + savedDeck.cardNames[i] + ".cd"));
                deck.cards.Insert(i, savedCards[i]);

            }

            return savedCards;
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

            deck = Deck.getDeck();
            deck.cards = BinaryDeserialize(openFileDialog1.FileName);

            //Card currentCard = nextCard(0);
            //myInkOverlays[FRONT].Ink.Load(currentCard.frontInk);
        }

        public void openDeck(string deckName)
        {
            deck = Deck.getDeck();
            deck.cards = BinaryDeserialize(deckName);
        }

        private void newCardButton_Click(object sender, EventArgs e)
        {
        }

        private void submitB_Click(object sender, EventArgs e)
        {
            bool correct;
            startP.Enabled = true;
            myInkOverlays[ANSWER].Ink.Load(currentCard.backInk);
            answerPanel.Refresh();
            myInkOverlays[BACK].Enabled = false;
            
            if (currentCard.gradeable)
            {
                correct = checkAnswer();
                if (correct)
                    OverrideP.Enabled = false;
                else
                {
                    OverrideP.Enabled = true;

                }
            }
            else
                teacherCheck();
            submitP.Enabled = false;
        }

        private Card nextCard(int index)
        {
            return deck.cards[index];
        }

        private double cardProgress = 0.0;
        private bool checkAnswer()
        {
            //MessageBox.Show(myInkOverlays[BACK].Ink.Strokes.ToString(), "Your Answer");
            //MessageBox.Show(myInkOverlays[ANSWER].Ink.Strokes.ToString(), "Actual Answer");
            cardProgress++;
            double deckcount = (double)deck.cards.Count;
            double increment = (cardProgress / deckcount) * 100.0;
            int increment2 = (int)(increment);


            try
            {

                if (myInkOverlays[BACK].Ink.Strokes.ToString().ToLower().Equals(myInkOverlays[ANSWER].Ink.Strokes.ToString().ToLower()))
                {
                    //MessageBox.Show("Correct! \nIn if statement", "Correct");
                    //MessageBox.Show("Increment: " + increment2 + "\n" + "Cards in Deck: " + deckCount);
                    win++;
                    scoreLabel.Text = "Score: " + win;
                    //MessageBox.Show("Increment: " + increment2.ToString());
                    //progressBar1.Maximum = 100;
                    //progressBar1.Value = (increment2);
                    //MessageBox.Show("Progress Bar Value: " + progressBar1.Value.ToString());
                    if (currentIndex == maxCards)
                    {
                        //MessageBox.Show("You have finished.");

                    }
                    double accuracy = ((double)win / cardProgress) * 100.0;
                    string acc = accuracy.ToString("#.##");
                    accuracyLabel.Text = "Accuracy: " + acc + "%";
                    if (startGameBClicked == deck.cards.Count)
                    {
                        startP.Text = "Finish";
                        startP.BackgroundImage = new Bitmap("C:\\Cards\\Images\\button.finish.png");
                        //axWindowsMediaPlayer1.Ctlcontrols.stop();
                        ReplayP.Enabled = true;
                    }
                    //cardProgress++;
                    //MessageBox.Show("Card Progress: " + cardProgress);
                    return true;
                }
                else
                {
                    deck.cards.Add(currentCard);
                    deckcount++;
                    //int prevProgBarValue = progressBar1.Value;
                    //MessageBox.Show("Incorrect \nIn else statement", "Incorrect");
                    //MessageBox.Show("Win: " + win.ToString());
                    double accuracy = ((double)win / cardProgress) * 100.0;
                    string acc = accuracy.ToString("#.##");
                    
                    if(accuracy > 0.0)
                        accuracyLabel.Text = "Accuracy: " + acc + "%";
                    else
                        accuracyLabel.Text = "Accuracy: 0%";
                    double increment2Wrong = (cardProgress / ((double)deckcount)) * 100.0;
                    int incrementFinal = (int)increment2Wrong;
                    //MessageBox.Show("Increment: " + incrementFinal);
                    //progressBar1.Maximum = 100;
                    //progressBar1.Value = (incrementFinal);
                    //MessageBox.Show("Progress Bar Value: " + progressBar1.Value.ToString());
                    if (currentIndex == maxCards)
                    {
                        //MessageBox.Show("You have finished.");

                    }
                    //cardProgress++;
                    //MessageBox.Show("Card Progress: " + cardProgress);
                    return false;
                }

            }
            catch (NullReferenceException)
            {
                //MessageBox.Show("Incorrect \nIn catch statement");
                return false;
            }


        }

        private void overrideB_Click(object sender, EventArgs e)
        {

            //MessageBox.Show("Overriden to Correct");
            int indexRange = deck.cards.Count - 1;
            deck.cards.RemoveAt(indexRange);
            overrideCount++;
            win++;
            scoreLabel.Text = "Score: " + win;
            double deckcount = (double)deck.cards.Count;
            double increment = (cardProgress / deckcount) * 100.0;
            int increment2 = (int)(increment);
            //MessageBox.Show("Deck count: " + deckcount);
            //MessageBox.Show("Value being set to: " + increment2);
            //progressBar1.Maximum = 100;
            //progressBar1.Value = (increment2);
            double accuracy = ((double)win / cardProgress) * 100.0;
            string acc = accuracy.ToString("#.##");
            accuracyLabel.Text = "Accuracy: " + acc + "%";
            if (startGameBClicked == deck.cards.Count)
            {
                startP.Text = "Finish";
                startP.BackgroundImage = new Bitmap("C:\\Cards\\Images\\button.finish.png");
                //axWindowsMediaPlayer1.Ctlcontrols.stop();
                ReplayP.Enabled = true;
            }

            //MessageBox.Show("Number of cards: " + deck.cards.Count);

        }

        private void teacherCheck()
        {
            //byte[] pic = new byte[myInkOverlays[BACK].Ink.Strokes.Count];
            MessageBox.Show("Answer will be evaluated by teacher");
            /*for (int i = 0; i < myInkOverlays[BACK].Ink.Strokes.Count; i++)
            {
                pic = myInkOverlays[BACK].Ink.Save(PersistenceFormat.InkSerializedFormat, CompressionMode.Maximum);
            }

            PictureBox bmp = new PictureBox();
            bmp.Image = BitmapFromStrokes(pic);*/

            FileStream gifFile;
            byte[] fortifiedGif = null;

            Directory.CreateDirectory("c:\\toBeGraded\\" + currentCard.cardname);
            //MessageBox.Show("c:\\toBeGraded\\" + currentCard.cardname);
            gifFile = File.OpenWrite("c:\\toBeGraded\\Ben.gif");
            fortifiedGif = myInkOverlays[BACK].Ink.Save(PersistenceFormat.Gif);
            gifFile.Write(fortifiedGif, 0, fortifiedGif.Length);
            gifFile.Close();
        }

        private void replayB_Click_1(object sender, EventArgs e)
        {
            deck = Deck.getDeck();
            deck.cards = BinaryDeserialize(file);
            //progressBar1.Value = 0;
            accuracyLabel.Text = "Accuracy: ";

            string FILE_NAME = @"C:\Cards\Student Results\" + username + " " + file.Substring(52) + " " + DateTime.Now.ToString("hh mm tt") + ".txt";
            StreamWriter file2 = new StreamWriter(FILE_NAME);
            file2.WriteLine(scoreLabel.Text + "\n");
            file2.WriteLine("Override Count: " + overrideCount);
            file2.WriteLine("Accuracy: " + (currentIndex / maxCards) + "%");
            for (int u = 0; u < deck.cards.Count; u++)
            {
                file2.WriteLine("\n" + deck.cards[u].cardname);
            }
            file2.Close();

            startGameBClicked = 0;
            win = 0;
            scoreLabel.Text = "Score: " + win;

            myInkOverlays[ANSWER].Ink.DeleteStrokes();
            //myInkOverlays[ANSWER].Ink.Dispose();
            myInkOverlays[ANSWER].Ink = new Ink();

            myInkOverlays[BACK].Ink.DeleteStrokes();
            myInkOverlays[BACK].Ink = new Ink();

            /*myInkOverlays[FRONT].Ink.DeleteStrokes();
            myInkOverlays[FRONT].Ink.Load(currentCard.frontInk);*/
            Refresh();

            startGameButton_Click(null, null);
        }

        bool ink = true;
        private void clearB_Click(object sender, EventArgs e)
        {
            try
            {
                ink = !ink;
                if (!ink)
                {
                    myInkOverlays[FRONT].EditingMode = InkOverlayEditingMode.Delete;
                    myInkOverlays[BACK].EditingMode = myInkOverlays[FRONT].EditingMode;
                    //clearP.Text = "Toggle Ink";
                    //clearP.Image = new Bitmap(Image.FromFile(Environment.CurrentDirectory + "\\eraser.bmp"));
                    inkToggleP.BackgroundImage = new Bitmap("C:\\Cards\\Images\\button.toggleerase.png");
                }

                if (ink)
                {
                    myInkOverlays[FRONT].EditingMode = InkOverlayEditingMode.Ink;
                    myInkOverlays[BACK].EditingMode = myInkOverlays[FRONT].EditingMode;
                    //clearP.Text = "Toggle Erase";
                    //clearP.Image = new Bitmap(Image.FromFile(Environment.CurrentDirectory + "\\pen.bmp"));
                    inkToggleP.BackgroundImage = new Bitmap("C:\\Cards\\Images\\button.toggleink.png");
                }
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("We are sorry for the error.  \nPlease restart the program, we are working on a fix.", "Invalid Operation Exception");
            }
        }
    }
}
