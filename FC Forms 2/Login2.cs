using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using Microsoft.Ink;
using System.IO;
//using Npgsql;


namespace WindowsFormsApplication1
{
    public partial class Login2 : UserControl
    {
        //NpgsqlConnection npgConn = new NpgsqlConnection();
        

        OleDbConnection conn = new OleDbConnection();
        DashboardTeacher td;
        DashboardStudent sd;
        public string creater = "";
        TextBox usernameTB = new TextBox();
        TextBox passwordTB = new TextBox();
        InkOverlay usernameInk, passwordInk;
        private const int NoOfTries = 5;
        string cards, temp, saveCards, saveDecks, studentResults, saveStudentCards, toBeGraded, categories, environmentFilepath;
        string loginDB;
        //okay, so, what is the problem?
        //I need to get the value in the username textbox and set it to a variable
        //i then need to access that variable in another class with that value
        //that value goes to null, when accessed in the
        //creater doesnt hold the username textbox value though... then what does?
        //to get the text its usernameTB.Text go to gmail. i have certain questio
        //LoginUC lUC = new LoginUC();


        private void Login_Load(object sender, EventArgs e)
        {
            // creater = usernameTB.Text;

        }

        public Login2()
        {
            InitializeComponent();

            environmentFilepath = "C:";
            saveCards = environmentFilepath + "\\Cards\\Created Cards\\";
            saveDecks = environmentFilepath + "\\Cards\\Created Decks\\";

            cards = environmentFilepath + "\\Cards\\";
            //saveCards = "C:\\Cards\\Created Cards\\";
            //saveDecks = "C:\\Cards\\Created Decks\\";
            saveStudentCards = environmentFilepath + "\\Cards\\Student Cards\\";
            studentResults = environmentFilepath + "\\Cards\\Student Results\\";
            toBeGraded = environmentFilepath + "\\Cards\\toBeGraded";
            categories = environmentFilepath + "\\Cards\\Categories.txt";
            loginDB = environmentFilepath + "\\Cards\\Students.accdb";
            temp = environmentFilepath + "\\Cards\\temp\\";

            if (!Directory.Exists(cards))
            {
                Directory.CreateDirectory(cards);
            }

            if (!Directory.Exists(saveCards))
                Directory.CreateDirectory(saveCards);

            if (!Directory.Exists(saveStudentCards))
                Directory.CreateDirectory(saveStudentCards);

            if (!Directory.Exists(studentResults))
                Directory.CreateDirectory(studentResults);

            if (!Directory.Exists(saveDecks))
                Directory.CreateDirectory(saveDecks);

            if (!Directory.Exists(toBeGraded))
                Directory.CreateDirectory(toBeGraded);

            if(!Directory.Exists(temp))
                Directory.CreateDirectory(temp);

            if (!File.Exists(categories))
            {
                File.Create(categories);
            }



            usernameInk = new InkOverlay(usernameP.Handle);
            passwordInk = new InkOverlay(passwordP.Handle);

            usernameInk.Enabled = true;
            passwordInk.Enabled = true;

            usernameInk.Stroke += new InkCollectorStrokeEventHandler(usernameInk_Stroke);
            passwordInk.Stroke += new InkCollectorStrokeEventHandler(passwordInk_Stroke);
            /*try
            {
                
                if (lUC.key.itsEquals("Enter"))
                    loginB_Click(this, EventArgs.Empty);
            }
            catch (NullReferenceException e)
            {
                usernameTB.Text = e.Message;
            }*/
            /*passwordTB.KeyDown += (sender, args) =>
                {
                    if (args.KeyCode == Keys.Return)
                        loginB.PerformClick();
                };*/
            //this.Controls.Add(usernameTB);
            //usernameTB.KeyPress += new KeyPressEventHandler(keypressed);

            loginP.Click += new EventHandler(loginB_Click_1);
        }

        /*void keypressed(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
                e.Handled = true;
        }*/
        private int tries = 0;

