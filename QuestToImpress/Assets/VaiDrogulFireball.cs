using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VaiDrogulFireball : MonoBehaviour
{
    public GameObject fireballPrefab;
    public Transform spawnPoint;
    public VaiDrogulCombat vaiDrogulCombat;

    float spawnCooldown = 1.4f;
    float cooldownCounter = 0f;

    public int numFireballs = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cooldownCounter += Time.deltaTime;
        if (cooldownCounter >= spawnCooldown)
        {
            //SpawnFireball();
            cooldownCounter = 0;
        }
    }


    public void SpawnFireball()
    {
        numFireballs++;

        float speed =  Random.Range(2.2f, 5.0f);
        float angle = Random.Range(-0.17f, 0.25f);

        GameObject newFireball = Instantiate(fireballPrefab);
        newFireball.transform.position = spawnPoint.position;
        newFireball.GetComponent<FireballControls>().SetSource(this.gameObject);
        newFireball.GetComponent<FireballControls>().SetFireballCourse(-speed, angle);
    }

    public void BurnPlayer()
    {
        vaiDrogulCombat.FireballAttack();       
    }
}
