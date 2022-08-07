using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class ChurchDialoges : MonoBehaviour
{
    public RomeoData romeoData;

    public GameObject romeoPortrait, mercutioPortrait, evilSpirtPortrait, priestPortrait;
    public SceneBasedPlayerControls playerControls;
    public PlayerProgress playerProgress;
    // Dialogue Runner ivariable for yarn spinner control.
    public DialogueRunner dialogueRunner;
    public GameObject clericFighting, clericIdel, clericPreCombat, clericEnding;
    public GameObject evilSpirtCombat, evilSpirtIdel;

    public Animator spiritAnimator;

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
           "DisplayEvilSpirt",
           DisplayEvilSpirt);

        dialogueRunner.AddCommandHandler<GameObject>(
           "DisplayPriest",
           DisplayPriest);

        //Hide portraits
        dialogueRunner.AddCommandHandler<GameObject>(
            "HideRomeo",
            HideRomeo);

        dialogueRunner.AddCommandHandler<GameObject>(
            "HideMercutio",
            HideMercutio);

        dialogueRunner.AddCommandHandler<GameObject>(
           "HideEvilSpirt",
           HideEvilSpirt);

        dialogueRunner.AddCommandHandler<GameObject>(
           "HidePriest",
           HidePriest);

        dialogueRunner.AddCommandHandler<GameObject>(
          "DeactivatePlayerMovment",
          DeactivatePlayerMovment);

        dialogueRunner.AddCommandHandler<GameObject>(
          "ReactivatePlayerMovment",
          ReactivatePlayerMovment);

        dialogueRunner.AddCommandHandler<GameObject>(
         "SignalPlayerToStartEvent",
         SignalPlayerToStartEvent);

        dialogueRunner.AddCommandHandler<GameObject>(
            "TurnOnClericIdel",
            TurnOnClericIdel);

        dialogueRunner.AddCommandHandler<GameObject>(
            "TurnOnClericFighting",
            TurnOnClericFighting);

        dialogueRunner.AddCommandHandler<GameObject>(
            "TurnOnClericEnding",
             TurnOnClericEnding);

        dialogueRunner.AddCommandHandler<GameObject>(
           "TurnOnClericPreCombat",
            TurnOnClericPreCombat);

        dialogueRunner.AddCommandHandler<GameObject>(
            "TurnOffClericIdel",
             TurnOffClericIdel);

        dialogueRunner.AddCommandHandler<GameObject>(
            "TurnOffClericFighting",
            TurnOffClericFighting);

        dialogueRunner.AddCommandHandler<GameObject>(
            "TurnOffClericEnding",
             TurnOffClericEnding);

        dialogueRunner.AddCommandHandler<GameObject>(
           "TurnOffClericPreCombat",
            TurnOffClericPreCombat);

        dialogueRunner.AddCommandHandler<GameObject>(
          "TurnOnEvilSpiritIdel",
           TurnOnEvilSpiritIdel);

        dialogueRunner.AddCommandHandler<GameObject>(
          "TurnOffEvilSpiritIdel",
           TurnOffEvilSpiritIdel);

        dialogueRunner.AddCommandHandler<GameObject>(
         "TurnOffEvilSpiritCombat",
          TurnOffEvilSpiritCombat);

        dialogueRunner.AddCommandHandler<GameObject>(
         "VanishEvilSpiritIdel",
          VanishEvilSpiritIdel);

        dialogueRunner.AddCommandHandler<GameObject>(
        "StartGameEnding",
         StartGameEnding);

        dialogueRunner.AddCommandHandler<GameObject>(
       "SignalPlayerEventOver",
        SignalPlayerEventOver);
    }


    void SignalPlayerToStartEvent(GameObject Player)
    {
        romeoData.currentEvent = RomeoData.Events.Combat;
        playerControls.locationSet = true;
        playerControls.eventConfirmed = true;
    }

    void SignalPlayerEventOver(GameObject Player)
    {
        romeoData.currentEvent = RomeoData.Events.None;
        playerControls.eventReady = false;
        playerControls.confirmingEvent = false;
        playerControls.eventConfirmed = false;
        playerControls.locationSet = false;
    }

    void StartGameEnding(GameObject Player)
    {
        playerProgress.part2EndActive = true;
    }

    void VanishEvilSpiritIdel(GameObject Player)
    {
        spiritAnimator.SetTrigger("Disappear");
        playerControls.TurnPlayerRight();
    }

    void TurnOnEvilSpiritIdel(GameObject Player)
    {
        evilSpirtIdel.SetActive(true);
    }
    void TurnOffEvilSpiritIdel(GameObject Player)
    {
        evilSpirtIdel.SetActive(false);
    }

    void TurnOffEvilSpiritCombat(GameObject Player)
    {
        evilSpirtCombat.SetActive(false);
    }

    void TurnOnClericEnding(GameObject Player)
    {
        clericEnding.SetActive(true);
    }

    void TurnOnClericFighting(GameObject Player)
    {
        clericFighting.SetActive(true);
    }

    void TurnOnClericIdel(GameObject Player)
    {
        clericIdel.SetActive(true);
    }

    void TurnOnClericPreCombat(GameObject Player)
    {
        clericPreCombat.SetActive(true);
    }

    void TurnOffClericEnding(GameObject Player)
    {
        clericEnding.SetActive(false);
    }

    void TurnOffClericFighting(GameObject Player)
    {
        clericFighting.SetActive(false);
    }

    void TurnOffClericIdel(GameObject Player)
    {
        clericIdel.SetActive(false);
    }
    
    void TurnOffClericPreCombat(GameObject Player)
    {
        clericPreCombat.SetActive(false);
    }

    void DisplayRomeo(GameObject Player)
    {
        romeoPortrait.SetActive(true);
    }

    void DisplayMercutio(GameObject Player)
    {
        mercutioPortrait.SetActive(true);
    }

    void DisplayEvilSpirt(GameObject Player)
    {
        evilSpirtPortrait.SetActive(true);
    }

    void DisplayPriest(GameObject Player)
    {
        priestPortrait.SetActive(true);
    }

    void HideRomeo(GameObject Player)
    {
        romeoPortrait.SetActive(false);
    }

    void HideMercutio(GameObject Player)
    {
        mercutioPortrait.SetActive(false);
    }

    void HideEvilSpirt(GameObject Player)
    {
        evilSpirtPortrait.SetActive(false);
    }

    void HidePriest(GameObject Player)
    {
        priestPortrait.SetActive(false);
    }

    void DeactivatePlayerMovment(GameObject Player)
    {
        playerControls.StopPlayer();
    }

    void ReactivatePlayerMovment(GameObject Player)
    {
        playerControls.StartPlayer();
    }
}
