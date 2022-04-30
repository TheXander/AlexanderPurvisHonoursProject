using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundNPCMovement : MonoBehaviour
{
    Animator animator;

    public Transform[] waypoints;
    int currentWaypoint = 0;
    int nextWapoint = 0;
    public float movmentSpeed;   
    public float WPRadius = 0.1f;
  
    float originalScaleX;
    bool characterFacingRight = true;

    public float pauseTime;
    float countDownTime;
    bool paused = false;

   
    private void Start()
    {
        animator = GetComponent<Animator>();
        DetermineNextWayPoint();
        originalScaleX = transform.localScale.x;
        countDownTime = pauseTime;
    }

    private void Update()
    {
        if (!paused)
        {
            MoveNPC();
        }
        else
        {
            CountDownTimer();
        }  
    }


    void MoveNPC()
    {
        if (Vector3.Distance(waypoints[currentWaypoint].position, transform.position) < WPRadius)
        {
            paused = true;
            animator.SetTrigger("Pause");
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypoint].position, Time.deltaTime * movmentSpeed);
        }
    }


    void DetermineNextWayPoint()
    {
        nextWapoint = Random.Range(0, waypoints.Length);
        if (nextWapoint == currentWaypoint)
        {
            nextWapoint++;

            if (nextWapoint >= waypoints.Length)
            {
                nextWapoint = 0;
            }
        }
       
        if (waypoints[nextWapoint].position.x < waypoints[currentWaypoint].position.x)
        {
            TurnLeft();
        }
        else
        {
            TurnRight();
        }

        animator.SetTrigger("Walk");
        currentWaypoint = nextWapoint;
    }

    void TurnLeft()
    {
        if (characterFacingRight)
        {
            transform.localScale = new Vector3(-originalScaleX, transform.localScale.y, transform.localScale.z);
            characterFacingRight = false;
        }       
    }

    void TurnRight()
    {
        if (!characterFacingRight)
        {
            transform.localScale = new Vector3(originalScaleX, transform.localScale.y, transform.localScale.z);
            characterFacingRight = true;
        }      
    }


    void CountDownTimer()
    {
        countDownTime -= 1 * Time.deltaTime;

        if (countDownTime <= 0)
        {
            countDownTime = pauseTime;
            paused = false;
            DetermineNextWayPoint();
        }
    }
}
