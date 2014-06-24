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
using AxWMPLib;
using System.Drawing.Imaging;
using System.Net;

namespace WindowsFormsApplication1
{
    public partial class CreateCard : UserControl
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
        InkOverlay check = new InkOverlay();
        private int inkIndexFront = 0;
        private int inkIndexBack = 0;
        private CardList cl;
        private cardFrom cFrom;
        private const string filename = "C:\\Users\\Kathy\\Documents\\Ben\\C#\\Save Files\\filename.txt";
        int fileKeepTrack = 0;
        string FILE_NAME = "C:\\Cards\\Categories.txt";

        Form1 add;
        public string file;
        string user;
        DashboardTeacher dashTeach;
        EditCardsTeacher edTeach;
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
        enum cardFrom
        {
            teacher = 0,
            student
        };

        private void BinarySerializeCard(Card card, string filename)
        {

            using (FileStream str = File.Create(filename))
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(str, card);
                str.Close();
            }

            if (MessageBox.Show("Would you like to save this card in the cloud?", "Uploading", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                uploadCard(filename);
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

        private void uploadCard(string cardPath)
        {

            WebClient client = new WebClient();
            client.Credentials = new NetworkCredential("flashcard", "flashcard");

            Uri file = new Uri(cardPath);
            string[] path = file.LocalPath.Split('\\');//splits the string into each folder/file name so I can use the file name
            //MessageBox.Show(path[path.Length - 1]);//shows the files string
            string cardName = path[path.Length - 1];

            Uri address = new Uri(@"ftp://www.benkenawell.net/Cards/" + cardName);//sends the file to ftp://benkenawell.net with the given name.
            try
            {
                byte[] arrReturn = client.UploadFile(address, null, cardPath);

                client.DownloadFile(@"ftp://benkenawell.net/Cards/cardNames.txt", @"C:\Cards\temp\cardNames.txt");

                StreamReader fileReader = new StreamReader(@"C:\Cards\temp\cardNames.txt", true);

                string text = "";
                while (true)
                {
                    if (text.Equals(cardName))
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

                using (System.IO.StreamWriter fileWriter = new System.IO.StreamWriter(@"C:\Cards\temp\cardNames.txt", true))
                {

                   
                    fileWriter.WriteLine(cardName);
                    fileWriter.Close();

                }

                client.UploadFile(@"ftp://benkenawell.net/Cards/cardNames.txt", @"C:\Cards\temp\cardNames.txt");
                File.Delete(@"C:\Cards\temp\cardNames.txt");
            }
            catch (Exception e1)
            {
                MessageBox.Show(cardPath + "\n" + cardName + "\n" + e1.ToString());
            }

            Refresh();
            
        }

        //Dashboard constructor
        public CreateCard(string filename, string usr, DashboardTeacher dT, EditCardsTeacher eT)
        {
            InitializeComponent();

            myInkOverlays[FRONT] = new InkOverlay(frontPanel.Handle);
            myInkOverlays[FRONT].Enabled = true;

            myInkOverlays[BACK] = new InkOverlay(BackPanel.Handle);
            myInkOverlays[BACK].Enabled = true;

            check = myInkOverlays[BACK];
            check.Stroke += new InkCollectorStrokeEventHandler(check_Stroke);

            currentCard = new Card();
            user = usr;
            dashTeach = dT;
            edTeach = eT;
            saveCards = "C:\\Cards\\Created Cards\\";
            edTeach = new EditCardsTeacher("", user, dashTeach);
            cardNames = new List<string> { };
            currentScreen = Screen.TDASH;
            currentMode = Mode.ADD;
        }

        private void check_Stroke(object sender, InkCollectorStrokeEventArgs e)
        {
            label1.Text = "Text: " + check.Ink.Strokes.ToString();
        }

        //Edit Card Button Constructor
        public CreateCard(Card crd, string usr, DashboardTeacher dT, List<string> cardN, EditCardsTeacher eT)
        {
            InitializeComponent();
            myInkOverlays[FRONT] = new InkOverlay(frontPanel.Handle);
            myInkOverlays[FRONT].Enabled = true;

            myInkOverlays[BACK] = new InkOverlay(BackPanel.Handle);
            myInkOverlays[BACK].Enabled = true;

            check = myInkOverlays[BACK];
            check.Stroke += new InkCollectorStrokeEventHandler(check_Stroke);

            user = usr;
            currentCard = crd;
            edTeach = eT;
            dashTeach = dT;
            LoadCard(crd);
            cardNames = new List<string> { };
            for (int i = 0; i < cardN.Count; i++)
                cardNames.Insert(i, cardN[i]);
            homeP.Enabled = false;
            saveCards = "C:\\Cards\\Created Cards\\";
            currentBChoice = ButtonChoice.EDIT;
            currentScreen = Screen.TEDIT;
        }

        //Create Card Button Constructor
        public CreateCard(string usr, EditCardsTeacher eT, DashboardTeacher dT, List<string> cardN)
        {
            InitializeComponent();
            myInkOverlays[FRONT] = new InkOverlay(frontPanel.Handle);
            myInkOverlays[FRONT].Enabled = true;

            myInkOverlays[BACK] = new InkOverlay(BackPanel.Handle);
            myInkOverlays[BACK].Enabled = true;

            check = myInkOverlays[BACK];
            check.Stroke += new InkCollectorStrokeEventHandler(check_Stroke);

            currentCard = new Card();
            user = usr;
            edTeach = eT;
            dashTeach = dT;
            cardNames = new List<string> { };
            for (int i = 0; i < cardN.Count; i++)
            {
                cardNames.Insert(i, cardN[i]);
                //MessageBox.Show(cardNames[i]);
            }
            saveCards = "C:\\Cards\\Created Cards\\";
            homeP.Enabled = false;
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
            cFrom = cardFrom.teacher;


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

            string stan = "";

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
                string[] text = File.ReadAllLines(FILE_NAME);
                stans = new string[text.Length];
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
            }
            if (cFrom == cardFrom.teacher)
                if (currentCard.cardname == "")
                {
                    //MessageBox.Show("Generating name for card...");
                    if (GradeableCB.Checked)
                    { currentCard.cardname = user + ", " + stan + currentCard.diff + ", " + DateTime.Now.ToString("hh mm tt") + ", computer graded"; }
                    else
                    { currentCard.cardname = user + ", " + stan + currentCard.diff + ", " + DateTime.Now.ToString("hh mm tt") + ", teacher graded"; }

                }
            if (cFrom == cardFrom.student)
            {
                if (GradeableCB.Checked)
                { currentCard.cardname = user + ", " + stan + currentCard.diff + ", " + DateTime.Now.ToString("hh mm tt") + ", computer graded"; }
                else
                { currentCard.cardname = user + ", " + stan + currentCard.diff + ", " + DateTime.Now.ToString("hh mm tt") + ", teacher graded"; }
            }

            //MessageBox.Show(saveCards + currentCard.cardname + ".cd");
            BinarySerializeCard(currentCard, saveCards + currentCard.cardname + ".cd");




            DialogResult dr = MessageBox.Show("Would you like to insert this card into a deck?", "Save Card", MessageBoxButtons.YesNo);

            if (dr == DialogResult.Yes)
            {
                cardNames.Add(currentCard.cardname);
                //edTeach.getCards(cardNames);
                edTeach.getAddCard(saveCards + currentCard.cardname + ".cd");
                edTeach = new EditCardsTeacher("", user, dashTeach,cardNames);
                this.Hide();
                //edTeach = new EditCardsTeacher("", user, dashTeach);
                Global.form.Controls.Add(edTeach);
                //edTeach.Show();
                this.Dispose();
            }

            currentCard = new Card();
            myInkOverlays[FRONT].Ink.DeleteStrokes();
            myInkOverlays[BACK].Ink.DeleteStrokes();
            gradeL.Text = "Grade";
            DifficultyL.Text = "Difficulty";
            StandardsL.Text = "Standards";
            pictureBox1.Image = null;
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
                toggleP.BackgroundImage = new Bitmap("C:\\Cards\\Images\\button.toggleerase.png");
                //toggleButton.Text = "Toggle Ink";
                //toggleButton.Image = new Bitmap(Image.FromFile(Environment.CurrentDirectory + "\\eraser.bmp"));
            }

            if (ink)
            {
                myInkOverlays[FRONT].EditingMode = InkOverlayEditingMode.Ink;
                myInkOverlays[BACK].EditingMode = myInkOverlays[FRONT].EditingMode;
                toggleP.BackgroundImage = new Bitmap("C:\\Cards\\Images\\button.toggleink.png");
                //toggleButton.Text = "Toggle Erase";
                //toggleButton.Image = new Bitmap(Image.FromFile(Environment.CurrentDirectory + "\\pen.bmp"));
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

            string[] text = File.ReadAllLines(FILE_NAME);
            Card currentCard = new Card();
            currentCard.diff = "";
            currentCard.standards = new string[text.Length];
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
                        MessageBox.Show("Card could not be saved.  Please make sure you have all categories changed.");
                        return;
                    }
                }
            }

