using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShielFire : MonoBehaviour
{
    int attackDamage = 3;
    public HealthBarManager healthBarManager;
    public ShielRotator shielRotator;
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("PlayerHit");
            healthBarManager.DecreasePlayerHealth(attackDamage);
            shielRotator.fireActive();
        }
    }
}
