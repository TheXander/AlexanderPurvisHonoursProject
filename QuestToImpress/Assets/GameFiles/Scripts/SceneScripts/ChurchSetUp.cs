using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class ChurchSetUp : MonoBehaviour
{
    public PlayerProgress playerProgress;
    public PlayerModel playerModel;
    public GameObject player;
    public RomeoData romeoData;
    public GameObject combat, evilSpirit;
    public GameObject dialogue;
    public GameObject priestEndingDialogue, priestFighting;
    public GameObject endingTriggerDialogue;
    public DialogueRunner dialogueRunner;
    public PlayerEventResults eventResults;

    public Transform postCombatPoint;

    // bools for control of set up
     bool activateMinorCombats, activateMajorCombats = false;
     bool activateMinorDialogs, activateMajorDialogs = false;


    // Start is called before the first frame update
    void Start()
    {
        // combat types
        if (playerModel.predictedPlayerType == "Completionist" || playerModel.predictedPlayerType == "Combat_CardGame_Enthusiast" ||
            playerModel.predictedPlayerType == "Combat_Dialogue_Enthusiast" || playerModel.predictedPlayerType == "Combat_Enthusiast_with_CardGame_Dialogue_Intrest" ||
            playerModel.predictedPlayerType == "Combat_Enthusiast_with_CardGame_Intrest" || playerModel.predictedPlayerType == "Combat_Enthusiast_with_Dialogue_Intrest" ||
            playerModel.predictedPlayerType == "Combat_Enthusiast")
        {
            activateMajorCombats = true;
            activateMinorCombats = true;

        }
        else if (playerModel.predictedPlayerType == "CardGame_Enthusiast_with_Combat_Dialogue_Intrest" || playerModel.predictedPlayerType == "Dialogue_Enthusiast_with_Combat_CardGame_Intrest" ||
            playerModel.predictedPlayerType == "CardGame_Enthusiast_with_Combat_Intrest" || playerModel.predictedPlayerType ==  "Dialogue_Enthusiast_with_Combat_Intrest" ||
            playerModel.predictedPlayerType == "Combat_CardGame_Dialogue_Intrested" || playerModel.predictedPlayerType == "Combat_Intrested")
        {
            activateMinorCombats = true;
        }

        
        // dialogue types
        if (playerModel.predictedPlayerType == "Completionist" || playerModel.predictedPlayerType == "CardGame_Dialogue_Enthusiast" ||
            playerModel.predictedPlayerType == "Combat_Dialogue_Enthusiast"|| playerModel.predictedPlayerType == "Dialogue_Enthusiast_with_Combat_CardGame_Intrest" |
            playerModel.predictedPlayerType == "Dialogue_Enthusiast_with_CardGame_Intrest" || playerModel.predictedPlayerType == "Dialogue_Enthusiast_with_Combat_Intrest" || 
            playerModel.predictedPlayerType == "Dialogue_Enthusiast")
        {
            activateMajorDialogs = true;
            activateMinorDialogs = true;
        }
        else if (playerModel.predictedPlayerType == "Combat_CardGame_Dialogue_Intrested" || playerModel.predictedPlayerType == "Dialogue_Intrested"||
            playerModel.predictedPlayerType == "Combat_Enthusiast_with_CardGame_Dialogue_Intrest" || playerModel.predictedPlayerType == "CardGame_Enthusiast_with_Combat_Dialogue_Intrest"||
            playerModel.predictedPlayerType == "Combat_Enthusiast_with_Dialogue_Intrest" || playerModel.predictedPlayerType == "CardGame_Enthusiast_with_Dialogue_Intrest")
        {
            activateMinorDialogs = true;
        }






        if (activateMajorCombats == true || activateMinorCombats)
        {           
            if (!playerProgress.churchCombatCompelte)
            {
                if (activateMinorDialogs == true || activateMajorDialogs == true)
                {
                    dialogue.SetActive(true);
                }
                else
                {
                    priestFighting.SetActive(true);
                }

                combat.SetActive(true);             
            }
            else
            {       
                player.transform.position = postCombatPoint.transform.position;
                priestEndingDialogue.SetActive(true);
                priestFighting.SetActive(false);
                evilSpirit.SetActive(true);
                if (eventResults.churchCombat == PlayerEventResults.EventResults.Win)
                {                   
                    StartCoroutine(RunWinDialogue());                  
                }
                else
                {             
                    StartCoroutine(RunLossDialogue());            
                }             
            }
        }
        else
        {
            priestEndingDialogue.SetActive(true);
        }


        //// if the player meets the dialoge intrested critearea then turn on the church precombat dialogue 
        //if (activateMajorDialogs == true)
        //{
        //    if (!playerProgress.churchCombatCompelte)
        //    {
        //        dialogue.SetActive(true);
        //    }
        //}
        //else if (activateMajorCombats == false)
        //{
           
        //}
    }


    IEnumerator RunWinDialogue()
    {     
        yield return new WaitForSeconds(1.0f);
        dialogueRunner.StartDialogue("EvilSpiritCombatWin");
    }

    IEnumerator RunLossDialogue()
    {
        yield return new WaitForSeconds(1.0f);
        dialogueRunner.StartDialogue("EvilSpiritCombatLoss");
    }
}
