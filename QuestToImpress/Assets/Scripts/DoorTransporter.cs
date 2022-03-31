using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTransporter : MonoBehaviour
{
    public PlayerMovement playerScript;
    public LevelLoader.Levels doorDestination;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            playerScript.newDestination = doorDestination;
            playerScript.locationSet = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        playerScript.locationSet = false;
    }
}
