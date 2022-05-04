using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompleteInstructionsManager : MonoBehaviour
{

    public GameObject general;
    public GameObject combat;
    public GameObject cardGame;
    public GameObject background;

    // Start is called before the first frame update
    void Start()
    {
        general.SetActive(true);
        background.SetActive(true);
    }

  

    public void ShowGeneral()
    {
        clearButtons();
        general.SetActive(true);
    }

    public void ShowCombat()
    {
        clearButtons();
        combat.SetActive(true);
    }

    public void ShowCardGame()
    {
        clearButtons();
        cardGame.SetActive(true);
    }


    void clearButtons()
    {
        general.SetActive(false);
        combat.SetActive(false);
        cardGame.SetActive(false);
    }
}
