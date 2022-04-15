using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;


public class LakeDialogs : MonoBehaviour
{
    public GameObject romeoPortrait, mercutioPortrait;
    public SceneBasedPlayerControls playerControls;
    public Animator mercutioAnimator;

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
            "DisplayMercutio",
            DisplayMercutio
            );

        //Hide portraits
        dialogueRunner.AddCommandHandler<GameObject>(
            "HideRomeo",
            HideRomeo
            );

        dialogueRunner.AddCommandHandler<GameObject>(
            "HideMercutio",
            HideMercutio
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
          "MoveMercutioToLake",
          MoveMercutioToLake
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

    void HideRomeo(GameObject Player)
    {
        romeoPortrait.SetActive(false);
    }

    void HideMercutio(GameObject Player)
    {
        mercutioPortrait.SetActive(false);
    }

    void DeactivatePlayerMovment(GameObject Player)
    {
        playerControls.StopPlayer();
    }

    void ReactivatePlayerMovment(GameObject Player)
    {
        playerControls.StartPlayer();
    }

    void MoveMercutioToLake(GameObject Player)
    {
        mercutioAnimator.SetTrigger("RunToLake");
    }
}
