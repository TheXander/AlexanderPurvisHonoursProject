using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

[CreateAssetMenu]
public class SaveDataManager : ScriptableObject
{
    // Player Model Save
    public PlayerModelSaveData activePlayerModelSave;
    public PlayerModel playerModel;
    public string saveName = "playerModelGameData4";
//-------------------------- Save Load and Delete player model data -----------------------------------------------
    public void SavePlayerModelData()
    {
        activePlayerModelSave.saveName = saveName;
        string dataPath = Application.persistentDataPath;

        if (System.IO.File.Exists(dataPath + "/" + saveName + ".save"))
        {
            var serializer = new XmlSerializer(typeof(PlayerModelSaveData));
            var stream = new FileStream(dataPath + "/" + saveName + ".save", FileMode.Open);
            serializer.Serialize(stream, activePlayerModelSave);
            stream.Close();
        }
        else
        {
            var serializer = new XmlSerializer(typeof(PlayerModelSaveData));
            var stream = new FileStream(dataPath + "/" + saveName + ".save", FileMode.Create);
            serializer.Serialize(stream, activePlayerModelSave);
            stream.Close();
        }
    }

    public void DeletePlayerModelData()
    {
        activePlayerModelSave.saveName = saveName;
        string dataPath = Application.persistentDataPath;

        if (System.IO.File.Exists(dataPath + "/" + saveName + ".save"))
        {
            File.Delete(dataPath + "/" + saveName + ".save");
        }
    }

    public void LoadPlayerModelData()
    {
        activePlayerModelSave.saveName = saveName;
        string dataPath = Application.persistentDataPath;

        if (System.IO.File.Exists(dataPath + "/" + saveName + ".save"))
        {        
            var serializer = new XmlSerializer(typeof(PlayerModelSaveData));
            var stream = new FileStream(dataPath + "/" + saveName + ".save", FileMode.Open);
            activePlayerModelSave = serializer.Deserialize(stream) as PlayerModelSaveData;
            stream.Close();
            RefreshPlayerModelData();
        }
    }

    // data refreshing functions
    void RefreshPlayerModelData()
    {
        // player ID Made up of day month year hour minute and seconds - column 1
        playerModel.playerID = activePlayerModelSave.playerID;
        playerModel.csvHeaderPlayerID = activePlayerModelSave.csvHeaderPlayerID;

        // Combat Event data - column 5 to 7
        playerModel.combatsEngagedIn = activePlayerModelSave.combatsEngagedIn;
        playerModel.combatWins = activePlayerModelSave.combatWins;
        playerModel.combatsAvoided = activePlayerModelSave.combatsAvoided;

        // Card game Event data - column 8 to 11
        playerModel.cardGamesEngagedIn = activePlayerModelSave.cardGamesEngagedIn;
        playerModel.cardGameWins = activePlayerModelSave.cardGameWins;
        playerModel.cardGameDraws = activePlayerModelSave.cardGameDraws;
        playerModel.cardGamesAvoided = activePlayerModelSave.cardGamesAvoided;

        // Dialog Event data - column 12 to 13
        playerModel.dialogueEngagedIn = activePlayerModelSave.dialogueEngagedIn;
        playerModel.dialogueAvoided = activePlayerModelSave.dialogueAvoided;
        playerModel.csvPlayerModelRecordings = activePlayerModelSave.csvPlayerModelRecordings;


        // Player Type prediction variables
        playerModel.predictedPlayerCombatPreference = activePlayerModelSave.predictedPlayerCombatPreference;
        playerModel.predictedPlayerCareGamePreference = activePlayerModelSave.predictedPlayerCareGamePreference;
        playerModel.predictedPlayerDialoguePreference = activePlayerModelSave.predictedPlayerDialoguePreference;
        playerModel.predictedPlayerType = activePlayerModelSave.predictedPlayerType;
    }

    //-------------------------- End of Save Load and Delete player model data ---------------------------------------------
}

[System.Serializable]
public class PlayerModelSaveData
{
    public string saveName;

    //---------------------Player Model Data---------------------------

    // player ID Made up of day month year hour minute and seconds - column 1
    public string playerID;
    public string csvHeaderPlayerID;

    // Combat Event data - column 5 to 7
    public int combatsEngagedIn;
    public int combatWins;
    public int combatsAvoided;

    // Card game Event data - column 8 to 11
    public int cardGamesEngagedIn;
    public int cardGameWins;
    public int cardGameDraws;
    public int cardGamesAvoided;

    // Dialog Event data - column 12 to 13
    public int dialogueEngagedIn;
    public int dialogueAvoided;

    //Player Type prediction variables
    public string predictedPlayerCombatPreference;
    public string predictedPlayerCareGamePreference;
    public string predictedPlayerDialoguePreference;
    public string predictedPlayerType;

    // csv info
    public List<string> csvPlayerModelRecordings;
}
