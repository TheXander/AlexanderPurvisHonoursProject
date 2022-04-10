using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CardGameManager : MonoBehaviour
{
    public OpponentResponseManager opponentResponseManager;

    public List<CardInfo> playingCards = new List<CardInfo>();
    public List<CardInfo> standeredPlayerDeck = new List<CardInfo>();
    public List<CardInfo> activePlayerDeck = new List<CardInfo>();

    public List<GameObject> cardsInHand = new List<GameObject>();
    public List<GameObject> handSlots = new List<GameObject>();
    public GameObject cardPrefab;
    public GameObject magnifiedCardPrefab;

    public TMP_Text playerHonourDisplay;
    public TMP_Text enemyHonourDisplay;

    public TMP_Text playerSpeachBubble;
    public Animator pSpeachBubbleAni;
    string newsentance;

    float cooldown = 3.2f;
    float cooldownCounter = 0f;
    bool bubbleUp = false;

    int playerHonour = 30;
    int enemyHonour = 20;

    public Animator playerCostObject;
    public Animator playerDamageObject;

    int pendingDamageToEnemy;
    int pendingDamageToPlayer;

    public Animator enemyCostObject;
    public Animator enemyDamageObject;

    public List<GameObject> magnifiedCards = new List<GameObject>();


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
                    if (!hit.transform.GetComponent<OnMouseOverCards>().isDeactivated)
                    {
                        PlayCard(hit.transform.gameObject);
                    }                   
                }
            }
        }

        if (bubbleUp)
        {
            Coundown();
        }
    }

    void Coundown()
    {
        cooldownCounter += Time.deltaTime;
        if (cooldownCounter >= cooldown)
        {
            bubbleUp = false;
            pSpeachBubbleAni.SetTrigger("Deactivate");
            playerSpeachBubble.text = "";
            cooldownCounter = 0;
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
            GameObject CardInHand = Instantiate(cardPrefab);

            SetUpCardTransform(CardInHand);

            AddCardData(CardInHand);
        }     
    }

    void AddCardData(GameObject Card) 
    {
        CardInfo cardData = activePlayerDeck[0];
        Card.GetComponent<PlayingCardControls>().setUpCard(cardData.cardName, cardData.cardCost, cardData.cardDamage, cardData.cardQuote, cardData.cardSource);
        Card.GetComponent<OnMouseOverCards>().cardGameManager = GetComponent<CardGameManager>();
        
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
        newsentance = cardToPlay.GetComponent<PlayingCardControls>().quote;     
        pendingDamageToEnemy = cardToPlay.GetComponent<PlayingCardControls>().damage;
        pendingDamageToPlayer = cardToPlay.GetComponent<PlayingCardControls>().cost;
        
        cooldown = (float)(0.06 * (float)newsentance.Length);

        pSpeachBubbleAni.SetTrigger("Activate");
        
        cardsInHand.Remove(cardToPlay);
        Destroy(cardToPlay);
        Sorthand();
        DeactivateHand();
    }

    public void StartDialogBoxText()
    {

        StartCoroutine(AddSentenceToDialogBox(newsentance));
    }

    public void CardResolution()
    {
        if (pendingDamageToPlayer > 0)
        {
            playerCostObject.SetTrigger("Activate");
        }

        if (pendingDamageToEnemy > 0)
        {
            playerDamageObject.SetTrigger("Activate");
        }

        opponentResponseManager.enemyTurn = true;
    }

    IEnumerator AddSentenceToDialogBox (string sentance)
    {     
        playerSpeachBubble.text = "";

        foreach(char letter in sentance)
        {
           playerSpeachBubble.text += letter;

            if (letter == sentance[sentance.Length-1])
            {
                bubbleUp = true;
            }

           yield return new WaitForSeconds(0.027f);
        }
    }


    // damage functions controled through animation
    public void AsignDamgeToPlayer()
    {
        playerHonour -= pendingDamageToPlayer;
        pendingDamageToPlayer = 0;
        playerHonourDisplay.text = playerHonour.ToString();
    }

    public void AsignDamgeToEnemey()
    {
       enemyHonour -= pendingDamageToEnemy;
        pendingDamageToEnemy = 0;
        enemyHonourDisplay.text = enemyHonour.ToString();
    }

    // Hand sorting so that cards are in the correct place after a card is played
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


    public void CrateMagnifiedCard(GameObject cardToMagnify)
    {
        bool cardExists = false;

        foreach(GameObject card in magnifiedCards)
        {
            if (card.GetComponent<PlayingCardControls>().nameOfCard == cardToMagnify.GetComponent<PlayingCardControls>().nameOfCard)
            {
                cardExists = true;
            }
        }

        if (!cardExists)
        {
            GameObject newMagnifiedCard = Instantiate(magnifiedCardPrefab);
            PlayingCardControls mCardData = cardToMagnify.GetComponent<PlayingCardControls>();
            newMagnifiedCard.GetComponent<PlayingCardControls>().setUpCard(
                mCardData.nameOfCard, mCardData.cost, mCardData.damage, mCardData.quote, mCardData.sourseOfCard);

            newMagnifiedCard.transform.position = new Vector3(0.0f, 1.9f, -7.0f);
            newMagnifiedCard.transform.localScale = new Vector3(0.97f, 0.97f, 0.97f);
            newMagnifiedCard.transform.rotation = new Quaternion(0, 0, 0, 0);
            magnifiedCards.Add(newMagnifiedCard);
        }       
    }


    public void DestroyMagnifiedCard(GameObject MagnifiedcardToDestroy)
    {
        foreach (GameObject magnifiedCard in magnifiedCards)
        {
            if (magnifiedCard.GetComponent<PlayingCardControls>().nameOfCard == MagnifiedcardToDestroy.GetComponent<PlayingCardControls>().nameOfCard)
            {
                magnifiedCards.Remove(magnifiedCard);
                Destroy(magnifiedCard);
                break;
            }
        }
    }

    void DeactivateHand()
    {
        foreach (GameObject card in cardsInHand)
        {
            card.GetComponent<OnMouseOverCards>().isDeactivated = true;
            card.GetComponent<PlayingCardControls>().TurnOff();
        }

        foreach(GameObject magnifiedCard in magnifiedCards)
        {
            Destroy(magnifiedCard);
        }

        magnifiedCards = new List<GameObject>();      
    }

    public void ActivateHand()
    {
        foreach (GameObject card in cardsInHand)
        {
            card.GetComponent<PlayingCardControls>().TurnOn();
            card.GetComponent<OnMouseOverCards>().isDeactivated = false;
        }
    }
}
