﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class TavernDialoges : MonoBehaviour
{
    public GameObject romeoPortrait, mercutioPortrait, tavernFighterPortrait,
        vikingPortrait, barkeeperPortrait;
    public SceneBasedPlayerControls playerControls;
    public GameObject barkeepDialog, barkeep;

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
           "DisplayTavernFighter",
           DisplayTavernFighter);

        dialogueRunner.AddCommandHandler<GameObject>(
           "DisplayViking",
           DisplayViking);

        dialogueRunner.AddCommandHandler<GameObject>(
           "DisplayBarkeep",
           DisplayBarkeep);

        //Hide portraits
        dialogueRunner.AddCommandHandler<GameObject>(
            "HideRomeo",
            HideRomeo);

        dialogueRunner.AddCommandHandler<GameObject>(
            "HideMercutio",
            HideMercutio);

        dialogueRunner.AddCommandHandler<GameObject>(
           "HideTavernFighter",
           HideTavernFighter);

        dialogueRunner.AddCommandHandler<GameObject>(
           "HideViking",
           HideViking);

        dialogueRunner.AddCommandHandler<GameObject>(
          "HideBarkeep",
          HideBarkeep);

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
        "SwitchBarkeep",
        SwitchBarkeep
        );

        dialogueRunner.AddCommandHandler<GameObject>(
        "SignalPlayerEventOver",
        SignalPlayerEventOver
        );

        dialogueRunner.AddCommandHandler<GameObject>(
        "SetBarmanDialogueComplete",
         SetBarmanDialogueComplete
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

    void DisplayTavernFighter(GameObject Player)
    {
        tavernFighterPortrait.SetActive(true);
    }

    void DisplayViking(GameObject Player)
    {
        vikingPortrait.SetActive(true);
    }

    void DisplayBarkeep(GameObject Player)
    {
        barkeeperPortrait.SetActive(true);
    }

    void HideRomeo(GameObject Player)
    {
        romeoPortrait.SetActive(false);
    }

    void HideMercutio(GameObject Player)
    {
        mercutioPortrait.SetActive(false);
    }

    void HideTavernFighter(GameObject Player)
    {
        tavernFighterPortrait.SetActive(false);
    }

    void HideViking(GameObject Player)
    {
        vikingPortrait.SetActive(false);
    }

    void HideBarkeep(GameObject Player)
    {
        barkeeperPortrait.SetActive(false);
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

    void SwitchBarkeep(GameObject Player)
    {
        barkeep.SetActive(true);
        barkeepDialog.SetActive(false);
    }

    void SetBarmanDialogueComplete(GameObject Player)
    {
        playerProgress.tavernDialogCompelte = true;
        playerProgress.levelOneEventsComplete++;
    }
}
