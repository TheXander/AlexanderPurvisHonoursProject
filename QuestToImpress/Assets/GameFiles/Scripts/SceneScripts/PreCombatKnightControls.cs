using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class PreCombatKnightControls : MonoBehaviour
{
    public CastleKnightControls knightControls;
    public DialogueRunner dialogueRunner;

    public void ActivateKnightInterupt()
    {
        dialogueRunner.StartDialogue("CastleKnightInterrupt");
    }

    public void SwithKnights()
    {
        knightControls.TurnKnightOnOff(CastleKnightControls.Kinghts.cardGameKnight, true);
        knightControls.TurnKnightOnOff(CastleKnightControls.Kinghts.preCombatKnight, false);
    }
}
