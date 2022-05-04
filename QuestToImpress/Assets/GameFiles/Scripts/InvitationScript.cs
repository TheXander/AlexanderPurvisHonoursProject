using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvitationScript : MonoBehaviour
{
    public PlayerProgress playerProgress;
    public bool onUIFilledScreen = false;
    public SceneBasedPlayerControls sceneBasedPlayerControls;

    public void SetJulietReady()
    {
        playerProgress.julietsReady = true;
        sceneBasedPlayerControls.movmentLocked = false;        
    }
}
