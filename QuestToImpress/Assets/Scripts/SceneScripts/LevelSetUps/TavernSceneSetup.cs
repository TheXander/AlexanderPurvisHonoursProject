using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TavernSceneSetup : MonoBehaviour
{
    public PlayerProgress playerProgress;

    public GameObject l1TavernDialog, l1TavernCardGame;

    public GameObject barman, tavernFighter;


    private void Awake()
    {
        if (playerProgress.tavernDialogCompelte)
        {
            l1TavernDialog.SetActive(false);
            barman.SetActive(true);
        }

        if (playerProgress.tavernFCardGameComplete)
        {
            l1TavernCardGame.SetActive(false);
            tavernFighter.SetActive(true);
        }
    } 
}
