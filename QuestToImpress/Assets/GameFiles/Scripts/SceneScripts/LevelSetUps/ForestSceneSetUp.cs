using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestSceneSetUp : MonoBehaviour
{
    public PlayerProgress playerProgress;

    public GameObject L1ForestCombat;
    public GameObject ForestKnight;

    public RomeoData romeoData;
    public PlayerEventResults eventResults;

    public GameObject firstCombatWinDialodue, firstCombatLossDialodue;

    private void Awake()
    {     
        // combat result Dialogue
        if (romeoData.previousLocation == LevelLoader.Levels.Combat)
        {
            switch (eventResults.forestKCombat)
            {
                case PlayerEventResults.EventResults.Win:
                    firstCombatWinDialodue.SetActive(true);
                    break;
                case PlayerEventResults.EventResults.Loss:
                    firstCombatLossDialodue.SetActive(true);
                    break;              
                default:
                    break;
            }
        }


        // progress
        if (playerProgress.forestKCombatCompelte)
        {
            L1ForestCombat.SetActive(false);
            ForestKnight.SetActive(true);
        }
    }
}
