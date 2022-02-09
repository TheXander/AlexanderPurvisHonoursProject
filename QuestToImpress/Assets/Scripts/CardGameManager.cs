using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardGameManager : MonoBehaviour
{ 
    public List<CardInfo> playingCards = new List<CardInfo>();
    public List<GameObject> cardsInHand = new List<GameObject>();
    public GameObject cardPrefab;


    public GameObject handSlot1;
    public GameObject handSlot2;
    public GameObject handSlot3;
    public GameObject handSlot4;
    public GameObject handSlot5;


    int numCardsInHand = 0;

    private void Start()
    {
        LoadCSVFile();
    }

    public void DrawCard()
    {
        if (numCardsInHand <= 4)
        {
            GameObject CardInHand = Instantiate(cardPrefab) as GameObject;
            
            switch (numCardsInHand)
            {
                case 4:
                    CardInHand.transform.position = handSlot5.transform.position;
                    CardInHand.transform.rotation = handSlot5.transform.rotation;
                    break;
                case 3:
                    CardInHand.transform.position = handSlot4.transform.position;
                    CardInHand.transform.rotation = handSlot4.transform.rotation;
                    break;
                case 2:
                    CardInHand.transform.position = handSlot3.transform.position;
                    CardInHand.transform.rotation = handSlot3.transform.rotation;
                    break;
                case 1:
                    CardInHand.transform.position = handSlot2.transform.position;
                    CardInHand.transform.rotation = handSlot2.transform.rotation;
                    break;
                case 0:
                    CardInHand.transform.position = handSlot1.transform.position;
                    CardInHand.transform.rotation = handSlot1.transform.rotation;
                    break;
                default:
                    print("Error");
                    break;
            }


            CardInfo cardData = playingCards[numCardsInHand];
            CardInHand.GetComponent<PlayingCardControls>().setUpCard(cardData.cardName, cardData.cardCost, cardData.cardDamage, cardData.cardQuote);

            cardsInHand.Add(CardInHand);
            numCardsInHand++;
        }     
    }

    void LoadCSVFile()
    {
        // clear list cards of cards
        playingCards.Clear();

        //Read from CSV file
        List<Dictionary<string, object>> data = CSVReader.Read("CardInfo");
        for (var i = 0; i < data.Count; i++)
        {
            string nameData = data[i]["Name"].ToString();
            int cost = int.Parse(data[i]["Cost"].ToString(), System.Globalization.NumberStyles.Integer);
            int damage = int.Parse(data[i]["Damage"].ToString(), System.Globalization.NumberStyles.Integer);
            string quote = data[i]["Quote"].ToString();

            CaptureCardFromCSV(nameData, cost, damage, quote);
        }
    }

    void CaptureCardFromCSV(string nameData, int cost, int damage, string quote)
    {
        CardInfo newCard = new CardInfo(nameData, cost, damage, quote);

        playingCards.Add(newCard);
    }
}
