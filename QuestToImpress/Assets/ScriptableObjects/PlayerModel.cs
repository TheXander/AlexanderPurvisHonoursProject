using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[CreateAssetMenu]
[System.Serializable]
public class PlayerModel : ScriptableObject
{

    // CSVFile data
    string filename = "Player Model";
    string headers = "PlayerID," +
            "Time Stamp, Game Running, Current Location," +
            "Combats Engaged In, Combat Wins, Combats Avoided," +
            "Card Games Engaged In, Card Game Wins, Card Game Draws, Card Games Avoided," +
            "Dialog Engaged In, Dialog Avoided";

    // Data

    // player ID Made up of day month year hour minute and seconds - column 1
    string playerID = "";

    // game state data - column 2 to 4
    string time = "";
    bool gameRunning = false;
    string currentLocation = "";

    // Combat Event data - column 5 to 7
    public int combatsEngagedIn = 0;
    public int combatWins = 0;
    public int combatsAvoided = 0;

    // Card game Event data - column 8 to 11
    public int cardGamesEngagedIn = 0;
    public int cardGameWins = 0;
    public int cardGameDraws = 0;
    public int cardGamesAvoided = 0;

    // Dialog Event data - column 12 to 13
    public int dialogueEngagedIn = 0;
    public int dialogueAvoided = 0;

    // --Setters--
  
    // game state data
    public void StandardUpdate(bool GameState, string location)
    {
        time = System.DateTime.UtcNow.ToLocalTime().ToString("HH:mm");
        gameRunning = GameState;
        currentLocation = location;
    }

    // Combat Event data
    public void NewCombatEngagement(bool playerWon)
    {
        combatsEngagedIn++;

        if (playerWon)
        {
            combatWins++;
        }

        WriteToCSV();
    }

    public void NewCombatAvoided()
    {
        combatsAvoided++;

        WriteToCSV();
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

        WriteToCSV();
    }

    public void NewCardGameAvoided()
    {
        cardGamesAvoided++;

        WriteToCSV();
    }


    // dialogue Event data
    public void NewDialogueEngagement()
    {
        dialogueEngagedIn++;

        WriteToCSV();
    }

    public void NewDialogueAvoided()
    {
        dialogueAvoided++;

        WriteToCSV();
    }

    public void Print()
    {
        Debug.Log("---------Player Model---------");


        Debug.Log("PlayerID = " + playerID);

        Debug.Log("Time = " + time);
        Debug.Log("GameRunning = " + gameRunning);
        Debug.Log("CurrentLocation = " + currentLocation);

        Debug.Log("Combat Wins = " + combatWins);
        Debug.Log("Combats Engaged In = " + combatsEngagedIn);
        Debug.Log("Combats Avoided = " + combatsAvoided);

        Debug.Log("card game Wins = " + cardGameWins);
        Debug.Log("card game draws = " + cardGameDraws);
        Debug.Log("card games Engaged In = " + cardGamesEngagedIn);
        Debug.Log("card games Avoided = " + cardGamesAvoided);

        Debug.Log("dialogue Engaged In = " + dialogueEngagedIn);
        Debug.Log("dialogue Avoided = " + dialogueAvoided);


        Debug.Log("------------------------------");
    }

    // -----------------CSVFile Functions-----------------------------

    // called first in main menu to begin the file
    public void CreateFile()
    {
        ClearAllData();
        CreateUniqueEnoughPlayerID();

        filename = Application.dataPath + "/Player " + playerID + " PlayerModel.csv";
        TextWriter tw = new StreamWriter(filename, false);
        tw.WriteLine(headers);
        tw.Close();

        playerID = playerID.Insert(0, "|");
        playerID = playerID.Insert(15, "|");

        // first write to csv
        StandardUpdate(true, "Main Menu");
        WriteToCSV();
    }


    void CreateUniqueEnoughPlayerID()
    {
        // Create Player ID from date and time of game launch down to the second
        playerID = System.DateTime.UtcNow.ToLocalTime().ToString("dd-MM-yyyyHH:mm:ss");
        // remove anything thats not a number so peeps dont catch on and call me out on it
        playerID = playerID.Remove(15,1);
        playerID = playerID.Remove(12,1);
        playerID = playerID.Remove(5,1);
        playerID = playerID.Remove(2,1);
    }

    void ClearAllData()
    {
       // player ID Made up of day month year hour minute and seconds - column 1
       playerID = "";

       // game state data - column 2 to 4
       time = "";
       gameRunning = false;
       currentLocation = "";

       // Combat Event data - column 5 to 7
       combatsEngagedIn = 0;
       combatWins = 0;
       combatsAvoided = 0;

       // Card game Event data - column 8 to 11
       cardGamesEngagedIn = 0;
       cardGameWins = 0;
       cardGameDraws = 0;
       cardGamesAvoided = 0;

       // Dialog Event data - column 12 to 13
       dialogueEngagedIn = 0;
       dialogueAvoided = 0;
    }




    public void WriteToCSV()
    {
        TextWriter tw = new StreamWriter(filename, true);

        tw.WriteLine(playerID + "," +
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
             dialogueAvoided);

        tw.Close();            
    }

}
