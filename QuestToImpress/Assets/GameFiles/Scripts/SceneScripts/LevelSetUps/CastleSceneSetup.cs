using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class CastleSceneSetup : MonoBehaviour
{
    public PlayerProgress playerProgress;
    public RomeoData romeoData;
    public PlayerEventResults playerEventResults;
    public DialogueRunner dialogueRunner;

    public GameObject romeo;
    public GameObject l1CastleCombat, l1CastleDialog;
    public GameObject castleKnight, juliet;
    public GameObject entranceDoor, exitDoor;

    public GameObject preCombatNPCs, PostCombatNPCs;
    public GameObject postCombatSpawnPos;

    float cooldownCounter = 0.0f;
    float sceneChangeCooldown = 1f;

    bool combatComplete = false;

    private void Awake()
    {
        if (playerProgress.castleCombatCompelte)
        {
            l1CastleCombat.SetActive(false);
            castleKnight.SetActive(true);

            entranceDoor.SetActive(false);
            exitDoor.SetActive(true);

            preCombatNPCs.SetActive(false);
            PostCombatNPCs.SetActive(true);
            l1CastleDialog.SetActive(false);
            juliet.SetActive(true);

            romeo.transform.position = postCombatSpawnPos.transform.position;
            combatComplete = true;          
        }

        if (playerProgress.castleDialogCompelte)
        {
            l1CastleDialog.SetActive(false);
            juliet.SetActive(true);
        }
    }

    void Update()
    {
        if (combatComplete)
        {
            cooldownCounter += Time.deltaTime;
            if (cooldownCounter >= sceneChangeCooldown)
            {
                if (playerEventResults.castleCombat == PlayerEventResults.EventResults.Win)
                {
                    dialogueRunner.StartDialogue("CastleKnightWinResolution");
                }
                else if (playerEventResults.castleCombat == PlayerEventResults.EventResults.Loss)
                {
                    dialogueRunner.StartDialogue("CastleKnightLoseResolution");
                }

                combatComplete = false;
            }
        }       
    }
}
