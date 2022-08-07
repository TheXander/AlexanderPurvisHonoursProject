using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlayerProgress : ScriptableObject
{
    // cardgame complete bools
    [SerializeField]
    public bool lakeCardGameComplete = false, tavernFCardGameComplete = false, cityCardGameComplete = false,
        tavernVCardGameComplete = false, forestCardGameComplete = false, tybaltCardGameComplete = false;

    // Combat complete bools
    [SerializeField]
    public bool castleCombatCompelte = false, forestKCombatCompelte = false, gravyardCombatCompelte = false,
        forestRHCombatCompelte = false, churchCombatCompelte = false, tybaltCombatCompelte = false;

    // dialog complete bools 
    [SerializeField]
    public bool castleDialogCompelte = false, tavernDialogCompelte = false, gravyardTDialogCompelte = false,
        gravyardMDialogCompelte = false, churchDialogCompelte = false, tybaltDialogCompelte = false;

    [SerializeField]
    public int levelOneEventsComplete;
    [SerializeField]
    public int levelTwoEventsComplete;

    [SerializeField]
    public bool julietsReady = false;

    [SerializeField]
    public bool invitedToJuliets = false;

    [SerializeField]
    public bool part2Active = false;

    [SerializeField]
    public bool part2EndActive = false;
}
