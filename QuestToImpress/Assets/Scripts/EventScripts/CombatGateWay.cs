using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatGateWay : MonoBehaviour
{
    public SceneBasedPlayerControls playerScript;
    LevelLoader.Levels destination = LevelLoader.Levels.Combat;
    public RomeoData.CombatEvents combatOponent;
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
            romeoData.CurrentCombat = combatOponent;
            playerScript.locationSet = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            romeoData.CurrentCombat = RomeoData.CombatEvents.None;
            romeoData.currentEvent = RomeoData.Events.None;
            playerScript.locationSet = false;
        }
    }
}
