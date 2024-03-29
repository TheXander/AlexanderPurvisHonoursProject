﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTransporter : MonoBehaviour
{
    public SceneBasedPlayerControls playerScript;
    public LevelLoader.Levels doorDestination;
    public LevelLoader.Levels gatewayOrigin;
    public RomeoData romeoData;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            playerScript.newDestination = doorDestination;
            romeoData.previousLocation = gatewayOrigin;
            romeoData.currentLocation = doorDestination;
            playerScript.locationSet = true;
            romeoData.currentEvent = RomeoData.Events.None;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            playerScript.locationSet = false;
        }
    }
}
