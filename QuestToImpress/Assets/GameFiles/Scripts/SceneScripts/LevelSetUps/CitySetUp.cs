using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CitySetUp : MonoBehaviour
{

    // bools for control of set up
    bool activateMajorCardGames = false;
    public PlayerModel playerModel;


    //graveyard
    public Transform graveyardSpawnPoint;
    public Transform graveyardCamPos;
    
    //forest
    public Transform forestSpawnPoint;
    public Transform forestCamPos;

    //tavern
    public Transform tavernSpawnPoint;
    public Transform tavernCamPos;

    //lake
    public Transform lakeSpawnPoint;
    public Transform lakeCamPos;

    //juliets
    public Transform julietsSpawnPoint;
    public Transform julietsCamPos;

    // main menu
    public Transform mainMenuSpawnPoint;
    public Transform mainMenuCamPos;

    public RomeoData romeoData;
    public PlayerEventResults eventResults;
    public GameObject player;
    public Camera playerCam;

    // tutorial 
    public GameObject levelOneBarriers;
    public GameObject JulietBarriers;

    // progress
    public PlayerProgress playerProgress;

    public GameObject l1CityCardGame;
    public GameObject cityKnight;

    public GameObject townNPCs;
    public GameObject cardWinResultDialogue, cardLossResultDialogue, cardDrawResultDialogue;

    public GameObject cardWinResultDialogueL2, cardLossResultDialogueL2, cardDrawResultDialogueL2;
    
    public InstructionsManager instructionsManager;
    public MapManager mapManager;

    public PostToutorialScreenControls postToutorialScreenControls;

    public GameObject wagonBarrier;
    public GameObject julietGate;

    public GameObject tavernGate;
    public GameObject tavernSign;

    public GameObject forestGate;
    public GameObject forestSign;

    public GameObject cardgameGhoul;


    private void Awake()
    {
        if (!playerProgress.part2Active)
        {
            //Part 1 city setUp 
            switch (romeoData.previousLocation)
            {
                case LevelLoader.Levels.Graveyard:
                    player.transform.position = graveyardSpawnPoint.position;
                    playerCam.transform.position = graveyardCamPos.position;
                    playerCam.GetComponent<CamPlayerTracking>().trackingActive = false;
                    break;
                case LevelLoader.Levels.Forest:
                    player.transform.position = forestSpawnPoint.position;
                    playerCam.transform.position = forestCamPos.position;
                    playerCam.GetComponent<CamPlayerTracking>().trackingActive = true;
                    break;
                case LevelLoader.Levels.Tavern:
                    player.transform.position = tavernSpawnPoint.position;
                    playerCam.transform.position = tavernCamPos.position;
                    playerCam.GetComponent<CamPlayerTracking>().trackingActive = true;
                    break;
                case LevelLoader.Levels.Lake:
                    player.transform.position = lakeSpawnPoint.position;
                    playerCam.transform.position = lakeCamPos.position;
                    playerCam.GetComponent<CamPlayerTracking>().trackingActive = true;
                    postToutorialScreenControls.OpenPostToutorialScreen();
                    player.GetComponent<SceneBasedPlayerControls>().LockPlayerMovement();
                    break;
                case LevelLoader.Levels.Juliets:

                    // if leaving juliets before talking with her           
                    player.transform.position = julietsSpawnPoint.position;
                    playerCam.transform.position = julietsCamPos.position;
                    playerCam.GetComponent<CamPlayerTracking>().trackingActive = false;
                    player.GetComponent<SceneBasedPlayerControls>().TurnPlayerLeft();
                    JulietBarriers.SetActive(false);

                    break;
                case LevelLoader.Levels.MainMenu:
                    player.transform.position = mainMenuSpawnPoint.position;
                    playerCam.transform.position = mainMenuCamPos.position;
                    playerCam.GetComponent<CamPlayerTracking>().trackingActive = true;
                    levelOneBarriers.SetActive(true);
                    JulietBarriers.SetActive(false);
                    townNPCs.SetActive(false);

                    instructionsManager.preTotorial = true;
                    mapManager.preTutorial = true;
                    break;
                default:

                    break;
            }

            // card game result Dialoge
            if (romeoData.previousLocation == LevelLoader.Levels.CardGame)
            {
                cityKnight.SetActive(true);

                switch (eventResults.cityCardGame)
                {
                    case PlayerEventResults.EventResults.Win:
                        cardWinResultDialogue.SetActive(true);
                        break;
                    case PlayerEventResults.EventResults.Loss:
                        cardLossResultDialogue.SetActive(true);
                        break;
                    case PlayerEventResults.EventResults.Draw:
                        cardDrawResultDialogue.SetActive(true);
                        break;
                    default:
                        break;
                }
            }

            // progress
            if (playerProgress.cityCardGameComplete)
            {
                l1CityCardGame.SetActive(false);
            }

        }
        else
        {
            JulietBarriers.SetActive(true);
            wagonBarrier.SetActive(false);
            julietGate.SetActive(false);

            l1CityCardGame.SetActive(false);
            cityKnight.SetActive(false);
            tavernGate.SetActive(false);
            tavernSign.SetActive(false);
            forestGate.SetActive(false);
            forestSign.SetActive(false);

            // cardgame types
            if (playerModel.predictedPlayerType == "Completionist" || playerModel.predictedPlayerType == "Combat_CardGame_Enthusiast" ||
                playerModel.predictedPlayerType == "CardGame_Dialogue_Enthusiast" || playerModel.predictedPlayerType == "CardGame_Enthusiast_with_Combat_Dialogue_Intrest" ||
                playerModel.predictedPlayerType == "CardGame_Enthusiast_with_Combat_Intrest" || playerModel.predictedPlayerType == "CardGame_Enthusiast_with_Dialogue_Intrest" ||
                playerModel.predictedPlayerType == "CardGame_Enthusiast")
            {

                activateMajorCardGames = true;
                Debug.Log("activateMajorCardGames");
            }

            if (activateMajorCardGames)
            {
                Debug.Log("adding ghoul");
                cardgameGhoul.SetActive(true);
            }
            

            //Part 2 city setUp 
            switch (romeoData.previousLocation)
            {

                case LevelLoader.Levels.Juliets:
                    // if leaving juliets before talking with her           
                    player.transform.position = julietsSpawnPoint.position;
                    playerCam.transform.position = julietsCamPos.position;
                    playerCam.GetComponent<CamPlayerTracking>().trackingActive = false;
                    player.GetComponent<SceneBasedPlayerControls>().TurnPlayerLeft();

                    break;
                case LevelLoader.Levels.Graveyard:
                    player.transform.position = graveyardSpawnPoint.position;
                    playerCam.transform.position = graveyardCamPos.position;
                    playerCam.GetComponent<CamPlayerTracking>().trackingActive = false;

                    break;

                default:

                    break;
            }

            // card game result Dialoge
            if (romeoData.previousLocation == LevelLoader.Levels.CardGame)
            {
                
                cardgameGhoul.SetActive(false);

                switch (eventResults.cityCardGame)
                {
                    case PlayerEventResults.EventResults.Win:
                        cardWinResultDialogueL2.SetActive(true);
                        break;
                    case PlayerEventResults.EventResults.Loss:
                        cardLossResultDialogueL2.SetActive(true);
                        break;
                    case PlayerEventResults.EventResults.Draw:
                        cardDrawResultDialogueL2.SetActive(true);
                        break;
                    default:
                        break;
                }
            }
        }
    }

    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Equals))
        {
            //levelOneBarriers.SetActive(false);
        }
    }
}
