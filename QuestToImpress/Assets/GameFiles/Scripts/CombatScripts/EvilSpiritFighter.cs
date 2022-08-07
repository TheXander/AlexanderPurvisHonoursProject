using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilSpiritFighter : MonoBehaviour
{
    public PlayerModel playerModel;
    public GameObject shield;
    // bools for control of set up
    bool activateMajorCombats = false;

    void Start()
    {
        if (playerModel.predictedPlayerType == "Completionist" || playerModel.predictedPlayerType == "Combat_CardGame_Enthusiast" ||
            playerModel.predictedPlayerType == "Combat_Dialogue_Enthusiast" || playerModel.predictedPlayerType == "Combat_Enthusiast_with_CardGame_Dialogue_Intrest" ||
            playerModel.predictedPlayerType == "Combat_Enthusiast_with_CardGame_Intrest" || playerModel.predictedPlayerType == "Combat_Enthusiast_with_Dialogue_Intrest" ||
            playerModel.predictedPlayerType == "Combat_Enthusiast")
        {
            activateMajorCombats = true;
           
        }

        if (activateMajorCombats)
        {
            UpgradeFightWithShield();
        }
    }

    void UpgradeFightWithShield()
    {
        shield.SetActive(true);
    }
}
