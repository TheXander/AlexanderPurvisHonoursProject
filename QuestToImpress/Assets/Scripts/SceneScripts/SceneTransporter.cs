using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTransporter : MonoBehaviour
{
   public LevelLoader levelLoader;
   public LevelLoader.Levels gatewayDestination;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {          
            levelLoader.LoadLevel(gatewayDestination);
        }
    }
}
