using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrawButton : MonoBehaviour
{
   public GameObject cardGameManager;
    CardGameManager cardGameManagerControls;

    private void Start()
    {
        cardGameManagerControls = cardGameManager.transform.GetComponent<CardGameManager>();
    }


    public void NewCardDraw()
    {
        cardGameManagerControls.DrawCard();
    }
}
