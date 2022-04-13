using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CitySetUp : MonoBehaviour
{
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
    public GameObject player;
    public Camera playerCam;

    // tutorial 
    public GameObject levelOneBarriers;

    // progress
    public PlayerProgress playerProgress;

    public GameObject l1CityCardGame;
    public GameObject cityKnight;

    private void Awake()
    {
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
                break;
            case LevelLoader.Levels.Juliets:
                player.transform.position = julietsSpawnPoint.position;
                playerCam.transform.position = julietsCamPos.position;
                playerCam.GetComponent<CamPlayerTracking>().trackingActive = false;
                player.GetComponent<SceneBasedPlayerControls>().TurnPlayerLeft();
                break;
            case LevelLoader.Levels.MainMenu:
                player.transform.position = mainMenuSpawnPoint.position;
                playerCam.transform.position = mainMenuCamPos.position;
                playerCam.GetComponent<CamPlayerTracking>().trackingActive = true;
                levelOneBarriers.SetActive(true);
                break;
            default:
               
                break;
        }

        // progress
        if (playerProgress.cityCardGameComplete)
        {
            l1CityCardGame.SetActive(false);
            cityKnight.SetActive(true);
        }      
    }
}
