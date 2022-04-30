using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CombatManager : MonoBehaviour
{
    public PlayerProgress playerProgress;
    public RomeoData romeoData;
    public PlayerEventResults eventResults;
    

    public Animator fightAnnouncement;
    public TMP_Text gameResultText;
    public SetUpCombatEvent setUpCombat;

    public enum CombatResults { None, Win, Lose};
    CombatResults combatResult = CombatResults.None;

    public PlayerModel playerModel;
    bool resultSentToPlayerModel = false;

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

        if (!resultSentToPlayerModel)
        {

            switch (romeoData.CurrentCombat)
            {
                case RomeoData.CombatEvents.CastleKnight:
                    playerProgress.castleCombatCompelte = true;
                    playerProgress.levelOneEventsComplete++;

                    switch (combatResult)
                    {
                        case CombatResults.Win:
                            eventResults.castleCombat = PlayerEventResults.EventResults.Win;
                            break;
                        case CombatResults.Lose:
                            eventResults.castleCombat = PlayerEventResults.EventResults.Loss;
                            break;
                        default:
                            Debug.Log("Error no result");
                            break;
                    }

                    break;
                case RomeoData.CombatEvents.ForestKnight:
                    playerProgress.forestKCombatCompelte = true;
                    playerProgress.levelOneEventsComplete++;
                    playerModel.StandardUpdate(true, "Forest");
                    switch (combatResult)
                    {
                        case CombatResults.Win:
                            eventResults.forestKCombat = PlayerEventResults.EventResults.Win;
                            playerModel.NewCombatEngagement(true);
                            break;
                        case CombatResults.Lose:
                            eventResults.forestKCombat = PlayerEventResults.EventResults.Loss;
                            playerModel.NewCombatEngagement(false);
                            break;
                        default:
                            Debug.Log("Error no result");
                            break;
                    }

                    break;
                case RomeoData.CombatEvents.CultistPriest:
                    playerProgress.gravyardCombatCompelte = true;
                    playerProgress.levelOneEventsComplete++;
                    playerModel.StandardUpdate(true, "Graveyard");
                    switch (combatResult)
                    {
                        case CombatResults.Win:
                            eventResults.gravyardCombat = PlayerEventResults.EventResults.Win;
                            playerModel.NewCombatEngagement(true);
                            break;
                        case CombatResults.Lose:
                            eventResults.gravyardCombat = PlayerEventResults.EventResults.Loss;
                            playerModel.NewCombatEngagement(false);
                            break;
                        default:
                            Debug.Log("Error no result");
                            break;
                    }

                    break;
                case RomeoData.CombatEvents.RedHood:
                    playerProgress.forestRHCombatCompelte = true;
                    playerProgress.levelTwoEventsComplete++;

                    switch (combatResult)
                    {
                        case CombatResults.Win:

                            break;
                        case CombatResults.Lose:

                            break;
                        default:
                            Debug.Log("Error no result");
                            break;
                    }
                    break;
                case RomeoData.CombatEvents.EvilSpirt:
                    playerProgress.churchCombatCompelte = true;
                    playerProgress.levelTwoEventsComplete++;

                    switch (combatResult)
                    {
                        case CombatResults.Win:

                            break;
                        case CombatResults.Lose:

                            break;
                        default:
                            Debug.Log("Error no result");
                            break;
                    }
                    break;
                case RomeoData.CombatEvents.Tybalt:
                    playerProgress.tybaltCombatCompelte = true;
                    playerProgress.levelTwoEventsComplete++;

                    switch (combatResult)
                    {
                        case CombatResults.Win:

                            break;
                        case CombatResults.Lose:

                            break;
                        default:
                            Debug.Log("Error no result");
                            break;
                    }
                    break;
                default:
                    Debug.Log("Error no result");
                    break;
            }

            resultSentToPlayerModel = true;
        }

        setUpCombat.ReturnPlayer();
    }
}