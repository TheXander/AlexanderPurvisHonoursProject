using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class CombatGateWay : MonoBehaviour
{
    public SceneBasedPlayerControls playerScript;
    LevelLoader.Levels destination = LevelLoader.Levels.Combat;
    public RomeoData.CombatEvents combatOponent;
    public LevelLoader.Levels gatewayOrigin;
    public RomeoData romeoData;

    // dialogue
    public SceneBasedPlayerControls playerControls;
    public DialogueRunner dialogueRunner;
    public string conversationStartNode;
    bool triggered = false;

    // Update is called once per frame
    void Update()
    {
        if (playerControls.eventReady && triggered && !playerControls.confirmingEvent)
        {
            playerControls.confirmingEvent = true;
            dialogueRunner.StartDialogue(conversationStartNode);
        }    
    }



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
            playerControls.confirmingEvent = false;
            Debug.Log(romeoData.currentEvent);
            
            if (!triggered)
            {
                triggered = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            romeoData.CurrentCombat = RomeoData.CombatEvents.None;
            romeoData.currentEvent = RomeoData.Events.None;
            playerScript.locationSet = false;
            triggered = false;
        }
    }
}
