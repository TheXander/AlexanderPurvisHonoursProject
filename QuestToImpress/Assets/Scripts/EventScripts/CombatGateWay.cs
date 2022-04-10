using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatGateWay : MonoBehaviour
{
    public PlayerMovement playerScript;
    LevelLoader.Levels destination = LevelLoader.Levels.Combat;
    public LevelLoader.Levels gatewayOrigin;
    public RomeoData romeoData;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            playerScript.newDestination = destination;
            romeoData.previousLocation = gatewayOrigin;
            romeoData.currentLocation = destination;
            romeoData.currentEvent = RomeoData.Events.Combat;
            playerScript.locationSet = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            romeoData.currentEvent = RomeoData.Events.None;
            playerScript.locationSet = false;
        }
    }
}
