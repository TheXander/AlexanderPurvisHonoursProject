using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactivatePlayerMovement : MonoBehaviour
{
    public SceneBasedPlayerControls playerControls;

    public void activatePlayerMovement()
    {
        print("Animation event activated!");
        playerControls.StartPlayer();
    }   
}
