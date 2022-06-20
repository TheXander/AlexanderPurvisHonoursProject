using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TotorialTrigger : MonoBehaviour
{
    public InstructionsManager instructionsManager;
    public SceneBasedPlayerControls sceneBasedPlayerControls;
    bool trigger = false;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player" && !trigger)
        {
            instructionsManager.ViewInstructions();
            sceneBasedPlayerControls.LockPlayerMovement();
            trigger = true;
        }
    }
}
