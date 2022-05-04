using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttackManager : MonoBehaviour
{
    Animator animator;
    int attackCounter = 0;
    int resetAttack = -1;
    Transform attackPoint;
    float attackRange = 1.0f;
    LayerMask enemyLayeres;
    int attackDamage = 20;
    float attackRate = 3f;
    float attackCooldown = 0f;
    

    // energy
    public Slider energySlider;
    float playerStartingEnergy = 200.0f;
    public float currentEnergy = 200.0f;
    float tickDownEnergyCooldown = 0.05f;
    float tickUpEnergyCooldown = 0.05f;
    float energyCounter = 0f;
    public bool isBlocking = false;
    public bool enemyDetected = false;


    public PlayerInputControls playerInputControls;
    public HealthBarManager healthManager;

    private void Awake()
    {      
        animator = GetComponent<Animator>();
        attackPoint = transform.Find("AttackPoint");
        enemyLayeres = LayerMask.GetMask("Enemies");

        // set up player health slider
        currentEnergy = playerStartingEnergy;

        energySlider.maxValue = currentEnergy;
        energySlider.value = currentEnergy;
    }

    private void Update()
    {
        if (isBlocking)
        {
            energyCounter += Time.deltaTime;
            if (energyCounter >= tickDownEnergyCooldown)
            {
                currentEnergy--;
                energySlider.value = currentEnergy;
                energyCounter = 0;

                if (currentEnergy <= 0)
                {
                    isBlocking = false;
                    animator.SetBool("IsBlocking", false);
                }
            }
        }
        else if (currentEnergy < playerStartingEnergy)
        {
            energyCounter += Time.deltaTime;
            if (energyCounter >= tickUpEnergyCooldown)
            {
                currentEnergy++;
                energySlider.value = currentEnergy;
                energyCounter = 0;
            }
        }      
    }


    public void Block()
    {
        if (currentEnergy > 5 && playerInputControls.playerAlive && playerInputControls.playerActive)
        {
            playerInputControls.blocking = true;

            isBlocking = true;
            animator.SetBool("IsBlocking", true);
            animator.SetTrigger("Block");
        }
    }

    public void ScusessfulBlock()
    {
        if (currentEnergy > 5 && playerInputControls.playerAlive)
        {           
            animator.SetTrigger("BlockedHit");
        }
    }

    public void EndBlock()
    {
        playerInputControls.blocking = false;

        if (isBlocking == true && playerInputControls.playerAlive)
        {
            isBlocking = false;
            animator.SetBool("IsBlocking", false);
        }      
    }

    public void Attack()
    {
        if (!playerInputControls.blocking && playerInputControls.playerActive)
        {

            if (currentEnergy >= 20)
            {
                bool enemyHit = false;

                if (Time.time >= attackCooldown && playerInputControls.playerActive == true && playerInputControls.playerAlive )
                {
                    currentEnergy -= 20;
                    energySlider.value = currentEnergy;

                    switch (attackCounter)
                    {
                        case 0:
                            animator.SetTrigger("attack1");
                            attackDamage = 4;
                            break;
                        case 1:
                            animator.SetTrigger("attack2");
                            attackDamage = 8;
                            break;
                        case 2:
                            animator.SetTrigger("attack3");
                            attackCounter = resetAttack;
                            attackDamage = 12;
                            break;
                        default:
                            break;
                    }

                    Collider2D[] enemiesHit = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayeres);
                    foreach (Collider2D enemy in enemiesHit)
                    {
                        healthManager.DecreaseEnemyHealth(attackDamage);

                        enemyHit = true;
                    }

                    if (enemyHit && healthManager.enemyIsVulnerable)
                    {
                        attackCounter++;

                        if (attackCounter > 2)
                        {
                            attackCounter = 0;
                        }
                    }
                    else
                    {
                        attackCounter = 0;
                    }

                    attackCooldown = Time.time + 2f / attackRate;
                }
            }
        }
    }   
}
