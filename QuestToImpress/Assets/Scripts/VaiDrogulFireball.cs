using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VaiDrogulFireball : MonoBehaviour
{
    public GameObject fireballPrefab;
    public Transform spawnPoint;
    public VaiDrogulCombat vaiDrogulCombat;


    public void SpawnFireball()
    {
        float speed =  Random.Range(2.2f, 5.0f);
        float angle = Random.Range(-0.17f, 0.25f);

        if (!vaiDrogulCombat.enemyFacingRight)
        {
            speed = speed * -1;
        }

        GameObject newFireball = Instantiate(fireballPrefab);
        newFireball.transform.position = spawnPoint.position;
        newFireball.GetComponent<FireballControls>().SetSource(this.gameObject);
        newFireball.GetComponent<FireballControls>().SetFireballCourse(speed, angle);
    }

    public void BurnPlayer()
    {
        vaiDrogulCombat.FireballAttack();       
    }
}
