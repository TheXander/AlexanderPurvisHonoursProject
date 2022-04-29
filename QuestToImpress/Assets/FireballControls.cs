using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballControls : MonoBehaviour
{  
    public  Rigidbody2D rb;
    public VaiDrogulFireball vaiDrogulFireballs;

    private void Start()
    {      
              
    }

    private void Update()
    {
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
           
            vaiDrogulFireballs.BurnPlayer();
            Destroy(gameObject);
        }    
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Wall"))
        {        
            Destroy(gameObject);
        }
    }

    public void SetFireballCourse(float speed, float angle)
    {
        rb.velocity = new Vector2(speed, angle);
    }

    public void SetSource(GameObject Source)
    {
        vaiDrogulFireballs = Source.GetComponent<VaiDrogulFireball>();
    }
}
