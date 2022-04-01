using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraveyardSetUp : MonoBehaviour
{
    //church 
    public Transform graveyardSpawnPoint;
    public Transform graveyardCamPos;

    public RomeoData romeoData;
    public GameObject player;
    public Camera playerCam;

    private void Awake()
    {
        if (romeoData.previousLocation == LevelLoader.Levels.Church)
        {
            player.transform.position = graveyardSpawnPoint.position;
            playerCam.transform.position = graveyardCamPos.position;
            playerCam.GetComponent<CamPlayerTracking>().trackingActive = false;
            player.GetComponent<PlayerMovement>().TurnPlayerRight();
        }
    }
}
