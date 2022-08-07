using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using System;
using System.IO;


public class JulietDialogueTrigger : MonoBehaviour
{
    public PlayerModel playerModel;
    public PlayerProgress playerProgress;
    public DialogueRunner dialogueRunner;
    public GameObject exitBarrier;
    public string conversationStartNode;
    bool triggered = false;

    // bools for control of set up
    bool activateMajorCombats = false;
    bool activateMajorCardGames = false;
    bool activateMajorDialogs = false;

    string csvPredictionHeaders =
           "PlayerID," +
           "Combats Engaged In, Combat Wins, Combats Avoided," +
           "Card Games Engaged In, Card Game Wins, Card Game Draws, Card Games Avoided," +
           "Dialog Engaged In, Dialog Avoided," +

           "Predicted Player Dialogue Preference," +
           "Predicted Player Dialogue Preference," +
           "Predicted Player Dialogue Preference," +

           "Predicted Player Type," +
           "Changes Made"
       ;

    string changesMade = "";

    public void Start()
    {
        // combat types
        if (playerModel.predictedPlayerType == "Completionist" || playerModel.predictedPlayerType == "Combat_CardGame_Enthusiast" ||
            playerModel.predictedPlayerType == "Combat_Dialogue_Enthusiast" || playerModel.predictedPlayerType == "Combat_Enthusiast_with_CardGame_Dialogue_Intrest" ||
            playerModel.predictedPlayerType == "Combat_Enthusiast_with_CardGame_Intrest" || playerModel.predictedPlayerType == "Combat_Enthusiast_with_Dialogue_Intrest" ||
            playerModel.predictedPlayerType == "Combat_Enthusiast")
        {
            activateMajorCombats = true;         
        }
       
        // cardgame types
        if (playerModel.predictedPlayerType == "Completionist" || playerModel.predictedPlayerType == "Combat_CardGame_Enthusiast" ||
            playerModel.predictedPlayerType == "CardGame_Dialogue_Enthusiast" || playerModel.predictedPlayerType == "CardGame_Enthusiast_with_Combat_Dialogue_Intrest" ||
            playerModel.predictedPlayerType == "CardGame_Enthusiast_with_Combat_Intrest" || playerModel.predictedPlayerType == "CardGame_Enthusiast_with_Dialogue_Intrest" ||
            playerModel.predictedPlayerType == "CardGame_Enthusiast")
        {
            activateMajorCardGames = true;       
        }

        // dialogue types
        if (playerModel.predictedPlayerType == "Completionist" || playerModel.predictedPlayerType == "CardGame_Dialogue_Enthusiast" ||
            playerModel.predictedPlayerType == "Combat_Dialogue_Enthusiast" || playerModel.predictedPlayerType == "Dialogue_Enthusiast_with_Combat_CardGame_Intrest" |
            playerModel.predictedPlayerType == "Dialogue_Enthusiast_with_CardGame_Intrest" || playerModel.predictedPlayerType == "Dialogue_Enthusiast_with_Combat_Intrest" ||
            playerModel.predictedPlayerType == "Dialogue_Enthusiast")
        {
            activateMajorDialogs = true;       
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!triggered)
        {
            triggered = true;         
            playerModel.LastUpdate("JulietsHouse");
            playerProgress.part2Active = true;
            exitBarrier.SetActive(false);

            if (playerModel.predictedPlayerType == "Completionist")
            {
                dialogueRunner.StartDialogue("JulietCompletionist");
                changesMade = "As a Completionist it was determind that you wished see all of the games content so all content was made avalible to you";
            }
            else if (playerModel.predictedPlayerType == "SpeedRunner")
            {
                changesMade = "As a speed runner it was determind that you wished to get through the game as fast as possible so the game was made shorter";

                dialogueRunner.StartDialogue("JulietSpeedRun");
                playerProgress.part2EndActive = true;
            }
            else if (playerModel.predictedPlayerType == "Disinterested")
            {
                dialogueRunner.StartDialogue("JulietDisinterested");
                playerProgress.part2EndActive = true;

            }
            else if (playerModel.predictedPlayerType == "Combat_CardGame_Dialogue_Intrested")
            {
                dialogueRunner.StartDialogue("JulietIntrested");
            }
            else if (activateMajorCombats && activateMajorCardGames)
            {
                dialogueRunner.StartDialogue("JulietMajorCombatsMajorCardGames");
            }
            else if (activateMajorCardGames && activateMajorDialogs)
            {
                dialogueRunner.StartDialogue("JulietsMajorCardGamesMajorDialogs");
            }
            else if (activateMajorCombats && activateMajorDialogs)
            {
                dialogueRunner.StartDialogue("JulietsMajorCombatsMajorDialogs");
            }
            else if (activateMajorCombats)
            {
                dialogueRunner.StartDialogue("JulietMajorCombats");
            }
            else if (activateMajorCardGames)
            {
                dialogueRunner.StartDialogue("JulietMajorCardGames");
            }
            else if (activateMajorDialogs)
            {
                dialogueRunner.StartDialogue("JulietMajorDialogs");
            }
            else
            {
                dialogueRunner.StartDialogue(conversationStartNode);
                playerProgress.part2EndActive = true;
            }         
        }

        recordPrediction();
    }

    void recordPrediction()
    {

        if (activateMajorCombats)
        {
            changesMade += " Because of your enthusiasm for combat more combats was added and npcs talk about you intrest in combat and juliet gave you a combat related gift";
        }
        if (activateMajorCardGames)
        {
            changesMade += " Because of your enthusiasm for card games more card games was added and npcs talk about you intrest in card games and juliet gave you a card game related gift";
        }
        if (activateMajorDialogs)
        {
            changesMade += " Because of your enthusiasm for dialog more dialog was added and npcs talk about you intrest in combat and juliet gave you a dialogue related gift";
        }
        if (activateMajorCombats && activateMajorDialogs)
        {
            changesMade += " Because of you enjoyed combat and dialog scenes where add so that you can talk about the combat";
        }

        string newModelRecord =
              playerModel.playerID + "," +
                   playerModel.combatsEngagedIn + "," +
                   playerModel.combatWins + "," +
                   playerModel.combatsAvoided + "," +
                   playerModel.cardGamesEngagedIn + "," +
                   playerModel.cardGameWins + "," +
                   playerModel.cardGameDraws + "," +
                   playerModel.cardGamesAvoided + "," +
                   playerModel.dialogueEngagedIn + "," +
                   playerModel.dialogueAvoided + "," +
                   playerModel.predictedPlayerCombatPreference + "," +
                   playerModel.predictedPlayerCareGamePreference + "," +
                   playerModel.predictedPlayerDialoguePreference + "," +
                   playerModel.predictedPlayerType + "," +
                   changesMade;


        string filename = Application.dataPath + "YourPredictionResults.csv";

        TextWriter tw = new StreamWriter(filename, true);
        tw.WriteLine(csvPredictionHeaders);      
        tw.WriteLine(newModelRecord);      
        tw.Close();
    }
}
