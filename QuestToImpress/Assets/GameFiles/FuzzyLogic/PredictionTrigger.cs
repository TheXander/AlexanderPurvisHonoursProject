using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class PredictionTrigger : MonoBehaviour
{
    public PredictPlayerType fuzzyPlayerTypePredictor;
    public PlayerModel playerModel;
    bool triggered = false;

    // csv variables  
    string csvPlayerModelRecording;
    string csvPredictionHeaders =
            "PlayerID," +
            "Combats Engaged In, Combat Wins, Combats Avoided," +
            "Card Games Engaged In, Card Game Wins, Card Game Draws, Card Games Avoided," +
            "Dialog Engaged In, Dialog Avoided," +

            "Predicted Player Dialogue Preference," +
            "Predicted Player Dialogue Preference," +
            "Predicted Player Dialogue Preference," +

            "Predicted Player Type"
        ;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player" && !triggered)
        {
            TriggerPrediction();
            triggered = true;
        }
    }

    void TriggerPrediction()
    {     
        fuzzyPlayerTypePredictor.MakePrediction();
        SetPredictedPlayerStats();
        RecordPredictionResults();
        CreatePredictionResultsCSV();

        playerModel.deleteOldData();
        // Warning makes sure to call save player model data after this 
        playerModel.UpdateSavePlayerModelData();
    }

    void RecordPredictionResults()
    {
        csvPlayerModelRecording =

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

                   playerModel.predictedPlayerType;
    }

    void CreatePredictionResultsCSV()
    {
        string filename = Application.dataPath + "PredictionResults.csv";

        TextWriter tw = new StreamWriter(filename, true);
        tw.WriteLine(csvPredictionHeaders);
        tw.WriteLine(csvPlayerModelRecording);
        
        tw.Close();
    }

    void SetPredictedPlayerStats()
    {
        // assign Combat Preference
        string fuzzyPredictedCombatPreference = "";
        switch (fuzzyPlayerTypePredictor.playerCombatPreference)
        {
            case PredictPlayerType.PlayerPreferences.Enthusiastic:
                fuzzyPredictedCombatPreference = "Enthusiastic";
                break;
            case PredictPlayerType.PlayerPreferences.Interested:
                fuzzyPredictedCombatPreference = "Interested";
                break;
            case PredictPlayerType.PlayerPreferences.Uninterested:
                fuzzyPredictedCombatPreference = "Uninterested";
                break;
            case PredictPlayerType.PlayerPreferences.FaildToIdentified:
                fuzzyPredictedCombatPreference = "FaildToIdentified";
                break;
            case PredictPlayerType.PlayerPreferences.Unassigned:
                fuzzyPredictedCombatPreference = "Unassigned";
                break;
            default:
                fuzzyPredictedCombatPreference = "Error";
                break;
        }

        playerModel.predictedPlayerCombatPreference = fuzzyPredictedCombatPreference;

        // assign Care Game Preference
        string fuzzyPredictedCareGamePreference = "";

        switch (fuzzyPlayerTypePredictor.playerCareGamePreference)
        {
            case PredictPlayerType.PlayerPreferences.Enthusiastic:
                fuzzyPredictedCareGamePreference = "Enthusiastic";
                break;
            case PredictPlayerType.PlayerPreferences.Interested:
                fuzzyPredictedCareGamePreference = "Interested";
                break;
            case PredictPlayerType.PlayerPreferences.Uninterested:
                fuzzyPredictedCareGamePreference = "Uninterested";
                break;
            case PredictPlayerType.PlayerPreferences.FaildToIdentified:
                fuzzyPredictedCareGamePreference = "FaildToIdentified";
                break;
            case PredictPlayerType.PlayerPreferences.Unassigned:
                fuzzyPredictedCareGamePreference = "Unassigned";
                break;
            default:
                fuzzyPredictedCareGamePreference = "Error";
                break;
        }

        playerModel.predictedPlayerCareGamePreference = fuzzyPredictedCareGamePreference;

        // assign Dialogue Preference
        string fuzzyPredictedDialoguePreference = "";

        switch (fuzzyPlayerTypePredictor.playerDialoguePreference)
        {
            case PredictPlayerType.PlayerPreferences.Enthusiastic:
                fuzzyPredictedDialoguePreference = "Enthusiastic";
                break;
            case PredictPlayerType.PlayerPreferences.Interested:
                fuzzyPredictedDialoguePreference = "Interested";
                break;
            case PredictPlayerType.PlayerPreferences.Uninterested:
                fuzzyPredictedDialoguePreference = "Uninterested";
                break;
            case PredictPlayerType.PlayerPreferences.FaildToIdentified:
                fuzzyPredictedDialoguePreference = "FaildToIdentified";
                break;
            case PredictPlayerType.PlayerPreferences.Unassigned:
                fuzzyPredictedDialoguePreference = "Unassigned";
                break;
            default:
                fuzzyPredictedDialoguePreference = "Error";
                break;
        }

        playerModel.predictedPlayerDialoguePreference = fuzzyPredictedDialoguePreference;

        // assign Player Type
        string fuzzyPredictedPlayerType = "";

        switch (fuzzyPlayerTypePredictor.playerType)
        {
            case PredictPlayerType.PlayerTypes.Completionist:
                fuzzyPredictedPlayerType = "Completionist";
                break;
            case PredictPlayerType.PlayerTypes.SpeedRunner:
                fuzzyPredictedPlayerType = "SpeedRunner";
                break;
            case PredictPlayerType.PlayerTypes.Combat_CardGame_Enthusiast:
                fuzzyPredictedPlayerType = "Combat_CardGame_Enthusiast";
                break;
            case PredictPlayerType.PlayerTypes.Combat_Dialogue_Enthusiast:
                fuzzyPredictedPlayerType = "Combat_Dialogue_Enthusiast";
                break;
            case PredictPlayerType.PlayerTypes.CardGame_Dialogue_Enthusiast:
                fuzzyPredictedPlayerType = "CardGame_Dialogue_Enthusiast";
                break;
            case PredictPlayerType.PlayerTypes.Combat_Enthusiast_with_CardGame_Dialogue_Interest:
                fuzzyPredictedPlayerType = "Combat_Enthusiast_with_CardGame_Dialogue_Intrest";
                break;
            case PredictPlayerType.PlayerTypes.CardGame_Enthusiast_with_Combat_Dialogue_Interest:
                fuzzyPredictedPlayerType = "CardGame_Enthusiast_with_Combat_Dialogue_Intrest";
                break;
            case PredictPlayerType.PlayerTypes.Dialogue_Enthusiast_with_Combat_CardGame_Interest:
                fuzzyPredictedPlayerType = "Dialogue_Enthusiast_with_Combat_CardGame_Intrest";
                break;
            case PredictPlayerType.PlayerTypes.Combat_Enthusiast_with_CardGame_Intrest:
                fuzzyPredictedPlayerType = "Combat_Enthusiast_with_CardGame_Intrest";
                break;
            case PredictPlayerType.PlayerTypes.Combat_Enthusiast_with_Dialogue_Intrest:
                fuzzyPredictedPlayerType = "Combat_Enthusiast_with_Dialogue_Intrest";
                break;
            case PredictPlayerType.PlayerTypes.CardGame_Enthusiast_with_Combat_Intrest:
                fuzzyPredictedPlayerType = "CardGame_Enthusiast_with_Combat_Intrest";
                break;
            case PredictPlayerType.PlayerTypes.CardGame_Enthusiast_with_Dialogue_Intrest:
                fuzzyPredictedPlayerType = "CardGame_Enthusiast_with_Dialogue_Intrest";
                break;
            case PredictPlayerType.PlayerTypes.Dialogue_Enthusiast_with_Combat_Intrest:
                fuzzyPredictedPlayerType = "Dialogue_Enthusiast_with_Combat_Intrest";
                break;
            case PredictPlayerType.PlayerTypes.Dialogue_Enthusiast_with_CardGame_Intrest:
                fuzzyPredictedPlayerType = "Dialogue_Enthusiast_with_CardGame_Intrest";
                break;
            case PredictPlayerType.PlayerTypes.Combat_Enthusiast:
                fuzzyPredictedPlayerType = "Combat_Enthusiast";
                break;
            case PredictPlayerType.PlayerTypes.CardGame_Enthusiast:
                fuzzyPredictedPlayerType = "CardGame_Enthusiast";
                break;
            case PredictPlayerType.PlayerTypes.Dialogue_Enthusiast:
                fuzzyPredictedPlayerType = "Dialogue_Enthusiast";
                break;
            case PredictPlayerType.PlayerTypes.Combat_CardGame_Dialogue_Intrested:
                fuzzyPredictedPlayerType = "Combat_CardGame_Dialogue_Intrested";
                break;
            case PredictPlayerType.PlayerTypes.Combat_Intrested:
                fuzzyPredictedPlayerType = "Combat_Intrested";
                break;
            case PredictPlayerType.PlayerTypes.CardGame_Intrested:
                fuzzyPredictedPlayerType = "CardGame_Intrested";
                break;
            case PredictPlayerType.PlayerTypes.Dialogue_Intrested:
                fuzzyPredictedPlayerType = "Dialogue_Intrested";
                break;
            case PredictPlayerType.PlayerTypes.Disinterested:
                fuzzyPredictedPlayerType = "Disinterested";
                break;
            case PredictPlayerType.PlayerTypes.Unidentified:
                fuzzyPredictedPlayerType = "Unidentified";
                break;
            default:
                fuzzyPredictedPlayerType = "Error";
                break;
        }

        playerModel.predictedPlayerType = fuzzyPredictedPlayerType;

        //Debug.Log("Combat_Intrested is (" + playerModel.predictedPlayerCombatPreference + ") CardGame_Intrested is (" + playerModel.predictedPlayerCareGamePreference + ") Dialogue_Intrested is (" + playerModel.predictedPlayerDialoguePreference + ") Player type is " + playerModel.predictedPlayerType);
    }
}
