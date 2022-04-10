using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleTextTrigger : MonoBehaviour
{

    public CardGameManager cardGameManager;

    public void ActivateBubbleText()
    {
        cardGameManager.StartDialogBoxText();
    }

    public void ResolveCard()
    {
        cardGameManager.CardResolution();
    }
}
