using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CombatManager : MonoBehaviour
{
    public PlayerProgress playerProgress;
    public RomeoData romeoData;

    public Animator fightAnnouncement;
    public TMP_Text gameResultText;
    public SetUpCombatEvent setUpCombat;

    public enum CombatResults { None, Win, Lose};
    CombatResults combatResult = CombatResults.None;

    public void ActivateFighters()
    {

    }
   
    public void RevealFightResult(CombatResults ResultOfCombat)
    {
        combatResult = ResultOfCombat;

        switch (combatResult)
        {
            case CombatResults.Win:
                gameResultText.text = "Romeo Wins!";
                break;
            case CombatResults.Lose:
                gameResultText.text = "You Lost! Sad times";
                break;        
            default:
                Debug.Log("Error no result");
                break;
        }

        fightAnnouncement.SetTrigger("Activate");
    }


    public void EndFight()
    {
        switch (romeoData.CurrentCombat)
        {
            case RomeoData.CombatEvents.CastleKnight:
                playerProgress.castleCombatCompelte = true;
                playerProgress.levelOneEventsComplete++;
                break;
            case RomeoData.CombatEvents.ForestKnight:
                playerProgress.forestKCombatCompelte = true;
                playerProgress.levelOneEventsComplete++;
                break;
            case RomeoData.CombatEvents.CultistPriest:
                playerProgress.gravyardCombatCompelte = true;
                playerProgress.levelOneEventsComplete++;
                break;
            case RomeoData.CombatEvents.RedHood:
                playerProgress.forestRHCombatCompelte = true;
                playerProgress.levelTwoEventsComplete++;
                break;
            case RomeoData.CombatEvents.EvilSpirt:
                playerProgress.churchCombatCompelte = true;
                playerProgress.levelTwoEventsComplete++;
                break;
            case RomeoData.CombatEvents.Tybalt:
                playerProgress.tybaltCombatCompelte = true;
                playerProgress.levelTwoEventsComplete++;
                break;
            default:
                Debug.Log("Error no result");
                break;
        }

        setUpCombat.ReturnPlayer();
    }
}