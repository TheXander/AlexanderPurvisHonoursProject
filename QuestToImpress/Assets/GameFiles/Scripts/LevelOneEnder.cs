using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelOneEnder : MonoBehaviour
{
   public SceneBasedPlayerControls sceneBasedPlayerControls;
   public GameObject Act1Endeding;
   bool trigger = false;

   private void OnTriggerEnter2D(Collider2D collision)
   {     
      if (collision.name == "Player" && !trigger)
      {
            trigger = true;
            sceneBasedPlayerControls.StopPlayer();
            Act1Endeding.SetActive(true);
      }
   }
}
