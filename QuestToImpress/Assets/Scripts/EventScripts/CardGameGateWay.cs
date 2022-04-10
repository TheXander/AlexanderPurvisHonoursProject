using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardGameGateWay : MonoBehaviour
{
    public PlayerMovement playerScript;
    LevelLoader.Levels destination = LevelLoader.Levels.CardGame;
    public LevelLoader.Levels gatewayOrigin;
    public RomeoData romeoData;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            playerScript.newDestination = destination;
            romeoData.previousLocation = gatewayOrigin;
            romeoData.currentLocation = destination;
            romeoData.currentEvent = RomeoData.Events.CardGame;
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
