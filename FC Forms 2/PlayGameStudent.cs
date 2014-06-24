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


namespace WindowsFormsApplication1
{
    public partial class PlayGameStudent : UserControl
    {

        Form initFlashCards;

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
        bool inkCard = true;
        bool autoM = false;


        string file;

        DashboardStudent sd;
        private string username;
        string saveDecks, saveCards, FILE_NAME, environmentFilepath, saveAutoMathCards;
        //CardList cL;


        public PlayGameStudent(DashboardStudent sOrig, string user)
        {
            sd = sOrig;
            username = user;
            InitializeComponent();
            environmentFilepath = "C:";
            saveCards = environmentFilepath + "\\Cards\\Created Cards\\";
            saveDecks = environmentFilepath + "\\Cards\\Created Decks\\";
            saveAutoMathCards = environmentFilepath + "\\Cards\\Created Cards\\AutoMath\\";
            if (currentIndex == maxCards)
            {
                startGameB.Text = "Finish";
                startP.Enabled = true;
            }

            myInkOverlays[FRONT] = new InkOverlay(frontPanel.Handle, true);
            myInkOverlays[BACK] = new InkOverlay(backPanel.Handle, true);
            myInkOverlays[ANSWER] = new InkOverlay(answerPanel.Handle, false);

            
            myInkOverlays[BACK].Ink.Strokes.Scale(0.75f, 0.75f);
            myInkOverlays[ANSWER].Ink.Strokes.Scale(0.75f, 0.75f);

            //openFileDialog1.ShowDialog();
            //cL = new CardList(this);
            //cL.Show();
            file = openFileDialog1.FileName;
            //saveDecks = environmentFilepath + "\\Cards\\Created Decks\\";

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
            replayP.Enabled = false;
            submitP.Enabled = false;
            overrideP.Enabled = false;
            //cardProg.Text = 1 + " " + "of" + " " + deck.cards.Count;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Strokes collectionFront = myInkOverlays[FRONT].Ink.Strokes;
            Strokes collectionBack = myInkOverlays[BACK].Ink.Strokes;
            Strokes collectionAnswer = myInkOverlays[ANSWER].Ink.Strokes;

            DialogResult dr;

            if (currentIndex != maxCards)
            {
                dr = MessageBox.Show("Are you sure you want to quit? All your hard work will be lost!", "Play or Exit", MessageBoxButtons.YesNo);

                if (dr == System.Windows.Forms.DialogResult.Yes)
                {
                    //axmediaplayer1.Ctlcontrols.stop();
                    this.Dispose();
                    sd.Show();
                }

                if (dr == System.Windows.Forms.DialogResult.No)
                {
                    return;
                }

            }

            if (currentIndex == maxCards)
            {
                //axmediaplayer1.Ctlcontrols.stop();
                this.Dispose();
                sd.Show();
            }
        }



        private int startGameBClicked = 0;
        private int index;
        private int cardProgr = 0;


        public void playAgain()
        {

        }

        public Card BinaryDeserializeCard(String filename)
        {
            //compatability issue
            //ArrayList temp = null;
            object obj = null;

            Card savedCard = null;
            try
            {
                using (FileStream str = File.OpenRead(filename))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    obj = bf.Deserialize(str);
                    str.Close();
                }
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("File was not found, please choose another file.\nRemember, you must have all the cards in a deck to play the deck.");
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

            try
            {
                using (FileStream str = File.OpenRead(filename))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    obj = bf.Deserialize(str);
                    str.Close();
                }
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("File was not found. Please choose another file.");
            }
            try
            {
                savedDeck = (Deck)obj;
                //MessageBox.Show("Deck has been cast.");
            }
            catch (InvalidCastException)
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
                if(autoM == false)
                savedCards.Insert(i, BinaryDeserializeCard(saveCards + savedDeck.cardNames[i] + ".cd"));
                if(autoM == true)
                savedCards.Insert(i, BinaryDeserializeCard(saveAutoMathCards + savedDeck.cardNames[i] + ".cd"));
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

        private string deckname;
        public void openDeck(string deckName, string nameOfDeck,bool autoMath)
        {
            deck = Deck.getDeck();
            autoM = autoMath;
            deck.cards = BinaryDeserialize(deckName);
            deckname = nameOfDeck;
        }

        private void newCardButton_Click(object sender, EventArgs e)
        {
        }

