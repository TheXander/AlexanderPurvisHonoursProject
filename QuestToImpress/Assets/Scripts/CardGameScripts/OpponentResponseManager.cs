using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentResponseManager : MonoBehaviour
{
    public CardGameManager cardGameManager;

    public bool enemyTurn = false;
    float cooldown = 5f;
    float cooldownCounter = 0f;

    private void Update()
    {
        if (enemyTurn)
        {
            Coundown();
        }
    }

    void Coundown()
    {
        cooldownCounter += Time.deltaTime;
        if (cooldownCounter >= cooldown)
        {

            ReactivatePlayersHand();
            enemyTurn = false;
            cooldownCounter = 0;
        }
    }


    void ReactivatePlayersHand()
    {
        cardGameManager.ActivateHand();
    }
}
