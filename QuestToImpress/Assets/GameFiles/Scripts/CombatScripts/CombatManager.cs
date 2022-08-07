using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CombatManager : MonoBehaviour
{
    public PlayerProgress playerProgress;
    public RomeoData romeoData;
    public PlayerEventResults eventResults;
    public PlayerInputControls playerInputControls;

    public Animator fightAnnouncement;
    public TMP_Text gameResultText;
    public SetUpCombatEvent setUpCombat;

    public enum CombatResults { None, Win, Lose};
    CombatResults combatResult = CombatResults.None;

    public PlayerModel playerModel;
    bool resultSentToPlayerModel = false;

    // enemies 
    public EnemyGauntletPriest enemyGauntletPriest;
    public VaiDrogulCombat vaiDrogulCombat;
    public CastleKnightCombat castleKnightCombat;


    public void ActivateFighters()
    {
        //Debug.Log(romeoData.CurrentCombat);
        playerInputControls.playerActive = true;

        switch (romeoData.CurrentCombat)
        {
            case RomeoData.CombatEvents.CastleKnight:
                castleKnightCombat.ActivateEnemy();
                break;
            case RomeoData.CombatEvents.ForestKnight:
                vaiDrogulCombat.enemyActive = true;
                break;
            case RomeoData.CombatEvents.CultistPriest:
                enemyGauntletPriest.ActivateEnemy();
                break;
            case RomeoData.CombatEvents.RedHood:

                break;
            case RomeoData.CombatEvents.EvilSpirt:

                break;
            case RomeoData.CombatEvents.Tybalt:

                break;
            default:
                Debug.Log("Error no result");
                break;
        }
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
                    //playerProgress.levelOneEventsComplete++;

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

                    playerModel.StandardUpdate(true, "Forest");

                    break;
                case RomeoData.CombatEvents.CultistPriest:
                    playerProgress.gravyardCombatCompelte = true;
                    playerProgress.levelOneEventsComplete++;
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

                    playerModel.StandardUpdate(true, "Graveyard");

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
                  
                    switch (combatResult)
                    {
                        case CombatResults.Win:
                            eventResults.churchCombat = PlayerEventResults.EventResults.Win;
                            break;
                        case CombatResults.Lose:
                            eventResults.churchCombat = PlayerEventResults.EventResults.Loss;
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