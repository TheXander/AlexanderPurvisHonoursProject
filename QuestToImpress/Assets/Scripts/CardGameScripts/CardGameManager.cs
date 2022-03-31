using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CardGameManager : MonoBehaviour
{
    public List<CardInfo> playingCards = new List<CardInfo>();
    public List<CardInfo> standeredPlayerDeck = new List<CardInfo>();
    public List<CardInfo> activePlayerDeck = new List<CardInfo>();

    public List<GameObject> cardsInHand = new List<GameObject>();
    public List<GameObject> handSlots = new List<GameObject>();
    public GameObject cardPrefab;

    public TMP_Text playerHonourDisplay;
    public TMP_Text enemyHonourDisplay;

    int playerHonour = 30;
    int enemyHonour = 20;


    private void Start()
    {
        LoadCSVFile();
        SetUpPlayerDeck();

        playerHonourDisplay.text = playerHonour.ToString();
        enemyHonourDisplay.text = enemyHonour.ToString();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {             
                if (hit.transform.tag == "PlayingCard")
                {
                    PlayCard(hit.transform.gameObject);
                }
            }
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
            string source = data[i]["Source"].ToString();

            CaptureCardFromCSV(nameData, cost, damage, quote, source);
        }

        AddCardsToDeck();
    }

    void CaptureCardFromCSV(string nameData, int cost, int damage, string quote, string source)
    {
        CardInfo newCard = new CardInfo(nameData, cost, damage, quote, source);
        playingCards.Add(newCard);
    }

    void AddCardsToDeck()
    {
        standeredPlayerDeck = playingCards;
    }

    void SetUpPlayerDeck() 
    {
        activePlayerDeck = standeredPlayerDeck;

        DeckShuffler.Shuffle(activePlayerDeck);
    }

    public void DrawCard()
    {
        if (cardsInHand.Count <= 4)
        {
            GameObject CardInHand = Instantiate(cardPrefab) as GameObject;

            SetUpCardTransform(CardInHand);

            AddCardData(CardInHand);
        }     
    }

    void AddCardData(GameObject Card) 
    {
        CardInfo cardData = activePlayerDeck[0];
       

        Card.GetComponent<PlayingCardControls>().setUpCard(cardData.cardName, cardData.cardCost, cardData.cardDamage, cardData.cardQuote, cardData.cardSource);
        cardsInHand.Add(Card);

        activePlayerDeck.Remove(cardData);
    }

    void SetUpCardTransform(GameObject Card)
    {
        switch (cardsInHand.Count)
        {
            case 0:
                Card.transform.position = handSlots[0].transform.position;
                Card.transform.rotation = handSlots[0].transform.rotation;
                break;
            case 1:
                Card.transform.position = handSlots[1].transform.position;
                Card.transform.rotation = handSlots[1].transform.rotation;
                break;
            case 2:
                Card.transform.position = handSlots[2].transform.position;
                Card.transform.rotation = handSlots[2].transform.rotation;
                break;
            case 3:
                Card.transform.position = handSlots[3].transform.position;
                Card.transform.rotation = handSlots[3].transform.rotation;
                break;
            case 4:
                Card.transform.position = handSlots[4].transform.position;
                Card.transform.rotation = handSlots[4].transform.rotation;
                break;
            default:
                print("Error!");
                break;
        }
    }



    public void PlayCard(GameObject cardToPlay)
    {
        playerHonour -= cardToPlay.GetComponent<PlayingCardControls>().cost;
        enemyHonour -= cardToPlay.GetComponent<PlayingCardControls>().damage;

        playerHonourDisplay.text = playerHonour.ToString();
        enemyHonourDisplay.text = enemyHonour.ToString();

        cardsInHand.Remove(cardToPlay);
        Destroy(cardToPlay);
        Sorthand();
    }

    void Sorthand()
    {       
       for (int i = 0; i < cardsInHand.Count; i++)
       {

            GameObject CardInHand = cardsInHand[i];

            switch (i)
            {
                case 0:
                    CardInHand.transform.position = handSlots[0].transform.position;
                    CardInHand.transform.rotation = handSlots[0].transform.rotation;
                    break;
                case 1:
                    CardInHand.transform.position = handSlots[1].transform.position;
                    CardInHand.transform.rotation = handSlots[1].transform.rotation;
                    break;
                case 2:
                    CardInHand.transform.position = handSlots[2].transform.position;
                    CardInHand.transform.rotation = handSlots[2].transform.rotation;
                    break;
                case 3:
                    CardInHand.transform.position = handSlots[3].transform.position;
                    CardInHand.transform.rotation = handSlots[3].transform.rotation;
                    break;
                case 4:
                    CardInHand.transform.position = handSlots[4].transform.position;
                    CardInHand.transform.rotation = handSlots[4].transform.rotation;
                    break;
                default:
                    print("Error!");
                    break;
            }
        }
    }
}
