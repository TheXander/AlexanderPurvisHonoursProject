using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyBubbleText : MonoBehaviour
{
    public OpponentResponseManager opponentResponseManager;
    public string newsentance;
    public TMP_Text eSpeachBubble;   

    public void ActivateBubbleText()
    {
        StartCoroutine(AddSentenceToDialogBox(newsentance));     
    }

    IEnumerator AddSentenceToDialogBox(string sentance)
    {
        eSpeachBubble.text = "";

        foreach (char letter in sentance)
        {
            eSpeachBubble.text += letter;         
            yield return new WaitForSeconds(0.027f);
        }
        opponentResponseManager.cardPlayed = true;
    }


    public void ResolveCard()
    {
        eSpeachBubble.text = "";
        opponentResponseManager.ResolveCardEffect();
    }
}
