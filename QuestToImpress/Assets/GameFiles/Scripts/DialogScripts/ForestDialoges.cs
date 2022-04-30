using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class ForestDialoges : MonoBehaviour
{
    public GameObject romeoPortrait, mercutioPortrait, samuraiPortrait,
        redHoodPortrait, ghoulPortrait, vaiPortrait, huntressPortrait;
    public SceneBasedPlayerControls playerControls;

    // Dialogue Runner ivariable for yarn spinner control.
    public DialogueRunner dialogueRunner;

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
             "DisplaySamurai",
             DisplaySamurai);

        dialogueRunner.AddCommandHandler<GameObject>(
            "DisplayRedHood",
            DisplayRedHood);

        dialogueRunner.AddCommandHandler<GameObject>(
             "DisplayGhoul",
            DisplayGhoul);

        dialogueRunner.AddCommandHandler<GameObject>(
             "DisplayVai",
             DisplayVai);

        dialogueRunner.AddCommandHandler<GameObject>(
            "DisplayHuntress",
             DisplayHuntress);
    
        //Hide portraits
        dialogueRunner.AddCommandHandler<GameObject>(
            "HideRomeo",
            HideRomeo);

        dialogueRunner.AddCommandHandler<GameObject>(
            "HideMercutio",
            HideMercutio);
        
        dialogueRunner.AddCommandHandler<GameObject>(
            "HideSamurai",
            HideSamurai);

        dialogueRunner.AddCommandHandler<GameObject>(
            "HideRedHood",
             HideRedHood);

        dialogueRunner.AddCommandHandler<GameObject>(
             "HideGhoul",
             HideGhoul);

        dialogueRunner.AddCommandHandler<GameObject>(
            "HideVai",
            HideVai);

        dialogueRunner.AddCommandHandler<GameObject>(
             "HideHuntress",
             HideHuntress);

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
    }


    void DisplayRomeo(GameObject Player)
    {
        romeoPortrait.SetActive(true);
    }

    void DisplayMercutio(GameObject Player)
    {
        mercutioPortrait.SetActive(true);
    }

    void DisplaySamurai(GameObject Player)
    {
        samuraiPortrait.SetActive(true);
    }

    void DisplayRedHood(GameObject Player)
    {
        redHoodPortrait.SetActive(true);
    }

    void DisplayGhoul(GameObject Player)
    {
        ghoulPortrait.SetActive(true);
    }

    void DisplayVai(GameObject Player)
    {
        vaiPortrait.SetActive(true);
    }

    void DisplayHuntress(GameObject Player)
    {
        huntressPortrait.SetActive(true);
    }


    // hide   
    void HideRomeo(GameObject Player)
    {
        romeoPortrait.SetActive(false);
    }

    void HideMercutio(GameObject Player)
    {
        mercutioPortrait.SetActive(false);
    }

    void HideSamurai(GameObject Player)
    {
        samuraiPortrait.SetActive(false);
    }

    void HideRedHood(GameObject Player)
    {
        redHoodPortrait.SetActive(false);
    }

    void HideGhoul(GameObject Player)
    {
        ghoulPortrait.SetActive(false);
    }

    void HideVai(GameObject Player)
    {
        vaiPortrait.SetActive(false);
    }

    void HideHuntress(GameObject Player)
    {
        huntressPortrait.SetActive(false);
    }

    void DeactivatePlayerMovment(GameObject Player)
    {
        playerControls.StopPlayer();
    }

    void ReactivatePlayerMovment(GameObject Player)
    {
        playerControls.StartPlayer();
    }

    // player interactions
    void SignalPlayerToStartEvent(GameObject Player)
    {
        playerControls.eventConfirmed = true;
    }
}
