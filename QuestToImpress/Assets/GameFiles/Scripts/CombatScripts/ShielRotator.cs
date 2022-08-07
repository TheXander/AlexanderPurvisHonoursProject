using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShielRotator : MonoBehaviour
{
    public GameObject shiledFire;
    float rotationSpeed = -3.5f;
    bool fireOut = false;
    float cooldown = 0.5f;
    float currentTime = 0.0f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, rotationSpeed)* Time.deltaTime);

        if (fireOut)
        {
            currentTime += 1 * Time.deltaTime;
            if (currentTime >= cooldown)
            {
                shiledFire.SetActive(true);
                fireOut = false;
                currentTime = 0;
            }               
        }
    }

    public void fireActive()
    {
        shiledFire.SetActive(false);
        fireOut = true;
    }
}
