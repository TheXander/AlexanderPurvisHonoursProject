using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModelUpdater : MonoBehaviour
{
    public PlayerModel playerModel;
    string location = "A nice beach with Safu";
    // Start is called before the first frame update
    void Start()
    {

        playerModel.CreateFile();


        playerModel.StandardUpdate(true, location);


        playerModel.NewCardGameAvoided();

        playerModel.NewCombatEngagement(false);
        playerModel.NewCombatEngagement(true);

        playerModel.NewCombatAvoided();


        playerModel.NewCardGameEngagement(true, false);
        playerModel.NewCardGameEngagement(false, true);
        playerModel.NewCardGameEngagement(false, false);

        playerModel.NewCardGameAvoided();

        playerModel.NewDialogueEngagement();
        playerModel.NewDialogueEngagement();



        playerModel.NewDialogueAvoided();
        playerModel.NewDialogueAvoided();

        playerModel.Print();
    }
   
}
