using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamPlayerTracking : MonoBehaviour
{
    public Transform targetPlayer;
    public Vector3 Offset;
    Vector3 targetPosition;
    Vector3 smoothedPosition;
    public float smoothingFactor;

    public bool trackingActive = true;

    private void FixedUpdate()
    {
        if (trackingActive)
        {
            targetPosition = targetPlayer.position + Offset;
            smoothedPosition = Vector3.Lerp(transform.position, targetPosition, smoothingFactor * Time.fixedDeltaTime);
            transform.position = smoothedPosition;
        }      
    }
}
