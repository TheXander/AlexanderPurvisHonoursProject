using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VaiDrogulCombat : MonoBehaviour
{
    [SerializeField] public bool enemyFacingRight;
    public Animator animator;
    public Animator effects;
   
    public bool enemyAlive = true;
    public bool enemyActive = false;

    public HealthBarManager healthBarManager;
    public PlayerAttackManager playerAttackManager;
    public VaiDrogulFireball vaiDrogulFireball;
    public GameObject player;
    public GameObject legs;
   
    int attackDamage = 15;

    float attackLongCooldown = 5f;
    float attackShortCooldown = 0.6f;
    float cooldownCounter = 0f;

    public Animator leftTeleporterAnimator;
    public FlameTeleporter leftTeleporterScript;
    public Animator rightTeleporterAnimator;
    public FlameTeleporter rightTeleporterScript;

    float teleportCountdown = 1.8f;
    float teleportCounter = 0f;
    public bool teleporting = false;
    bool teleportInProgress = false;

    int attacks = 0;
    bool isIdle = false;
    bool shortAttackCoolActive = true;
    bool longAttackCoolActive = false;

    private void Awake()
    {
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
    }

    void Update()
    {
        if (enemyAlive && !teleporting && enemyActive)
        {
            if (shortAttackCoolActive && !longAttackCoolActive)
            {
                if (!isIdle)
                {

                    animator.SetTrigger("idle");
                    isIdle = true;
                }

                cooldownCounter += Time.deltaTime;
                if (cooldownCounter >= attackShortCooldown)
                {

                    if (attacks > 7)
                    {
                        longAttackCoolActive = true;
                        cooldownCounter = 0;
                    }
                    else
                    {
                        shortAttackCoolActive = false;
                        isIdle = false;
                        cooldownCounter = 0;

                        Attack();
                    }
                }
            }

            if (longAttackCoolActive)
            {
                cooldownCounter += Time.deltaTime;
                if (cooldownCounter >= attackLongCooldown)
                {
                    longAttackCoolActive = false;
                    attacks = 0;
                }
            }
        }
        else if (teleporting && !teleportInProgress)
        {           
            teleportCounter += Time.deltaTime;
            if (teleportCounter >= teleportCountdown)
            {
                teleportInProgress = true;
                ActivateTeleporters();
            }
        }
    }

    void ActivateTeleporters()
    {
        if (leftTeleporterScript.currentHost)
        {
            leftTeleporterAnimator.SetTrigger("Teleport");
        }
        else
        {
            rightTeleporterAnimator.SetTrigger("Teleport");
        }       
    }

    public void ResetTeleport()
    {
        teleportCounter = 0f;
        teleporting = false;
        teleportInProgress = false;      
    }

    public void FlipSprite()
    {
        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;

        if (theScale.x < 0)
        {
            enemyFacingRight = false;
        }
        else
        {
            enemyFacingRight = true;
        }       
    }

    void Attack()
    {
        animator.SetTrigger("attack");
        shortAttackCoolActive = true;
        attacks++;
    }

    public void LaunchFireballs()
    {
        vaiDrogulFireball.SpawnFireball();
    }

    public void FireballAttack()
    {
        if (enemyAlive)
        {
            bool attackBlocked = false;

            if (playerAttackManager.isBlocking)
            {
                attackBlocked = true;
                playerAttackManager.ScusessfulBlock();
                effects.SetTrigger("BlockedFlame");
            }

            if (enemyActive)
            {
                if (!attackBlocked)
                {
                    healthBarManager.DecreasePlayerHealth(attackDamage);
                    effects.SetTrigger("HitWithFlame");
                }              
            }
        }
    }

    public void DamageReaction(float currentHealth)
    {
        if (currentHealth <= 0)
        {
            animator.SetBool("isDead", true);
            animator.SetTrigger("Die");
            transform.position = new Vector3(transform.position.x, -3.2f, transform.position.z);
            enemyAlive = false;
            healthBarManager.enemyIsAlive = false;
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            GetComponent<BoxCollider2D>().enabled = false;
            legs.SetActive(false);
            transform.position = new Vector3(transform.position.x, transform.position.y, -5);
        }
        else
        {
            isIdle = false;
            shortAttackCoolActive = true;

            animator.SetTrigger("damaged");
        }
    }
}
