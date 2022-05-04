using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TotorialTrigger : MonoBehaviour
{
    public InstructionsManager instructionsManager;
    bool trigger = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player" && !trigger)
        {
            instructionsManager.ViewInstructions();
            trigger = true;
        }
    }
}
