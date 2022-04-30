using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballControls : MonoBehaviour
{  
    public  Rigidbody2D rb;
    public VaiDrogulFireball vaiDrogulFireballs;
    Vector2 direction;

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
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = direction;
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
        direction = new Vector2(speed, 0);
    }

    public void SetSource(GameObject Source)
    {
        vaiDrogulFireballs = Source.GetComponent<VaiDrogulFireball>();
    }
}
