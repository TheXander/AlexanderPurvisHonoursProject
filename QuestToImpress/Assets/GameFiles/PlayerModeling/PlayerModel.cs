using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
// Created by ALexander Purvis copyright Alexander Purvis
[CreateAssetMenu]
public class PlayerModel : ScriptableObject
{
    // Data
    // player ID Made up of day month year hour minute and seconds - column 1
    [SerializeField]
    string playerID = "";

    [SerializeField]
    string csvHeaderPlayerID = "";

    // game state data - column 2 to 4
    [SerializeField]
    string time = "";
    [SerializeField]
    bool gameRunning = false;
    [SerializeField]
    string currentLocation = "";

    // Combat Event data - column 5 to 7
    [SerializeField]
    public int combatsEngagedIn = 0;
    [SerializeField]
    public int combatWins = 0;
    [SerializeField]
    public int combatsAvoided = 0;

    // Card game Event data - column 8 to 11
    [SerializeField]
    public int cardGamesEngagedIn = 0;
    [SerializeField]
    public int cardGameWins = 0;
    [SerializeField]
    public int cardGameDraws = 0;
    [SerializeField]
    public int cardGamesAvoided = 0;

    // Dialog Event data - column 12 to 13
    [SerializeField]
    public int dialogueEngagedIn = 0;
    [SerializeField]
    public int dialogueAvoided = 0;

    [SerializeField]
    List<string> csvPlayerModelRecordings = new List<string>();

    // CSVFile data
    string filename = "Error";
    string headers = "PlayerID," +
            "Time Stamp, Game Running, Current Location," +
            "Combats Engaged In, Combat Wins, Combats Avoided," +
            "Card Games Engaged In, Card Game Wins, Card Game Draws, Card Games Avoided," +
            "Dialog Engaged In, Dialog Avoided";

    // reset
    public void resetScriptableObject()
    {   
        playerID = "";
        csvHeaderPlayerID = "";
        time = "";    
        gameRunning = false;      
        currentLocation = "";            
        combatsEngagedIn = 0;       
        combatWins = 0;
        combatsAvoided = 0;
  
        cardGamesEngagedIn = 0;
        cardGameWins = 0;
        cardGameDraws = 0;
        cardGamesAvoided = 0;

        dialogueEngagedIn = 0;
        dialogueAvoided = 0;

        // CSVFile data
         filename = "Error";
         headers = "PlayerID," +
                "Time Stamp, Game Running, Current Location," +
                "Combats Engaged In, Combat Wins, Combats Avoided," +
                "Card Games Engaged In, Card Game Wins, Card Game Draws, Card Games Avoided," +
                "Dialog Engaged In, Dialog Avoided";

        csvPlayerModelRecordings.Clear();
    }

    // --Setters--
    // game state data
    public void StandardUpdate(bool GameState, string location)
    {
        time = System.DateTime.UtcNow.ToLocalTime().ToString("HH:mm");
        gameRunning = GameState;
        currentLocation = location;
        UpdatePlayerModelRecords();
    }

    public void LastUpdate(string location)
    {
        time = System.DateTime.UtcNow.ToLocalTime().ToString("HH:mm");
        gameRunning = false;
        currentLocation = location;
        UpdatePlayerModelRecords();
        WriteToCSV();
    }


    // Created by ALexander Purvis copyright Alexander Purvis
    // Combat Event data
    public void NewCombatEngagement(bool playerWon)
    {
        combatsEngagedIn++;

        if (playerWon)
        {
            combatWins++;
        }
    }

    public void NewCombatAvoided()
    {
        combatsAvoided++;
    }

    // Card Game Event data

    public void NewCardGameEngagement(bool playerWon, bool playerDrew)
    {       
        cardGamesEngagedIn++;

        if (playerWon)
        {
            cardGameWins++;
        }
        else if (playerDrew)
        {
            cardGameDraws++;
        }
    }

    public void NewCardGameAvoided()
    {
        cardGamesAvoided++;
    }

    // dialogue Event data
    public void NewDialogueEngagement()
    {
        dialogueEngagedIn++;
    }

    public void NewDialogueAvoided()
    {
        dialogueAvoided++;
    }
  
    // -----------------CSVFile Functions-----------------------------
    // called first in main menu to begin the file
    public void CreateBlankPlayerModel()
    {
        resetScriptableObject();
        CreatePlayerID();
    }

    void CreatePlayerID()
    {
        // Create Player ID from date and time of game launch down to the second
        playerID = System.DateTime.UtcNow.ToLocalTime().ToString("dd-MM-yyyyHH:mm:ss");
        // remove anything thats not a number so peeps dont catch on and call me out on it
        playerID = playerID.Remove(15,1);
        playerID = playerID.Remove(12,1);
        playerID = playerID.Remove(5,1);
        playerID = playerID.Remove(2,1);

        csvHeaderPlayerID = playerID;
       
        playerID = playerID.Insert(0, "|");
        playerID = playerID.Insert(15, "|");
    }


    public void UpdatePlayerModelRecords()
    {
        string newModelRecord =
                playerID + "," +
                    time + "," +
                    gameRunning + "," +
                    currentLocation + "," +
                     combatsEngagedIn + "," +
                     combatWins + "," +
                     combatsAvoided + "," +
                     cardGamesEngagedIn + "," +
                     cardGameWins + "," +
                     cardGameDraws + "," +
                     cardGamesAvoided + "," +
                     dialogueEngagedIn + "," +
                     dialogueAvoided;
        csvPlayerModelRecordings.Add(newModelRecord);
        Debug.Log(newModelRecord);
    }


    void WriteToCSV()
    {
        filename = Application.dataPath + "Player" + csvHeaderPlayerID + " PlayerModel.csv";
  
        TextWriter tw = new StreamWriter(filename, true);
        tw.WriteLine(headers);
       
        foreach (string record in csvPlayerModelRecordings) 
        {
            tw.WriteLine(record);
        }
        tw.Close();
    }
}
