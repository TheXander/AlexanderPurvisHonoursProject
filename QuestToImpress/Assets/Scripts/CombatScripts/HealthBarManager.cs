using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarManager : MonoBehaviour
{
    public CombatManager combatManager;
    public RomeoData romeoData;

    public PlayerInputControls playerInputControls;
    public EnemyGauntletPriest enemyGauntletPriest;
    public VaiDrogulCombat vaiDrogulCombat;
    public CastleKnightCombat castleKnightCombat;

    public Slider playerHealthSlider;
    public Animator playerHealthAnimator;
    public Slider enemyHealthSlider;
    public Animator enemyHealthAnimator;

    float playerStartingHealth = 100.0f;

    float priestStartingHealth = 150.0f;
    float vaiDrogulStartingHealth = 120.0f;
    float castleKnightStartingHealth = 90.0f;

    float currentPlayerHealth, currentEnemyHealth;
    public bool enemyIsAlive = true;
    public bool enemyIsVulnerable = true;

    private void Awake()
    {
       
        switch (romeoData.CurrentCombat)
        {
            case RomeoData.CombatEvents.CastleKnight:
                
                SetUpHealth(castleKnightStartingHealth);               
                break;
            case RomeoData.CombatEvents.ForestKnight:

                SetUpHealth(vaiDrogulStartingHealth);
                break;
            case RomeoData.CombatEvents.CultistPriest:

                SetUpHealth(priestStartingHealth);
                break;
            case RomeoData.CombatEvents.RedHood:


                break;
            case RomeoData.CombatEvents.EvilSpirt:


                break;
            case RomeoData.CombatEvents.Tybalt:


                break;
            default:
                Debug.Log("Error no CurrentCombat");
                SetUpHealth(80.0f);
                break;
        }
    }

    

    public void SetUpHealth(float enemyStartingHealth)
    {
        // set up player health slider
        currentPlayerHealth = playerStartingHealth;

        playerHealthSlider.maxValue = currentPlayerHealth;
        playerHealthSlider.value = currentPlayerHealth;

        currentEnemyHealth = enemyStartingHealth;
        // set up enemy health slider
        enemyHealthSlider.maxValue = currentEnemyHealth;
        enemyHealthSlider.value = currentEnemyHealth;
    }

    public void DecreasePlayerHealth(float damage)
    {    
        if (currentPlayerHealth  > 0 && enemyIsAlive &&  playerInputControls.isGrounded)
        {
            currentPlayerHealth -= damage;
            playerHealthSlider.value = currentPlayerHealth;

            if (currentPlayerHealth <= 0)
            {
                combatManager.RevealFightResult(CombatManager.CombatResults.Lose);
            }
            else
            {
                playerHealthAnimator.SetTrigger("Damaged");
            }

            playerInputControls.DamageReaction(currentPlayerHealth);
        }    
    }

    public void DecreaseEnemyHealth(float damage)
    {
        if (currentEnemyHealth > 0 && playerInputControls.playerAlive && enemyIsVulnerable)
        {
            currentEnemyHealth -= damage;
            enemyHealthSlider.value = currentEnemyHealth;
            CommunicateDamageToEnemy();
            if (currentEnemyHealth <= 0)
            {
                combatManager.RevealFightResult(CombatManager.CombatResults.Win);
            }
            else
            {
                enemyHealthAnimator.SetTrigger("Damaged");
            }
        }     
    }


    void CommunicateDamageToEnemy()
    {
        switch (romeoData.CurrentCombat)
        {
            case RomeoData.CombatEvents.CastleKnight:
                castleKnightCombat.DamageReaction(currentEnemyHealth);
                break;
            case RomeoData.CombatEvents.ForestKnight:
                vaiDrogulCombat.DamageReaction(currentEnemyHealth);
                break;
            case RomeoData.CombatEvents.CultistPriest:

                enemyGauntletPriest.DamageReaction(currentEnemyHealth);
                break;
            case RomeoData.CombatEvents.RedHood:
               
                break;
            case RomeoData.CombatEvents.EvilSpirt:
           
                break;
            case RomeoData.CombatEvents.Tybalt:
        
                break;
            default:
                // castleKnightCombat.DamageReaction(currentEnemyHealth);
                // enemyGauntletPriest.DamageReaction(currentEnemyHealth);
                vaiDrogulCombat.DamageReaction(currentEnemyHealth);
                break;
        }
    }
}
