using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayingCardControls : MonoBehaviour
{
    public TMP_Text cardName;
    public TMP_Text cardCost;
    public TMP_Text cardDamage;
    public TMP_Text cardQuote;
    public TMP_Text cardSource;

    public int cost;
    public int damage;


    // Called when card is spawned so that the card has the required information and abilities 
    public void setUpCard(string newName, int newCost, int newDamage, string newQuote, string newSource)
    {
        cardName.text = newName;
        cardCost.text = newCost.ToString();
        cost = newCost;
        cardDamage.text = newDamage.ToString();
        damage = newDamage;
        cardQuote.text = newQuote;
        cardSource.text = newSource;
    }
}
