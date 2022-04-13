using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraveyardSetUp : MonoBehaviour
{
    public PlayerProgress playerProgress;

    //church 
    public Transform graveyardSpawnPoint;
    public Transform graveyardCamPos;

    public RomeoData romeoData;
    public GameObject player;
    public Camera playerCam;

    public GameObject l1GraveyardCombat, l1GraveyardDialog;
    public GameObject tybalt, priest;


    private void Awake()
    {
        if (romeoData.previousLocation == LevelLoader.Levels.Church)
        {
            player.transform.position = graveyardSpawnPoint.position;
            playerCam.transform.position = graveyardCamPos.position;
            playerCam.GetComponent<CamPlayerTracking>().trackingActive = false;
            player.GetComponent<SceneBasedPlayerControls>().TurnPlayerRight();
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
}
