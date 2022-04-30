using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageTrigger : MonoBehaviour
{
    public CardGameManager cardGameManager;

    public void DamageEnemy()
    {
        cardGameManager.AsignDamgeToEnemey();
    }
}
