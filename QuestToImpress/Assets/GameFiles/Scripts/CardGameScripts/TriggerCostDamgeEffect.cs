using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCostDamgeEffect : MonoBehaviour
{
    public Animator animator;

    public void ActivateEffectAnaimation()
    {
        animator.SetTrigger("FadeInOut");
    }
}