            this.Hide();
            //Global.form.Controls.Add(dashTeach);
            dashTeach.Show();
            //this.Dispose();
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

            string stan = "";

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
                string[] text = File.ReadAllLines(FILE_NAME);
                stans = new string[text.Length];
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
            }
            if (currentCard.cardname == "")
            {
                //MessageBox.Show("Generating name for card...");
                if (GradeableCB.Checked)
                { currentCard.cardname = user + ", " + stan + currentCard.diff + ", " + DateTime.Now.ToString("hh mm tt") + ", computer graded"; }
                else
                { currentCard.cardname = user + ", " + stan + currentCard.diff + ", " + DateTime.Now.ToString("hh mm tt") + ", teacher graded"; }

            }

            //MessageBox.Show(saveCards + currentCard.cardname + ".cd");
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

        public void inkOverlays()
        {
            myInkOverlays[FRONT].Enabled = false;
            myInkOverlays[FRONT].Ink.Dispose();
            myInkOverlays[FRONT].Ink = new Ink();
            myInkOverlays[FRONT].Ink.Load(currentCard.frontInk);
            myInkOverlays[FRONT].Enabled = false;

            myInkOverlays[BACK].Enabled = false;
            myInkOverlays[BACK].Ink.Dispose();
            myInkOverlays[BACK].Ink = new Ink();
            myInkOverlays[BACK].Ink.Load(currentCard.backInk);
            myInkOverlays[BACK].Enabled = false;
        }

        public void getCard(string cardReference)
        {
            currentCard = new Card();
            currentCard = BinaryDeserializeCard(cardReference);
            //frontPanel.Controls.Clear();
            //BackPanel.Controls.Clear();
            if (currentCard.panelBackground != null)
            {

                pictureBox1.Enabled = true;
                pictureBox1.Visible = true;
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;              
                pictureBox1.Image = new Bitmap(currentCard.panelBackground);
                
            }



            if (cardReference.Contains("C:\\Cards\\Created Cards\\"))
            {

                if (cardReference.Contains("C:\\Cards\\Created Cards\\AutoMath\\"))
                {
                    Label question = new Label();
                    Label answer = new Label();

                    question.Size = new System.Drawing.Size(frontPanel.Height - 50, frontPanel.Width);
                    question.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold);
                    question.Text = currentCard.num1.ToString() + currentCard.operate.ToString() + currentCard.num2.ToString();
                    question.Location = new System.Drawing.Point((frontPanel.Width) / 4, (frontPanel.Height) / 4);

                    answer.Size = new System.Drawing.Size(BackPanel.Height - 50, BackPanel.Width);
                    answer.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold);
                    answer.Text = currentCard.answer.ToString();
                    answer.Location = new System.Drawing.Point((BackPanel.Width) / 4, (BackPanel.Height) / 4);

                    frontPanel.Controls.Add(question);
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

                try
                {

                    inkOverlays();
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
            }

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

        private void studentCardListB_Click(object sender, EventArgs e)
        {
            cl = new CardList(this, "hi");
            cl.Show();
            cFrom = cardFrom.student;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            DrawingAttributes da = new DrawingAttributes();
            colorP.BackColor = colorDialog1.Color;
            da.Color = colorDialog1.Color;
            //BackColor = colorDialog1.Color;
            myInkOverlays[FRONT].DefaultDrawingAttributes = da;
            myInkOverlays[BACK].DefaultDrawingAttributes = da;
        }

        private void CreateCard_Load(object sender, EventArgs e)
        {
            toggleP.BackgroundImage = new Bitmap("C:\\Cards\\Images\\button.toggleink.png");
        }

        private void addPic_Click(object sender, EventArgs e)
        {
            oF.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (oF.ShowDialog() == DialogResult.OK)
            {
                //Clears any controls (i.e. textboxes, labels, pictureboxes, etc) from the frontpanel
                //frontPanel.Controls.Clear();

                pictureBox1.Enabled = true;
                pictureBox1.Visible = true;

                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                //pictureBox1.InkEnabled = true;

                //Sets the Image property to the image in the filename selected
                pictureBox1.Image = new Bitmap(oF.FileName);

                //pictureBox1.EditingMode = InkOverlayEditingMode.Select;

                //Attaches the filepath to the card frontimage property so that the image is saved with the card
                
                //Adds the picturebox to the Panel to show up
                //frontPanel.Controls.Add(pictureBox1);

                //frontPanel.BackgroundImage = new Bitmap(oF.FileName);
                //Card.FitImage(frontPanel, new Bitmap(oF.FileName));
                currentCard.panelBackground = new Bitmap(oF.FileName);
            }
            oF.Dispose();

        }


        string audioLocation;

        private void audioP(object sender, EventArgs e)
        {

        }

        private void click_playaudio(object sender, EventArgs e)
        {
            if (currentCard.audioLocation != null)
            {

                try
                {
                    System.Media.SoundPlayer player = new System.Media.SoundPlayer();

                    player.SoundLocation = audioLocation;

                    player.Load();

                    player.PlaySync();



                }
                catch (Win32Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }

            
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

            }
        }

        private void picZoomPanel_Click(object sender, EventArgs e)
        {
            picZoomPanel.Visible = false;
            picZoomPanel.Enabled = false;
        }

           

    }
}
