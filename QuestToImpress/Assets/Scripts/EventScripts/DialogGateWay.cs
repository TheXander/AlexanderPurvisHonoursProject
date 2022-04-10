using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogGateWay : MonoBehaviour
{
    public RomeoData romeoData;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            romeoData.currentEvent = RomeoData.Events.Dialog;
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            romeoData.currentEvent = RomeoData.Events.None;
        }
    }
}