        private void submitB_Click(object sender, EventArgs e)
        {
            bool correct;
            startP.Enabled = true;
            try
            {
                myInkOverlays[ANSWER].Ink.Load(currentCard.backInk);
                myInkOverlays[ANSWER].Ink.Strokes.Scale(0.75f, 0.75f);
            }
            catch (ArgumentException)
            {
            }
            if (currentCard.wordCard == true)
            {
                //inkCard = false;
                WordCardShow(false, true);
            }
            if (currentCard.autoMathCard == true)
            {
                //inkCard = false;
                AutoMathCardShow(false, true);
            }
            answerPanel.Refresh();
            myInkOverlays[BACK].Enabled = false;

            if (currentCard.gradeable)
            {
                correct = checkAnswer();
                if (correct)
                    overrideP.Enabled = false;
                else
                {
                    overrideP.Enabled = true;

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
            if (inkCard == true)
            {
                MessageBox.Show("Your answer: " + myInkOverlays[BACK].Ink.Strokes.ToString() + "\n" + "Actual Answer: " + myInkOverlays[ANSWER].Ink.Strokes.ToString(), "Evaluate");
                //MessageBox.Show(myInkOverlays[ANSWER].Ink.Strokes.ToString(), "Actual Answer");
                cardProgress++;

                double deckcount = (double)deck.cards.Count;
                double increment = (cardProgress / deckcount) * 100.0;
                int increment2 = (int)(increment);


                try
                {

                    if (myInkOverlays[BACK].Ink.Strokes.ToString().ToLower().Equals(myInkOverlays[ANSWER].Ink.Strokes.ToString().ToLower()))
                    {
                        //MessageBox.Show("Index: " + index + "Current Index" + currentIndex);
                        MessageBox.Show("Correct! :)", "Correct");
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
                            //randomizeButton.Enabled = true;
                            originalButton.Enabled = true;

                        }
                        double accuracy = ((double)win / cardProgress) * 100.0;
                        string acc = accuracy.ToString("#.##");
                        accuracyLabel.Text = "Accuracy: " + acc + "%";
                        if (startGameBClicked == deck.cards.Count)
                        {
                            startGameB.Text = "Finish";
                            //axmediaplayer1.Ctlcontrols.stop();
                            replayP.Enabled = true;
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
                        MessageBox.Show("Incorrect :(", "Incorrect");
                        //MessageBox.Show("Win: " + win.ToString());
                        double accuracy = ((double)win / cardProgress) * 100.0;
                        string acc = accuracy.ToString("#.##");
                        if (accuracy > 0.0)
                        {
                            accuracyLabel.Text = "Accuracy: " + acc + "%";
                        }
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
                            //randomizeButton.Enabled = true;
                            originalButton.Enabled = true;

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

            if (inkCard == false && currentCard.autoMathCard == true)
            {
                //MessageBox.Show("Index: " + index + "Current Index" + currentIndex);
                MessageBox.Show("Your answer: " + myInkOverlays[BACK].Ink.Strokes.ToString() + "\n" + "Actual Answer: " + currentCard.answer.ToString() , "Evaluate");
                //MessageBox.Show(myInkOverlays[ANSWER].Ink.Strokes.ToString(), "Actual Answer");
                cardProgress++;

                double deckcount = (double)deck.cards.Count;
                double increment = (cardProgress / deckcount) * 100.0;
                int increment2 = (int)(increment);


                try
                {

                    if (myInkOverlays[BACK].Ink.Strokes.ToString().ToLower().Equals(currentCard.answer.ToString().ToLower()))
                    {
                        MessageBox.Show("Correct! :)", "Correct");
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
                            //randomizeButton.Enabled = true;
                            originalButton.Enabled = true;

                        }
                        double accuracy = ((double)win / cardProgress) * 100.0;
                        string acc = accuracy.ToString("#.##");
                        accuracyLabel.Text = "Accuracy: " + acc + "%";
                        if (startGameBClicked == deck.cards.Count)
                        {
                            startGameB.Text = "Finish";
                            //axmediaplayer1.Ctlcontrols.stop();
                            replayP.Enabled = true;
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
                        MessageBox.Show("Incorrect :(", "Incorrect");
                        //MessageBox.Show("Win: " + win.ToString());
                        double accuracy = ((double)win / cardProgress) * 100.0;
                        string acc = accuracy.ToString("#.##");
                        if (accuracy > 0.0)
                        {
                            accuracyLabel.Text = "Accuracy: " + acc + "%";
                        }
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
                            //randomizeButton.Enabled = true;
                            originalButton.Enabled = true;

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

            if (inkCard == false && currentCard.wordCard == true)
            {
                //MessageBox.Show("Index: " + index + "Current Index" + currentIndex);
                MessageBox.Show("Your answer: " + myInkOverlays[BACK].Ink.Strokes.ToString() + "\n" + "Actual Answer: " + currentCard.answerWord.Trim(), "Evaluate");
                //MessageBox.Show(myInkOverlays[ANSWER].Ink.Strokes.ToString(), "Actual Answer");
                cardProgress++;

                double deckcount = (double)deck.cards.Count;
                double increment = (cardProgress / deckcount) * 100.0;
                int increment2 = (int)(increment);


                try
                {

                    if (myInkOverlays[BACK].Ink.Strokes.ToString().ToLower() == (currentCard.answerWord.Trim().ToLower()))
                    {
                        MessageBox.Show("Correct! :)", "Correct");
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
                            //randomizeButton.Enabled = true;
                            originalButton.Enabled = true;

                        }
                        double accuracy = ((double)win / cardProgress) * 100.0;
                        string acc = accuracy.ToString("#.##");
                        accuracyLabel.Text = "Accuracy: " + acc + "%";
                        if (startGameBClicked == deck.cards.Count)
                        {
                            startGameB.Text = "Finish";
                            //axmediaplayer1.Ctlcontrols.stop();
                            replayP.Enabled = true;
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
                        MessageBox.Show("Incorrect :(", "Incorrect");
                        //MessageBox.Show("Win: " + win.ToString());
                        double accuracy = ((double)win / cardProgress) * 100.0;
                        string acc = accuracy.ToString("#.##");
                        if (accuracy > 0.0)
                        {
                            accuracyLabel.Text = "Accuracy: " + acc + "%";
                        }
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
                            //randomizeButton.Enabled = true;
                            originalButton.Enabled = true;

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

            return false;

        }

        private void overrideB_Click(object sender, EventArgs e)
        {

            //MessageBox.Show("Overriden to Correct");
            //myInkOverlays[ANSWER].Ink.Load(currentCard.backInk);
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
            // progressBar1.Value = (increment2);
            double accuracy = ((double)win / cardProgress) * 100.0;
            string acc = accuracy.ToString("#.##");
            accuracyLabel.Text = "Accuracy: " + acc + "%";
            if (startGameBClicked == deck.cards.Count)
            {
                startGameB.Text = "Finish";
                //axmediaplayer1.Ctlcontrols.stop();
                replayP.Enabled = true;
            }

            //MessageBox.Show("Number of cards: " + deck.cards.Count);

            overrideP.Enabled = false;

        }

        void AutoMathCardShow(bool quest, bool ans)
        {
            frontPanel.Controls.Clear();
            answerPanel.Controls.Clear();

            if (quest == true && ans == false)
            {
                Label question = new Label();
                
                question.Size = new System.Drawing.Size(frontPanel.Height - 50, frontPanel.Width);
                question.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold);
                question.Text = currentCard.num1.ToString() + currentCard.operate.ToString() + currentCard.num2.ToString();
                question.Location = new System.Drawing.Point((frontPanel.Width) / 4, (frontPanel.Height) / 4);
                
                frontPanel.Controls.Add(question);
            }

            if (quest == false && ans == true)
            {
                Label answer = new Label();

                answer.Size = new System.Drawing.Size(answerPanel.Height - 50, answerPanel.Width);
                answer.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold);
                answer.Text = currentCard.answer.ToString();
                answer.Location = new System.Drawing.Point((answerPanel.Width) / 4, (answerPanel.Height) / 4);

                answerPanel.Controls.Add(answer);
            }
        }

        void WordCardShow(bool quest, bool ans)
        {
            frontPanel.Controls.Clear();
            answerPanel.Controls.Clear();

            if (quest == true && ans == false)
            {
                Label question = new Label();

                question.Size = new System.Drawing.Size(frontPanel.Height - 50, frontPanel.Width);
                question.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold);
                question.Text = currentCard.question;
                question.Location = new System.Drawing.Point((frontPanel.Width) / 4, (frontPanel.Height) / 4);

                frontPanel.Controls.Add(question);

            }

            if (quest == false && ans == true)
            {
                Label answer = new Label();


                answer.Size = new System.Drawing.Size(answerPanel.Height - 50, answerPanel.Width);
                answer.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold);
                answer.Text = currentCard.answerWord;
                answer.Location = new System.Drawing.Point((answerPanel.Width) / 4, (answerPanel.Height) / 4);

                answerPanel.Controls.Add(answer);
            }
        }

        private int cardP = 1;
        private void startGameButton_Click(object sender, EventArgs e)
        {
            startGameBClicked++;
            cardProgr++;
            int randomIndex = r.Next(deck.cards.Count);

            pictureBox1.Enabled = false;
            pictureBox1.Visible = false;


            cardProg.Text = "Card: " + " " + cardP + " " + "of" + " " + deck.cards.Count.ToString();
            cardP++;

            if (startGameBClicked <= 1)
            {
                if (originalButton.Checked)
                {
                    //axmediaplayer1.URL = @"C:\Users\Radhir.RADRAV2\Desktop\Jeopardy (Think Song).mp3";
                    //axmediaplayer1.settings.setMode("loop", true);
                    startP.Enabled = false;
                    overrideP.Enabled = false;
                    startGameB.Text = "Show New Card";
                    index = 0;

                    currentCard = nextCard(index);
                    answerPanel.Controls.Clear();


                    myInkOverlays[FRONT].Enabled = false;
                    myInkOverlays[FRONT].Ink.Dispose();
                    myInkOverlays[FRONT].Ink = new Ink();
                    try
                    {
                        
                        myInkOverlays[FRONT].Ink.Load(currentCard.frontInk);
                        myInkOverlays[FRONT].Ink.Strokes.Scale(0.75f, 0.75f);
                    }
                    catch (ArgumentException)
                    {
                    }
                    if (currentCard.wordCard == true)
                    {
                        inkCard = false;
                        WordCardShow(true,false);
                    }
                    if (currentCard.autoMathCard == true)
                    {
                        inkCard = false;
                        AutoMathCardShow(true,false);
                    }
                    if (currentCard.panelBackground != null)
                    {
                        pictureBox1.Enabled = true;
                        pictureBox1.Visible = true;
                        pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                        pictureBox1.Image = new Bitmap(currentCard.panelBackground);

                    }

                    myInkOverlays[FRONT].Enabled = true;
                    frontPanel.Refresh();

                    myInkOverlays[BACK].Enabled = true;
                    myInkOverlays[BACK].DefaultDrawingAttributes = myInkOverlays[FRONT].DefaultDrawingAttributes;
                    submitP.Enabled = true;
                    index = 1;
                    originalButton.Enabled = false;
                    //randomizeButton.Enabled = false;

                }

                /*if (randomizeButton.Checked)
                {
                    //MessageBox.Show("Random checked");
                    //axmediaplayer1.URL = @"C:\Users\Radhir.RADRAV2\Jeopardy (Think Song).mp3";
                    //axmediaplayer1.settings.setMode("loop", true);
                    startGameButton.Enabled = false;
                    overrideB.Enabled = false;
                    startGameButton.Text = "Show New Card";
                    currentCard = nextCard(randomIndex);

                    myInkOverlays[FRONT].Enabled = false;
                    myInkOverlays[FRONT].Ink.Dispose();
                    myInkOverlays[FRONT].Ink = new Ink();
                    myInkOverlays[FRONT].Ink.Load(currentCard.frontInk);
                    myInkOverlays[FRONT].Enabled = true;
                    frontPanel.Refresh();

                    myInkOverlays[BACK].Enabled = true;
                    myInkOverlays[BACK].DefaultDrawingAttributes = myInkOverlays[FRONT].DefaultDrawingAttributes;
                    submitB.Enabled = true;
                    //randomizeButton.Enabled = false;
                    originalButton.Enabled = false;


                }*/
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

                    answerPanel.Controls.Clear();
                    try
                    {
                        
                        myInkOverlays[FRONT].Ink.Load(currentCard.frontInk);
                        myInkOverlays[FRONT].Ink.Strokes.Scale(0.75f, 0.75f);
                    }
                    catch (ArgumentException)
                    {
                    }

                    if (currentCard.wordCard == true)
                    {
                        inkCard = false;
                        WordCardShow(true, false);
                    }
                    if (currentCard.autoMathCard == true)
                    {
                        inkCard = false;
                        AutoMathCardShow(true, false);
                    }

                    if (currentCard.panelBackground != null)
                    {
                        pictureBox1.Enabled = true;
                        pictureBox1.Visible = true;
                        pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                        pictureBox1.Image = new Bitmap(currentCard.panelBackground);
                    }

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
                    myInkOverlays[BACK].DefaultDrawingAttributes = myInkOverlays[FRONT].DefaultDrawingAttributes;
                    submitP.Enabled = true;
                    originalButton.Enabled = false;
                    //randomizeButton.Enabled = false;

                }

                /*if (randomizeButton.Checked)
                {
                    startGameButton.Enabled = false;
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
                    /*Refresh();


                    myInkOverlays[BACK].Enabled = true;
                    myInkOverlays[BACK].DefaultDrawingAttributes = myInkOverlays[FRONT].DefaultDrawingAttributes;
                    submitB.Enabled = true;
                    //randomizeButton.Enabled = false;
                    originalButton.Enabled = false;
                    if (cardProgr == deck.cards.Count)
                    {
                        cardProgr = deck.cards.Count;
                    }
                } */
            

            }


            int count = myInkOverlays[ANSWER].Ink.Strokes.Count;
            if (index == deck.cards.Count && (count != 0 || inkCard == false) && (currentIndex == maxCards) && startGameBClicked > deck.cards.Count)
            {
                //MessageBox.Show("Entered if");
                MessageBox.Show("Printing report...");
                string FILE_NAME = environmentFilepath + "\\Cards\\Student Results\\" + username + " " + deckname + " " + DateTime.Now.ToString("hh mm tt") + ".txt";
                StreamWriter file2 = new StreamWriter(FILE_NAME);
                file2.WriteLine(scoreLabel.Text + "\n");
                file2.WriteLine("Override Count: " + overrideCount);
                file2.WriteLine(accuracyLabel.Text + "%");
                file2.WriteLine("Number of cards in deck: " + deck.cards.Count);
                for (int u = 0; u < deck.cards.Count; u++)
                {
                    file2.WriteLine("\n" + deck.cards[u].cardname);
                }
                file2.Close();
            }

            if (startGameBClicked > deck.cards.Count)
            {
                quitP.Enabled = false;
                submitP.Enabled = false;
                clearB.Enabled = false;

                this.Dispose();
                sd.Show();
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
                try
                {
                    
                    myInkOverlays[FRONT].Ink.Load(currentCard.frontInk);
                    myInkOverlays[FRONT].Ink.Strokes.Scale(0.75f, 0.75f);
                }
                catch (ArgumentException)
                {

                }

                //Console.WriteLine("before Image stuff");
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


        }

        

        private void teacherCheck()
        {

            win++;
            cardProgress++;

            double deckcount = (double)deck.cards.Count;
            double increment = (cardProgress / deckcount) * 100.0;
            int increment2 = (int)(increment);

            //progressBar1.Maximum = 100;
            //progressBar1.Value = increment2;

            double accuracy = ((double)win / cardProgress) * 100.0;
            string acc = accuracy.ToString("#.##");
            if (accuracy > 0.0)
            {
                accuracyLabel.Text = "Accuracy: " + acc + "%";
            }
            else
                accuracyLabel.Text = "Accuracy: 0%";


            //byte[] pic = new byte[myInkOverlays[BACK].Ink.Strokes.Count];
            MessageBox.Show("Answer will be evaluated by teacher");
            /*for (int i = 0; i < myInkOverlays[BACK].Ink.Strokes.Count; i++)
            {
                pic = myInkOverlays[BACK].Ink.Save(PersistenceFormat.InkSerializedFormat, CompressionMode.Maximum);
            }

            PictureBox bmp = new PictureBox();
            bmp.Image = BitmapFromStrokes(pic);*/

            FileStream gifFileFront;
            FileStream gifFileBack;
            FileStream gifFileAnswer;
            byte[] fortifiedGif = null;

            string filepath = "C:\\Cards\\toBeGraded\\" + currentCard.cardname;
            Directory.CreateDirectory(filepath);
            //MessageBox.Show("c:\\toBeGraded\\" + currentCard.cardname);

            gifFileFront = File.OpenWrite(filepath + "\\" + username + " FRONT.gif");
            fortifiedGif = myInkOverlays[FRONT].Ink.Save(PersistenceFormat.Gif);
            gifFileFront.Write(fortifiedGif, 0, fortifiedGif.Length);
            gifFileFront.Close();

            gifFileBack = File.OpenWrite(filepath + "\\" + username + " BACK.gif");
            fortifiedGif = myInkOverlays[BACK].Ink.Save(PersistenceFormat.Gif);
            gifFileBack.Write(fortifiedGif, 0, fortifiedGif.Length);
            gifFileBack.Close();

            gifFileAnswer = File.OpenWrite(filepath + "\\" + username + " ANSWER.gif");
            fortifiedGif = myInkOverlays[ANSWER].Ink.Save(PersistenceFormat.Gif);
            gifFileAnswer.Write(fortifiedGif, 0, fortifiedGif.Length);
            gifFileAnswer.Close();

        }
        private void replayB_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show(deckname, "Deck Name");
            deck = Deck.getDeck();
            //MessageBox.Show("Deckname: " + deckname);
            deck.cards = BinaryDeserialize(saveDecks + deckname);
            //progressBar1.Value = 0;
            accuracyLabel.Text = "Accuracy: ";

            string FILE_NAME = "C:\\Cards\\Student Results\\" + username + " " + deckname + " " + DateTime.Now.ToString("hh mm tt") + ".txt";
            StreamWriter file2 = new StreamWriter(FILE_NAME);
            file2.WriteLine(scoreLabel.Text + "\n");
            file2.WriteLine("Override Count: " + overrideCount);
            file2.WriteLine(accuracyLabel.Text + "%");
            file2.WriteLine("Number of cards in deck: " + deck.cards.Count);
            for (int u = 0; u < deck.cards.Count; u++)
            {
                file2.WriteLine("\n" + deck.cards[u].cardname);
            }
            file2.Close();

            startGameBClicked = 0;
            win = 0;
            cardP = 1;
            cardProgress = 0;
            scoreLabel.Text = "Score: " + win;

            for (int i = 0; i < 3; i++)
            {
                myInkOverlays[i].Enabled = false;
                myInkOverlays[i].Ink.DeleteStrokes();
                myInkOverlays[i].Ink.Dispose();
                myInkOverlays[i].Ink = new Ink();
                myInkOverlays[i].Enabled = true;
            }
            /*myInkOverlays[ANSWER].Ink.DeleteStrokes();
            //myInkOverlays[ANSWER].Ink.Dispose();
            myInkOverlays[ANSWER].Ink = new Ink();

            myInkOverlays[BACK].Ink.DeleteStrokes();
            myInkOverlays[BACK].Ink = new Ink();

            /*myInkOverlays[FRONT].Ink.DeleteStrokes();
            myInkOverlays[FRONT].Ink.Load(currentCard.frontInk);*/
            Refresh();

            //startGameButton_Click(null, null);
            //startGameButton.Text = "Start Game";
            //startGameButton.Enabled = true;
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
                    clearB.Text = "Toggle Ink";
                    toginkP.BackgroundImage = new Bitmap(Image.FromFile("C:\\Cards\\Images\\button.toggleerase.png"));
                }

                if (ink)
                {
                    myInkOverlays[FRONT].EditingMode = InkOverlayEditingMode.Ink;
                    myInkOverlays[BACK].EditingMode = myInkOverlays[FRONT].EditingMode;
                    clearB.Text = "Toggle Erase";
                    toginkP.BackgroundImage = new Bitmap(Image.FromFile("C:\\Cards\\Images\\button.toggleink.png"));
                }
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("We are sorry for the error.  \nPlease restart the program, we are working on a fix.", "Invalid Operation Exception");
            }
        }

        private void originalButton_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void cardProg_Click(object sender, EventArgs e)
        {

        }

        private void picZoomPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (currentCard.panelBackground != null)
            {
                Image zoomPic = currentCard.panelBackground;
                picZoomPanel.BackgroundImageLayout = ImageLayout.Stretch;
                zoomPic = new Bitmap(zoomPic, new Size(frontPanel.Height, frontPanel.Width));

                picZoomPanel.Visible = true;
                picZoomPanel.BackgroundImage = zoomPic;
                picZoomPanel.Enabled = true;
                picZoomPanel.BringToFront();

            }
        }

        private void picZoomPanel_Click(object sender, EventArgs e)
        {
            picZoomPanel.Visible = false;
            picZoomPanel.Enabled = false;
        }

        private void scratchWorkB_Click(object sender, EventArgs e)
        {
            ScratchPanel sp = new ScratchPanel();
            sp.Show();
        }

    }
}
