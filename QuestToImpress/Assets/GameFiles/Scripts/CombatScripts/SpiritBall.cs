using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiritBall : MonoBehaviour
{
    float speed = 2.0f;
    private Rigidbody2D rb;
    public HealthBarManager healthBarManager;
    public PlayerAttackManager playerAttackManager;
    int attackDamage = 8;
    public bool isBlockable = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, speed);
    }

    public void SetVelocity(Vector2 newVelocity) {
        rb.velocity = newVelocity;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (!isBlockable)
            {
                healthBarManager.DecreasePlayerHealth(attackDamage);
                Destroy(gameObject);
            }
            else
            {
                if (playerAttackManager.isBlocking)
                {
                    playerAttackManager.ScusessfulBlock();
                }
                else
                {
                    healthBarManager.DecreasePlayerHealth(attackDamage);
                }
                Destroy(gameObject);
            }         
        }

        if (collision.CompareTag("FireWall"))
        {
            Destroy(gameObject);
        }
    }
}
