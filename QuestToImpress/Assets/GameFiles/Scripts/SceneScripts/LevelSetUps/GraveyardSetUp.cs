using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraveyardSetUp : MonoBehaviour
{

    // bools for control of set up
    bool activateMinorCombats, activateMajorCombats = false;
    bool activateMinorCardGames, activateMajorCardGames = false;
    bool activateMinorDialogs, activateMajorDialogs = false;

    public GameObject graveyardExit;

    public PlayerProgress playerProgress;
    public PlayerModel playerModel;
    //church 
    public Transform graveyardSpawnPoint;
    public Transform graveyardCamPos;
    public RomeoData romeoData;
    public GameObject player;
    public Camera playerCam;
    public GameObject l1GraveyardCombat, l1GraveyardDialog;
    public GameObject tybalt, priest;
    public GameObject combatWinDialodue, combatLossDialodue;
    public PlayerEventResults eventResults;
    public GameObject churchBarriers, churchGate;
    public GameObject l2MercutioDialog, Mercutio;
    public GameObject JulietTybaltWarning;
    private void Awake()
    {
        if (!playerProgress.part2Active)
        {
            if (romeoData.previousLocation == LevelLoader.Levels.Church)
            {
                player.transform.position = graveyardSpawnPoint.position;
                playerCam.transform.position = graveyardCamPos.position;
                playerCam.GetComponent<CamPlayerTracking>().trackingActive = false;
                player.GetComponent<SceneBasedPlayerControls>().TurnPlayerRight();
            }

            // combat result Dialogue
            if (romeoData.previousLocation == LevelLoader.Levels.Combat)
            {
                switch (eventResults.gravyardCombat)
                {
                    case PlayerEventResults.EventResults.Win:
                        combatWinDialodue.SetActive(true);
                        break;
                    case PlayerEventResults.EventResults.Loss:
                        combatLossDialodue.SetActive(true);
                        break;
                    default:
                        break;
                }
            }

            if (playerProgress.gravyardCombatCompelte)
            {
                l1GraveyardCombat.SetActive(false);
                priest.SetActive(true);
            }

            if (playerProgress.gravyardTDialogCompelte)
            {
                l1GraveyardDialog.SetActive(false);
                tybalt.SetActive(true);
            }
        }
        else
        {
            graveyardExit.SetActive(false);

            // combat types
            if (playerModel.predictedPlayerType == "Completionist" || playerModel.predictedPlayerType == "Combat_CardGame_Enthusiast" ||
                playerModel.predictedPlayerType == "Combat_Dialogue_Enthusiast" || playerModel.predictedPlayerType == "Combat_Enthusiast_with_CardGame_Dialogue_Intrest" ||
                playerModel.predictedPlayerType == "Combat_Enthusiast_with_CardGame_Intrest" || playerModel.predictedPlayerType == "Combat_Enthusiast_with_Dialogue_Intrest" ||
                playerModel.predictedPlayerType == "Combat_Enthusiast")
            {
                activateMajorCombats = true;
                activateMinorCombats = true;

            }
            else if (playerModel.predictedPlayerType == "CardGame_Enthusiast_with_Combat_Dialogue_Intrest" || playerModel.predictedPlayerType == "Dialogue_Enthusiast_with_Combat_CardGame_Intrest" ||
                playerModel.predictedPlayerType == "CardGame_Enthusiast_with_Combat_Intrest" || playerModel.predictedPlayerType == "Dialogue_Enthusiast_with_Combat_Intrest" ||
                playerModel.predictedPlayerType == "Combat_CardGame_Dialogue_Intrested" || playerModel.predictedPlayerType == "Combat_Intrested")
            {
                activateMinorCombats = true;
            }

            // cardgame types
            if (playerModel.predictedPlayerType == "Completionist" || playerModel.predictedPlayerType == "Combat_CardGame_Enthusiast" ||
                playerModel.predictedPlayerType == "CardGame_Dialogue_Enthusiast" || playerModel.predictedPlayerType == "CardGame_Enthusiast_with_Combat_Dialogue_Intrest" ||
                playerModel.predictedPlayerType == "CardGame_Enthusiast_with_Combat_Intrest" || playerModel.predictedPlayerType == "CardGame_Enthusiast_with_Dialogue_Intrest" ||
                playerModel.predictedPlayerType == "CardGame_Enthusiast")
            {

                activateMajorCardGames = true;
                activateMinorCardGames = true;
            }
            else if (playerModel.predictedPlayerType == "Combat_CardGame_Dialogue_Intrested" || playerModel.predictedPlayerType == "CardGame_Intrested" ||
                playerModel.predictedPlayerType == "Combat_Enthusiast_with_CardGame_Dialogue_Intrest" || playerModel.predictedPlayerType == "Dialogue_Enthusiast_with_Combat_CardGame_Intrest" ||
                playerModel.predictedPlayerType == "Combat_Enthusiast_with_CardGame_Intrest" || playerModel.predictedPlayerType == "Dialogue_Enthusiast_with_CardGame_Intrest")
            {
                activateMinorCardGames = true;
            }

            // dialogue types
            if (playerModel.predictedPlayerType == "Completionist" || playerModel.predictedPlayerType == "CardGame_Dialogue_Enthusiast" ||
                playerModel.predictedPlayerType == "Combat_Dialogue_Enthusiast" || playerModel.predictedPlayerType == "Dialogue_Enthusiast_with_Combat_CardGame_Intrest" |
                playerModel.predictedPlayerType == "Dialogue_Enthusiast_with_CardGame_Intrest" || playerModel.predictedPlayerType == "Dialogue_Enthusiast_with_Combat_Intrest" ||
                playerModel.predictedPlayerType == "Dialogue_Enthusiast")
            {
                activateMajorDialogs = true;
                activateMinorDialogs = true;
            }
            else if (playerModel.predictedPlayerType == "Combat_CardGame_Dialogue_Intrested" || playerModel.predictedPlayerType == "Dialogue_Intrested" ||
                playerModel.predictedPlayerType == "Combat_Enthusiast_with_CardGame_Dialogue_Intrest" || playerModel.predictedPlayerType == "CardGame_Enthusiast_with_Combat_Dialogue_Intrest" ||
                playerModel.predictedPlayerType == "Combat_Enthusiast_with_Dialogue_Intrest" || playerModel.predictedPlayerType == "CardGame_Enthusiast_with_Dialogue_Intrest")
            {
                activateMinorDialogs = true;
            }

            l1GraveyardDialog.SetActive(false);
            tybalt.SetActive(false);
            l1GraveyardCombat.SetActive(false);
            priest.SetActive(false);
            churchBarriers.SetActive(false);

            if (!playerProgress.part2EndActive)
            {


                // check that the end has not started
                if (!playerProgress.part2EndActive)
                {
                    if (activateMajorDialogs)
                    {
                        if (!playerProgress.gravyardMDialogCompelte)
                        {
                            l2MercutioDialog.SetActive(true);
                        }
                        else
                        {
                            Mercutio.SetActive(true);
                        }
                    }
                }

                if (!activateMajorDialogs && !activateMajorCardGames && !activateMajorCombats
                    && !activateMinorDialogs && !activateMinorCardGames && !activateMinorCombats)
                {
                    JulietTybaltWarning.SetActive(true);
                }
                churchGate.SetActive(true);
            }
            else
            {
                churchGate.SetActive(false);           
                JulietTybaltWarning.SetActive(true);
            }


            if (romeoData.previousLocation == LevelLoader.Levels.Church)
            {
                player.transform.position = graveyardSpawnPoint.position;
                playerCam.transform.position = graveyardCamPos.position;
                playerCam.GetComponent<CamPlayerTracking>().trackingActive = false;
                player.GetComponent<SceneBasedPlayerControls>().TurnPlayerRight();
            }         
        }
    }
}
