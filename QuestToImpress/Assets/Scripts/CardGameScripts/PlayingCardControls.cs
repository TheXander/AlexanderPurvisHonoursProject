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
    public string nameOfCard;
    public string quote;
    public string sourseOfCard;

    // Called when card is spawned so that the card has the required information and abilities 
    public void setUpCard(string newName, int newCost, int newDamage, string newQuote, string newSource)
    {
        cardName.text = newName;
        nameOfCard = newName;
        cardCost.text = newCost.ToString();
        cost = newCost;
        cardDamage.text = newDamage.ToString();
        damage = newDamage;
        cardQuote.text = newQuote;
        quote = newQuote;
        cardSource.text = newSource;
        sourseOfCard = newSource;
    }

    public void TurnOff()
    {
        GetComponent<SpriteRenderer>().color = new Vector4(1, 1, 1, 0.4f);
        cardName.color = new Vector4(1, 1, 1, 0.4f);
        cardCost.color = new Vector4(1, 1, 1, 0.4f);
        cardDamage.color = new Vector4(1, 1, 1, 0.4f);
        cardQuote.color = new Vector4(1, 1, 1, 0.4f);
        cardSource.color = new Vector4(1, 1, 1, 0.4f);
    }

    public void TurnOn()
    {
        GetComponent<SpriteRenderer>().color = new Vector4(1, 1, 1, 1);
        cardName.color = new Vector4(0, 0, 0, 1);
        cardCost.color = new Vector4(0, 0, 0, 1);
        cardDamage.color = new Vector4(0, 0, 0, 1);
        cardQuote.color = new Vector4(0, 0, 0, 1);
        cardSource.color = new Vector4(0, 0, 0, 1);
    }
}
