﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using Microsoft.Ink;
using System.Reflection;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using Microsoft.Office.Interop.Word;
using Microsoft.Office.Interop.PowerPoint;
using Microsoft.Office.Core;
using System.Net;


namespace WindowsFormsApplication1
{
    public partial class EditCardsTeacher : UserControl
    {
        
        /*public enum Mode
        {
            Ink = 0,
            Erase
        }*/
        public InkOverlay front, back;

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openDeckD.ShowDialog();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveDeckD.ShowDialog();
        }

        private void inkColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
        }

     /*   private void playGameButton_Click(object sender, EventArgs e)
        {
            PlayGameTeacher playGame = new PlayGameTeacher();
            this.Hide();
            playGame.Show();
        }
        */
        private void insertImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openDeckD.ShowDialog();
        }

        private void HomeB_Click(object sender, EventArgs e)
        {
            //TeacherDashboard tDash = new TeacherDashboard();

            Strokes collection = thumbInkOverlays[0].Ink.Strokes;
            if (collection.Count >= 0)
            {
                DialogResult dr = MessageBox.Show("If you continue, these cards will not be here when you come back.\nWould you like to save before exiting?", "Save or Exit", MessageBoxButtons.YesNoCancel);
                if (dr == System.Windows.Forms.DialogResult.Cancel)
                    return;
                if (dr == System.Windows.Forms.DialogResult.Yes)
                {
                    dialog = new SaveDeck(user, cardNames, tdOriginal);
                    dialog.TopMost = true;
                    dialog.Show();
                    //this.Hide();
                    //this.Dispose();
                    return;
                }
               // int counter = 0;
        
                if (dr == System.Windows.Forms.DialogResult.No)
                {

                    int numberOfElementsInCardsBeforeClearing = deck.cards.Count;
                    for (int i = 0; i < numberOfElementsInCardsBeforeClearing; i++)
                    {
                        deck.cards.RemoveAt(0);
                        //clearThumb(i);
                        //initThumbs(i, getThumbPanel(i));
                    }
                   
                }

            }

            //Refresh();
            closeDeck();
            updateThumbs();            
            //this.Dispose();
            tdOriginal.Show();
            this.Dispose();
        }

   
        enum Mode
        {
            ADD = 0,
            INSERT,
            VIEW,
            REPLACE
        };

        private DashboardTeacher tdOriginal;
        private const int FRONT = 0;
        private const int BACK = 1;
        private int currentCardIndex;
        private int insertPosition;
        private Mode currentMode;
        private int thumbIndex;
        private int insertIndex;
        Image currentBackgroundImage;
        Image currentFrontImage;
        Image currentBackImage;

        private InkOverlay[] myInkOverlays = new InkOverlay[2];
        private InkOverlay myInkOverlay;
        private InkOverlay[] FrontSavedStrokes = new InkOverlay[30];
        private InkOverlay[] BackSavedStrokes = new InkOverlay[30];
        private int inkIndexFront = 0;
        private int inkIndexBack = 0;

        private RecognizerContext myRecognizer = new RecognizerContext();
        private RecognizerContext[] myRecognizers = new RecognizerContext[2];
        private InkOverlay[] thumbInkOverlays = new InkOverlay[5];
        private Color penColor;
        private Deck deck = Deck.getDeck();

        private bool[] firstTime = new bool[2];
        private bool[] thumbFirstTime = new bool[7];
        private int[] thumbCardIndex = new int[7];

        private DrawingAttributes da;
        private bool MathM = false;
        public string labelText;
        public string finalGlobalLabelText;
        bool autoMath;

        private string user = "";
        Form1 add;
        //OpenWF openWF;
        //Login login;
        SaveDeck dialog;
        CreateCard cc;
        int noOfCards;

        Card currentCard;
        string saveCards, saveDecks,saveAutoMath;
        List<String> cardNames;
        CardList cL;

        private void BinarySerialize(List<Card> list, string filename)
        {
            using (FileStream str = File.Create(filename))
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(str, list);
            }

            if (MessageBox.Show("Would you like to save this deck in the cloud?", "Uploading", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                uploadDeck(filename);
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

        private static void BinarySerializeCard(Card card, string filename)
        {
            using (FileStream str = File.Create(filename))
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(str, card);
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

        public void saveCard_Click(object sender, EventArgs e)
        {
            setCardFileName();
            MessageBox.Show("Do not change file name"); 
            saveCardD.ShowDialog();
            //saveCardD.FileName = standardsL.Text;
                        
            /*for (int i = 0; i < add.diffCB.Length; i++)
            {
                if (add.diffCB[i].Checked)
                {
                    string filenamedifficulty = add.diffCB[i].Text;

                }

            }*/

            
        }

        // Deserialize an ArrayList object from a binary file.
        public List<Card> BinaryDeserialize(string filename)
        {
            //compatability issue
            //ArrayList temp = null;
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
            catch (InvalidCastException)
            {
                MessageBox.Show("This deck file appears to be corrupt.");
                return new List<Card> { };
            }

            //MessageBox.Show("savedDeck has " + savedDeck.cardNames.Count + " cards in it.");

            savedCards = new List<Card> { };
            cardNames = new List<string>();

            for (int i = 0; i < savedDeck.cardNames.Count; i++)
            {
                //MessageBox.Show("Card " + i + ": " + savedDeck.cardNames[i]);
                //MessageBox.Show(saveCards + savedDeck.cardNames[i] + ".cd");
                if (autoMath == false)
                    savedCards.Insert(i, BinaryDeserializeCard(saveCards + savedDeck.cardNames[i] + ".cd"));
                if (autoMath == true)
                    savedCards.Insert(i, BinaryDeserializeCard(saveAutoMath + savedDeck.cardNames[i] + ".cd"));
                cardNames.Add(savedDeck.cardNames[i]);
                deck.cards.Insert(i, savedCards[i]);
             }
            /*}
            catch (Exception ex)
            {
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
            }*/
            return savedCards;
        }

        private Panel getThumbPanel(int i)
        {
            if (i == 0) return thumb1;
            else if (i == 1) return thumb2;
            else if (i == 2) return thumb3;
            else if (i == 3) return thumb4;
            else /*if (i == 4)*/ return thumb5;
            //else if (i == 5) return thumb6; 
            //else return thumb7; 
        }

        private void updateThumbs()
        {
            int i;
            //initialize thumb backgrounds
            thumb1.BackgroundImage = null;
            thumb2.BackgroundImage = null;
            thumb3.BackgroundImage = null;
            thumb4.BackgroundImage = null;
            thumb5.BackgroundImage = null;
            //thumb6.BackgroundImage = null;
            //thumb7.BackgroundImage = null;

            for (i = 0; i < 5; i++)
            {
                if (deck.cards.Count > (thumbIndex + i))
                {
                    //resize must be done
                    int index = i + thumbIndex;
                    if (deck.cards[index].frontImage != null)
                    {
                        Image image = Image.FromStream(new MemoryStream(Convert.FromBase64String(deck.cards[i].frontImage)));
                        if (index == 0)
                            Card.FitImage(thumb1, image);
                        else if (index == 1)
                            Card.FitImage(thumb2, image);
                        else if (index == 2)
                            Card.FitImage(thumb3, image);
                        else if (index == 3)
                            Card.FitImage(thumb4, image);
                        else if (index == 4)
                            Card.FitImage(thumb5, image);
                        //else if (index == 5)
                        //Card.FitImage(thumb6, image);
                        //else if (index == 6)
                        //Card.FitImage(thumb7, image);
                    }
                    else if (deck.backgroundImage != null)
                    {
                        Image image = Image.FromStream(new MemoryStream(Convert.FromBase64String(deck.backgroundImage)));

                        if (index == 0)
                            Card.FitImage(thumb1, image);
                        else if (index == 1)
                            Card.FitImage(thumb2, image);
                        else if (index == 2)
                            Card.FitImage(thumb3, image);
                        else if (index == 3)
                            Card.FitImage(thumb4, image);
                        else if (index == 4)
                            Card.FitImage(thumb5, image);
                        //else if (index == 5)
                        //Card.FitImage(thumb6, image);
                        //else if (index == 6)
                        //Card.FitImage(thumb7, image);
                    }
                    updateThumbInkOverlay(i, thumbIndex + i);

                }
                else
                {
                    break;
                }
            }
            for (; i < 5; i++)
            {
                clearThumb(i);
            }
            insertPosition = thumbCardIndex[0] + insertIndex;
        }

        private void clearThumb(int i)
        {
            thumbInkOverlays[i].Enabled = false;
            thumbInkOverlays[i].Ink = new Ink();
        }

        private void updateThumbInkOverlay(int thumbIndex, int cIndex)
        {
                currentCard = deck.cards[cIndex];
                thumbCardIndex[thumbIndex] = cIndex;
                thumbInkOverlays[thumbIndex].Enabled = false;
                thumbInkOverlays[thumbIndex].Ink.Dispose();
                thumbInkOverlays[thumbIndex].Ink = new Ink();
                try
                {
                    thumbInkOverlays[thumbIndex].Ink.Load(currentCard.frontInk);
                    thumbInkOverlays[thumbIndex].Ink.Strokes.Scale(0.65f, 0.65f);
                }
                catch (ArgumentException)
                {
                }
                float xScale = ((float)thumb4.Width) / FrontPanel.Width;
                float yScale = ((float)thumb4.Height) / FrontPanel.Height;
                thumbInkOverlays[thumbIndex].Ink.Strokes.Scale(xScale, yScale);
        }

        private void paint(int i, PictureBox p)
        {
            //currentPanel = i;

            if (firstTime[i])
            {
                firstTime[i] = false;
                myInkOverlays[i] = new InkOverlay(p.Handle, true);
                myInkOverlay = new InkOverlay(p.Handle, true);
                myRecognizers[i] = new RecognizerContext();

                da = new DrawingAttributes();

                da.AntiAliased = true;
                da.PenTip = Microsoft.Ink.PenTip.Ball;
                da.Transparency = 0;
                da.Width = 70.0f;
                da.Color = Color.Black;

                myInkOverlays[i].DefaultDrawingAttributes = da;
                myInkOverlays[i].Enabled = false;
                myInkOverlays[i].CursorInRange +=
                       new InkCollectorCursorInRangeEventHandler(
                       this.myInkOverlays_CursorInRange);
                myInkOverlays[i].Stroke += new InkCollectorStrokeEventHandler(Parse_Stroke);

            }

        }


        private int getPanelIndex(Object sender)
        {
            for (int i = 0; i < myInkOverlays.Length; i++)
            {
                if (sender.Equals(myInkOverlays[i]))
                {
                    return i;
                }
            }
            return -1;
        }


        //Used for math mode stroke parsing
        private void Parse_Stroke(object sender, InkCollectorStrokeEventArgs e)
        {
            //Console.WriteLine("Drawing Strokes");
            if (MathM) //Enter if mathmode is on
            {

                int currentPanel = getPanelIndex(sender);

                //Console.WriteLine("Current Panel: {0}", currentPanel);

                RecognitionStatus Rstatus;
                String recognized = "";

                myRecognizers[currentPanel].Strokes = myInkOverlays[currentPanel].Ink.Strokes;
                if (myRecognizers[currentPanel].Strokes != null && myRecognizers[currentPanel].Strokes.Count > 0)
                {
                    recognized = myRecognizers[currentPanel].Recognize(out Rstatus).TopString;
                    //MessageBox.Show("Text:\n\n" + recognized);
                }
                else
                {
                    //MessageBox.Show("No input given");
                }

                if (recognized.Equals("o") || recognized.Equals("O") || recognized.Equals("0"))
                {
                    System.Drawing.Rectangle bbox = myRecognizers[currentPanel].Strokes.GetBoundingBox();
                    InkOverlay newInkOverlay;
                    int radius = bbox.Height / 2;
                    int p_x = bbox.Left + radius;
                    int p_y = bbox.Top + radius;

                    draw_Circle(radius, p_x, p_y, currentPanel);
                    myInkOverlays[currentPanel].Enabled = false;

                    if (currentPanel == FRONT)
                    {
                        FrontSavedStrokes[inkIndexFront] = myInkOverlays[currentPanel];
                        newInkOverlay = new InkOverlay(FrontPanel.Handle, true);
                        inkIndexFront++;
                    }
                    else
                    {
                        BackSavedStrokes[inkIndexBack] = myInkOverlays[currentPanel];
                        newInkOverlay = new InkOverlay(BackPanel.Handle, true);
                        inkIndexBack++;
                    }

                    newInkOverlay.DefaultDrawingAttributes = da;
                    newInkOverlay.CursorInRange += new InkCollectorCursorInRangeEventHandler(
                                                   this.myInkOverlays_CursorInRange);
                    newInkOverlay.Stroke += new InkCollectorStrokeEventHandler(Parse_Stroke);

                    newInkOverlay.Enabled = true;
                    myInkOverlays[currentPanel] = newInkOverlay;
                }
                else if (recognized.Equals("A"))
                {
                    Console.WriteLine("Draw Triangle");
                    System.Drawing.Rectangle bbox = myRecognizers[currentPanel].Strokes.GetBoundingBox();
                    InkOverlay newInkOverlay;
                    int radius = bbox.Height / 2;
                    int p_x = bbox.Left + radius;
                    int p_y = bbox.Top + radius;

                    drawTriangle(p_x, p_y, currentPanel);

                    myInkOverlays[currentPanel].Enabled = false;

                    if (currentPanel == FRONT)
                    {
                        FrontSavedStrokes[inkIndexFront] = myInkOverlays[currentPanel];
                        newInkOverlay = new InkOverlay(FrontPanel.Handle, true);
                        inkIndexFront++;
                    }
                    else
                    {
                        BackSavedStrokes[inkIndexBack] = myInkOverlays[currentPanel];
                        newInkOverlay = new InkOverlay(BackPanel.Handle, true);
                        inkIndexBack++;
                    }

                    newInkOverlay.DefaultDrawingAttributes = da;
                    newInkOverlay.CursorInRange += new InkCollectorCursorInRangeEventHandler(
                                                   this.myInkOverlays_CursorInRange);
                    newInkOverlay.Stroke += new InkCollectorStrokeEventHandler(Parse_Stroke);

                    newInkOverlay.Enabled = true;
                    myInkOverlays[currentPanel] = newInkOverlay;

                }
                else if ((recognized.Equals("x") || recognized.Equals("X")))
                {
                    Console.WriteLine("Draw X");
                    System.Drawing.Rectangle bbox = myRecognizers[currentPanel].Strokes.GetBoundingBox();
                    InkOverlay newInkOverlay;
                    int radius = bbox.Height / 2;
                    int p_x = bbox.Left + radius;
                    int p_y = bbox.Top + radius;

                    drawX(p_x, p_y, currentPanel);

                    myInkOverlays[currentPanel].Enabled = false;

                    if (currentPanel == FRONT)
                    {
                        FrontSavedStrokes[inkIndexFront] = myInkOverlays[currentPanel];
                        newInkOverlay = new InkOverlay(FrontPanel.Handle, true);
                        inkIndexFront++;
                    }
                    else
                    {
                        BackSavedStrokes[inkIndexBack] = myInkOverlays[currentPanel];
                        newInkOverlay = new InkOverlay(BackPanel.Handle, true);
                        inkIndexBack++;
                    }

                    newInkOverlay.DefaultDrawingAttributes = da;
                    newInkOverlay.CursorInRange += new InkCollectorCursorInRangeEventHandler(
                                                   this.myInkOverlays_CursorInRange);
                    newInkOverlay.Stroke += new InkCollectorStrokeEventHandler(Parse_Stroke);

                    newInkOverlay.Enabled = true;
                    myInkOverlays[currentPanel] = newInkOverlay;
                }
            }
        }

        private InkOverlayEditingMode modeSaved;
        private void myInkOverlays_CursorInRange(object sender,
            InkCollectorCursorInRangeEventArgs e)
        {

            if (e.Cursor.Inverted)
            {
                for (int i = 0; i < 2; i++)
                {
                    if (myInkOverlays[i].EditingMode != InkOverlayEditingMode.Delete)
                    {
                        // Save current editing mode so we can restore it later
                        modeSaved = myInkOverlays[i].EditingMode;

                        // Switch to delete mode
                        myInkOverlays[i].EditingMode = InkOverlayEditingMode.Delete;
                    }

                    else
                    {
                        // Ink tip is being used, so restore previous mode if we
                        // need to

                        if (myInkOverlays[i].EditingMode == InkOverlayEditingMode.Delete &&
                            modeSaved != InkOverlayEditingMode.Delete)
                        {
                            // Restore the previous editing mode
                            myInkOverlays[i].EditingMode = modeSaved;
                        }
                    }
                }
            }
        }
        private void initThumbs(int i, Panel p)
        {
            if (thumbFirstTime[i])
            {
                thumbFirstTime[i] = false;
                thumbInkOverlays[i] = new InkOverlay(p.Handle, true);
                DrawingAttributes da = new DrawingAttributes();

                da.AntiAliased = true;
                da.PenTip = Microsoft.Ink.PenTip.Ball;
                da.Transparency = 0;
                da.Width = 70.0f;
                da.Color = Color.Black;

                thumbInkOverlays[i].DefaultDrawingAttributes = da;
                thumbInkOverlays[i].Enabled = false;
            }
        }

        private void Panel_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void Panel_DragDrop(object sender, DragEventArgs e)
        {
            PictureBox panel = (PictureBox)sender;
            Graphics g = panel.CreateGraphics();
            g.DrawImage((Image)e.Data.GetData(DataFormats.Bitmap), new System.Drawing.Point(0, 0));
        }

        private void FrontPanel_Paint(object sender, PaintEventArgs e)
        {

            //paint(FRONT, FrontPanel);

        }

        private void BackPanel_Paint(object sender, PaintEventArgs e)
        {
            //paint(BACK, BackPanel);
        }

        private void displayNext_Click_1(object sender, EventArgs e)
        {
            if (deck.cards.Count == 0)
            {
                return;
            }
            if (insertIndex < 5 && insertIndex >= deck.cards.Count - 1)
            {
                currentCardIndex = thumbCardIndex[insertIndex];
                changeBarPosition(insertIndex + 1);
                changeSelectedThumb(insertIndex + 1);
            }
            else
            {
                if (deck.cards.Count > 7)
                {
                    doNextThumb();
                    currentCardIndex = thumbCardIndex[insertIndex];
                }
                else
                {
                    currentCardIndex = 0;
                    changeBarPosition(0);

                    changeSelectedThumb(0);

                    thumbIndex = 0;
                    updateThumbs();
                }
            }
            if (currentCardIndex >= deck.cards.Count)
            {
                currentCardIndex = 0;
            }

            currentMode = Mode.VIEW;

            currentCard = deck.cards[currentCardIndex];

            front.Enabled = false;
            front.Ink.Dispose();
            front.Ink = new Ink();
            try
            {
                front.Ink.Load(currentCard.frontInk);
            }
            catch (ArgumentException)
            {
            }
            front.Enabled = false;

            back.Enabled = false;
            back.Ink.Dispose();
            back.Ink = new Ink();
            try
            {
                back.Ink.Load(currentCard.backInk);
            }
            catch (ArgumentException)
            {
            }
            back.Enabled = false;
        }

        //Open Deck Button
        
        private void loadDeck_Click_1(object sender, EventArgs e)
        {
                     
            //loadDeckDialog.ShowDialog();
            //openDeckD.ShowDialog();
            cL = new CardList(this, "hi");
            //cL.Show();
            //updateThumbs();
            //displayThumbCard(0);
            cL.TopMost = true;
            cL.Show();
        }


        #region misc
        private void insertCard()
        {
            if (currentMode == Mode.ADD)
            {
                return;
            }
            //insertPosition = currentCardIndex; 
            currentMode = Mode.INSERT;
            //if (insertPosition == deck.cards.Count)
            if (insertPosition >= deck.cards.Count)
            {
                currentMode = Mode.ADD;
            }

            front.Enabled = false;
            back.Enabled = false;

            front.Ink.DeleteStrokes(front.Ink.Strokes);
            back.Ink.DeleteStrokes(back.Ink.Strokes);
            front.Enabled = false;
            back.Enabled = false;

            DifficultyL.Text = "Difficulty";
            standardsL.Text = "Standards";
            noOfCards++;
            noOfCardsL.Text = noOfCards + " cards";
            Refresh();
        }
        #endregion


        private void saveDeckDialog_FileOk(object sender, CancelEventArgs e)
        {
            
        }

     

        #region click event

        private void prevThumb_Click(object sender, EventArgs e)
        {
            if (thumbIndex > 0)
            {
                thumbIndex--;
                updateThumbs();
                Refresh();
            }
        }

        void doNextThumb()
        {
            if (deck.cards.Count > thumbIndex + 5)
            {
                thumbIndex++;
                updateThumbs();
                Refresh();
            }
        }

        private void nextThumb_Click(object sender, EventArgs e)
        {
            doNextThumb();
        }

        private void clearFront_Click(object sender, EventArgs e)
        {
            front.Enabled = false;
            front.Ink.DeleteStrokes(front.Ink.Strokes);
            front.Enabled = false;

            for (int i = 0; i < inkIndexFront; i++)
            {
                FrontSavedStrokes[i].Ink.DeleteStrokes();
            }


            if (currentBackgroundImage != null)
            {
                Card.FitImage(FrontPanel, currentBackgroundImage);
            }
            else
            {
                //FrontPanel.Image = null;
            }
            Refresh();
        }

        private void clearBack_Click(object sender, EventArgs e)
        {
            back.Enabled = false;
            back.Ink.DeleteStrokes(back.Ink.Strokes);
            back.Enabled = false;


            for (int i = 0; i < inkIndexBack; i++)
            {
                BackSavedStrokes[i].Ink.DeleteStrokes();
            }

            if (currentBackgroundImage != null)
            {
                Card.FitImage(BackPanel, currentBackgroundImage);
            }
            else
            {
                //BackPanel.Image = null; 
            }

            Refresh();
        }
        private void clearBoth_Click(object sender, EventArgs e)
        {
            front.Enabled = false;
            back.Enabled = false;

            front.Ink.DeleteStrokes(front.Ink.Strokes);
            back.Ink.DeleteStrokes(back.Ink.Strokes);
            front.Enabled = false;
            back.Enabled = false;

            for (int i = 0; i < inkIndexFront; i++)
            {
                FrontSavedStrokes[i].Ink.DeleteStrokes();
            }

            for (int i = 0; i < inkIndexBack; i++)
            {
                BackSavedStrokes[i].Ink.DeleteStrokes();
            }

            inkIndexFront = 0;
            inkIndexBack = 0;

            if (currentBackgroundImage != null)
            {
                Card.FitImage(FrontPanel, currentBackgroundImage);
                Card.FitImage(BackPanel, currentBackgroundImage);
            }
            else
            {
                // FrontPanel.Image = null;
                // BackPanel.Image = null; 
            }
            Refresh();
        }
        public void dispose(bool disposing)
        {
        }

        private void FlashCards_Load(object sender, EventArgs e)
        {

        }
        private void changePenAttributes()
        {
            back.DefaultDrawingAttributes.Color = penColor;
            front.DefaultDrawingAttributes.Color = penColor;
        }

        /*private void blackColor_Click(object sender, EventArgs e)
        {
            penColor = blackColorButton.BackColor;
            changePenAttributes();
        }

        private void redColor_Click(object sender, EventArgs e)
        {
            penColor = redColorButton.BackColor;
            changePenAttributes();
        }

        private void greenColor_Click(object sender, EventArgs e)
        {
            penColor = greenColorButton.BackColor;
            changePenAttributes();
        }

        private void blueColor_Click(object sender, EventArgs e)
        {
            penColor = blueColorButton.BackColor;
            changePenAttributes();
        }*/

        private void FlashCards_Shown(object sender, EventArgs e)
        {
        }

        /*private void playGame_Click(object sender, EventArgs e)
        {
                Form mygame = new Game(this);
                this.Hide();
                mygame.Show();
        }*/

        private void displayPrev_Click(object sender, EventArgs e)
        {
            if (deck.cards.Count == 0)
            {
                return;
            }
            if (insertIndex < 5 && insertIndex > 0)
            {
                currentCardIndex = thumbCardIndex[insertIndex] - 1;
            }
            if (currentCardIndex < 0)
            {
                currentCardIndex = deck.cards.Count - 1;
            }

            currentMode = Mode.VIEW;

            currentCard = deck.cards[currentCardIndex];

            front.Enabled = false;
            front.Ink.Dispose();
            front.Ink = new Ink();
            try
            {
                front.Ink.Load(currentCard.frontInk);
            }
            catch (ArgumentException)
            {
            }
            front.Enabled = false;

            back.Enabled = false;
            back.Ink.Dispose();
            back.Ink = new Ink();
            try
            {
                back.Ink.Load(currentCard.backInk);
            }
            catch (ArgumentException)
            {
            }
            back.Enabled = false;
        }
        private void changeBarPosition(int index)
        {
            int barX = 0;
            if (index == 0)
            {
                barX = prevThumbP.Location.X + prevThumbP.Width + 1;
                insertIndex = 0;
            }
            else
            {
                Panel previousThumb = getThumbPanel(index - 1);
                barX = previousThumb.Location.X + previousThumb.Width + 1;
                insertIndex = index;
            }
            insertPosition = thumbCardIndex[0] + insertIndex;
            System.Drawing.Point newPt = new System.Drawing.Point();
            newPt.X = (int)barX;
            newPt.Y = insertBar.Location.Y;
            insertBar.Location = newPt;
        }

        private void FlashCards_MouseClick(object sender, MouseEventArgs e)
        {
            double topY = thumb1.Location.Y;
            double bottomY = topY + thumb1.Height;
            //double spacing = thumb2.Location.X - (thumb1.Location.X + thumb1.Width);
            double xPos = e.X;
            double barX = -1;
            int offset = 1;

            if (e.Y <= topY)
            {
                // insertIndex = -1; 
                insertIndex = 0;
                if (xPos >= thumb5.Location.X + (thumb5.Width / 2.0))//thumb5 was thumb7
                {
                    barX = thumb5.Location.X + thumb5.Width + offset; //thumb5 was thumb7
                    insertIndex = 5;//was 7
                }
                else
                {
                    for (int i = 1; i < 5; i++)//5 was 7
                    {
                        Panel previousThumb = getThumbPanel(i - 1);
                        Panel curThumb = getThumbPanel(i);
                        double firstX = previousThumb.Location.X + (previousThumb.Width / 2.0);
                        double lastX = curThumb.Location.X + (curThumb.Width / 2.0);
                        if (xPos >= firstX && xPos <= lastX)
                        {
                            barX = previousThumb.Location.X + previousThumb.Width + offset;
                            insertIndex = i;
                            break;
                        }
                    }
                    if (insertIndex == -1)
                    {
                        barX = prevThumbP.Location.X + prevThumbP.Width + offset;
                        insertIndex = 0;
                    }
                    currentMode = Mode.INSERT;
                }
                if (insertIndex > deck.cards.Count)
                {
                    insertIndex = deck.cards.Count;
                    changeBarPosition(insertIndex);

                    changeSelectedThumb(insertIndex);

                    currentMode = Mode.ADD;
                }
                else
                {
                    System.Drawing.Point newPt = new System.Drawing.Point();
                    newPt.X = (int)barX;
                    newPt.Y = insertBar.Location.Y;
                    insertBar.Location = newPt;
                    insertPosition = thumbCardIndex[0] + insertIndex;
                }
            }
        }
        void setCardStandards()
        {
            //Card currentCard = new Card();
            currentCard.diff = add.difficulty();
            currentCard.standards = add.standards();
            currentCard.grade = add.grade();

            DifficultyL.Text = currentCard.diff;
            if (currentCard.diff == null || currentCard.diff == "")
            {
                DifficultyL.Text = "Difficulty";
            }

            for (int i = 0; i < add.stan.Length; i++)
            {
                if (add.stan[i] != "")
                {
                    standardsL.Text = add.stan[i];
                }

            }

            //for (int i = 0; i < add.grad.Length; i++)
            //{
                if (add.grad != "")
                {
                    gradeL.Text = add.grad;
                }

            //}

        }
        #region thumbCards
        void displayThumbCard(int index)
        {
            BackPanel.Controls.Clear();
            FrontPanel.Controls.Clear();

            pictureBox1.Visible = false;
            pictureBox1.Enabled = false;

            front.Ink.DeleteStrokes();
            back.Ink.DeleteStrokes();
            FrontPanel.Refresh();
            BackPanel.Refresh();

            if (index >= deck.cards.Count)
            {
                return;
            }
            currentMode = Mode.REPLACE;
            int currentCardIndex = thumbCardIndex[index];
            if (currentCardIndex != -1)
            {
                //Card currentCard;
                if (currentCardIndex >= deck.cards.Count)
                {
                    currentCard = new Card();
                    
                }
                else
                {
                    currentCard = deck.cards[currentCardIndex];
                    
                }
                    front.Enabled = false;
                    front.Ink.Dispose();
                    front.Ink = new Ink();
                    try
                    {
                        front.Ink.Load(currentCard.frontInk);
                        front.Ink.Strokes.Scale(0.65f, 0.65f);
                    }
                    catch (ArgumentException)
                    {
                    }
                    if (currentCard.panelBackground != null)
                    {
                        pictureBox1.Enabled = true;
                        pictureBox1.Visible = true;
                        pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

                        //Sets the Image property to the image in the filename selected
                        pictureBox1.Image = currentCard.panelBackground;

                        //Adds the picturebox to the Panel to show up
                        
                    }

                    if (currentCard.autoMathCard == true)
                    {
                        //currentCard = new Card();
                        currentCard = deck.cards[currentCardIndex];
                        AutoMathCardShow();

                    }
                    if (currentCard.wordCard == true)
                    {
                        currentCard = deck.cards[currentCardIndex];
                        WordCardShow();
                    }
                    //setCardStandards();
                    //currentCard.standards = add.standards();
                    //currentCard.diff = add.difficulty();
                    //currentCard.grade = add.grade();

                string labelText = "";
                bool hasStandards = false;
                //MessageBox.Show("A standard: " + currentCard.standards[0]);
                do
                {
                    for (int i = 0; i < currentCard.standards.Length; i++)
                    {
                        if (currentCard.standards[i] != "")
                        {
                            labelText = labelText + currentCard.standards[i] + "\n";
                            //globalLabelText = labelText;
                            hasStandards = true;
                        }
                    }
                } while (!hasStandards);
                /*string gradeText = "";
                for (int i = 0; i < currentCard.grade.Length; i++)
                {
                    if (currentCard.grade != "")
                    {
                        gradeText = gradeText + currentCard.grade + "\n";
                        globalLabelText = labelText;
                    }
                }*/

                standardsL.Text = labelText;
                DifficultyL.Text = currentCard.diff;
                gradeL.Text = currentCard.grade;
                GradeableCB.Checked = currentCard.gradeable;


                front.Enabled = false;
                FrontPanel.Refresh();
                if (currentCard.frontImage == null)
                {
                    if (currentBackgroundImage != null)
                    {
                        Card.FitImage(FrontPanel, currentBackgroundImage);
                        
                    }
                    else
                    {
                        //FrontPanel.Image = null;
                    }
                }
                else
                {
                    Image image = Image.FromStream(new MemoryStream(Convert.FromBase64String(currentCard.frontImage)));
                    Card.FitImage(FrontPanel, image);
                    currentFrontImage = image;
                }


                back.Enabled = false;
                back.Ink.Dispose();
                back.Ink = new Ink();
                try
                {
                    back.Ink.Load(currentCard.backInk);
                    back.Ink.Strokes.Scale(0.65f, 0.65f);
                    
                }
                catch (ArgumentException)
                {
                }
                back.Enabled = false;
                BackPanel.Refresh();
                if (currentCard.backImage == null)
                {
                    if (currentBackgroundImage != null)
                    {
                        Card.FitImage(BackPanel, currentBackgroundImage);
                    }
                    else
                    {
                        //BackPanel.Image = null;
                    }
                }
                else
                {
                    Image image = Image.FromStream(new MemoryStream(Convert.FromBase64String(currentCard.backImage)));
                    Card.FitImage(BackPanel, image);
                    currentBackImage = image;
                }

                changeBarPosition(index);
                changeSelectedThumb(index);
            }

         }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                Image zoomPic = currentCard.panelBackground;
                picZoomPanel.BackgroundImageLayout = ImageLayout.Stretch;
                zoomPic = new Bitmap(zoomPic, new Size(FrontPanel.Height, FrontPanel.Width));

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



        public void changeSelectedThumb(int index)
        {
            if (index == 0)
            {
                thumb1.BorderStyle = BorderStyle.Fixed3D;
                thumb2.BorderStyle = BorderStyle.FixedSingle;
                thumb3.BorderStyle = BorderStyle.FixedSingle;
                thumb4.BorderStyle = BorderStyle.FixedSingle;
                thumb5.BorderStyle = BorderStyle.FixedSingle;
            }
            if (index == 1)
            {
                thumb1.BorderStyle = BorderStyle.FixedSingle;
                thumb2.BorderStyle = BorderStyle.Fixed3D;
                thumb3.BorderStyle = BorderStyle.FixedSingle;
                thumb4.BorderStyle = BorderStyle.FixedSingle;
                thumb5.BorderStyle = BorderStyle.FixedSingle;
            }
            if (index == 2)
            {
                thumb1.BorderStyle = BorderStyle.FixedSingle;
                thumb2.BorderStyle = BorderStyle.FixedSingle;
                thumb3.BorderStyle = BorderStyle.Fixed3D;
                thumb4.BorderStyle = BorderStyle.FixedSingle;
                thumb5.BorderStyle = BorderStyle.FixedSingle;
            }
            if (index == 3)
            {
                thumb1.BorderStyle = BorderStyle.FixedSingle;
                thumb2.BorderStyle = BorderStyle.FixedSingle;
                thumb3.BorderStyle = BorderStyle.FixedSingle;
                thumb4.BorderStyle = BorderStyle.Fixed3D;
                thumb5.BorderStyle = BorderStyle.FixedSingle;
            }
            if (index == 4)
            {
                thumb1.BorderStyle = BorderStyle.FixedSingle;
                thumb2.BorderStyle = BorderStyle.FixedSingle;
                thumb3.BorderStyle = BorderStyle.FixedSingle;
                thumb4.BorderStyle = BorderStyle.FixedSingle;
                thumb5.BorderStyle = BorderStyle.Fixed3D;
            }
        }

        #region thumb_mouseClicks

        private void thumb1_MouseClick(object sender, MouseEventArgs e)
        {
            displayThumbCard(0);
            
        }

        private void thumb2_MouseClick(object sender, MouseEventArgs e)
        {
            displayThumbCard(1);
            
        }
        private void thumb3_MouseClick(object sender, MouseEventArgs e)
        {
            displayThumbCard(2);
            
        }
        private void thumb4_MouseClick(object sender, MouseEventArgs e)
        {
            displayThumbCard(3);
            
        }
        private void thumb5_MouseClick(object sender, MouseEventArgs e)
        {
            displayThumbCard(4);
            
        }
        #endregion
        #endregion
        //Create Card Button
        private void createNewCard_Click(object sender, EventArgs e)
        {
            //if (cardNames.Count == 0)
              //  cc = new CreateCard("", user, tdOriginal);
            //else if (cardNames.Count > 0)
                cc = new CreateCard(user, this, tdOriginal, cardNames);
            this.Hide();
            Global.form.Controls.Add(cc);
            addCards();
            currentMode = Mode.ADD;

            /*if (currentMode == Mode.INSERT)
            {
                if (insertPosition > deck.cards.Count)
                {
                    insertPosition = deck.cards.Count;

                }

                deck.cards.Insert(insertPosition, currentCard);
                if (insertPosition <= deck.cards.Count && insertPosition < 5)
                {
                    add = new Form1(this);
                    currentCard.standards = new string[15];
                    currentCard.grade = "";
                    currentCard.diff = "";
                    changeBarPosition(insertPosition + 1);
                    changeSelectedThumb(insertPosition + 1);
                }
                if (insertIndex > 5)
                {
                    doNextThumb();
                }
            }
            else if (currentMode == Mode.ADD)
            {
                deck.cards.Insert(deck.cards.Count, currentCard);
                if (deck.cards.Count > 5)
                {
                    doNextThumb();
                }
                if (deck.cards.Count < 6)
                {
                    changeBarPosition(deck.cards.Count);
                    changeSelectedThumb(deck.cards.Count);
                }
            }
            else // view mode
            {
                if (insertPosition < deck.cards.Count)
                {
                    deck.cards.RemoveAt(insertPosition);
                }
                deck.cards.Insert(insertPosition, currentCard);
                updateThumbs();
                if (insertPosition > 5)
                {
                    doNextThumb();
                }
                Refresh();
                currentMode = Mode.INSERT;

            }

            //MessageBox.Show("grade: " + currentCard.grade + "\nstandard: " + currentCard.standards[0] + "\ndifficulty: " + currentCard.diff);


            front.Ink.DeleteStrokes(front.Ink.Strokes);
            back.Ink.DeleteStrokes(back.Ink.Strokes);

            front.Enabled = false;
            back.Enabled = false;
            updateThumbs();
            Refresh();

            front.Enabled = false;
            back.Enabled = false;

            front.Ink.DeleteStrokes(front.Ink.Strokes);
            back.Ink.DeleteStrokes(back.Ink.Strokes);
            front.Enabled = false;
            back.Enabled = false;

            DifficultyL.Text = "Difficulty";
            standardsL.Text = "Standards";
            gradeL.Text = "Grade";


            MessageBox.Show("grade: " + currentCard.grade + "\nstandard: " + currentCard.standards[0] + "\ndifficulty: " + currentCard.diff);
            currentCard = new Card();
            Refresh();


            if (currentBackgroundImage == null)
            {
                // FrontPanel.Image = null;
                // BackPanel.Image = null; 
            }
            else// show background if it's set
            {
                Card.FitImage(FrontPanel, currentBackgroundImage);
                Card.FitImage(BackPanel, currentBackgroundImage);
            }



            */


            //this.Dispose();
            /*currentCard = new Card();
            currentMode = Mode.INSERT;
            front.Enabled = false;
            back.Enabled = false;

            front.Ink.DeleteStrokes(front.Ink.Strokes);
            back.Ink.DeleteStrokes(back.Ink.Strokes);
            front.Enabled = false;
            back.Enabled = false;
            FrontPanel.Refresh();
            BackPanel.Refresh();
            DifficultyL.Text = "Difficulty";
            standardsL.Text = "Standards";
            gradeL.Text = "Grade";
            currentFrontImage = null;
            currentBackImage = null;

            //DifficultyL.Text = "Difficulty";
            //standardsL.Text = "Standards";
            currentCard = new Card();
            
            if (currentBackgroundImage == null)
            {
                // FrontPanel.Image = null;
                // BackPanel.Image = null;                 
            }
            else
            {
                Card.FitImage(FrontPanel, currentBackgroundImage);
                Card.FitImage(BackPanel, currentBackgroundImage);
            }
            changeBarPosition(deck.cards.Count);
            changeSelectedThumb(deck.cards.Count);
            currentCard.diff = null;
            currentCard.standards = null;
            currentCard.grade = null;
            //Refresh();*/
                        
        }

        public string setCardFileName()
        {
            Card currentCard = new Card();
           //login = new Login(); 
           // string creater = login.getUserName();
            currentCard.diff = add.difficulty();
            currentCard.standards = add.standards();
            //currentCard.username = login.usernameTB.Text;
            //saveCardD.FileName = currentCard.diff;
            
            for (int i = 0; i < add.stan.Length; i++)
            {
                if (add.stan[i] != "")
                {
                    return saveCardD.FileName = user + ", " + currentCard.standards[i] + ", " +  currentCard.diff + ", " + DateTime.Now.ToString("HH mm tt");
                }
            }

            return null;

        }

        public string setDeckFileName()
        {
            return user;

        }

        //Remove Card Button
        private void deleteCard_Click(object sender, EventArgs e)
        {
            int deletePosition = insertIndex;
            if (deck.cards.Count > deletePosition)
            {
                cardNames.Remove(currentCard.cardname);
                currentCard = new Card();
                currentCard.diff = "";
                currentCard.standards = new string[15];
                currentCard.grade = "";
                deck.cards.RemoveAt(thumbCardIndex[deletePosition]);
                front.Enabled = false;
                back.Enabled = false;

                front.Ink.DeleteStrokes(front.Ink.Strokes);
                back.Ink.DeleteStrokes(back.Ink.Strokes);
                front.Enabled = false;
                back.Enabled = false;
                DifficultyL.Text = "Difficulty";
                standardsL.Text = "Standards";
                gradeL.Text = "Grade";
                //noOfCards--;
                //noOfCardsL.Text = noOfCards + " cards";       Taken care of in subtractCards() method
                Refresh();
            }
            updateThumbs();

            subtractCards();
        }



        // load background button
        /*private void loadBackgroundImageButton_Click(object sender, EventArgs e)
        {
            /*loadBackgroundImageDialog
            openDeckD.ShowDialog();
        }*/
        // open dialog for background image 
        private void loadBackgroundImage_FileOk(object sender, CancelEventArgs e)
        {
            Assembly asm = Assembly.GetExecutingAssembly();

            currentBackgroundImage = Image.FromFile(/*loadBackgroundImageDialog*/openDeckD.FileName);

            MemoryStream ms = new MemoryStream();
            currentBackgroundImage.Save(ms, currentBackgroundImage.RawFormat);
            deck.backgroundImage = Convert.ToBase64String(ms.ToArray());

            if (insertPosition >= deck.cards.Count)
            {
                Card.FitImage(FrontPanel, currentBackgroundImage);
                Card.FitImage(BackPanel, currentBackgroundImage);
                updateThumbs();
                return;
            }

            currentCard = deck.cards[insertPosition];
            //currentCard.picture.Image = currentBackgroundImage;

            // show the background only if there is no image for the current card
            if (currentCard.frontImage == null)
            {
                Card.FitImage(FrontPanel, currentBackgroundImage);
            }
            else // front side has an image
            {
                Card.FitImage(FrontPanel, Image.FromStream(new MemoryStream(Convert.FromBase64String(currentCard.frontImage))));
            }
            if (currentCard.backImage == null)
            {
                Card.FitImage(BackPanel, currentBackgroundImage);
            }
            else // back side has an image
            {
                Card.FitImage(BackPanel, Image.FromStream(new MemoryStream(Convert.FromBase64String(currentCard.backImage))));
            }
            updateThumbs();
        }

        // insert image to front side
        /*private void insertFrontImageButton_Click(object sender, EventArgs e)
        {
            /*insertFrontImageDialog
            openDeckD.ShowDialog();
        }*/

        // open dialog for inserting image to front side
        private void insertFrontImage_FileOk(object sender, CancelEventArgs e)
        {
            Assembly asm = Assembly.GetExecutingAssembly();
            currentFrontImage = Image.FromFile(/*insertFrontImageDialog*/openDeckD.FileName);
            Card.FitImage(FrontPanel, currentFrontImage);
        }


        // insert image to back side
        private void insertBackImageButton_Click(object sender, EventArgs e)
        {
            /*insertBackImageDialog*/
            openDeckD.ShowDialog();
        }

        // open dialog for inserting image to back side
        private void insertBackImage_FileOk(object sender, CancelEventArgs e)
        {
            Assembly asm = Assembly.GetExecutingAssembly();
            currentBackImage = Image.FromFile(/*insertBackImageDialog*/openDeckD.FileName);
            Card.FitImage(BackPanel, currentBackImage);
        }


        // delete image from front side 
        private void deleteFrontImage_Click(object sender, EventArgs e)
        {
            if (deck.cards.Count > 0)
            {
                currentCard = deck.cards[currentCardIndex];
                currentFrontImage = null;
            }
            if (deck.backgroundImage == null)
            {
                //FrontPanel.Image = null;
            }
            else
            {
                Card.FitImage(FrontPanel, Image.FromStream(new MemoryStream(Convert.FromBase64String(deck.backgroundImage))));
                return;
            }
        }
        // delete image from back side
        private void deleteBackImage_Click(object sender, EventArgs e)
        {
            if (deck.cards.Count > 0)
            {
                currentCard = deck.cards[currentCardIndex];
                currentBackImage = null;
            }

            if (deck.backgroundImage == null)
            {
                //BackPanel.Image = null;
            }
            else
            {
                Card.FitImage(BackPanel, Image.FromStream(new MemoryStream(Convert.FromBase64String(deck.backgroundImage))));
                return;
            }
        }

        // "About" button. 
        private void about_Click(object sender, EventArgs e)
        {
            MessageBox.Show("FlashCards for Memory Imporvement\n\nDesigned, built, and tested\n\nDevelopment Team:\nYoungJoo Jeong(Computer Science & Human Computer Interaction)\nJay JW Heo(Computer Science)\nDave Hacker(CS),Manoj Kintali)(CS)\n\nAdvisor: Prof. Ananda Gunawardena\n\nA Free Gift from Carnegie Mellon University\n\nWindows XP Tablet PC, Vista and Windows 7 Compatible\n\nCopyright @ 2008-2010 Carnegie Mellon University");
        }

        
        /*private void MathMode_Click(object sender, EventArgs e)
        {
            if (MathM == false)
            {
                MathM = true;
                MathMode.BackColor = Color.Red;
                MathMode.Text = "Draw";
            }
            else
            {
                MathM = false;
                MathMode.BackColor = Color.LightGray;
                MathMode.Text = "Math";
            }



            InkOverlay newInkOverlay;

            front.Enabled = false;
            back.Enabled = false;

            FrontSavedStrokes[inkIndexFront] = front;
            newInkOverlay = new InkOverlay(FrontPanel.Handle, true);
            inkIndexFront++;
            newInkOverlay.DefaultDrawingAttributes = da;
            newInkOverlay.CursorInRange += new InkCollectorCursorInRangeEventHandler(
                                           this.myInkOverlays_CursorInRange);
            newInkOverlay.Stroke += new InkCollectorStrokeEventHandler(Parse_Stroke);
            newInkOverlay.Enabled = true;
            front = newInkOverlay;


            BackSavedStrokes[inkIndexBack] = back;
            newInkOverlay = new InkOverlay(BackPanel.Handle, true);
            inkIndexBack++;
            newInkOverlay.DefaultDrawingAttributes = da;
            newInkOverlay.CursorInRange += new InkCollectorCursorInRangeEventHandler(
                                           this.myInkOverlays_CursorInRange);
            newInkOverlay.Stroke += new InkCollectorStrokeEventHandler(Parse_Stroke);
            newInkOverlay.Enabled = true;
            back = newInkOverlay;

        }*/


        #endregion


        #region drawing function for math modes
        private void draw_Circle(int Radius, int initialX, int initialY, int currentPanel)
        {
            System.Drawing.Point[] circleStroke = new System.Drawing.Point[3600];
            double myAngle = 0.0;
            int circlePoint = 3600;

            for (int i = 0; i < circlePoint; i++)
            {
                circleStroke[i].X = (int)(initialX + (Radius * (Math.Cos(myAngle))));
                circleStroke[i].Y = (int)(initialY + (Radius * (Math.Sin(myAngle))));
                myAngle += 0.1;
            }

            //Console.WriteLine("Circle Radius: {0}", Radius);
            //Console.WriteLine("Circle Center: ({0}, {1})", initialX, initialY);

            myInkOverlays[currentPanel].Ink.DeleteStrokes();
            myInkOverlays[currentPanel].Ink.CreateStroke(circleStroke);
            Refresh();
        }

        private void drawX(int initialX, int initialY, int currentPanel)
        {
            int iniX = initialX;
            int iniY = initialY;


            initialX = iniX - 900;
            initialY = iniY + 100;
            int initialX2 = iniX + 900;
            int initialY2 = initialY;

            System.Drawing.Point[] myNewStroke = new System.Drawing.Point[1800];
            System.Drawing.Point[] myNewStroke2 = new System.Drawing.Point[1800];

            for (int i = 0; i < 1800; i++)
            {
                myNewStroke[i].X = initialX;
                myNewStroke[i].Y = initialY;
                myNewStroke2[i].X = initialX2;
                myNewStroke2[i].Y = initialY2;

                initialX++;
                initialY--;
                initialX2--;
                initialY2--;
            }

            myInkOverlays[currentPanel].Ink.DeleteStrokes();
            myInkOverlays[currentPanel].Ink.CreateStroke(myNewStroke);
            myInkOverlays[currentPanel].Ink.CreateStroke(myNewStroke2);
            Refresh();
        }


        private void drawTriangle(int initialX, int initialY, int currentPanel)
        {
            int iniX = initialX;
            int iniY = initialY;


            initialX = iniX - 1800;
            initialY = iniY + 200;
            int initialX2 = iniX + 1800;
            int initialY2 = initialY;

            int iniX3, endX3, iniY3;

            iniX3 = initialX;
            endX3 = initialX2;
            iniY3 = initialY;

            int baseLength = endX3 - iniX3;

            System.Drawing.Point[] myNewStroke3 = new System.Drawing.Point[baseLength];


            System.Drawing.Point[] myNewStroke = new System.Drawing.Point[1800];
            System.Drawing.Point[] myNewStroke2 = new System.Drawing.Point[1800];

            for (int i = 0; i < 1800; i++)
            {
                myNewStroke[i].X = initialX;
                myNewStroke[i].Y = initialY;
                myNewStroke2[i].X = initialX2;
                myNewStroke2[i].Y = initialY2;

                initialX++;
                initialY--;
                initialX2--;
                initialY2--;
            }



            for (int i = 0; i < baseLength; i++)
            {
                myNewStroke3[i].X = iniX3;
                myNewStroke3[i].Y = iniY3;
                iniX3++;
            }


            myInkOverlays[currentPanel].Ink.DeleteStrokes();
            myInkOverlays[currentPanel].Ink.CreateStroke(myNewStroke);
            myInkOverlays[currentPanel].Ink.CreateStroke(myNewStroke2);
            myInkOverlays[currentPanel].Ink.CreateStroke(myNewStroke3);
            Refresh();
        }
        #endregion

        //public Mode mode { get; set; }





        //bool ink = true;
        //Add Card Button
        private void clearBothButton_Click(object sender, EventArgs e)
        {
            cL = new CardList(this);
            cL.TopMost = true;
            cL.Show();
            addCards();
            currentMode = Mode.ADD;

            /*ink = !ink;
            if (!ink)
            {
                front.EditingMode = InkOverlayEditingMode.Delete;
                back.EditingMode = front.EditingMode;
                toggleButton.Text = "Toggle Ink";
                toggleButton.Image = new Bitmap(Image.FromFile(Environment.CurrentDirectory + "\\eraser.bmp"));
            }

            if (ink)
            {
                front.EditingMode = InkOverlayEditingMode.Ink;
                back.EditingMode = front.EditingMode;
                toggleButton.Text = "Toggle Erase";
                toggleButton.Image = new Bitmap(Image.FromFile(Environment.CurrentDirectory + "\\pen.bmp"));
            }*/
        }

        public void getAddCard(string cardReference)
        {
            currentCard = new Card();
            currentCard = BinaryDeserializeCard(cardReference);
            cardNames.Add(currentCard.cardname);
            LoadCard();
        }

        public void getCards(List<string> cardN)
        {
            foreach (string s in cardN)
            {
                cardNames.Add(s);
                //currentCard = new Card();
                currentCard = BinaryDeserializeCard(saveCards + s + ".cd");
                LoadCard();
            }
        }

        private void LoadCard()
        {

            //if (buttonChoice.Equals("EDIT"))
            //{
              //  deleteCardButton.PerformClick();
            //}

            if (currentCard.wordCard == true)
            {
                WordCardShow();
            }

            if (currentCard.autoMathCard == true)
            {
                AutoMathCardShow();
            }

            if (currentCard.panelBackground != null)
            {
                //MessageBox.Show("Card contains image");
                pictureBox1.Enabled = true;
                pictureBox1.Visible = true;
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

                //Sets the Image property to the image in the filename selected
                pictureBox1.Image = currentCard.panelBackground;

                //Adds the picturebox to the Panel to show up

            }

            try
            {
                front.Enabled = false;
                front.Ink.Dispose();
                front.Ink = new Ink();
                try
                {
                    front.Ink.Load(currentCard.frontInk);
                }
                catch (ArgumentException)
                {
                }
                front.Enabled = false;

                back.Enabled = false;
                back.Ink.Dispose();
                back.Ink = new Ink();
                try
                {
                    back.Ink.Load(currentCard.backInk);
                }
                catch (ArgumentException)
                {
                }
                back.Enabled = false;
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message + "\nPlease contact the  developers with this error if ink will not show after clicking \"Ok\".","Argument Exception");
            }
                Refresh();
                DifficultyL.Text = currentCard.diff;
                gradeL.Text = currentCard.grade;
                string labelText = "";
                for (int i = 0; i < currentCard.standards.Length; i++)
                {
                    if (currentCard.standards[i] != "")
                    {
                        labelText = labelText + currentCard.standards[i] + "\n";
                        //globalLabelText = labelText;
                    }
                }
                standardsL.Text = labelText;
                GradeableCB.Checked = currentCard.gradeable;
            
            

            InsertCardToDeck();
        }

        private void InsertCardToDeck()
        {
            if (front.Ink.Strokes.Count == 0)
            {
                if (currentFrontImage == null)
                    return;
            }
            if (back.Ink.Strokes.Count == 0)
            {
                if (currentBackImage == null)
                    return;
            }
            if (currentMode == Mode.VIEW)
            {
                return;
            }

            front.Enabled = false;
            back.Enabled = false;

            //Card currentCard = new Card();
            
            currentCard.frontInk = front.Ink.Save(PersistenceFormat.InkSerializedFormat, CompressionMode.Maximum);
            currentCard.backInk = back.Ink.Save(PersistenceFormat.InkSerializedFormat, CompressionMode.Maximum);

            for (int i = 0; i < inkIndexFront; i++)
            {
                currentCard.frontInk = FrontSavedStrokes[i].Ink.Save(PersistenceFormat.InkSerializedFormat, CompressionMode.Maximum);
            }

            for (int i = 0; i < inkIndexBack; i++)
            {
                currentCard.backInk = 
                    BackSavedStrokes[i].Ink.Save(PersistenceFormat.InkSerializedFormat, CompressionMode.Maximum);
            }


            if (currentFrontImage != null)
            {
                MemoryStream ms = new MemoryStream();
                currentFrontImage.Save(ms, currentFrontImage.RawFormat);
                currentCard.frontImage = Convert.ToBase64String(ms.ToArray());
                currentFrontImage = null;
            }
            else
            {
                currentCard.frontImage = null;
            }

            if (currentBackImage != null)
            {
                MemoryStream ms = new MemoryStream();
                currentBackImage.Save(ms, currentBackImage.RawFormat);
                currentCard.backImage = Convert.ToBase64String(ms.ToArray());
                currentBackImage = null;
            }
            else
            {
                currentCard.backImage = null;
            }
            
            /*currentCard.gradeable = GradeableCB.Checked;
            string stan = "";
            
            if(currentCard.diff == "")
            {
                try
                {
                    //string diff = add.difficulty();
                    //if(diff != currentCard.diff)
                    //    currentCard.diff = diff;
                    currentCard.diff = add.difficulty();
                }
                catch (NullReferenceException)
                {
                    MessageBox.Show("Please choose a difficulty for this card.");
                    return;
                }
            }
            if(currentCard.grade == "")
            {
                try
                {
                    //string grade = add.grade();
                    //if(grade != currentCard.grade)
                     //   currentCard.grade = grade;
                    currentCard.grade = add.grade();
                }
                catch (FileLoadException)
                {
                    MessageBox.Show("Please add a grade level for this card.");
                    return;
                }
            }

            bool stanHasValues = false;
            for(int i = 0; i < currentCard.standards.Length; i++)
                if (currentCard.standards[i] != "")
                {
                    stanHasValues = true;
                    break;
                }
            //if (!stanHasValues)
            //{
                try
                {
                    currentCard.standards = add.standards();

                    //MessageBox.Show("Adding Card Name\nstandard: " + currentCard.standards[0] + "\ngrade: " + currentCard.grade + "\ndifficulty: " + currentCard.diff);


                    for (int i = 0; i < currentCard.standards.Length; i++)
                    {
                        try
                        {
                            stan = stan + currentCard.standards[i].Substring(0, 5) + ", ";
                        }
                        catch (ArgumentOutOfRangeException ex)
                        { }
                    }
                }
                catch (ArgumentException)
                {
                    MessageBox.Show("Please choose at least one standard for this card.");
                    return;
                }
            //}
            if (currentCard.cardname == "")
            {
                //MessageBox.Show("Generating name for card...");
                addCards();
                if (GradeableCB.Checked)
                { currentCard.cardname = user + ", " + stan + currentCard.diff + ", " + DateTime.Now.ToString("hh mm tt") + ", computer graded"; }
                else
                { currentCard.cardname = user + ", " + stan + currentCard.diff + ", " + DateTime.Now.ToString("hh mm tt") + ", teacher graded"; }

                cardNames.Add(currentCard.cardname);
            }


            BinarySerializeCard(currentCard, saveCards + currentCard.cardname + ".cd");


            //MessageBox.Show("grade: " + currentCard.grade + "\nstandard: " + currentCard.standards[0] + "\ndifficulty: " + currentCard.diff);
            */

            //MessageBox.Show(currentMode.ToString());

            if (currentMode == Mode.INSERT)
            {
               if (insertPosition > deck.cards.Count)
                {
                    insertPosition = deck.cards.Count;
                    
                }

                deck.cards.Insert(insertPosition, currentCard);
                if (insertPosition <= deck.cards.Count && insertPosition < 5)
                {
                    //add = new Form1(this);
                    currentCard.standards = new string[15];
                    currentCard.grade = "";
                    currentCard.diff = "";
                    changeBarPosition(insertPosition + 1);
                    changeSelectedThumb(insertPosition + 1);
                }
                if (insertIndex > 5)
                {
                    doNextThumb();
                }
            }
            else if (currentMode == Mode.ADD)
            {
                deck.cards.Insert(deck.cards.Count, currentCard);
                if (deck.cards.Count > 5)
                {
                    doNextThumb();
                }
                if (deck.cards.Count < 6)
                {
                    changeBarPosition(deck.cards.Count);
                    changeSelectedThumb(deck.cards.Count);
                }
            }
            else // view mode
            {
                if (insertPosition < deck.cards.Count)
                {
                    deck.cards.RemoveAt(insertPosition);
                }
                deck.cards.Insert(insertPosition, currentCard);
                updateThumbs();
                if (insertPosition > 5)
                {
                    doNextThumb();
                }
                Refresh();
                currentMode = Mode.INSERT;

            }

            //MessageBox.Show(currentMode.ToString(), "After");
            //MessageBox.Show("grade: " + currentCard.grade + "\nstandard: " + currentCard.standards[0] + "\ndifficulty: " + currentCard.diff);


            front.Ink.DeleteStrokes(front.Ink.Strokes);
            back.Ink.DeleteStrokes(back.Ink.Strokes);

            front.Enabled = false;
            back.Enabled = false;
            updateThumbs();
            Refresh();

            front.Enabled = false;
            back.Enabled = false;

            front.Ink.DeleteStrokes(front.Ink.Strokes);
            back.Ink.DeleteStrokes(back.Ink.Strokes);
            front.Enabled = false;
            back.Enabled = false;

            DifficultyL.Text = "Difficulty";
            standardsL.Text = "Standards";
            gradeL.Text = "Grade";

           
            //MessageBox.Show("grade: " + currentCard.grade + "\nstandard: " + currentCard.standards[0] + "\ndifficulty: " + currentCard.diff);
            currentCard = new Card();
            Refresh();
                  

            if (currentBackgroundImage == null)
            {
                // FrontPanel.Image = null;
                // BackPanel.Image = null; 
            }
            else// show background if it's set
            {
                Card.FitImage(FrontPanel, currentBackgroundImage);
                Card.FitImage(BackPanel, currentBackgroundImage);
            }
        }

            /*private void addStandards()
            {
                add = new Form1();
                for (int i = 0; i < add.stan.Length; i++)
                {
                    if (add.stan[i] != "")
                    {
                        standardsL.Text = add.stan[i];
                    }
                }
        }*/

        private void clearFrontButton_Click(object sender, EventArgs e)
        {
            front.Ink.DeleteStrokes();
            FrontPanel.Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            back.Ink.DeleteStrokes();
            BackPanel.Refresh();
        }

        private void saveCardD_FileOk(object sender, CancelEventArgs e)
        {
            /*if (front.Ink.Strokes.Count == 0)
            {
                if (currentFrontImage == null)
                    return;
            }
            if (back.Ink.Strokes.Count == 0)
            {
                if (currentBackImage == null)
                    return;
            }
            if (currentMode == Mode.VIEW)
            {
                return;
            }

            front.Enabled = false;
            back.Enabled = false;*/

            //Card currentCard = new Card();

            currentCard.frontInk = front.Ink.Save(PersistenceFormat.InkSerializedFormat, CompressionMode.Maximum);
            currentCard.backInk = back.Ink.Save(PersistenceFormat.InkSerializedFormat, CompressionMode.Maximum);

            for (int i = 0; i < inkIndexFront; i++)
            {
                currentCard.frontInk = FrontSavedStrokes[i].Ink.Save(PersistenceFormat.InkSerializedFormat, CompressionMode.Maximum);
            }

            for (int i = 0; i < inkIndexBack; i++)
            {
                currentCard.backInk = BackSavedStrokes[i].Ink.Save(PersistenceFormat.InkSerializedFormat, CompressionMode.Maximum);
            }


            if (currentFrontImage != null)
            {
                MemoryStream ms = new MemoryStream();
                currentFrontImage.Save(ms, currentFrontImage.RawFormat);
                currentCard.frontImage = Convert.ToBase64String(ms.ToArray());
                currentFrontImage = null;
            }
            else
            {
                currentCard.frontImage = null;
            }

            if (currentBackImage != null)
            {
                MemoryStream ms = new MemoryStream();
                currentBackImage.Save(ms, currentBackImage.RawFormat);
                currentCard.backImage = Convert.ToBase64String(ms.ToArray());
                currentBackImage = null;
            }
            else
            {
                currentCard.backImage = null;
            }

            try
            {
                currentCard.diff = add.difficulty();
                currentCard.standards = add.standards();
                currentCard.grade = add.grade();
                for (int i = 0; i < add.stan.Length; i++)
                {
                    if (add.stan[i] != "")
                    {
                        currentCard.cardname = user + ", " + currentCard.standards[i] + ", " + currentCard.diff + ", " + DateTime.Now.ToString("hh mm tt");
                    }
                }
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Please choose a difficulty for this card.");
                return;
            }
            catch (FileLoadException)
            {
                MessageBox.Show("Please add a grade level for this card.");
                return;
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Please choose at least one standard for this card.");
                return;
            }
            currentCard.gradeable = GradeableCB.Checked;

            BinarySerializeCard(currentCard, saveCardD.FileName);

            createNewCard_Click(null, null);
            front.Enabled = false;
            back.Enabled = false;
        }

        private void saveDeck_Click_1(object sender, EventArgs e)
            
        {
            dialog = new SaveDeck(user, cardNames, this,false);
            dialog.TopMost = true;
            dialog.Show();
        }

        public void saveDeck_close()
        {
            dialog.Dispose();

            try
            {
                for (int i = 0; i < deck.cards.Count; i++)
                {
                    clearThumb(i);
                    initThumbs(i, getThumbPanel(i));
                }
                //deleteCard_Click(null, null);
                //updateThumbs();
                changeBarPosition(0);
                changeSelectedThumb(0);
                thumb1_MouseClick(null,null);
                currentCard = new Card();

                noOfCards = 0;
                noOfCardsL.Text = noOfCards + " cards";

                deck = null;
                deck = Deck.getDeck();

                front.Ink.DeleteStrokes(front.Ink.Strokes);
                back.Ink.DeleteStrokes(back.Ink.Strokes);

                front.Enabled = false;
                back.Enabled = false;
                updateThumbs();
                Refresh();

                front.Enabled = false;
                back.Enabled = false;

                front.Ink.DeleteStrokes(front.Ink.Strokes);
                back.Ink.DeleteStrokes(back.Ink.Strokes);
                front.Enabled = false;
                back.Enabled = false;

                DifficultyL.Text = "Difficulty";
                standardsL.Text = "Standards";
                gradeL.Text = "Grade";
                cardNames = new List<string> { };
                deck.cards = new List<Card> { };
                currentCard = new Card();

                Refresh();
            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e.Message + "\nPlease call for assistance.");
                //this.Hide();
                this.Dispose();
                EditCardsTeacher edTeach = new EditCardsTeacher("", user, tdOriginal);
                Global.form.Controls.Add(edTeach);
            }
            /*catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }*/
        }

        public void openCardD_FileOk(object sender, CancelEventArgs e)
        {
            currentCard = BinaryDeserializeCard(openCardD.FileName);
           // Card card = openWF.card;
            
            //FrontPanel.BackgroundImage = card.frontImage;
            //front.Enabled = false;
            //back.Enabled = false;
            try
            {
                front.Enabled = false;
                front.Ink.Dispose();
                front.Ink = new Ink();
                try
                {
                    front.Ink.Load(currentCard.frontInk);
                }
                catch (ArgumentException)
                {
                }
                front.Enabled = false;

                back.Enabled = false;
                back.Ink.Dispose();
                back.Ink = new Ink();
                try
                {
                    back.Ink.Load(currentCard.backInk);
                }
                catch (ArgumentException)
                {
                }
                back.Enabled = false;
            }
            catch (ArgumentException eA)
            {
                MessageBox.Show(eA.Message);
            }
            FrontPanel.Refresh();
            BackPanel.Refresh();

            string labelText = "";
            for (int i = 0; i < currentCard.standards.Length; i++)
            {
                if (currentCard.standards[i] != "")
                {
                    labelText = labelText + currentCard.standards[i] + "\n";
                    //globalLabelText = labelText;
                }
            }
            string gradeText = "";
            //for (int i = 0; i < currentCard.grade.Length; i++)
            //{
                if (currentCard.grade != "")
                {
                    gradeText = gradeText + currentCard.grade + "\n";
                    //globalLabelText = labelText;
                }
            //}
            
            standardsL.Text = labelText;
            DifficultyL.Text = currentCard.diff;
            gradeL.Text = gradeText;
            GradeableCB.Checked = currentCard.gradeable;
            //globalLabelText = finalGlobalLabelText;
            

            //saveCurrentButton_Click(null, null);

            front.Enabled = false;
            back.Enabled = false;

            if (currentCard.panelBackground != null)
            {
                Card.FitImage(FrontPanel,currentCard.panelBackground);
            }
        }

        public void openDeckD_FileOk(object sender, EventArgs e)
        {


            deck.cards = BinaryDeserialize(openDeckD.FileName);
            //MessageBox.Show("Binary Deserialization should have occurred.");
            try
            {
                noOfCards = deck.cards.Count;
                noOfCardsL.Text = noOfCards + " cards";
            }
            catch (NullReferenceException) { }


            string labelText = "";
            for (int i = 0; i < deck.cards[0].standards.Length; i++)
            {
                if (deck.cards[0].standards[i] != "")
                {
                    labelText = labelText + currentCard.standards[i] + "\n";
                    //globalLabelText = labelText;
                }
            }
            string gradeText = "";
            //for (int i = 0; i < currentCard.grade.Length; i++)
            //{
            if (deck.cards[0].grade != "")
            {
                gradeText = gradeText + currentCard.grade + "\n";
                //globalLabelText = labelText;
            }
            //}
            //MessageBox.Show("Grade: " + deck.cards[0].grade);
            standardsL.Text = labelText;
            DifficultyL.Text = deck.cards[0].diff;
            gradeL.Text = gradeText;
            GradeableCB.Checked = deck.cards[0].gradeable;
            
        }

        void AutoMathCardShow()
        {
            Label question = new Label();
            Label answer = new Label();

            question.Size = new System.Drawing.Size(FrontPanel.Height - 50, FrontPanel.Width);
            question.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold);
            question.Text = currentCard.num1.ToString() + currentCard.operate.ToString() + currentCard.num2.ToString();
            question.Location = new System.Drawing.Point((FrontPanel.Width) / 4, (FrontPanel.Height) / 4);

            answer.Size = new System.Drawing.Size(BackPanel.Height - 50, BackPanel.Width);
            answer.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold);
            answer.Text = currentCard.answer.ToString();
            answer.Location = new System.Drawing.Point((BackPanel.Width) / 4, (BackPanel.Height) / 4);

            FrontPanel.Controls.Add(question);
            BackPanel.Controls.Add(answer);
        }

        void WordCardShow()
        {
            Label question = new Label();
            Label answer = new Label();

            question.Size = new System.Drawing.Size(FrontPanel.Height - 50, FrontPanel.Width);
            question.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold);
            question.Text = currentCard.question;
            question.Location = new System.Drawing.Point((FrontPanel.Width) / 4, (FrontPanel.Height) / 4);

            answer.Size = new System.Drawing.Size(BackPanel.Height - 50, BackPanel.Width);
            answer.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold);
            answer.Text = currentCard.answerWord;
            answer.Location = new System.Drawing.Point((BackPanel.Width) / 4, (BackPanel.Height) / 4);

            FrontPanel.Controls.Add(question);
            BackPanel.Controls.Add(answer);
        }

        public int openDeckBClicked = 0;
        public void OpenDeckB_loadCard(string deckName, bool autoM)
        {
            //MessageBox.Show("Inside Open Deck Method");
            openDeckBClicked++;
            autoMath = autoM;
            
            if (openDeckBClicked > 1)
            {
                int numberOfElementsInCardNamesBeforeClearing = cardNames.Count;
                //MessageBox.Show(cardNames.Count.ToString() + " " + numberOfElementsInCardNamesBeforeClearing.ToString());
                cardNames.Clear();
            }
            deck.cards = BinaryDeserialize(deckName);
              
            //MessageBox.Show("Binary Deserialization should have occurred.");
            try
            {
                noOfCards = deck.cards.Count;
                noOfCardsL.Text = noOfCards + " cards";
            }
            catch (NullReferenceException) { }

            for (int i = 0; i < deck.cards.Count; i++)
            {
                if (deck.cards[i].autoMathCard == true)
                {
                    currentCard = new Card();
                    currentCard = deck.cards[0];
                    AutoMathCardShow();
                    break;
                }

                if (deck.cards[i].wordCard == true)
                {
                    currentCard = new Card();
                    currentCard = deck.cards[0];
                    WordCardShow();
                    break;
                }

            }

            string labelText = "";
            for (int i = 0; i < deck.cards[0].standards.Length; i++)
            {
                if (deck.cards[0].standards[i] != "")
                {
                    labelText = labelText + deck.cards[0].standards[i] + "\n";
                    //globalLabelText = labelText;
                }
            }
            //MessageBox.Show(labelText, "Standards");
            standardsL.Text = labelText;
            DifficultyL.Text = deck.cards[0].diff;
            gradeL.Text = deck.cards[0].grade;
            GradeableCB.Checked = deck.cards[0].gradeable;
            
            Refresh();
            updateThumbs();
            displayThumbCard(0);
            
        }

        private void openCard_Click(object sender, EventArgs e)
        {

            openCardD.ShowDialog();


        }

        private void standardsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //add = new Form1(this);
            add.Show();
        }

        /*private void OpenB_Click(object sender, EventArgs e)
        {
            openWF = new OpenWF();
            openWF.Show();

        }*/

        public EditCardsTeacher(string filename, string usr, DashboardTeacher tOrig, List<string> cardN)
        {
            InitializeComponent();
            user = usr;
            tdOriginal = tOrig;
            //add = new Form1(this);
            front = new InkOverlay(FrontPanel.Handle);
            back = new InkOverlay(BackPanel.Handle);

            saveCards = "C:\\Cards\\Created Cards\\";
            saveDecks = "C:\\Cards\\Created Decks\\";
            saveAutoMath = "C:\\Cards\\Created Cards\\AutoMath\\";

            //mode = Mode.Ink;
            try
            {
                front.Enabled = false;
                back.Enabled = false;
            }
            catch (COMException)
            {

            }
            //front.Stroke += new InkCollectorStrokeEventHandler(front_Stroke);

            //front.EditingMode = InkOverlayEditingMode.Ink;
            //back.EditingMode = front.EditingMode;


            //not my code
            //this.WindowState = FormWindowState.Normal;
            //this.FormBorderStyle = FormBorderStyle.Fixed3D;
            //this.TopMost = true;

            for (int i = 0; i < 2; i++)
            {
                firstTime[i] = true;
            }
            for (int i = 0; i < 5; i++)
            {
                thumbFirstTime[i] = true;
                initThumbs(i, getThumbPanel(i));

                //thumbCardIndex[i] = -1; 
                thumbCardIndex[i] = 0;
            }
            insertPosition = 0;
            currentCardIndex = 0;
            thumbIndex = 0;
            penColor = Color.Black;

            //   deck.cards.Add(new Card()); 

            currentBackgroundImage = null;
            currentFrontImage = null;
            currentBackImage = null;

            if (filename != "")
                deck.cards = BinaryDeserialize(filename);



            //my code
            //for (int i = 0; i < standards.Length; i++)
            //     standards[i] = "";

            noOfCardsL.Text = "Number of Cards";

            deck = Deck.getDeck();
            cardNames = new List<string> { };
            for (int i = 0; i < cardN.Count; i++)
            {
                cardNames.Add(cardN[i]);
            }
            Refresh();
            updateThumbs();
            displayThumbCard(0);
        }

        public EditCardsTeacher(string filename, string usr, DashboardTeacher tOrig)
        {
            InitializeComponent();
            user = usr;
            //add = new Form1(this);
            currentCard = new Card();
            //Card card = BinaryDeserializeCard(openCardD.FileName);
            //string[] key = new string[add.stan.Length];

            
            saveCards = "C:\\Cards\\Created Cards\\";
            saveDecks = "C:\\Cards\\Created Decks\\";
            saveAutoMath = "C:\\Cards\\Created Cards\\AutoMath\\";
            

            tdOriginal = tOrig;
            //my code

            front = new InkOverlay(FrontPanel.Handle);
            back = new InkOverlay(BackPanel.Handle);

            //mode = Mode.Ink;
            try
            {
                front.Enabled = false;
                back.Enabled = false;
            }
            catch (COMException)
            {

            }
            //front.Stroke += new InkCollectorStrokeEventHandler(front_Stroke);

            //front.EditingMode = InkOverlayEditingMode.Ink;
            //back.EditingMode = front.EditingMode;


            //not my code
            //this.WindowState = FormWindowState.Normal;
            //this.FormBorderStyle = FormBorderStyle.Fixed3D;
            //this.TopMost = true;

            for (int i = 0; i < 2; i++)
            {
                firstTime[i] = true;
            }
            for (int i = 0; i < 5; i++)
            {
                thumbFirstTime[i] = true;
                initThumbs(i, getThumbPanel(i));

                //thumbCardIndex[i] = -1; 
                thumbCardIndex[i] = 0;
            }
            insertPosition = 0;
            currentCardIndex = 0;
            thumbIndex = 0;
            penColor = Color.Black;

            //   deck.cards.Add(new Card()); 

            currentBackgroundImage = null;
            currentFrontImage = null;
            currentBackImage = null;

            if (filename != "")
                deck.cards = BinaryDeserialize(filename);



            //my code
            //for (int i = 0; i < standards.Length; i++)
            //     standards[i] = "";

            noOfCardsL.Text = "Number of Cards";
            
            deck = Deck.getDeck();
            cardNames = new List<string> { };
        }

        //Edit Card Button
        private void saveCurrentButton_Click(object sender, EventArgs e)
        {
            
            cc = new CreateCard(currentCard,user, tdOriginal, cardNames, this);
            deleteCard_Click(null,null);
            this.Dispose();
            Global.form.Controls.Add(cc);
            currentMode = Mode.ADD;

            

            //this.Dispose();
        }

        private void saveDeckD_FileOk(object sender, CancelEventArgs e)
        {
            BinarySerialize(deck.cards, saveDeckD.FileName);
        }

        /*private void deckSummaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeckSummary dialog = new DeckSummary();
            dialog.Show();
        }*/

        private void addCards()
        {
            noOfCards++;

            if (noOfCards < 1)
            {
                noOfCards = 0;
                noOfCardsL.Text = noOfCards + " cards";
            }
            else if (noOfCards == 1)
                noOfCardsL.Text = noOfCards + " card";

            else if (noOfCards > 1)
                noOfCardsL.Text = noOfCards + " cards";
        }

        private void subtractCards()
        {
            noOfCards--;

            if (noOfCards < 1)
            {
                noOfCards = 0;
                noOfCardsL.Text = noOfCards + " cards";
            }
            else if (noOfCards == 1)
                noOfCardsL.Text = noOfCards + " card";

            else if (noOfCards > 1)
                noOfCardsL.Text = noOfCards + " cards";
        }

        private void closeDeck()
        {
            if(cardNames.Count < 5)
                for (int i = 0; i < cardNames.Count; i++)
                {
                    displayThumbCard(i);
                    deleteCard_Click(null, null);
                }
        }

        private void EditCardsTeacher_Load(object sender, EventArgs e)
        {

        }

        private void addPpt_Click(object sender, EventArgs e)
        {


            List<Slide> slideList = new List<Slide>();
            List<String> Questions = new List<String>();
            List<String> Answers = new List<String>();

            //Same thing may happen with the word feature. Not sure if this had been encountered yet...
            if (MessageBox.Show("For this feature to work properly, please have the file you wish to use already opened in Microsoft PowerPoint. Otherwise the file will not be reachable and an error will occur. Is the file already open?", "Error Prevention", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                oF.Filter = "PowerPoint Files(*.ppt; *.pptx)|*.ppt; *.pptx";
                if (oF.ShowDialog() == DialogResult.OK)
                {
                    Microsoft.Office.Interop.PowerPoint.Application application = new Microsoft.Office.Interop.PowerPoint.Application();
                    
                    Presentation ppt = application.Presentations.Open(oF.FileName);

                    Microsoft.Office.Interop.PowerPoint.TextRange range;

                    //Starts at second slide (Assuming for now that there is a title slide)
                    int i = 2;

                    //Make sure not to take data from a title slide
                    // if (ppt.Slides[i].Layout.Equals(PpSlideLayout.ppLayoutTitle) || ppt.Slides[i].Layout.Equals(PpSlideLayout.ppLayoutTitleOnly))
                    //      i++;

                    while (i <= ppt.Slides.Count)
                    {
                        
                        //Goes to current slide, 2nd shape (Content of a Title and Content Slide) and sets that as the text range
                        range = ppt.Slides[i].Shapes[2].TextFrame.TextRange;

                        
                        //Adds the first line of text to the Questions list
                        Questions.Add(range.Paragraphs(1, 1).Text);

                        
                        //Adds the second line of text to the Answers list
                        Answers.Add(range.Paragraphs(2, 1).Text);

                        //MessageBox.Show("Question: " + Questions[i - 1] + "   Answer: " + Answers[i - 1]);

                        i++;

                    }

                    if (Questions.Count == 1)
                    {
                        Label question = new Label();
                        Label answer = new Label();

                        question.Size = new System.Drawing.Size(FrontPanel.Height - 50, FrontPanel.Width);
                        question.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold);
                        currentCard.question = Questions[0];
                        question.Text = Questions[0];
                        question.Location = new System.Drawing.Point((FrontPanel.Width) / 4, (FrontPanel.Height) / 4);

                        answer.Size = new System.Drawing.Size(BackPanel.Height - 50, BackPanel.Width);
                        answer.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold);
                        currentCard.answerWord = Answers[0];
                        answer.Text = Answers[0];
                        answer.Location = new System.Drawing.Point((BackPanel.Width) / 4, (BackPanel.Height) / 4);
                        currentCard.wordCard = true;

                        FrontPanel.Controls.Add(question);
                        BackPanel.Controls.Add(answer);

                        if (myInkOverlays[FRONT] == null || myInkOverlays[BACK] == null)
                        {
                            myInkOverlays[FRONT] = new InkOverlay();
                            myInkOverlays[BACK] = new InkOverlay();
                        }

                        myInkOverlays[FRONT].Enabled = false;
                        myInkOverlays[FRONT].Ink.Dispose();
                        myInkOverlays[FRONT].Ink = new Ink();
                        myInkOverlays[FRONT].Enabled = false;

                        myInkOverlays[BACK].Enabled = false;
                        myInkOverlays[BACK].Ink.Dispose();
                        myInkOverlays[BACK].Ink = new Ink();
                        myInkOverlays[BACK].Enabled = false;
                    }
                    

                    if (ppt.Slides.Count >= 2)
                    {
                        DialogResult dr = MessageBox.Show("There is more than one question in the file. Would you like to save all the questions as individual cards into a deck?", "Save or Exit", MessageBoxButtons.YesNo);
                        if (dr == DialogResult.Yes)
                        {
                            //Start at slide 2 (Index 1), assume title slide
                            for (int index = 2; index <= ppt.Slides.Count; index++)
                            {
                                //Index - 2 because slides start at 1 instead of 0 and we are disregarding the title slide (slide 1) at this time
                                currentCard.question = Questions[index - 2];
                                currentCard.answerWord = Answers[index - 2];
                                currentCard.wordCard = true;
                                //Index - 1 because slides start at 1 instead of 0
                                currentCard.cardname = oF.SafeFileName + " " + (index - 1);
                                cardNames.Add(currentCard.cardname);
                                //cardList.Add(currentCard);
                                BinarySerializeCard(currentCard, "C:\\Cards\\Created Cards\\" + oF.SafeFileName + " " + (index - 1) + ".cd");
                                currentCard = new Card();
                            }
                            dialog = new SaveDeck(user, cardNames, this,true);
                            dialog.TopMost = true;
                            dialog.Show();
                        }

                        if (dr == DialogResult.No)
                        {

                        }
                    }

                    application.Quit();

                }

                oF.Dispose();

            }
        }

        private void addWord_Click(object sender, EventArgs e)
        {
            //int numOfParagraphsNumbered = 0;
            List<Paragraph> parListNumbered = new List<Paragraph>();
            List<Paragraph> parListNumberedQuestions = new List<Paragraph>();
            List<Paragraph> parListNumberedAnswers = new List<Paragraph>();

            oF.Filter = "Word Files(*.doc; *.docx)|*.doc; *.docx";

            if (oF.ShowDialog() == DialogResult.OK)
            {
                // Open a doc file.
                Microsoft.Office.Interop.Word.Application application = new Microsoft.Office.Interop.Word.Application();
                Document document = application.Documents.Open(oF.FileName);

                // Loop through all words in the document.
                int count = document.Words.Count;

                foreach (Paragraph par in document.Content.Paragraphs)
                {
                    object obj = par.Range.ListFormat;

                    if (par.Range.ListFormat.ListType == WdListType.wdListNoNumbering)
                    {
                        //MessageBox.Show("Not a numbered paragraph");
                    }

                    if (par.Range.ListFormat.ListType == WdListType.wdListSimpleNumbering)
                    {
                        parListNumbered.Add(par);
                        //MessageBox.Show(parListNumbered.Count.ToString());
                    }
                }

                if (parListNumbered.Count == 2)
                {

                    for (int i = 0; i < parListNumbered.Count; i++)
                    {
                        if (parListNumbered[i].Range.ListFormat.ListLevelNumber == 1)
                        {
                            //MessageBox.Show("Question: " + parListNumbered[i].Range.Text);
                            parListNumberedQuestions.Add(parListNumbered[i]);

                        }

                        if (parListNumbered[i].Range.ListFormat.ListLevelNumber == 2)
                        {
                            //MessageBox.Show("Answer: " + parListNumbered[i].Range.Text);
                            parListNumberedAnswers.Add(parListNumbered[i]);
                        }
                    }

                    Label question = new Label();
                    Label answer = new Label();

                    question.Size = new System.Drawing.Size(FrontPanel.Height - 50, FrontPanel.Width);
                    question.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold);
                    currentCard.question = parListNumberedQuestions[0].Range.Text;
                    question.Text = parListNumberedQuestions[0].Range.Text;
                    question.Location = new System.Drawing.Point((FrontPanel.Width) / 4, (FrontPanel.Height) / 4);

                    answer.Size = new System.Drawing.Size(BackPanel.Height - 50, BackPanel.Width);
                    answer.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold);
                    currentCard.answerWord = parListNumberedAnswers[0].Range.Text;
                    answer.Text = parListNumberedAnswers[0].Range.Text;
                    answer.Location = new System.Drawing.Point((BackPanel.Width) / 4, (BackPanel.Height) / 4);

                    currentCard.wordCard = true;

                    FrontPanel.Controls.Add(question);
                    BackPanel.Controls.Add(answer);

                    myInkOverlays[FRONT].Enabled = false;
                    myInkOverlays[FRONT].Ink.Dispose();
                    myInkOverlays[FRONT].Ink = new Ink();
                    myInkOverlays[FRONT].Enabled = false;

                    myInkOverlays[BACK].Enabled = false;
                    myInkOverlays[BACK].Ink.Dispose();
                    myInkOverlays[BACK].Ink = new Ink();
                    myInkOverlays[BACK].Enabled = false;
                }

                if (parListNumbered.Count > 2)
                {
                    //MessageBox.Show("Number of numbered paragraphs: " + parListNumbered.Count.ToString());
                    for (int i = 0; i < parListNumbered.Count; i++)
                    {
                        if (parListNumbered[i].Range.ListFormat.ListLevelNumber == 1)
                        {
                            //MessageBox.Show("Question: " + parListNumbered[i].Range.Text);
                            parListNumberedQuestions.Add(parListNumbered[i]);

                        }

                        if (parListNumbered[i].Range.ListFormat.ListLevelNumber == 2)
                        {
                            //MessageBox.Show("Answer: " + parListNumbered[i].Range.Text);
                            parListNumberedAnswers.Add(parListNumbered[i]);
                        }
                    }

                    DialogResult dr = MessageBox.Show("There is more than one question in the file. Would you like to save all the questions as individual cards into a deck?", "Save or Exit", MessageBoxButtons.YesNo);
                    if (dr == DialogResult.Yes)
                    {
                        for (int i = 0; i < parListNumberedQuestions.Count; i++)
                        {
                            currentCard.question = parListNumberedQuestions[i].Range.Text;
                            currentCard.answerWord = parListNumberedAnswers[i].Range.Text;
                            currentCard.wordCard = true;
                            currentCard.cardname = oF.SafeFileName + " " + i;
                            cardNames.Add(currentCard.cardname);
                            //cardList.Add(currentCard);
                            BinarySerializeCard(currentCard, "C:\\Cards\\Created Cards\\" + oF.SafeFileName + " " + i + ".cd");
                            currentCard = new Card();
                        }
                        dialog = new SaveDeck(user, cardNames, this,true);
                        dialog.TopMost = true;
                        
                        dialog.Show();
                    }

                    if (dr == DialogResult.No)
                    {

                    }
                }

                application.Quit();


            }

            oF.Dispose();
                
            
        }

        private void autoMathP_Click(object sender, EventArgs e)
        {
            this.Hide();
            AutoMath autoMath = new AutoMath(this,user);
            Global.form.Controls.Add(autoMath);
        }
    }
}