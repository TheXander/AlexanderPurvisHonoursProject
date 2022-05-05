using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuSetUp : MonoBehaviour
{

    public PlayerModel playerModel;

    public PlayerEventResults eventResults;
    public PlayerProgress playerProgress;
    public RomeoData romeoData;


    // Start is called before the first frame update
    void Start()
    {
        // EventResults resets
        // reset Level One Card Games resluts 
        eventResults.lakeCardGame = PlayerEventResults.EventResults.None;
        eventResults.tavernFCardGame = PlayerEventResults.EventResults.None;
        eventResults.cityCardGame = PlayerEventResults.EventResults.None;

        // reset Level One Combats resluts 
        eventResults.castleCombat = PlayerEventResults.EventResults.None;
        eventResults.forestKCombat = PlayerEventResults.EventResults.None;
        eventResults.gravyardCombat = PlayerEventResults.EventResults.None;

        // playerProgress resets
        // cardgame complete bool resets
        playerProgress.lakeCardGameComplete = false;
        playerProgress.tavernFCardGameComplete = false;
        playerProgress.cityCardGameComplete = false;
        playerProgress.tavernVCardGameComplete = false;
        playerProgress.forestCardGameComplete = false;
        playerProgress.tybaltCardGameComplete = false;

        // combat complete bool resets
        playerProgress.castleCombatCompelte = false;
        playerProgress.forestKCombatCompelte = false;
        playerProgress.gravyardCombatCompelte = false;
        playerProgress.forestRHCombatCompelte = false;
        playerProgress.churchCombatCompelte = false;
        playerProgress.tybaltCombatCompelte = false;

        // dialog complete bool resets
        playerProgress.castleDialogCompelte = false;
        playerProgress.tavernDialogCompelte = false;
        playerProgress.gravyardTDialogCompelte = false;
        playerProgress.gravyardMDialogCompelte = false;
        playerProgress.churchDialogCompelte = false;
        playerProgress.tybaltDialogCompelte = false;

        //Number of events Complete
        playerProgress.levelOneEventsComplete = 0;
        playerProgress.levelTwoEventsComplete = 0;


        playerProgress.levelOneEventsComplete = 0;
        playerProgress.levelTwoEventsComplete = 0;

        playerProgress.julietsReady = false;
        playerProgress.invitedToJuliets = false;


        // RomeoData resets
        // rest Current Events 
        romeoData.CurrentCardgame = RomeoData.CardgameEvents.None;
        romeoData.CurrentCombat = RomeoData.CombatEvents.None;
        romeoData.CurrentDialog = RomeoData.DialogEvents.None;

        romeoData.currentEvent = RomeoData.Events.None;

        romeoData.currentLocation = LevelLoader.Levels.MainMenu;
        romeoData.previousLocation = LevelLoader.Levels.MainMenu;


        playerModel.reset();


        playerModel.CreateFile();
    }
}
