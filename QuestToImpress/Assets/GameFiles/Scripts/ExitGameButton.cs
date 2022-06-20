using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Created by ALexander Purvis copyright Alexander Purvis
public class ExitGameButton : MonoBehaviour
{
    public PlayerModel playerModel;
    bool shutingDown = false;
    float cooldownCounter = 0;
    float shutdownTime = 0.8f;
   
    public void ExitTheGame()
    {
        if (!shutingDown)
        {
            playerModel.LastUpdate("JulietsHouse");
            shutingDown = true;
        }     
    }

    private void Update()
    {
        if (shutingDown)
        {
            cooldownCounter += Time.deltaTime;
            if (cooldownCounter >= shutdownTime)
            {             
                Application.Quit();
            }
        }
    }    
}
