using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace WindowsFormsApplication1
{
    public partial class AutoMath : UserControl
    {
        public AutoMath()
        {
            InitializeComponent();
        }

        Random random = new Random();
        int num1, num2;
        List<Card> cardList = new List<Card>();
        List<String> cardNames = new List<String>();
        Card currentCard;
        DashboardTeacher td;
        SaveDeck sd;
        string user;
        string autoMathCard = "C:\\Cards\\Created Cards\\";
        string autoMathDeck = "C:\\Cards\\Created Decks\\";

        public AutoMath(EditCardsTeacher td, string usr)
        {
            InitializeComponent();
            user = usr;
        }

        public int Random()
        {
            int diff = difficultySlider.Value;

            if (diff == 0)
            {
                return random.Next(1, 9);
            }

            else if (diff == 1)
            {
                return random.Next(10, 99);
            }

            else if (diff == 2)
            {
                return random.Next(100, 999);
            }

            return 0;

        }

        private void buttonClicks(object sender, EventArgs e)
        {

        }


        private void generateButton_Click(object sender, EventArgs e)
        {
            num1 = Random();
            num2 = Random();

            if (numericUpDown1.Value == 0)
            {
                if (addP.BorderStyle == BorderStyle.Fixed3D)
                {
                    int sum = num1 + num2;
                    currentCard = new Card();
                    currentCard.num1 = num1;
                    currentCard.num2 = num2;
                    currentCard.answer = sum;
                    currentCard.operate = "+";
                    BinarySerializeCard(currentCard, "C:\\Cards\\Created Cards\\AutoMath\\mathTrial.cd");
                }

                if (subP.BorderStyle == BorderStyle.Fixed3D)
                {
                    int difference = num1 - num2;
                    currentCard = new Card();
                    currentCard.num1 = num1;
                    currentCard.num2 = num2;
                    currentCard.answer = difference;
                    currentCard.operate = "-";
                    BinarySerializeCard(currentCard, "C:\\Cards\\Created Cards\\AutoMath\\mathTrial.cd");
                }

                if (multP.BorderStyle == BorderStyle.Fixed3D)
                {
                    int result = num1 * num2;
                    currentCard = new Card();
                    currentCard.num1 = num1;
                    currentCard.num2 = num2;
                    currentCard.answer = result;
                    currentCard.operate = "*";
                    BinarySerializeCard(currentCard, "C:\\Cards\\Created Cards\\AutoMath\\mathTrial.cd");
                }

                if (divideP.BorderStyle == BorderStyle.Fixed3D)
                {
                    int quotient = num1 / num2;
                    currentCard = new Card();
                    currentCard.num1 = num1;
                    currentCard.num2 = num2;
                    currentCard.answer = quotient;
                    currentCard.operate = "/";
                    BinarySerializeCard(currentCard, "C:\\Cards\\Created Cards\\AutoMath\\mathTrial.cd");
                }
            }

            else
            {
                if (addP.BorderStyle == BorderStyle.Fixed3D)
                {
                    for (int i = 1; i <= numericUpDown1.Value; i++)
                    {
                        num1 = Random();
                        num2 = Random();

                        currentCard = new Card();
                        int sum = num1 + num2;
                        currentCard.num1 = num1;
                        currentCard.num2 = num2;
                        currentCard.answer = sum;
                        currentCard.operate = "+";
                        currentCard.cardname = "Add" + i;
                        currentCard.autoMathCard = true;
                        BinarySerializeCard(currentCard, "C:\\Cards\\Created Cards\\AutoMath\\Add" + i + ".cd");
                        cardList.Add(currentCard);
                        cardNames.Add(currentCard.cardname);
                    }
                    sd = new SaveDeck(user, cardNames, this);
                    sd.Show();
                    //BinarySerialize(cardList, autoMathDeck + "mathTrial.fc");
                    //MessageBox.Show("Card Count:" + cardList.Count);
                }

                if (subP.BorderStyle == BorderStyle.Fixed3D)
                {
                    for (int i = 1; i <= numericUpDown1.Value; i++)
                    {
                        num1 = Random();
                        num2 = Random();
                        currentCard = new Card();
                        int difference = num1 - num2;
                        currentCard.num1 = num1;
                        currentCard.num2 = num2;
                        currentCard.answer = difference;
                        currentCard.operate = "-";
                        currentCard.cardname = "Subtract" + i;
                        currentCard.autoMathCard = true;
                        BinarySerializeCard(currentCard, "C:\\Cards\\Created Cards\\AutoMath\\Subtract" + i + ".cd");
                        cardList.Add(currentCard);
                        cardNames.Add(currentCard.cardname);
                    }
                    //BinarySerialize(cardList, autoMathDeck + "mathTrial.fc");
                    sd = new SaveDeck(user, cardNames, this);
                    sd.Show();
                }

                if (multP.BorderStyle == BorderStyle.Fixed3D)
                {
                    for (int i = 1; i <= numericUpDown1.Value; i++)
                    {
                        num1 = Random();
                        num2 = Random();
                        currentCard = new Card();
                        int result = num1 * num2;
                        currentCard.num1 = num1;
                        currentCard.num2 = num2;
                        currentCard.answer = result;
                        currentCard.operate = "*";
                        currentCard.cardname = "Mult" + i;
                        currentCard.autoMathCard = true;
                        BinarySerializeCard(currentCard, "C:\\Cards\\Created Cards\\AutoMath\\Mult" + i + ".cd");
                        cardList.Add(currentCard);
                        cardNames.Add(currentCard.cardname);
                    }
                    //BinarySerialize(cardList, autoMathDeck + "mathTrial.fc");
                    sd = new SaveDeck(user, cardNames, this);
                    sd.Show();
                }

                if (divideP.BorderStyle == BorderStyle.Fixed3D)
                {
                    for (int i = 1; i <= numericUpDown1.Value; i++)
                    {
                        num1 = Random();
                        num2 = Random();
                        currentCard = new Card();
                        int quotient = num1 / num2;
                        currentCard.num1 = num1;
                        currentCard.num2 = num2;
                        currentCard.answer = quotient;
                        currentCard.operate = "/";
                        currentCard.cardname = "Div" + i;
                        currentCard.autoMathCard = true;
                        BinarySerializeCard(currentCard, "C:\\Cards\\Created Cards\\AutoMath\\Div" + i + ".cd");
                        cardList.Add(currentCard);
                        cardNames.Add(currentCard.cardname);
                    }
                    //BinarySerialize(cardList, autoMathDeck + "mathTrial.fc");
                    sd = new SaveDeck(user, cardNames, this);
                    sd.Show();
                }
            }

        }

        private static void BinarySerialize(List<Card> list, string filename)
        {
            using (FileStream str = File.Create(filename))
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(str, list);
            }
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

        private int addButtonClick = 0;
        private bool addButtonClicked = false;
        private void addButton_Click(object sender, EventArgs e)
        {
            addButtonClick++;

            if (addButtonClick % 2 == 1)
            {
                addButtonClicked = true;
                addP.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                subP.Enabled = false;
                multP.Enabled = false;
                divideP.Enabled = false;
            }
            if (addButtonClick % 2 == 0)
            {
                addButtonClicked = false;
                addP.BorderStyle = System.Windows.Forms.BorderStyle.None;
                subP.Enabled = true;
                multP.Enabled = true;
                divideP.Enabled = true;
            }

        }

        private int subButtonClick = 0;
        private bool subBClicked = false;
        private void subButton_Click(object sender, EventArgs e)
        {
            subButtonClick++;

            if (subButtonClick % 2 != 0)
            {
                subBClicked = true;
                subP.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                addP.Enabled = false;
                multP.Enabled = false;
                divideP.Enabled = false;
            }
            if (subButtonClick % 2 == 0)
            {
                subBClicked = false;
                subP.BorderStyle = System.Windows.Forms.BorderStyle.None;
                addP.Enabled = true;
                multP.Enabled = true;
                divideP.Enabled = true;
            }
        }

        private int multButtonClick = 0;
        private bool multBClicked = false;
        private void multButton_Click(object sender, EventArgs e)
        {
            multButtonClick++;

            if (multButtonClick % 2 != 0)
            {
                multBClicked = true;
                multP.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                addP.Enabled = false;
                subP.Enabled = false;
                divideP.Enabled = false;
            }
            if (multButtonClick % 2 == 0)
            {
                multBClicked = false;
                multP.BorderStyle = System.Windows.Forms.BorderStyle.None;
                addP.Enabled = true;
                subP.Enabled = true;
                divideP.Enabled = true;
            }
        }

        private int divButtonClick = 0;
        private bool divBClicked = false;
        private void divButton_Click(object sender, EventArgs e)
        {
            divButtonClick++;

            if (divButtonClick % 2 != 0)
            {
                divBClicked = true;
                divideP.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                subP.Enabled = false;
                multP.Enabled = false;
                addP.Enabled = false;

            }

            if (divButtonClick % 2 == 0)
            {
                divBClicked = false;
                divideP.BorderStyle = System.Windows.Forms.BorderStyle.None;
                subP.Enabled = true;
                multP.Enabled = true;
                addP.Enabled = true;
            }
        }

        private void homeP_Click(object sender, EventArgs e)
        {
            td = new DashboardTeacher(user);
            this.Hide();
            Global.form.Controls.Add(td);
        }

       
    }
}
