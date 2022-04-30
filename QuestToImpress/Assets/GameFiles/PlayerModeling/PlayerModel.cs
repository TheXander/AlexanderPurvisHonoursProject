using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[CreateAssetMenu]
public class PlayerModel : ScriptableObject
{
    // Data

    // player ID Made up of day month year hour minute and seconds - column 1
    [SerializeField]
    string playerID = "";

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

    // CSVFile data
    string filename = "Player Model";
    string headers = "PlayerID," +
            "Time Stamp, Game Running, Current Location," +
            "Combats Engaged In, Combat Wins, Combats Avoided," +
            "Card Games Engaged In, Card Game Wins, Card Game Draws, Card Games Avoided," +
            "Dialog Engaged In, Dialog Avoided";

    // --Setters--

    // game state data
    public void StandardUpdate(bool GameState, string location)
    {
        Debug.Log("StandardUpdate ");

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
        Debug.LogWarning("dialogueEngagedIn++ ");
        dialogueEngagedIn++;

        WriteToCSV();
    }

    public void NewDialogueAvoided()
    {
        dialogueAvoided++;

        WriteToCSV();
    }

    
    // -----------------CSVFile Functions-----------------------------

    // called first in main menu to begin the file
    public void CreateFile()
    {
        ClearAllData();
        CreateUniqueEnoughPlayerID();

       // filename = Application.dataPath + "/Player " + playerID + " PlayerModel.csv";
        filename = Application.dataPath + "/PlayerModel.csv";
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
        filename = Application.dataPath + "/PlayerModel.csv";

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
