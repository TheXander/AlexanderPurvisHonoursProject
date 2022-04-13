using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastleSceneSetup : MonoBehaviour
{
    public PlayerProgress playerProgress;

    public GameObject l1CastleCombat, l1CastleDialog;

    public GameObject castleKnight, juliet;


    private void Awake()
    {
        if (playerProgress.castleCombatCompelte)
        {
            l1CastleCombat.SetActive(false);
            castleKnight.SetActive(true);
        }

        if (playerProgress.castleDialogCompelte)
        {
            l1CastleDialog.SetActive(false);
            juliet.SetActive(true);
        }
    }
}
