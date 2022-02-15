using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CardInfo
{
    public string cardName;
    public int cardCost;
    public int cardDamage;
    public string cardQuote;
    public string cardSource;

    public CardInfo(string newName, int newCost, int newDamage, string newQuote, string newSource)
    {
        cardName = newName;
        cardCost = newCost;
        cardDamage = newDamage;
        cardQuote = newQuote;
        cardSource = newSource;
    }
}
