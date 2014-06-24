using System;
using System.Collections;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;

/// <summary>
/// Summary description for Class1
/// </summary>
[Serializable]
public class Card
{
    public byte[] frontInk;
    public byte[] backInk;

    public string frontImage;
    public string backImage;

    // the number of times the user answers correctly/incorrectly
    public int correct;
    public int wrong;
    public int position;
    public int difficulty;

    public string diff;
    public string[] standards;
    public string grade;
    public string username;
    
    public string cardname;

    //gradeable means the answer will be checked by the computer
    public bool gradeable;

    //variables are only used for AutoMath
    public int num1;
    public int num2;
    public int answer;
    public string operate;

    //for audio
    public bool audioFound;
    public string audioLocation;

    //for a background image
    public Image panelBackground;
    public bool autoMathCard;

    public string answerWord, question;
    public Image answerPPT, questionPPT;
    public bool wordCard;

    public Card()
    {
        frontInk = null;
        backInk = null;

        frontImage = null;
        backImage = null;

        correct = 0;
        wrong = 0;
        position = 1;

        gradeable = true;
        cardname = "";
        grade = "";
        diff = "";
        standards = new string[15];

        audioLocation = null;

        panelBackground = null;

        question = null;
        questionPPT = null;
        answerPPT = null;
        answerWord = null;
        wordCard = false;
    }

    public static bool ThumbnailCallback()
    {
        return true;
    }

    public static void FitImage(Panel panel, Image image)
    {
        if (image == null)
            panel.BackgroundImage = null;
        else
        {
            int smallerWidth = (image.Width > panel.Width) ? panel.Width : image.Width;
            int smallerHeight = (image.Height > panel.Height) ? panel.Height : image.Height;
            panel.BackgroundImage = image.GetThumbnailImage(smallerWidth, smallerHeight, new Image.GetThumbnailImageAbort(ThumbnailCallback), IntPtr.Zero);
        }
    }

    public static void FitImage(PictureBox panel, Image image)
    {
        if (image == null)
            panel.BackgroundImage = null;
        else
        {
            int smallerWidth = (image.Width > panel.Width) ?  panel.Width : image.Width;
            int smallerHeight = (image.Height > panel.Height) ?  panel.Height : image.Height;
            panel.Image = image.GetThumbnailImage(smallerWidth, smallerHeight, new Image.GetThumbnailImageAbort(ThumbnailCallback), IntPtr.Zero);
        }
    }
    
    
};


