using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentResponseManager : MonoBehaviour
{
    public CardGameManager cardGameManager;
    public EnemyBubbleText enemyBubble;
    public Animator eSpeachBubbleAni;
    public Animator playerDamageObject;
    public Animator enemyCostObject;
    public bool enemyTurn = false;
    public bool cardPlayed = false;
    bool resolving = false;
    
    float bubbleCooldown = 5f;
    float fadeCooldown = 3.2f;
    float resolutionCooldown = 6;
    float cooldownCounter = 0f;

    int damageToPlayer = 2;
    int damageToEnemy = 1;

    public string sentance = "Test sentanse";
    CardInfo currentEnemyCard;

    private void Update()
    {
        if (enemyTurn)
        {
            BubbleCoundown();
        }
        else if (cardPlayed)
        {
            FadeCoundown();
        }
        else if (resolving)
        {
            ResoltionCountdown();
        }
    }

    void BubbleCoundown()
    {
        cooldownCounter += Time.deltaTime;
        if (cooldownCounter >= bubbleCooldown)
        {
            if (cardGameManager.gameOver)
            {
                enemyTurn = false;
                cooldownCounter = 0;
                cardGameManager.EndCardGame();
            }
            else {
                // add top card from decklist and then remove that card from the list
                currentEnemyCard = cardGameManager.enemyDecklist[0];
                cardGameManager.enemyDecklist.Remove(cardGameManager.enemyDecklist[0]);

                sentance = currentEnemyCard.cardQuote;
                damageToEnemy = currentEnemyCard.cardCost;
                damageToPlayer = currentEnemyCard.cardDamage;

                enemyBubble.newsentance = sentance;
                eSpeachBubbleAni.SetTrigger("Activate");

                enemyTurn = false;
                cooldownCounter = 0;
            }            
        }
    }

    void FadeCoundown()
    {
        cooldownCounter += Time.deltaTime;
        if (cooldownCounter >= fadeCooldown)
        {
            eSpeachBubbleAni.SetTrigger("Deactivate");
            cardPlayed = false;
            resolving = true;
            cooldownCounter = 0;
        }
    }

    void ResoltionCountdown()
    {
        cooldownCounter += Time.deltaTime;
        if (cooldownCounter >= resolutionCooldown)
        {
            ReactivatePlayersHand();
            resolving = false;
            cooldownCounter = 0;
        }
    }

    public void ResolveCardEffect()
    {
        cardGameManager.pendingDamageToPlayer = damageToPlayer;
        cardGameManager.pendingDamageToEnemy = damageToEnemy;
      
        if (cardGameManager.pendingDamageToPlayer > 0)
        {
            playerDamageObject.SetTrigger("Activate");
        }

        if (cardGameManager.pendingDamageToEnemy > 0)
        {
            enemyCostObject.SetTrigger("Activate");
        }     
    }

    public void ReactivatePlayersHand()
    {
       
       cardGameManager.ActivateHand();        
    }
}
