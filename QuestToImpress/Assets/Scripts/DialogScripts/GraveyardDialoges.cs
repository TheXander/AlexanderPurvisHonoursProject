using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class GraveyardDialoges : MonoBehaviour
{
    public GameObject romeoPortrait, mercutioPortrait, cultistPortrait, grocerPortrait, tybaltPortrait;
    public SceneBasedPlayerControls playerControls;
    public GameObject tybaltDialog, tybalt;

    // Dialogue Runner ivariable for yarn spinner control.
    public DialogueRunner dialogueRunner;
    public PlayerProgress playerProgress;

    public void Awake()
    {
        //show portraits
        dialogueRunner.AddCommandHandler<GameObject>(
            "DisplayRomeo",
            DisplayRomeo);

        dialogueRunner.AddCommandHandler<GameObject>(
            "DisplayMercutio",
            DisplayMercutio);

        dialogueRunner.AddCommandHandler<GameObject>(
         "DisplayCultist",
         DisplayCultist);

        dialogueRunner.AddCommandHandler<GameObject>(
            "DisplayGrocer",
            DisplayGrocer);

        dialogueRunner.AddCommandHandler<GameObject>(
           "DisplayTybalt",
           DisplayTybalt);
       
        //Hide portraits
        dialogueRunner.AddCommandHandler<GameObject>(
            "HideRomeo",
            HideRomeo);

        dialogueRunner.AddCommandHandler<GameObject>(
            "HideMercutio",
            HideMercutio);

        dialogueRunner.AddCommandHandler<GameObject>(
           "HideCardCultist",
            HideCardCultist);

        dialogueRunner.AddCommandHandler<GameObject>(
            "HideGrocer",
             HideGrocer);

        dialogueRunner.AddCommandHandler<GameObject>(
           "HideTybalt",
            HideTybalt);

        dialogueRunner.AddCommandHandler<GameObject>(
          "DeactivatePlayerMovment",
          DeactivatePlayerMovment);

        dialogueRunner.AddCommandHandler<GameObject>(
          "ReactivatePlayerMovment",
          ReactivatePlayerMovment);

        dialogueRunner.AddCommandHandler<GameObject>(
        "SignalPlayerToStartEvent",
        SignalPlayerToStartEvent
        );

        dialogueRunner.AddCommandHandler<GameObject>(
        "SignalPlayerEventOver",
        SignalPlayerEventOver
        );

        dialogueRunner.AddCommandHandler<GameObject>(
        "SwitchTybalt",
         SwitchTybalt
        );

        dialogueRunner.AddCommandHandler<GameObject>(
       "SetTybaltDialogueComplete",
        SetTybaltDialogueComplete
       );
    }

    void DisplayRomeo(GameObject Player)
    {
        romeoPortrait.SetActive(true);
    }

    void DisplayMercutio(GameObject Player)
    {
        mercutioPortrait.SetActive(true);
    }
    void DisplayCultist(GameObject Player)
    {
        cultistPortrait.SetActive(true);
    }
    void DisplayGrocer(GameObject Player)
    {
        grocerPortrait.SetActive(true);
    }
    void DisplayTybalt(GameObject Player)
    {
        tybaltPortrait.SetActive(true);
    }

    void HideRomeo(GameObject Player)
    {
        romeoPortrait.SetActive(false);
    }

    void HideMercutio(GameObject Player)
    {
        mercutioPortrait.SetActive(false);
    }

    void HideCardCultist(GameObject Player)
    {
        cultistPortrait.SetActive(false);
    }

    void HideGrocer(GameObject Player)
    {       
        grocerPortrait.SetActive(false);
    }

    void HideTybalt(GameObject Player)
    {
        tybaltPortrait.SetActive(false);
    }

    // player interactions

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

    void SwitchTybalt(GameObject Player)
    {
        tybalt.SetActive(true);
        tybaltDialog.SetActive(false);
    }

    void SetTybaltDialogueComplete(GameObject Player)
    {
        playerProgress.gravyardTDialogCompelte = true;
        playerProgress.levelOneEventsComplete++;
    }
}