        private void loginB_Click_1(object sender, EventArgs e)
        {
            /* cards = "C:\\Cards\\";
             saveCards = "C:\\Cards\\Created Cards\\";
             saveDecks = "C:\\Cards\\Created Decks\\";
             saveStudentCards = "C:\\Cards\\Student Cards\\";
             studentResults = "C:\\Cards\\Student Results\\";

             MessageBox.Show("Save Decks: " + Directory.Exists(saveDecks).ToString());
             MessageBox.Show("Cards: " + Directory.Exists(cards).ToString());
             MessageBox.Show("Save student cards: " + Directory.Exists(saveStudentCards).ToString());
             MessageBox.Show("Save cards: " + Directory.Exists(saveCards).ToString());
             MessageBox.Show("Student results: " + Directory.Exists(studentResults).ToString());*/

            usernameInk.Enabled = false;
            passwordInk.Enabled = false;

            if (check() == true)
            {

                sd = new DashboardStudent(creater);
                Global.form.Controls.Add(sd);
                this.Dispose();

            }
            //else
            //    creater = "";

            else if (checkTeacher() == true)
            {
                td = new DashboardTeacher(creater);
                Global.form.Controls.Add(td);
                this.Dispose();
            }

            else
            {
                usernameInk.Ink.DeleteStrokes();
                passwordInk.Ink.DeleteStrokes();

                usernameInk.Ink.Dispose();
                passwordInk.Ink.Dispose();

                usernameInk.Ink = new Ink();
                passwordInk.Ink = new Ink();

                usernameL.Text = "Username";
                passwordL.Text = "Password";

                toolTip1.Show("Try Again", usernameP, 1500);

                usernameInk.Enabled = true;
                passwordInk.Enabled = true;
            }

            tries++;
            if (tries >= NoOfTries)
            {
                /*usernameP.Enabled = false;
                passwordP.Enabled = false;

                usernameTB.Visible = true;
                passwordTB.Visible = true;
                //triesUsernameL.Visible = true;
                //triesPasswordL.Visible = true;

                usernameInk.Enabled = false;
                passwordInk.Enabled = false;*/

                usernameInk.Enabled = false;
                passwordInk.Enabled = false;

                usernameTB.Multiline = false;
                passwordTB.Multiline = false;

                usernameTB.TextAlign = HorizontalAlignment.Center;
                passwordTB.TextAlign = HorizontalAlignment.Center;

                usernameTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 58F, System.Drawing.FontStyle.Bold);
                passwordTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 58F, System.Drawing.FontStyle.Bold);

                

                passwordTB.PasswordChar = '*';

                usernameTB.Size = new System.Drawing.Size(usernameP.Width, usernameP.Height);
                passwordTB.Size = new System.Drawing.Size(passwordP.Width, passwordP.Height);

                usernameP.Controls.Add(usernameTB);
                passwordP.Controls.Add(passwordTB);

                usernameTB.Focus();

                usernameTB.Show();
                passwordTB.Show();

                //toolTip1.Show("Please try signing in with these textboxes", this);
            }


        }
        public string getUserName()
        {
            return creater;
        }

        public bool check()
        {
            
            
            
            loginDB = "C:\\Cards\\Students.accdb";



            //npgConn.ConnectionString = "Server=postgres://wvifgiff:Zhva4tzKGSLHjebZG00lJz4fNp4RkJYd@babar.elephantsql.com:5432/wvifgiff;Port=5432;Database=ELEPHANTSQL_URL;User=SFCMU;Password=flashcards";
            //npgConn.Open();
            
            
            
            conn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source= " + loginDB + ";Persist Security Info=False;";
            conn.Open();
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            ds.Tables.Add(dt);
            OleDbDataAdapter da = new OleDbDataAdapter("Select * from StudentsLogin", conn);
            da.Fill(dt);

            //creater = usernameInk.Ink.Strokes.ToString();
            //MessageBox.Show(usernameInk.Ink.Strokes.ToString() +"\n" + passwordInk.Ink.Strokes.ToString());
            creater = usernameInk.Ink.Strokes.ToString();
            if (tries >= NoOfTries)
                creater = usernameTB.Text;


            foreach (DataRow r in dt.Rows)
            {

                if (r[0].ToString() == creater && r[1].ToString() == passwordInk.Ink.Strokes.ToString() || r[0].ToString() == usernameTB.Text && r[1].ToString() == passwordTB.Text)
                {

                    return true;
                }
            }

            conn.Close();
            return false;
        }

        public bool checkTeacher()
        {
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            ds.Tables.Add(dt);
            OleDbDataAdapter da = new OleDbDataAdapter("Select * from TeacherLogin", conn);
            da.Fill(dt);
            creater = usernameInk.Ink.Strokes.ToString();
            if (tries >= NoOfTries)
                creater = usernameTB.Text;
            foreach (DataRow r in dt.Rows)
            {

                if (r[0].ToString() == creater && r[1].ToString() == passwordInk.Ink.Strokes.ToString() || r[0].ToString() == usernameTB.Text && r[1].ToString() == passwordTB.Text)
                {
                    return true;
                }
            }
            conn.Close();

            return false;
        }

        private void usernameInk_Stroke(object sender, InkCollectorStrokeEventArgs e)
        {
            usernameL.Text = usernameInk.Ink.Strokes.ToString();
        }

        private void passwordInk_Stroke(object sender, InkCollectorStrokeEventArgs e)
        {
            passwordL.Text = passwordInk.Ink.Strokes.ToString();
        }

        private void exitB_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            usernameInk.Enabled = false;
            usernameInk.Ink.DeleteStrokes();
            usernameInk.Ink.Dispose();
            usernameInk.Ink = new Ink();
            usernameInk.Enabled = true;
            usernameL.Text = "Username";
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            passwordInk.Enabled = false;
            passwordInk.Ink.DeleteStrokes();
            passwordInk.Ink.Dispose();
            passwordInk.Ink = new Ink();
            passwordInk.Enabled = true;
            passwordL.Text = "Password";
        }
    }
}

