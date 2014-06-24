using System;
using System.Collections.Generic;
using System.Collections;

/// <summary>
/// Summary description for Class1
/// </summary>
[Serializable]
public sealed class Deck
{
    static Deck deck = null;
    public List<Card> cards;
    public string backgroundImage;
    public int numberOfCards;
    public string description;
    public string deckName;
    public List<string> cardNames;
    
    private Deck()
    {
        cards = new List<Card>();
        backgroundImage = null;
        description = null;
        deckName = null;
        cardNames = new List<string>();
                
    }

    public static Deck getDeck()
    {
        if (deck == null)
        {
            deck = new Deck();
        }
        return deck;
    }
}
