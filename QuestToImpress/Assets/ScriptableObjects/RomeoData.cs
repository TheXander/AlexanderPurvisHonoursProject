using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class RomeoData : ScriptableObject
{
    [SerializeField]
    public LevelLoader.Levels previousLocation = LevelLoader.Levels.MainMenu;

    [SerializeField]
    public LevelLoader.Levels currentLocation = LevelLoader.Levels.MainMenu;

    // Event Managment
    public enum Events { None, CardGame, Combat, Dialog };
    public Events currentEvent = Events.None;
    public Vector3 previousPlayerCoordinates;

    // Events
    public enum CardgameEvents { None, LakeFighter, TavernFighter, CityKnight, TavernAxeMan, ForestGhoul, Tybalt};
    public enum CombatEvents { None, CastleKnight, ForestKnight, CultistPriest, RedHood, EvilSpirt, Tybalt};
    public enum DialogEvents { None, Mercutio}

    // Current Cardgame Event
    public CardgameEvents CurrentCardgame = CardgameEvents.None;
    // Current Combat Event
    public CombatEvents CurrentCombat = CombatEvents.None;
    // Current Dialog Event
    public DialogEvents CurrentDialog = DialogEvents.None;
}