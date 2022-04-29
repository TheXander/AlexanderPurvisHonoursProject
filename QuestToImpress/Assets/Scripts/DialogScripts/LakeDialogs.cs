using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;


public class LakeDialogs : MonoBehaviour
{
    public GameObject romeoPortrait, mercutioPortrait, lakeKnightPortrait;
    public SceneBasedPlayerControls playerControls;
    public Animator mercutioAnimator;
    public Animator lakeKnightAnimator;
    public Animator postCastleMercutioAnimator;


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

        dialogueRunner.AddCommandHandler<GameObject>(
           "DisplayLakeKnight",
           DisplayLakeKnight
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
            "HideLakeKnight",
            HideLakeKnight
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
          "MoveMercutioToCastle",
          MoveMercutioToCastle
          );

        dialogueRunner.AddCommandHandler<GameObject>(
        "MoveMercutioToCity",
        MoveMercutioToCity
        );
        
        dialogueRunner.AddCommandHandler<GameObject>(
         "MoveLakeKnightToCastle",
          MoveLakeKnightToCastle
          );

        
        dialogueRunner.AddCommandHandler<GameObject>(
         "SignalPlayerToStartEvent",
         SignalPlayerToStartEvent
         );      
    }

    // Show Portraits
    void DisplayRomeo(GameObject Player)
    {
        romeoPortrait.SetActive(true);
    }

    void DisplayMercutio(GameObject Player)
    {
        mercutioPortrait.SetActive(true);
    }

    void DisplayLakeKnight(GameObject Player)
    {
        lakeKnightPortrait.SetActive(true);
    }

    // Hide Portraits
    void HideRomeo(GameObject Player)
    {
        romeoPortrait.SetActive(false);
    }

    void HideMercutio(GameObject Player)
    {
        mercutioPortrait.SetActive(false);
    }

    void HideLakeKnight(GameObject Player)
    {
        lakeKnightPortrait.SetActive(false);
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

    //animation triggers
    void MoveMercutioToCastle(GameObject Player)
    {
        mercutioAnimator.SetTrigger("RunToCastle");
    }
    void MoveMercutioToCity(GameObject Player)
    {
        postCastleMercutioAnimator.SetTrigger("RunToCity");
    }
    void MoveLakeKnightToCastle(GameObject Player)
    {
        lakeKnightAnimator.SetTrigger("RunToCastle");
    }
  
    // player interactions
    void SignalPlayerToStartEvent(GameObject Player)
    {
        playerControls.eventConfirmed = true;
    }
}
