using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGauntletPriest : MonoBehaviour
{
    [SerializeField] private bool enemyFacingRight;
    private Rigidbody2D spriteBody2D;
    private Vector3 velocityZero = Vector3.zero;
    [Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = 0.2f;	// How much to smooth out the movement
    private Animator animator;
    int direction = 0;
    float movmentSpeed = 10.0f;
    float move;

    public bool enemyAlive = true;
    public bool enemyActive = false;
    bool takingdamage = false;
 
    public HealthBarManager healthBarManager;
    public PlayerAttackManager playerAttackManager;
    public GameObject player;
    public GameObject legs;

    Transform attackPoint;
    LayerMask playerLayeres;
    int attackDamage = 5;
    float attackRange = 2f;

    float attackLongCooldown = 4.4f;
    float attackShortCooldown = 1.4f;
    float cooldownCounter = 0f;

    float walkingTime = 5f;
    float walkingCounter = 0f;

    int attacks = 0;
    bool freeToMoveAttack = true;
    bool isIdle = false;
    bool shortAttackCoolActive = false;
    bool longAttackCoolActive = false;

    private void Awake()
    {
        spriteBody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
       
        attackPoint = transform.Find("AttackPoint");
        playerLayeres = LayerMask.GetMask("Player");
    }


    void Update()
    {

        if (enemyAlive && enemyActive)
        {
            if (shortAttackCoolActive)
            {
                if (!isIdle)
                {
                    healthBarManager.enemyIsVulnerable = true;
                    animator.SetBool("onBreak", true);
                    animator.SetTrigger("idle");
                    isIdle = true;
                }

               
                cooldownCounter += Time.deltaTime;
                if (cooldownCounter >= attackShortCooldown)
                {
                    shortAttackCoolActive = false;
                    freeToMoveAttack = true;
                    isIdle = false;
                    cooldownCounter = 0;
                    animator.SetBool("onBreak", false);
                }
            }

            if (longAttackCoolActive)
            {

                if (!isIdle)
                {
                    healthBarManager.enemyIsVulnerable = true;
                    animator.SetBool("onBreak", true);
                    animator.SetTrigger("idle");
                    isIdle = true;
                }
             
                cooldownCounter += Time.deltaTime;
                if (cooldownCounter >= attackLongCooldown)
                {
                    longAttackCoolActive = false;
                    freeToMoveAttack = true;
                    isIdle = false;
                    cooldownCounter = 0;
                    animator.SetBool("onBreak", false);
                }
            }

            if (freeToMoveAttack)
            {
                MoveEnemy();
            }
        }          
    }


    public void MoveEnemy()
    {
        if (enemyAlive && enemyActive)
        {
            

            walkingCounter += Time.deltaTime;
            if (walkingCounter >= walkingTime)
            {
                longAttackCoolActive = true;
                freeToMoveAttack = false;
                walkingCounter = 0;
            }


            animator.SetTrigger("walk");
            isIdle = false;

            Vector2 playerPos = player.transform.position;
            Vector2 currentPos = this.transform.position;

            if (playerPos.x < currentPos.x)
            {
                direction = -1;
                if (enemyFacingRight == true)
                {
                    FlipSprite();
                    enemyFacingRight = false;
                }
            }
            else if (playerPos.x > currentPos.x)
            {
                direction = 1;
                if (enemyFacingRight == false)
                {
                    FlipSprite();
                    enemyFacingRight = true;
                }
            }


            
            if (Vector2.Distance(currentPos, playerPos) <= attackRange)
            {
                animator.SetTrigger("attack");
                healthBarManager.enemyIsVulnerable = false;
            }
            else
            {
                healthBarManager.enemyIsVulnerable = true;
                // animator.SetFloat("enemySpeed", Mathf.Abs((float)direction));
                move = (direction * Time.fixedDeltaTime) * movmentSpeed;
                // Move the character by finding the target velocity
                Vector3 targetVelocity = new Vector2(move * 10f, spriteBody2D.velocity.y);
                // And then smoothing it out and applying it to the character
                spriteBody2D.velocity = Vector3.SmoothDamp(spriteBody2D.velocity, targetVelocity, ref velocityZero, m_MovementSmoothing);
             
            }
        }
    }


    private void FlipSprite()
    {
        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }


    public void Attack() {

        if (enemyAlive)
        {          
            bool attackBlocked = false;

            if (playerAttackManager.isBlocking && playerAttackManager.enemyDetected)
            {
                attackBlocked = true;
                playerAttackManager.ScusessfulBlock();
            }

            if (enemyActive)
            {
                Collider2D[] playerHits = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerLayeres);
                foreach (Collider2D playerHit in playerHits)
                {

                    if (!attackBlocked)
                    {
                        healthBarManager.DecreasePlayerHealth(attackDamage);
                    }

                    attacks++;
                    freeToMoveAttack = false;
                    walkingCounter = 0f;
                    isIdle = false;
                    if (attacks >= 3)
                    {
                        longAttackCoolActive = true;
                    }
                    else
                    {
                        shortAttackCoolActive = true;
                    }
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
                enemyAlive = false;
                healthBarManager.enemyIsAlive = false;
                GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
                GetComponent<BoxCollider2D>().enabled = false;
                legs.SetActive(false);
                transform.position = new Vector3(transform.position.x, transform.position.y, -5);
            }
            else
            {
                freeToMoveAttack = false;
                isIdle = false;
                shortAttackCoolActive = true;

                animator.SetTrigger("damaged");
            }              
    }

    public void ActivateEnemy()
    {
        if (takingdamage)
        {
            takingdamage = false;
        }
        enemyActive = true;
    }

    public void DeactivateEnemy()
    {
        if (!takingdamage)
        {

            enemyActive = false;
            takingdamage = true;
        }
    }
}
