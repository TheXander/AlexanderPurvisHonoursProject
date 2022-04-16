using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LakeSetUp : MonoBehaviour
{
    // castle 
    public Transform castleSpawnPoint;
    public Transform castleCamPos;

    public RomeoData romeoData;
    public PlayerEventResults eventResults;
    public GameObject player;
    public Camera playerCam;

    // level Progress
    public PlayerProgress playerProgress;

    public GameObject l1LakeCardGame;
    public GameObject lakeFighter;

    public GameObject cityBarrier, citySign, castleBarrier, castleSign;

    public GameObject CardWinResultDialogue, CardLossResultDialogue, CardDrawResultDialogue;

    private void Awake()
    {
        if (romeoData.previousLocation == LevelLoader.Levels.Castle)
        {
            player.transform.position = castleSpawnPoint.position;
            playerCam.transform.position = castleCamPos.position;
            playerCam.GetComponent<CamPlayerTracking>().trackingActive = false;
            player.GetComponent<SceneBasedPlayerControls>().TurnPlayerLeft();

            cityBarrier.SetActive(false);
            citySign.SetActive(true);
            castleBarrier.SetActive(true);
            castleSign.SetActive(false);
        }
        else if (romeoData.previousLocation == LevelLoader.Levels.CardGame)
        {
    
            switch (eventResults.lakeCardGame)
            {
                case PlayerEventResults.EventResults.Win:
                    CardWinResultDialogue.SetActive(true);
                    break;
                case PlayerEventResults.EventResults.Loss:
                    CardLossResultDialogue.SetActive(true);
                    break;
                case PlayerEventResults.EventResults.Draw:
                    CardDrawResultDialogue.SetActive(true);
                    break;
                default:
                    break;
            }
        }

        if (playerProgress.lakeCardGameComplete)
        {
            l1LakeCardGame.SetActive(false);
            lakeFighter.SetActive(true);
        }
    }
}
