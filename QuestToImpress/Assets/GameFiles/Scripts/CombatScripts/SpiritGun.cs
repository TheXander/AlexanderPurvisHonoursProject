using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiritGun : MonoBehaviour
{
    public GameObject SpiritBall;
    SpiritBall spiritBallControls;

    public HealthBarManager healthBarManager;
    public PlayerAttackManager playerAttackManager;

    public float setUpTimer = 8.0f;
    public float spawnTimer = 3.0f;
    float currentTime = 0.0f;
    public Vector2 fieringDirection = new Vector2(0,-4);
    public bool onRoof = false;
    bool setUp = false;

    void Update()
    {
        if (!setUp)
        {
            currentTime += 1 * Time.deltaTime;
            if (currentTime >= setUpTimer)
            {
                currentTime = 0;
                setUp = true;
            }
        }
        else
        {
           currentTime += 1 * Time.deltaTime;

           if (currentTime >= spawnTimer)
           {
                    currentTime = 0;
                    spawnBall();
           }               
        }
    }

    void spawnBall()
    {
        GameObject newBall = Instantiate(SpiritBall) as GameObject;

        newBall.transform.position = transform.position;
        spiritBallControls = newBall.GetComponent<SpiritBall>();
        spiritBallControls.SetVelocity(fieringDirection);

        spiritBallControls.healthBarManager = healthBarManager;
        spiritBallControls.playerAttackManager = playerAttackManager;

        if (!onRoof)
        {
            spiritBallControls.isBlockable = true;
        }
    }
}
