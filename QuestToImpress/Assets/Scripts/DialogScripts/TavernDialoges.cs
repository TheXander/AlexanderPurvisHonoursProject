using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class TavernDialoges : MonoBehaviour
{
    public GameObject romeoPortrait, mercutioPortrait, tavernFighterPortrait,
        vikingPortrait, barkeeperPortrait;
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
