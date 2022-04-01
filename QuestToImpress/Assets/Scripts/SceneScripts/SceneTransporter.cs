using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTransporter : MonoBehaviour
{
   public LevelLoader levelLoader;
   public LevelLoader.Levels gatewayDestination;
   public LevelLoader.Levels gatewayOrigin;
   public RomeoData romeoData;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            romeoData.previousLocation = gatewayOrigin;
            romeoData.currentLocation = gatewayDestination;

            levelLoader.LoadLevel(gatewayDestination);          
        }
    }
}
