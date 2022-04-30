using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class JulietsHouseDialoges : MonoBehaviour
{

    public GameObject romeoPortrait, julietPortrait;
    public SceneBasedPlayerControls playerControls;

    // Dialogue Runner ivariable for yarn spinner control.
    public DialogueRunner dialogueRunner;

    public void Awake()
    {
        //show portraits
        dialogueRunner.AddCommandHandler<GameObject>(
            "DisplayRomeo",
            DisplayRomeo
            );

        dialogueRunner.AddCommandHandler<GameObject>(
           "DisplayJuliet",
           DisplayJuliet
           );

        //Hide portraits
        dialogueRunner.AddCommandHandler<GameObject>(
            "HideRomeo",
            HideRomeo
            );

        dialogueRunner.AddCommandHandler<GameObject>(
            "HideJuliet",
            HideJuliet
            );


        dialogueRunner.AddCommandHandler<GameObject>(
          "DeactivatePlayerMovment",
          DeactivatePlayerMovment
          );

        dialogueRunner.AddCommandHandler<GameObject>(
          "ReactivatePlayerMovment",
          ReactivatePlayerMovment
          );

        dialogueRunner.AddCommandHandler<GameObject>(
         "SignalPlayerToStartEvent",
         SignalPlayerToStartEvent
         );

        dialogueRunner.AddCommandHandler<GameObject>(
        "SignalPlayerEventOver",
        SignalPlayerEventOver
        );   
    }

    // Show Portraits
    void DisplayRomeo(GameObject Player)
    {
        romeoPortrait.SetActive(true);
    }

    void DisplayJuliet(GameObject Player)
    {
        julietPortrait.SetActive(true);
    }

   
    // Hide Portraits
    void HideRomeo(GameObject Player)
    {
        romeoPortrait.SetActive(false);
    }
 
    void HideJuliet(GameObject Player)
    {
        julietPortrait.SetActive(false);
    }
  
    //player control interactions
    void DeactivatePlayerMovment(GameObject Player)
    {
        playerControls.StopPlayer();
    }

    void ReactivatePlayerMovment(GameObject Player)
    {
        playerControls.StartPlayer();
    }

    void SignalPlayerToStartEvent(GameObject Player)
    {
        playerControls.eventConfirmed = true;
    }

    void SignalPlayerEventOver(GameObject Player)
    {
        playerControls.eventReady = false;
        playerControls.confirmingEvent = false;
        playerControls.eventConfirmed = false;
    }  
}
