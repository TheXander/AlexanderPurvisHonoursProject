using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameTeleporter : MonoBehaviour
{

    public bool currentHost = false;

    public Animator otherPortal;
    public Transform thisPortalTransform;
    public Transform HidingSpot;
    public GameObject vaiDrogul;

    bool triggerOtherTeleporter = false;
    float teleportCounter = 0;
    float teleportCountdown = 3.0f;

    void Update()
    {
        if (triggerOtherTeleporter)
        {
            teleportCounter += Time.deltaTime;
            if (teleportCounter >= teleportCountdown)
            {

                otherPortal.SetTrigger("Teleport");
                triggerOtherTeleporter = false;
                teleportCounter  = 0;
            }
        }
    }


    public void Transport()
    {
        if (vaiDrogul.GetComponent<VaiDrogulCombat>().enemyAlive)
        {
            if (currentHost)
            {
                vaiDrogul.transform.position = HidingSpot.position;
                currentHost = false;
                triggerOtherTeleporter = true;
            }
            else
            {
                vaiDrogul.transform.position = thisPortalTransform.position;
                currentHost = true;
                vaiDrogul.GetComponent<VaiDrogulCombat>().ResetTeleport();
                vaiDrogul.GetComponent<VaiDrogulCombat>().FlipSprite();
            }
        }     
    }
}
