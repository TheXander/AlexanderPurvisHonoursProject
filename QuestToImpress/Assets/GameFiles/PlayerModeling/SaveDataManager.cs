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

    //public PlayerEventResults eventResults;
    //public PlayerProgress playerProgress;
    //public RomeoData romeoData;


//-------------------------- Save Load and Delete player model data -----------------------------------------------
    public void SavePlayerModelData()
    {
        activePlayerModelSave.saveName = "playermodelgamedata";
        string dataPath = Application.persistentDataPath;

        if (System.IO.File.Exists(dataPath + "/" + "playermodelgamedata" + ".save"))
        {
            var serializer = new XmlSerializer(typeof(PlayerModelSaveData));
            var stream = new FileStream(dataPath + "/" + "playermodelgamedata" + ".save", FileMode.Open);
            serializer.Serialize(stream, activePlayerModelSave);
            stream.Close();
        }
        else
        {
            var serializer = new XmlSerializer(typeof(PlayerModelSaveData));
            var stream = new FileStream(dataPath + "/" + "playermodelgamedata" + ".save", FileMode.Create);
            serializer.Serialize(stream, activePlayerModelSave);
            stream.Close();
        }
    }

    public void DeletePlayerModelData()
    {
        activePlayerModelSave.saveName = "playermodelgamedata";
        string dataPath = Application.persistentDataPath;

        if (System.IO.File.Exists(dataPath + "/" + "playermodelgamedata" + ".save"))
        {
            File.Delete(dataPath + "/" + "playermodelgamedata" + ".save");
        }
    }

    public void LoadPlayerModelData()
    {
        activePlayerModelSave.saveName = "playermodelgamedata";
        string dataPath = Application.persistentDataPath;

        if (System.IO.File.Exists(dataPath + "/" + "playermodelgamedata" + ".save"))
        {
            var serializer = new XmlSerializer(typeof(PlayerModelSaveData));
            var stream = new FileStream(dataPath + "/" + "playermodelgamedata" + ".save", FileMode.Open);
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

    public List<string> csvPlayerModelRecordings;
}
