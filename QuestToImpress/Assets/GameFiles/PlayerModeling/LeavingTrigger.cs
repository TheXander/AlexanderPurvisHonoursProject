using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeavingTrigger : MonoBehaviour
{
    public LevelLoader levelLoader;
    bool leavingRegistered = false;

    public PlayerModel playerModel;
    public PlayerProgress playerProgress;
    public RomeoData romeoData;
   
    // Update is called once per frame
    void Update()
    {

        if (levelLoader.Transporting && !leavingRegistered && romeoData.currentEvent == RomeoData.Events.None)
        {
            leavingRegistered = true;
            Debug.Log("Beep");

            if (!playerProgress.tavernDialogCompelte)
            {
                playerModel.NewDialogueAvoided();
                playerModel.StandardUpdate(true, "Tavern");
            }

            if (!playerProgress.tavernFCardGameComplete)
            {
                playerModel.NewCardGameAvoided();
                playerModel.StandardUpdate(true, "Tavern");
            }
        }
    }
}
