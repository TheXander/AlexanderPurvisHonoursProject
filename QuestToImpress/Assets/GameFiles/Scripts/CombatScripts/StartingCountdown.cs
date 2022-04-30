using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingCountdown : MonoBehaviour
{
   public CombatManager combatManager;

   public void BeginFight()
   {
        combatManager.ActivateFighters();
   }
}