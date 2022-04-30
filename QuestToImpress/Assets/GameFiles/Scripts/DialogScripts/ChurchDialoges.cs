using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class ChurchDialoges : MonoBehaviour
{
    public GameObject romeoPortrait, mercutioPortrait, evilSpirtPortrait, priestPortrait;
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

    // player interactions
    void SignalPlayerToStartEvent(GameObject Player)
    {
        playerControls.eventConfirmed = true;
    }
}
