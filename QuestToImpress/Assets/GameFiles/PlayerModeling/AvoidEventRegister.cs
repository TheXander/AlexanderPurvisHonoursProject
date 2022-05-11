using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvoidEventRegister : MonoBehaviour
{
    public  enum EventTypes { None, Combat, CardGame, Dialogue}
    public EventTypes typeOfEvent;

    public enum Locations { None, City, Graveyard, Forest, Tavern}
    public Locations thisLocation;
    public PlayerModel playerModel;

    public bool registerCanceled = false;

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "Player" && !registerCanceled)
        {


            switch (typeOfEvent)
            {
                case EventTypes.Combat:
                    playerModel.NewCombatAvoided();
                    break;
                case EventTypes.CardGame:
                    playerModel.NewCardGameAvoided();
                    break;
                case EventTypes.Dialogue:
                    playerModel.NewDialogueAvoided();
                    break;
                default:

                    break;
            }

            switch (thisLocation)
            {
                case Locations.City:
                    playerModel.StandardUpdate(true, "City");
                    break;
                case Locations.Graveyard:
                    playerModel.StandardUpdate(true, "Graveyard");
                    break;
                case Locations.Forest:
                    playerModel.StandardUpdate(true, "Forest");
                    break;
                case Locations.Tavern:
                    playerModel.StandardUpdate(true, "Tavern");
                    break;
                default:

                    break;
            }
        }
    }
}
