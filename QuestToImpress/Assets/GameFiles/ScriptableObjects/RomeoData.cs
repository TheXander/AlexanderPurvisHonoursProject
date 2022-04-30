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
    [SerializeField]
    public enum Events { None, CardGame, Combat, Dialog };
    [SerializeField]
    public Events currentEvent = Events.None;
    [SerializeField]
    public Vector3 previousPlayerCoordinates;

    // Events
    [SerializeField]
    public enum CardgameEvents { None, LakeFighter, TavernFighter, CityKnight, TavernAxeMan, ForestGhoul, Tybalt};
    [SerializeField]
    public enum CombatEvents { None, CastleKnight, ForestKnight, CultistPriest, RedHood, EvilSpirt, Tybalt};
    [SerializeField]
    public enum DialogEvents { None, Mercutio}

    // Current Cardgame Event
    [SerializeField]
    public CardgameEvents CurrentCardgame = CardgameEvents.None;
    // Current Combat Event
    [SerializeField]
    public CombatEvents CurrentCombat = CombatEvents.None;
    // Current Dialog Event
    [SerializeField]
    public DialogEvents CurrentDialog = DialogEvents.None;
}