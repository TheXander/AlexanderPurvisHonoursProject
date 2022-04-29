using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlayerEventResults : ScriptableObject
{
  
    public enum EventResults { None, Win, Loss, Draw}

    // Level One Card Games
    public EventResults lakeCardGame, tavernFCardGame, cityCardGame = EventResults.None;

    // Level One Combats
    public EventResults castleCombat, forestKCombat, gravyardCombat = EventResults.None;

    // Level One Dialogues
    public EventResults julietDialogue, barmanDialogue, tybaltDialogue = EventResults.None; 
}
