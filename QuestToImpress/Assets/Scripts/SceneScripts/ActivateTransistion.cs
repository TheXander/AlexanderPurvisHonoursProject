using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateTransistion : MonoBehaviour
{
    public RomeoData romeoData;
    public LevelLoader levelLoader;
    public LevelLoader.Levels gatewayDestination;
    public LevelLoader.Levels gatewayOrigin;

    public void StartTrasition()
    {           
        romeoData.previousLocation = gatewayOrigin;
        romeoData.currentLocation = gatewayDestination;
        levelLoader.LoadLevel(gatewayDestination);
    }
}
