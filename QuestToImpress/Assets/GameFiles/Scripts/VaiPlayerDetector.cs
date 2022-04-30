using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VaiPlayerDetector : MonoBehaviour
{
    public VaiDrogulCombat vaiDrogulCombat;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
      
            vaiDrogulCombat.teleporting = true;
        }
    }
}
