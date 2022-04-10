using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LakeSetUp : MonoBehaviour
{
    //castle 
    public Transform castleSpawnPoint;
    public Transform castleCamPos;

    public RomeoData romeoData;
    public GameObject player;
    public Camera playerCam;

    private void Awake()
    {
        if (romeoData.previousLocation == LevelLoader.Levels.Castle)
        {
            player.transform.position = castleSpawnPoint.position;
            playerCam.transform.position = castleCamPos.position;
            playerCam.GetComponent<CamPlayerTracking>().trackingActive = false;
            player.GetComponent<PlayerMovement>().TurnPlayerLeft();
        }
    }
}
