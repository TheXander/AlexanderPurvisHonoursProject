using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlayerEventResults : ScriptableObject
{
    [SerializeField]
    public enum EventResults { None, Win, Loss, Draw}

    // Level One Card Games
    [SerializeField]
    public EventResults lakeCardGame, tavernFCardGame, cityCardGame = EventResults.None;

    // Level One Combats
    [SerializeField]
    public EventResults castleCombat, forestKCombat, gravyardCombat = EventResults.None;

    // Level One Dialogues
    [SerializeField]
    public EventResults julietDialogue, barmanDialogue, tybaltDialogue = EventResults.None; 
}
