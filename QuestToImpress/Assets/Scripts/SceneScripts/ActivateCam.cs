using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateCam : MonoBehaviour
{
    public CamPlayerTracking camTracker;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.name == "Player")
        {
            camTracker.trackingActive = true;
        }
    }
}
