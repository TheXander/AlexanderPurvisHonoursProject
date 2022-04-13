using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestSceneSetUp : MonoBehaviour
{
    public PlayerProgress playerProgress;

    public GameObject L1ForestCombat;

    public GameObject ForestKnight;


    private void Awake()
    {
        if (playerProgress.forestKCombatCompelte)
        {
            L1ForestCombat.SetActive(false);
            ForestKnight.SetActive(true);
        }       
    }
}
