using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JulietBarrier : MonoBehaviour
{
    public PlayerProgress playerProgress;

    // Update is called once per frame
    void Update()
    {
        if (playerProgress.invitedToJuliets)
        {
            gameObject.SetActive(false);
        }
    }
}
