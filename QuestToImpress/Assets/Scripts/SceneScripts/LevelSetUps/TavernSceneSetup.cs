using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TavernSceneSetup : MonoBehaviour
{
    public PlayerProgress playerProgress;

    public GameObject l1TavernDialog, l1TavernCardGame;

    public GameObject barman, tavernFighter;
    public PlayerEventResults eventResults;
    public RomeoData romeoData;
    public GameObject cardOneWinDialogue, cardOneLossDialogue, cardOneDrawDialogue;

    private void Awake()
    {

        // card game result Dialoge
        if (romeoData.previousLocation == LevelLoader.Levels.CardGame)
        {
          
            switch (eventResults.tavernFCardGame)
            {
                case PlayerEventResults.EventResults.Win:
                    cardOneWinDialogue.SetActive(true);
                    break;
                case PlayerEventResults.EventResults.Loss:
                    cardOneLossDialogue.SetActive(true);
                    break;
                case PlayerEventResults.EventResults.Draw:
                    cardOneDrawDialogue.SetActive(true);
                    break;
                default:
                    break;
            }
        }


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
