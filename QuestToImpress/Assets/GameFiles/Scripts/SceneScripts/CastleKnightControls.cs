using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastleKnightControls : MonoBehaviour
{
    public CastleDialogeHandler dialogeHandler;
    public GameObject preCombatKnight, postCombatKnight, cardGameKnight;
    public Animator preCombatKnightAnimator;
    public enum Kinghts { preCombatKnight, postCombatKnight, cardGameKnight }

    public void TurnKnightOnOff(Kinghts knight, bool SetKnightActive)
    {
        switch (knight)
        {
            case Kinghts.cardGameKnight:
                cardGameKnight.SetActive(SetKnightActive);
                break;
            case Kinghts.postCombatKnight:
                postCombatKnight.SetActive(SetKnightActive);
                break;
            case Kinghts.preCombatKnight:
                preCombatKnight.SetActive(SetKnightActive);
                break;
            default:
              
                break;
        }
    }

    public void MovePreCombatKnightToPlayer()
    {
        preCombatKnightAnimator.SetTrigger("MoveToPlayer");
    }

}
