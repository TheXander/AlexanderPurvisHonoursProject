using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlayerProgress : ScriptableObject
{
    // cardgame complete bools
    public bool lakeCardGameComplete = false, tavernFCardGameComplete = false, cityCardGameComplete = false,
        tavernVCardGameComplete = false, forestCardGameComplete = false, tybaltCardGameComplete = false;
    
    // Combat complete bools
    public bool castleCombatCompelte = false, forestKCombatCompelte = false, gravyardCombatCompelte = false,
        forestRHCombatCompelte = false, churchCombatCompelte = false, tybaltCombatCompelte = false;
   
    // dialog complete bools 
    public bool castleDialogCompelte = false, tavernDialogCompelte = false, gravyardTDialogCompelte = false,
        gravyardMDialogCompelte = false, churchDialogCompelte = false, tybaltDialogCompelte = false;

    public int levelOneEventsComplete;
    public int levelTwoEventsComplete;
}
