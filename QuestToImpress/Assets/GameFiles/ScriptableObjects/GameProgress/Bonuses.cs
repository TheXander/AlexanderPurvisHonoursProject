using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Bonuses : ScriptableObject {

    [SerializeField]
    public int healthBonus = 0;

    [SerializeField]
    public int attackBonus = 0;

    [SerializeField]
    public int honourBonus = 0;
}
