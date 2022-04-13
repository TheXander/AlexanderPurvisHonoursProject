using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarManager : MonoBehaviour
{
    public CombatManager combatManager;

    public Slider playerHealthSlider;
    public Slider enemyHealthSlider;

    float playerStartingHealth = 100.0f;
    float currentPlayerHealth, currentEnemyHealth;

    bool qKeyUp = true;
    bool eKeyUp = true;

    bool decreesePlayerHealth = false;
    bool decreeseEnemyHealth = false;

    private void Awake()
    {
        SetUpHealth(100.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("q") && qKeyUp)
        {
            decreesePlayerHealth = true;
        }

        if (Input.GetKeyDown("e") && eKeyUp)
        {
            decreeseEnemyHealth = true;
        }

        if (Input.GetKeyUp("q") )
        {
            qKeyUp = true;
        }

        if (Input.GetKeyUp("e"))
        {
            eKeyUp = true;
        }

        if (decreesePlayerHealth)
        {
            qKeyUp = false;
            decreesePlayerHealth = false;
            DecreasePlayerHealth(40.0f);
        }
        if (decreeseEnemyHealth)
        {
            eKeyUp = false;
            decreesePlayerHealth = false;
            DecreaseEnemyHealth(40.0f);
        }
    }

    public void SetUpHealth(float enemyStartingHealth)
    {
        // set up player health slider
        playerHealthSlider.maxValue = playerStartingHealth;
        playerHealthSlider.value = playerStartingHealth;

        // set up enemy health slider
        enemyHealthSlider.maxValue = enemyStartingHealth;
        enemyHealthSlider.value = enemyStartingHealth;
    }

    public void DecreasePlayerHealth(float damage)
    {
        currentPlayerHealth -= damage;
        playerHealthSlider.value = currentPlayerHealth;

        if (currentPlayerHealth <= 0)
        {
            combatManager.RevealFightResult(CombatManager.CombatResults.Lose);
        }
    }

    public void DecreaseEnemyHealth(float damage)
    {
        currentEnemyHealth -= damage;
        enemyHealthSlider.value = currentEnemyHealth;
        
        if (currentEnemyHealth <= 0)
        {
            combatManager.RevealFightResult(CombatManager.CombatResults.Win);
        }
    }
}
