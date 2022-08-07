using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class GraveyardDialoges : MonoBehaviour
{
    public Bonuses bonusManagment;

    public GameObject romeoPortrait, mercutioPortrait, cultistPortrait, grocerPortrait, tybaltPortrait;
    public SceneBasedPlayerControls playerControls;
    public GameObject tybaltDialog, tybalt;
    public GameObject l2MercutioDialog, Mercutio;

    public GameObject relic1, relic2, relic3;
    public GameObject relicsCompleted;

    // Dialogue Runner ivariable for yarn spinner control.
    public DialogueRunner dialogueRunner;
    public PlayerProgress playerProgress;

    public PlayerModel playerModel;
    bool talkingToCardGame = false;

    // for mecutio poem
    bool line1Chosen, line2Chosen;
    bool line3Chosen, line4Chosen;

    public Animator julietAnimator;

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

        // level 2 stuff
        dialogueRunner.AddCommandHandler<GameObject>(
       "SetMercutioDialogueComplete",
        SetMercutioDialogueComplete
       );

        // m convo
        dialogueRunner.AddCommandHandler<GameObject>(
      "ActivateRelic1",
       ActivateRelic1
      );
        dialogueRunner.AddCommandHandler<GameObject>(
      "ActivateRelic2",
       ActivateRelic2
      );
        dialogueRunner.AddCommandHandler<GameObject>(
      "ActivateRelic3",
       ActivateRelic3
      );

       dialogueRunner.AddCommandHandler<GameObject>(
        "CompleteRelics",
         CompleteRelics
        );

       dialogueRunner.AddCommandHandler<GameObject>(
        "chosePoemOption1",
         chosePoemOption1
        );

       dialogueRunner.AddCommandHandler<GameObject>(
        "chosePoemOption2",
         chosePoemOption2
        );

       dialogueRunner.AddCommandHandler<GameObject>(
        "chosePoemOption3",
         chosePoemOption3
        );

       dialogueRunner.AddCommandHandler<GameObject>(
        "chosePoemOption4",
         chosePoemOption4
        );


        dialogueRunner.AddCommandHandler<GameObject>(
         "ProducePoemn",
          ProducePoemn
         );


        dialogueRunner.AddCommandHandler<GameObject>(
         "ResolveRelecs",
          ResolveRelecs
         );

        dialogueRunner.AddCommandHandler<GameObject>(
         "MoveJulietToTown",
          MoveJulietToTown
         );
    }

    void MoveJulietToTown(GameObject Player)
    {
        julietAnimator.SetTrigger("RunToTown");
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
        talkingToCardGame = false;
    }
    void DisplayGrocer(GameObject Player)
    {
        grocerPortrait.SetActive(true);
    }
    void DisplayTybalt(GameObject Player)
    {
        tybaltPortrait.SetActive(true);
        talkingToCardGame = true;
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

        if (talkingToCardGame)
        {
            //----------Record in player model-------------
            playerModel.NewDialogueEngagement();
            playerModel.StandardUpdate(true, "Graveyard");
        }
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

    void SetMercutioDialogueComplete(GameObject Player)
    {
        playerProgress.gravyardMDialogCompelte = true;
        l2MercutioDialog.SetActive(false);
        Mercutio.SetActive(true);
    }


    void ActivateRelic1(GameObject Player)
    {
        relic1.SetActive(true);
    }
    void ActivateRelic2(GameObject Player)
    {
        relic2.SetActive(true);
    }
    void ActivateRelic3(GameObject Player)
    {
        relic3.SetActive(true);
    }

    void CompleteRelics(GameObject Player)
    {
        relicsCompleted.SetActive(true);
    }


    void chosePoemOption1(GameObject Player)
    {
        line1Chosen = true;
    }
    void chosePoemOption2(GameObject Player)
    {
        line2Chosen = true;
    }
    void chosePoemOption3(GameObject Player)
    {
        line3Chosen = true;
    }
    void chosePoemOption4(GameObject Player)
    {
        line4Chosen = true;
    }


    void ProducePoemn(GameObject Player)
    {
        StartCoroutine(RecitePoem());
    }

    IEnumerator RecitePoem()
    {    
        yield return new WaitForSeconds(1.2f);

        if (line1Chosen && line3Chosen)
        {
            dialogueRunner.StartDialogue("RecitePoemV1");
        }
        if (line1Chosen && line4Chosen)
        {
            dialogueRunner.StartDialogue("RecitePoemV2");
        }
        if (line2Chosen && line3Chosen)
        {
            dialogueRunner.StartDialogue("RecitePoemV3");
        }
        if (line2Chosen && line4Chosen)
        {
            dialogueRunner.StartDialogue("RecitePoemV4");
        }
    }


    void ResolveRelecs(GameObject Player)
    {
        StartCoroutine(RelicBlessing());
    }

    IEnumerator RelicBlessing()
    {
        yield return new WaitForSeconds(1.4f);

        if (playerModel.predictedPlayerType == "Completionist")
        {
            // combat and card game bonus
            dialogueRunner.StartDialogue("BlessingCombatAndCardGame");
            bonusManagment.attackBonus += 5;
            bonusManagment.healthBonus += 5;
            bonusManagment.honourBonus += 5;
        }
        else if (playerModel.predictedPlayerType == "Combat_Dialogue_Enthusiast")
        {
            // combat bonus
            dialogueRunner.StartDialogue("BlessingCombat");
            bonusManagment.attackBonus += 5;
            bonusManagment.healthBonus += 5;
        }
        else if(playerModel.predictedPlayerType == "CardGame_Dialogue_Enthusiast")
        {
            // card game bonus
            dialogueRunner.StartDialogue("BlessingCardGame");
        }
        else if(playerModel.predictedPlayerType == "Dialogue_Enthusiast_with_Combat_CardGame_Intrest")
        {
            // combat and card game bonus
            dialogueRunner.StartDialogue("BlessingCombatAndCardGame");
            bonusManagment.attackBonus += 5;
            bonusManagment.healthBonus += 5;
            bonusManagment.honourBonus += 5;
        }
        else if (playerModel.predictedPlayerType == "Dialogue_Enthusiast_with_CardGame_Intrest")
        {
            //card game bonus
            dialogueRunner.StartDialogue("BlessingCardGame");
        }
        else if (playerModel.predictedPlayerType == "Dialogue_Enthusiast_with_Combat_Intrest")
        {
            // combat bonus
            dialogueRunner.StartDialogue("BlessingCombat");
            bonusManagment.attackBonus += 5;
            bonusManagment.healthBonus += 5;
        }
        else
        {
            // Defalt End
            dialogueRunner.StartDialogue("BlessingDefault");
        }

    }
}
