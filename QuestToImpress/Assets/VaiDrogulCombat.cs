using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VaiDrogulCombat : MonoBehaviour
{
    [SerializeField] private bool enemyFacingRight;
    private Rigidbody2D spriteBody2D;
    private Vector3 velocityZero = Vector3.zero;
    [Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = 0.2f;	// How much to smooth out the movement
    private Animator animator;
    public Animator effects;
    int direction = 0;
    float movmentSpeed = 10.0f;
    float move;

    public bool enemyAlive = true;
    public bool enemyActive = true;
    bool takingdamage = false;

    public HealthBarManager healthBarManager;
    public PlayerAttackManager playerAttackManager;
    public VaiDrogulFireball vaiDrogulFireball;
    public GameObject player;
    public GameObject legs;

     
    int attackDamage = 5;
    float attackRange = 3f;

    float attackLongCooldown = 2f;
    float attackShortCooldown = 0.4f;
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
    }


    void Update()
    {
     
    }


    public void MoveEnemy()
    {
       
    }


    private void FlipSprite()
    {
        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }


    void Attack()
    {
        effects.SetTrigger("Attack");
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

                attacks++;
                             
                if (attacks >= 4)
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


    public void DamageReaction(float currentHealth)
    {
        if (currentHealth <= 0)
        {
            animator.SetBool("isDead", true);
            animator.SetTrigger("Die");
            transform.position = new Vector3(transform.position.x, -2.8f, transform.position.z);
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
}
