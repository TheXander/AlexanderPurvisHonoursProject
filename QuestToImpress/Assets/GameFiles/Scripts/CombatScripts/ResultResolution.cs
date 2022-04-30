using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultResolution : MonoBehaviour
{
    public CombatManager combatManager;

    public void EndFight()
    {
        combatManager.EndFight();
    }
}
