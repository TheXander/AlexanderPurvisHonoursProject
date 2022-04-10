using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour
{
    public LevelLoader levelLoader;
    public LevelLoader.Levels gatewayDestination;
    public LevelLoader.Levels gatewayOrigin;
    public RomeoData romeoData;
    public Animator uiAnimator;

    public void StartGame()
    {
        uiAnimator.SetTrigger("HideUI");
        romeoData.previousLocation = gatewayOrigin;
        romeoData.currentLocation = gatewayDestination;
        levelLoader.LoadLevel(gatewayDestination);
    }
}
