using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour
{  
    public Animator uiAnimator;
    public Animator introAnimator;

    public void StartGame()
    {      
        uiAnimator.SetTrigger("HideUI");
        introAnimator.SetTrigger("PlayIntro");
    }
}
