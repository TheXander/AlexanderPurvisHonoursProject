using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvoidRegisterCanceller : MonoBehaviour
{
    public AvoidEventRegister avoidEventRegister;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            avoidEventRegister.registerCanceled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            avoidEventRegister.registerCanceled = false;
        }
    }

}
