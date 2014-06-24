using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Ink;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace WindowsFormsApplication1
{
    public partial class CreateCardStudent : UserControl
    {
        private string grade;
        private string diff;
        private string[] stans;

        private const int FRONT = 0;
        private const int BACK = 1;
        private int insertIndex;
        private Mode currentMode;
        private InkOverlay[] myInkOverlays = new InkOverlay[2];
        private InkOverlay myInkOverlay;
        private InkOverlay[] FrontSavedStrokes = new InkOverlay[30];
        private InkOverlay[] BackSavedStrokes = new InkOverlay[30];
        private int inkIndexFront = 0;
        private int inkIndexBack = 0;
        private CardList cl;
        private const string FILE_NAME = "C:\\Users\\Kathy\\Documents\\Ben\\C#\\Save Files\\filename.txt";
        int fileKeepTrack = 0;

        Form1 add;
        public string file;
        string user;
        DashboardStudent dashTeach;
        EditCardsStudent edTeach;
        string saveCards;
        Card currentCard;
        List<string> cardNames;

        ButtonChoice currentBChoice;
        Screen currentScreen;


        enum Mode
        {
            ADD = 0,
            INSERT,
            VIEW,
            REPLACE
        };
        enum ButtonChoice
        {
            CREATE = 0,
            EDIT
        };
        enum Screen
        {
            TDASH = 0,
            TEDIT
        };

        private static void BinarySerializeCard(Card card, string filename)
        {

            using (FileStream str = File.Create(filename))
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(str, card);
                str.Close();
            }
        }

        public Card BinaryDeserializeCard(string filename)
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

            catch (ArgumentException e)
            {
                MessageBox.Show(e.Message);

            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("Please open a card first through the Card List");
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

        //Dashboard constructor
        public CreateCardStudent(string filename, string usr, DashboardStudent dT, EditCardsStudent eT)
        {
            InitializeComponent();
            myInkOverlays[FRONT] = new InkOverlay(frontPanel.Handle);
            myInkOverlays[FRONT].Enabled = true;

            myInkOverlays[BACK] = new InkOverlay(BackPanel.Handle);
            myInkOverlays[BACK].Enabled = true;

            currentCard = new Card();
            user = usr;
            dashTeach = dT;
            edTeach = eT;
            saveCards = "C:\\Cards\\Student Cards\\";
            edTeach = new EditCardsStudent("", user, dashTeach);
            cardNames = new List<string> { };
            currentScreen = Screen.TDASH;
            currentMode = Mode.ADD;
        }

        //Edit Card Button Constructor
        public CreateCardStudent(Card crd,string usr,DashboardStudent dT, List<string> cardN, EditCardsStudent eT)
        {
            InitializeComponent();
            myInkOverlays[FRONT] = new InkOverlay(frontPanel.Handle);
            myInkOverlays[FRONT].Enabled = true;

            myInkOverlays[BACK] = new InkOverlay(BackPanel.Handle);
            myInkOverlays[BACK].Enabled = true;

            user = usr;
            currentCard = crd;
            edTeach = eT;
            dashTeach = dT;
            LoadCard(crd);
            cardNames = new List<string> { };
            for (int i = 0; i < cardN.Count; i++)
                cardNames.Insert(i, cardN[i]);
            saveCards = "C:\\Cards\\Student Cards\\";
            currentBChoice = ButtonChoice.EDIT;
            currentScreen = Screen.TEDIT;
        }

        //Create Card Button Constructor
        public CreateCardStudent(string usr, EditCardsStudent eT, DashboardStudent dT, List<string> cardN)
        {
            InitializeComponent();
            myInkOverlays[FRONT] = new InkOverlay(frontPanel.Handle);
            myInkOverlays[FRONT].Enabled = true;

            myInkOverlays[BACK] = new InkOverlay(BackPanel.Handle);
            myInkOverlays[BACK].Enabled = true;

            currentCard = new Card();
            user = usr;
            edTeach = eT;
            dashTeach = dT;
            cardNames = new List<string> { };
            for (int i = 0; i < cardN.Count; i++)
                cardNames.Insert(i, cardN[i]);
            saveCards = "C:\\Cards\\Student Cards\\";

            currentBChoice = ButtonChoice.CREATE;
            currentScreen = Screen.TEDIT;
        }

        private void LoadCard(Card currentCard)
        {
            try
            {
                myInkOverlays[FRONT].Enabled = false;
                myInkOverlays[FRONT].Ink.Dispose();
                myInkOverlays[FRONT].Ink = new Ink();
                myInkOverlays[FRONT].Ink.Load(currentCard.frontInk);
                myInkOverlays[FRONT].Enabled = true;

                myInkOverlays[BACK].Enabled = false;
                myInkOverlays[BACK].Ink.Dispose();
                myInkOverlays[BACK].Ink = new Ink();
                myInkOverlays[BACK].Ink.Load(currentCard.backInk);
                myInkOverlays[BACK].Enabled = true;
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Please retry opening.  If the problem persists, feel free to contact the developers.\nThe file may be corrupt or you may need to choose a card first.", "Argument Exception");
                return;
            }
            string labelText = "";
            for (int i = 0; i < currentCard.standards.Length; i++)
            {
                if (currentCard.standards[i] != "")
                {
                    labelText = labelText + currentCard.standards[i] + "\n";
                }
            }
            StandardsL.Text = labelText;

            DifficultyL.Text = currentCard.diff;
            gradeL.Text = currentCard.grade;
            GradeableCB.Checked = currentCard.gradeable;
        }

        public void getfileName(string fName)
        {

            file = fName;
            //MessageBox.Show(file);
            Card card = BinaryDeserializeCard(file);
        }
        public void openCardB_Click(object sender, EventArgs e)
        {
            cl = new CardList(this);
            cl.Show();
            /*string[] text = File.ReadAllLines(FILE_NAME);
            if (text.Contains(""))
            {
                MessageBox.Show("Please open a card first");

            }
            Card currentCard = BinaryDeserializeCard(text[0]);
              */
            // Card card = openWF.card;

            //FrontPanel.BackgroundImage = card.frontImage;
            //front.Enabled = false;
            //back.Enabled = false;
            
        }


        private void saveCardB_Click(object sender, EventArgs e)
        {

            //Card currentCard = new Card();
            try
            {
                currentCard.frontInk = myInkOverlays[FRONT].Ink.Save(PersistenceFormat.InkSerializedFormat, CompressionMode.Maximum);
                currentCard.backInk = myInkOverlays[BACK].Ink.Save(PersistenceFormat.InkSerializedFormat, CompressionMode.Maximum);
            }
            catch (NullReferenceException)
            {

            }

            for (int i = 0; i < inkIndexFront; i++)
            {
                currentCard.frontInk = FrontSavedStrokes[i].Ink.Save(PersistenceFormat.InkSerializedFormat, CompressionMode.Maximum);
            }

            for (int i = 0; i < inkIndexBack; i++)
            {
                currentCard.backInk = BackSavedStrokes[i].Ink.Save(PersistenceFormat.InkSerializedFormat, CompressionMode.Maximum);
            }

            /*if (DifficultyL.Text == "Difficulty" || StandardsL.Text == "Standards" || gradeL.Text == "Grade")
            {
                currentCard.diff = add.difficulty();
                currentCard.grade = add.grade();
                currentCard.standards = add.standards();
                currentCard.gradeable = GradeableCB.Checked;

                
                    if (currentCard.grade != "")
                    {
                        MessageBox.Show(currentCard.grade);
                    }
                

                for (int i = 0; i < currentCard.standards.Length; i++)
                {
                    if (currentCard.standards[i] != "")
                    {
                        MessageBox.Show(currentCard.standards[i]);
                    }
                }

                for (int i = 0; i < add.stan.Length; i++)
                {
                    if (add.stan[i] != "")
                    {
                        currentCard.cardname = currentCard.standards[i] + ", " + currentCard.diff + ", " + DateTime.Now.ToString("hh mm tt");
                    }
                }
            }

                                   
                BinarySerializeCard(currentCard, "C:\\Users\\Radhir.RADRAV2\\Desktop\\Cards\\Created Cards\\" + currentCard.cardname + ".cd");
                MessageBox.Show("C:\\Users\\Radhir.RADRAV2\\Desktop\\Cards\\Created Cards\\" + currentCard.cardname + ".cd");
                MessageBox.Show("Card has been saved.");*/
            //MessageBox.Show(GradeableCB.Checked.ToString(), "CheckBox");
            //MessageBox.Show(currentCard.gradeable.ToString(), "Gradeable");

            /*string stan = "";

            try
            {
                NullReferenceException ex = new NullReferenceException();

                if (currentCard.grade != "")
                    grade = currentCard.grade;
                else
                    throw ex;

                if(currentCard.diff != "")
                    diff = currentCard.diff;
                else
                    throw ex;

                bool stansHasValues = false;
                stans = new string[15];
                for (int i = 0; i < currentCard.standards.Length; i++)
                {
                    stans[i] = currentCard.standards[i];
                    if(stans[i] != "")
                        stansHasValues = true;
                }
                if(!stansHasValues)
                    throw ex;
            }

            catch (NullReferenceException)
            {

                try
                {
                    currentCard.gradeable = true;
                    currentCard.gradeable = GradeableCB.Checked;
                }
                catch (NullReferenceException)
                {
                    MessageBox.Show("An error has occured.  Please try again.\nIf this problem persists, please restart the program.", "Null Reference Exception");
                    return;
                }
                

                if (currentCard.diff == "")
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
                if (currentCard.grade == "")
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
                for (int i = 0; i < currentCard.standards.Length; i++)
                    if (currentCard.standards[i] != "")
                    {
                        stanHasValues = true;
                        break;
                    }
                if (stanHasValues)
                {
                    try
                    {
                        currentCard.standards = add.standards();



                        for (int i = 0; i < currentCard.standards.Length; i++)
                        {
                            try
                            {
                                stan = stan + currentCard.standards[i].Substring(0, 5) + ", ";
                            }
                            catch (ArgumentOutOfRangeException)
                            { }
                        }
                    }

                    catch (ArgumentException)
                    {
                        MessageBox.Show("Please choose at least one standard for this card.");
                        return;
                    }
                }
            }*/
            if (currentCard.cardname == "")
            {
                currentCard.cardname = user + ", " + DateTime.Now.ToString("hh mm tt");
            }

            //MessageBox.Show(saveCards + currentCard.cardname + ".cd");
            BinarySerializeCard(currentCard, saveCards + currentCard.cardname + ".cd");


            
            
            /*DialogResult dr = MessageBox.Show("Would you like to insert this card to a deck?","Save Card", MessageBoxButtons.YesNo);

            if (dr == DialogResult.Yes)
            {
                cardNames.Add(currentCard.cardname);
                //edTeach.getCards(cardNames);
                edTeach.getAddCard(saveCards + currentCard.cardname + ".cd");
                this.Hide();
                edTeach.Show();
            }*/

            currentCard = new Card();
            myInkOverlays[FRONT].Ink.DeleteStrokes();
            myInkOverlays[BACK].Ink.DeleteStrokes();
            gradeL.Text = "Grade";
            DifficultyL.Text = "Difficulty";
            StandardsL.Text = "Standards";
            frontPanel.Refresh();
            BackPanel.Refresh();

        }




        private void clearFrontB_Click(object sender, EventArgs e)
        {
            myInkOverlays[FRONT].Ink.DeleteStrokes();
            frontPanel.Refresh();
        }

        private void clearBackB_Click(object sender, EventArgs e)
        {
            myInkOverlays[BACK].Ink.DeleteStrokes();
            BackPanel.Refresh();
        }

        bool ink = true;
        private void toggleButton_Click(object sender, EventArgs e)
        {
            ink = !ink;
            if (!ink)
            {
                myInkOverlays[FRONT].EditingMode = InkOverlayEditingMode.Delete;
                myInkOverlays[BACK].EditingMode = myInkOverlays[FRONT].EditingMode;
                toggleButton.Text = "Toggle Ink";
                toggleButton.Image = new Bitmap(Image.FromFile(Environment.CurrentDirectory + "\\eraser.bmp"));
            }

            if (ink)
            {
                myInkOverlays[FRONT].EditingMode = InkOverlayEditingMode.Ink;
                myInkOverlays[BACK].EditingMode = myInkOverlays[FRONT].EditingMode;
                toggleButton.Text = "Toggle Erase";
                toggleButton.Image = new Bitmap(Image.FromFile(Environment.CurrentDirectory + "\\pen.bmp"));
            }
        }

        private void addCategoriesB_Click(object sender, EventArgs e)
        {
            add = new Form1(this);
            add.Show();
        }

        private void createNewCardButton_Click(object sender, EventArgs e)
        {
            myInkOverlays[FRONT].Enabled = false;
            myInkOverlays[BACK].Enabled = false;
            myInkOverlays[FRONT].Ink.DeleteStrokes();
            myInkOverlays[BACK].Ink.DeleteStrokes();
            myInkOverlays[FRONT].Enabled = true;
            myInkOverlays[BACK].Enabled = true;
            frontPanel.Refresh();
            BackPanel.Refresh();
            DifficultyL.Text = "Difficulty";
            StandardsL.Text = "Standards";
            gradeL.Text = "Grade";

            Card currentCard = new Card();
            currentCard.diff = "";
            currentCard.standards = new string[15];
            currentCard.grade = "";

        }

        /*private void button1_Click(object sender, EventArgs e)
        {
            cl = new CardList();
            cl.Show();
        }*/

        private void button1_Click_1(object sender, EventArgs e)
        {
            //MessageBox.Show("Hello");
            if (File.Exists(FILE_NAME))
            {
                File.Delete(FILE_NAME);
            }

        }

        private void homeB_Click(object sender, EventArgs e)
        {
            bool cardSaved = false;
            Strokes frontCollection = myInkOverlays[FRONT].Ink.Strokes;
            Strokes backCollection = myInkOverlays[BACK].Ink.Strokes;
            if (frontCollection.Count > 0 || backCollection.Count > 0)
            {
                DialogResult dr = MessageBox.Show("If you continue, this card will not be here when you come back.\nWould you like to save before exiting?", "Save or Exit", MessageBoxButtons.YesNoCancel);
                if (dr == System.Windows.Forms.DialogResult.Cancel)
                    return;
                if (dr == System.Windows.Forms.DialogResult.Yes)
                {
                    cardSaved = saveCardGoingHome();
                    if (!cardSaved)
                    {
                        MessageBox.Show("Card could not be saved.  Please make sure you have ink on the front and back of the card.\nThen please, try again.");
                        return;
                    }
                }
            }

            //this.Hide();
            dashTeach.Show();
            this.Dispose();
        }

        private bool saveCardGoingHome()
        {
            bool cardHasSaved = false;
            //Card currentCard = new Card();
            try
            {
                currentCard.frontInk = myInkOverlays[FRONT].Ink.Save(PersistenceFormat.InkSerializedFormat, CompressionMode.Maximum);
                currentCard.backInk = myInkOverlays[BACK].Ink.Save(PersistenceFormat.InkSerializedFormat, CompressionMode.Maximum);
            }
            catch (NullReferenceException)
            {

            }

            for (int i = 0; i < inkIndexFront; i++)
            {
                currentCard.frontInk = FrontSavedStrokes[i].Ink.Save(PersistenceFormat.InkSerializedFormat, CompressionMode.Maximum);
            }

            for (int i = 0; i < inkIndexBack; i++)
            {
                currentCard.backInk = BackSavedStrokes[i].Ink.Save(PersistenceFormat.InkSerializedFormat, CompressionMode.Maximum);
            }

            /*if (DifficultyL.Text == "Difficulty" || StandardsL.Text == "Standards" || gradeL.Text == "Grade")
            {
                currentCard.diff = add.difficulty();
                currentCard.grade = add.grade();
                currentCard.standards = add.standards();
                currentCard.gradeable = GradeableCB.Checked;

                
                    if (currentCard.grade != "")
                    {
                        MessageBox.Show(currentCard.grade);
                    }
                

                for (int i = 0; i < currentCard.standards.Length; i++)
                {
                    if (currentCard.standards[i] != "")
                    {
                        MessageBox.Show(currentCard.standards[i]);
                    }
                }

                for (int i = 0; i < add.stan.Length; i++)
                {
                    if (add.stan[i] != "")
                    {
                        currentCard.cardname = currentCard.standards[i] + ", " + currentCard.diff + ", " + DateTime.Now.ToString("hh mm tt");
                    }
                }
            }

                                   
                BinarySerializeCard(currentCard, "C:\\Users\\Radhir.RADRAV2\\Desktop\\Cards\\Created Cards\\" + currentCard.cardname + ".cd");
                MessageBox.Show("C:\\Users\\Radhir.RADRAV2\\Desktop\\Cards\\Created Cards\\" + currentCard.cardname + ".cd");
                MessageBox.Show("Card has been saved.");*/
            //MessageBox.Show(GradeableCB.Checked.ToString(), "CheckBox");
            //MessageBox.Show(currentCard.gradeable.ToString(), "Gradeable");

            /*string stan = "";

            try
            {
                NullReferenceException ex = new NullReferenceException();

                if (currentCard.grade != "")
                    grade = currentCard.grade;
                else
                    throw ex;

                if (currentCard.diff != "")
                    diff = currentCard.diff;
                else
                    throw ex;

                bool stansHasValues = false;
                stans = new string[15];
                for (int i = 0; i < currentCard.standards.Length; i++)
                {
                    stans[i] = currentCard.standards[i];
                    if (stans[i] != "")
                        stansHasValues = true;
                }
                if (!stansHasValues)
                    throw ex;
            }

            catch (NullReferenceException)
            {

                try
                {
                    currentCard.gradeable = true;
                    currentCard.gradeable = GradeableCB.Checked;
                }
                catch (NullReferenceException)
                {
                    MessageBox.Show("An error has occured.  Please try again.\nIf this problem persists, please restart the program.", "Null Reference Exception");
                    return cardHasSaved;
                }


                if (currentCard.diff == "")
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
                        return cardHasSaved;
                    }
                }
                if (currentCard.grade == "")
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
                        return cardHasSaved;
                    }
                }

                bool stanHasValues = false;
                for (int i = 0; i < currentCard.standards.Length; i++)
                    if (currentCard.standards[i] != "")
                    {
                        stanHasValues = true;
                        break;
                    }
                if (stanHasValues)
                {
                    try
                    {
                        currentCard.standards = add.standards();



                        for (int i = 0; i < currentCard.standards.Length; i++)
                        {
                            try
                            {
                                stan = stan + currentCard.standards[i].Substring(0, 5) + ", ";
                            }
                            catch (ArgumentOutOfRangeException)
                            { }
                        }
                    }

                    catch (ArgumentException)
                    {
                        MessageBox.Show("Please choose at least one standard for this card.");
                        return cardHasSaved;
                    }
                }
            }*/
            if (currentCard.cardname == "")
            {
                //MessageBox.Show("Generating name for card...");
                if (GradeableCB.Checked)
                { currentCard.cardname = user + ", " + DateTime.Now.ToString("hh mm tt"); }
                else
                { currentCard.cardname = user + ", " + DateTime.Now.ToString("hh mm tt"); }

            }

            MessageBox.Show(saveCards + currentCard.cardname + ".cd");
            BinarySerializeCard(currentCard, saveCards + currentCard.cardname + ".cd");
            cardHasSaved = true;
            return cardHasSaved;



            /*DialogResult dr = MessageBox.Show("Would you like to insert this card to a deck?", "Save Card", MessageBoxButtons.YesNo);

            if (dr == DialogResult.Yes)
            {
                cardNames.Add(currentCard.cardname);
                //edTeach.getCards(cardNames);
                edTeach.getAddCard(saveCards + currentCard.cardname + ".cd");
                this.Hide();
                edTeach.Show();
            }

            currentCard = new Card();
            myInkOverlays[FRONT].Ink.DeleteStrokes();
            myInkOverlays[BACK].Ink.DeleteStrokes();
            gradeL.Text = "Grade";
            DifficultyL.Text = "Difficulty";
            StandardsL.Text = "Standards";
            frontPanel.Refresh();
            BackPanel.Refresh();*/
        }

        public void getCard(string cardReference)
        {
            currentCard = new Card();
            currentCard = BinaryDeserializeCard(cardReference);



            try
            {
                myInkOverlays[FRONT].Enabled = false;
                myInkOverlays[FRONT].Ink.Dispose();
                myInkOverlays[FRONT].Ink = new Ink();
                myInkOverlays[FRONT].Ink.Load(currentCard.frontInk);
                myInkOverlays[FRONT].Enabled = true;

                myInkOverlays[BACK].Enabled = false;
                myInkOverlays[BACK].Ink.Dispose();
                myInkOverlays[BACK].Ink = new Ink();
                myInkOverlays[BACK].Ink.Load(currentCard.backInk);
                myInkOverlays[BACK].Enabled = true;
            }
            catch (ArgumentException eA)
            {
                MessageBox.Show(eA.Message);
            }

            catch (NullReferenceException eN)
            {
                MessageBox.Show(eN.Message);
            }
            frontPanel.Refresh();
            BackPanel.Refresh();

            try
            {
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
                    gradeText = gradeText + currentCard.grade + "\n";
                //globalLabelText = labelText;

                //}

                StandardsL.Text = labelText;
                DifficultyL.Text = currentCard.diff;
                gradeL.Text = gradeText;
                GradeableCB.Checked = currentCard.gradeable;
            }

            catch (NullReferenceException eN)
            {
                MessageBox.Show(eN.Message);
            }


            //globalLabelText = finalGlobalLabelText;


            //saveCurrentButton_Click(null, null);

            myInkOverlays[FRONT].Enabled = true;
            myInkOverlays[BACK].Enabled = true;
            //saveCardB.Enabled = false;
        }

        private void colorB_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            DrawingAttributes da = new DrawingAttributes();
            //colorB.BackColor = colorDialog1.Color;
            da.Color = colorDialog1.Color;
            BackColor = colorDialog1.Color;
            myInkOverlays[FRONT].DefaultDrawingAttributes = da;
            myInkOverlays[BACK].DefaultDrawingAttributes = da;
        }

        private void CreateCardStudent_Load(object sender, EventArgs e)
        {

        }
    }        
 }

