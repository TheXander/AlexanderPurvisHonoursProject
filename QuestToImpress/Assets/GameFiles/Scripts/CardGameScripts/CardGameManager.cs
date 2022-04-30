using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CardGameManager : MonoBehaviour
{

    public PlayerModel playerModel;

    public OpponentResponseManager opponentResponseManager;
    public SetUpCardGameEvent setUpEvent;
    public enum GameOutcomes { Win, Lose, Draw};
    GameOutcomes gameOutcome;
    public TMP_Text gameResultText;

    public RomeoData romeoData;
    public PlayerProgress playerProgress;
    public PlayerEventResults eventResults;

    // Player deck
    public List<CardInfo> playingCards = new List<CardInfo>();
    public List<CardInfo> standeredPlayerDeck = new List<CardInfo>();
    public List<CardInfo> activePlayerDeck = new List<CardInfo>();

    // Enemy Deck
    public List<CardInfo> enemyDecklist = new List<CardInfo>();

    public List<GameObject> cardsInHand = new List<GameObject>();
    public List<GameObject> handSlots = new List<GameObject>();
    public GameObject cardPrefab;
    public GameObject magnifiedCardPrefab;

    public TMP_Text playerHonourDisplay;
    public TMP_Text enemyHonourDisplay;

    public TMP_Text playerSpeachBubble;
    public Animator pSpeachBubbleAni;

    public Animator enemyAnimator;
    public Animator romeoAnimator;
    string newsentance;
    float bubbleCooldown = 3.2f;
    float returnPlayerCooldown = 4.5f;
    float cooldownCounter = 0f;
    bool bubbleUp = false;

    int playerHonour = 30;
    int enemyHonour = 9;

    public Animator playerCostObject;
    public Animator playerDamageObject;

    public int pendingDamageToEnemy;
    public int pendingDamageToPlayer;

    public Animator enemyCostObject;
    public Animator enemyDamageObject;

    public List<GameObject> magnifiedCards = new List<GameObject>();  
    
    // Deck managment
    public bool cardAvalible = true;
    public GameObject deckOutline;

    public bool gameOver = false;
    bool gameResolved = false;

    bool resultSentToPlayerModel = false;

    private void Start()
    {
        LoadPlayerDeckCSVFile();
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
            bubbleCoundown();

            
        }

        if (gameResolved)
        {
            returnPlayerCountdown();
        }       
    }

    void bubbleCoundown()
    {
        cooldownCounter += Time.deltaTime;
        if (cooldownCounter >= returnPlayerCooldown)
        {
            bubbleUp = false;
            pSpeachBubbleAni.SetTrigger("Deactivate");
            playerSpeachBubble.text = "";
            cooldownCounter = 0;
        }
    }

    void returnPlayerCountdown()
    {
        cooldownCounter += Time.deltaTime;
        if (cooldownCounter >= bubbleCooldown)
        {       
            gameResolved = false;
            cooldownCounter = 0;
            setUpEvent.ReturnPlayer();
        }
    }

    void LoadPlayerDeckCSVFile()
    {
        // clear list of previous cards
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
        if (cardAvalible)
        {
            GameObject CardInHand = Instantiate(cardPrefab);

            SetUpCardTransform(CardInHand);
            AddCardData(CardInHand);

            if (cardsInHand.Count >= 5)
            {
                cardAvalible = false;
                deckOutline.SetActive(false);    
            }
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
        deckOutline.SetActive(false);
        cardAvalible = false;

        newsentance = cardToPlay.GetComponent<PlayingCardControls>().quote;     
        pendingDamageToEnemy = cardToPlay.GetComponent<PlayingCardControls>().damage;
        pendingDamageToPlayer = cardToPlay.GetComponent<PlayingCardControls>().cost;
        
        bubbleCooldown = (float)(0.06 * (float)newsentance.Length);

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
           yield return new WaitForSeconds(0.027f);
        }

        bubbleUp = true;
    }


    // damage functions controled through animation
    public void AsignDamgeToPlayer()
    {
        playerHonour -= pendingDamageToPlayer;
        pendingDamageToPlayer = 0;
        if (playerHonour <= 0)
        {
            playerHonourDisplay.text = "X";
            romeoAnimator.SetTrigger("Defeated");
            gameOver = true;
        }
        else
        {
            playerHonourDisplay.text = playerHonour.ToString();
        }     
    }

    public void AsignDamgeToEnemey()
    {
       enemyHonour -= pendingDamageToEnemy;
       pendingDamageToEnemy = 0;
      
        if (enemyHonour <= 0)
        {
            enemyHonourDisplay.text = "X";
            enemyAnimator.SetTrigger("Defeated");
            gameOver = true;
        }
        else
        {
            enemyHonourDisplay.text = enemyHonour.ToString();          
        }
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
        if (!gameOver)
        {
            deckOutline.SetActive(true);
            cardAvalible = true;

            foreach (GameObject card in cardsInHand)
            {
                card.GetComponent<PlayingCardControls>().TurnOn();
                card.GetComponent<OnMouseOverCards>().isDeactivated = false;
            }
        }
        else
        {
            EndCardGame();
        }
    }

    public void EndCardGame()
    {
        if (playerHonour <= 0 && enemyHonour <= 0)
        {
            gameOutcome = GameOutcomes.Draw;
        }
        else if (enemyHonour <= 0)
        {
            gameOutcome = GameOutcomes.Win;
        }
        else if (playerHonour <= 0)
        {
            gameOutcome = GameOutcomes.Lose;
        }
        else
        {
            Debug.Log("Error");
        }

        if (!resultSentToPlayerModel)
        {
            switch (romeoData.CurrentCardgame)
            {
                case RomeoData.CardgameEvents.LakeFighter:
                    switch (gameOutcome)
                    {
                        case GameOutcomes.Win:
                            eventResults.lakeCardGame = PlayerEventResults.EventResults.Win;

                            break;
                        case GameOutcomes.Lose:
                            eventResults.lakeCardGame = PlayerEventResults.EventResults.Loss;

                            break;
                        case GameOutcomes.Draw:
                            eventResults.lakeCardGame = PlayerEventResults.EventResults.Draw;

                            break;
                        default:
                            break;
                    }
                    break;

                case RomeoData.CardgameEvents.TavernFighter:

                    playerModel.StandardUpdate(true, "Tavern");

                    switch (gameOutcome)
                    {
                        case GameOutcomes.Win:
                            eventResults.tavernFCardGame = PlayerEventResults.EventResults.Win;
                            Debug.Log("win ");
                            //Player Model update                      
                            playerModel.NewCardGameEngagement(true, false);
                            break;
                        case GameOutcomes.Lose:
                            eventResults.tavernFCardGame = PlayerEventResults.EventResults.Loss;
                            Debug.Log("loss ");
                            //Player Model update                        
                            playerModel.NewCardGameEngagement(false, false);
                            break;
                        case GameOutcomes.Draw:
                            eventResults.tavernFCardGame = PlayerEventResults.EventResults.Draw;
                            Debug.Log("draw ");
                            //Player Model update                        
                            playerModel.NewCardGameEngagement(false, true);
                            break;
                        default:
                            break;
                    }
                    break;

                case RomeoData.CardgameEvents.CityKnight:

                    playerModel.StandardUpdate(true, "City");

                    switch (gameOutcome)
                    {
                        case GameOutcomes.Win:
                            eventResults.cityCardGame = PlayerEventResults.EventResults.Win;
                            //Player Model update                      
                            playerModel.NewCardGameEngagement(true, false);
                            break;
                        case GameOutcomes.Lose:
                            eventResults.cityCardGame = PlayerEventResults.EventResults.Loss;
                            //Player Model update                        
                            playerModel.NewCardGameEngagement(false, false);
                            break;
                        case GameOutcomes.Draw:
                            eventResults.cityCardGame = PlayerEventResults.EventResults.Draw;
                            //Player Model update                        
                            playerModel.NewCardGameEngagement(false, true);
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }
        }

        
      
        switch (gameOutcome)
        {
            case GameOutcomes.Win:
                gameResultText.text = "Romeo Wins!";
                break;
            case GameOutcomes.Lose:
                gameResultText.text = "You Lost! Sad times";
                break;
            case GameOutcomes.Draw:
                gameResultText.text = "Draw!";
                break;
            default:
                break;
        }

        gameResolved = true;

        MarkCombatAsComplete();
    }

  
    void MarkCombatAsComplete()
    {
        switch (romeoData.CurrentCardgame)
        {
            case RomeoData.CardgameEvents.LakeFighter:
                playerProgress.lakeCardGameComplete = true;
                playerProgress.levelOneEventsComplete++;
                break;
            case RomeoData.CardgameEvents.TavernFighter:
                playerProgress.tavernFCardGameComplete = true;
                playerProgress.levelOneEventsComplete++;
                break;
            case RomeoData.CardgameEvents.CityKnight:
                playerProgress.cityCardGameComplete = true;
                playerProgress.levelOneEventsComplete++;
                break;
            case RomeoData.CardgameEvents.TavernAxeMan:
                playerProgress.tavernVCardGameComplete = true;
                playerProgress.levelTwoEventsComplete++;
                break;
            case RomeoData.CardgameEvents.ForestGhoul:
                playerProgress.forestCardGameComplete = true;
                playerProgress.levelTwoEventsComplete++;
                break;
            case RomeoData.CardgameEvents.Tybalt:
                playerProgress.tybaltCardGameComplete = true;
                playerProgress.levelTwoEventsComplete++;
                break;
            default:
                Debug.Log("Error no result");
                break;
        }
    }

    // enemy setUp
    public void LoadEnemyDeckCSVFile(RomeoData.CardgameEvents Opponent)
    {    
        // clear list of previous cards
        enemyDecklist.Clear();

        switch (Opponent)
        {
            case RomeoData.CardgameEvents.LakeFighter:

                List<Dictionary<string, object>> lakeFighterData = CSVReader.Read("LakeKnightDeckList");
                for (var i = 0; i < lakeFighterData.Count; i++)
                {
                    string nameData = lakeFighterData[i]["Name"].ToString();
                    int cost = int.Parse(lakeFighterData[i]["Cost"].ToString(), System.Globalization.NumberStyles.Integer);
                    int damage = int.Parse(lakeFighterData[i]["Damage"].ToString(), System.Globalization.NumberStyles.Integer);
                    string quote = lakeFighterData[i]["Quote"].ToString();
                    string source = lakeFighterData[i]["Source"].ToString();

                    CardInfo newCard = new CardInfo(nameData, cost, damage, quote, source);
                    enemyDecklist.Add(newCard);
                }
                 enemyHonour = 24;
                break;
            case RomeoData.CardgameEvents.TavernFighter:
                List<Dictionary<string, object>> data = CSVReader.Read("TavernFighterDeckList");
                for (var i = 0; i < data.Count; i++)
                {
                    string nameData = data[i]["Name"].ToString();
                    int cost = int.Parse(data[i]["Cost"].ToString(), System.Globalization.NumberStyles.Integer);
                    int damage = int.Parse(data[i]["Damage"].ToString(), System.Globalization.NumberStyles.Integer);
                    string quote = data[i]["Quote"].ToString();
                    string source = data[i]["Source"].ToString();

                    CardInfo newCard = new CardInfo(nameData, cost, damage, quote, source);
                    enemyDecklist.Add(newCard);
                }
                  enemyHonour = 30;
                break;
            case RomeoData.CardgameEvents.CityKnight:
                List<Dictionary<string, object>> cityKnightData = CSVReader.Read("CityKnightDeckList");
                for (var i = 0; i < cityKnightData.Count; i++)
                {
                    string nameData = cityKnightData[i]["Name"].ToString();
                    int cost = int.Parse(cityKnightData[i]["Cost"].ToString(), System.Globalization.NumberStyles.Integer);
                    int damage = int.Parse(cityKnightData[i]["Damage"].ToString(), System.Globalization.NumberStyles.Integer);
                    string quote = cityKnightData[i]["Quote"].ToString();
                    string source = cityKnightData[i]["Source"].ToString();

                    CardInfo newCard = new CardInfo(nameData, cost, damage, quote, source);
                    enemyDecklist.Add(newCard);
                }
                  enemyHonour = 25;       
                break;
            case RomeoData.CardgameEvents.TavernAxeMan:

               
                break;
            case RomeoData.CardgameEvents.ForestGhoul:

               
                break;
            case RomeoData.CardgameEvents.Tybalt:

               
                break;

            default:
                break;
        }              
    }
}