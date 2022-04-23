using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class CastleDialogeHandler : MonoBehaviour
{
    public GameObject romeoPortrait, mercutioPortrait, julietPortrait, castleKnightPortrait, kingPortrait;
    public GameObject julietDialogeEvent, juliet;
    public SceneBasedPlayerControls playerControls;
    public CastleKnightControls knightControls;

    public RomeoData romeoData;
    public LevelLoader levelLoader;

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
           "DisplayJuliet",
           DisplayJuliet
           );

        dialogueRunner.AddCommandHandler<GameObject>(
           "DisplayCastleKnight",
           DisplayCastleKnight
           );

        dialogueRunner.AddCommandHandler<GameObject>(
           "DisplayKing",
           DisplayKing
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
            "HideJuliet",
            HideJuliet
            );

        dialogueRunner.AddCommandHandler<GameObject>(
            "HideCastleKnight",
             HideCastleKnight
             );

        dialogueRunner.AddCommandHandler<GameObject>(
            "HideKing",
            HideKing
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

        // events
        dialogueRunner.AddCommandHandler<GameObject>(
         "ActivateCastleKnight",
         ActivateCastleKnight
        );

         dialogueRunner.AddCommandHandler<GameObject>(
         "SwitchJuliets",
         SwitchJuliets
         );

        dialogueRunner.AddCommandHandler<GameObject>(
        "LeaveCastle",
        LeaveCastle
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

    void DisplayJuliet(GameObject Player)
    {
        julietPortrait.SetActive(true);
    }

    void DisplayCastleKnight(GameObject Player)
    {
        castleKnightPortrait.SetActive(true);
    }

    void DisplayKing(GameObject Player)
    {
        kingPortrait.SetActive(true);
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

    void HideJuliet(GameObject Player)
    {
        julietPortrait.SetActive(false);
    }

    void HideCastleKnight(GameObject Player)
    {
        castleKnightPortrait.SetActive(false);
    }

    void HideKing(GameObject Player)
    {
        kingPortrait.SetActive(false);
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


    void ActivateCastleKnight(GameObject Player)
    {
        knightControls.MovePreCombatKnightToPlayer();
    }

    void SwitchJuliets(GameObject Player)
    {
        juliet.SetActive(true);
        julietDialogeEvent.SetActive(false);
    }

    void LeaveCastle(GameObject Player)
    {
        romeoData.previousLocation = LevelLoader.Levels.Castle;
        romeoData.currentLocation = LevelLoader.Levels.Lake;
        levelLoader.LoadLevel(LevelLoader.Levels.Lake);
    }
}
