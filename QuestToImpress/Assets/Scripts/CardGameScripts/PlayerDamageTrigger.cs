using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageTrigger : MonoBehaviour
{
    public CardGameManager cardGameManager;

    public void DamagePlayer()
    {
        cardGameManager.AsignDamgeToPlayer();
    }
}
