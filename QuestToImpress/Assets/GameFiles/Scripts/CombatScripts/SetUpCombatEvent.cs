using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetUpCombatEvent : MonoBehaviour
{
    public RomeoData romeoData;

    public GameObject cityScene;
    public GameObject graveyardScene;
    public GameObject tavernScene;
    public GameObject lakeScene;
    public GameObject forestScene;
    public GameObject churchScene;
    public GameObject castleScene;

    public GameObject ForestSpawnPoint, CastleSpawnPoint, GraveyardSpawnPoint;
    public GameObject player;

    // Character Portraits
    public Image pCastleKnight, pForestKnight, pGraveyardPriest,
                        pForestRedHood, pChurchPriest, PTybalt;

    public LevelLoader levelLoader;
    LevelLoader.Levels returnDestination;



    private void Awake()
    {
        SetUpScene();
        ChoseEnemey();
    }

   
    public void ReturnPlayer()
    {
        romeoData.previousLocation = LevelLoader.Levels.Combat;
        levelLoader.LoadLevel(returnDestination);
    }

    void SetUpScene()
    {
        switch (romeoData.previousLocation)
        {
            case LevelLoader.Levels.City:
                returnDestination = LevelLoader.Levels.City;
                cityScene.SetActive(true);
                break;
            case LevelLoader.Levels.Graveyard:
                returnDestination = LevelLoader.Levels.Graveyard;
                player.transform.position = GraveyardSpawnPoint.transform.position;
                graveyardScene.SetActive(true);
                break;
            case LevelLoader.Levels.Tavern:
                returnDestination = LevelLoader.Levels.Tavern;
                tavernScene.SetActive(true);
                break;
            case LevelLoader.Levels.Lake:
                returnDestination = LevelLoader.Levels.Lake;
                lakeScene.SetActive(true);
                break;
            case LevelLoader.Levels.Forest:
                returnDestination = LevelLoader.Levels.Forest;
                player.transform.position = ForestSpawnPoint.transform.position;
                forestScene.SetActive(true);
                break;
            case LevelLoader.Levels.Church:
                returnDestination = LevelLoader.Levels.Church;
                churchScene.SetActive(true);
                break;
            case LevelLoader.Levels.Castle:
                returnDestination = LevelLoader.Levels.Castle;
                player.transform.position = CastleSpawnPoint.transform.position;
                castleScene.SetActive(true);        
                break;

            default:
                break;
        }
    }

    void ChoseEnemey()
    {
        switch (romeoData.CurrentCombat)
        {
            case RomeoData.CombatEvents.CastleKnight:
                SetUpCastleKnight();
                break;
            case RomeoData.CombatEvents.ForestKnight:
                SetUpForestKnight();
                break;
            case RomeoData.CombatEvents.CultistPriest:
                SetUpCultistPriest();
                break;
            case RomeoData.CombatEvents.RedHood:
                SetUpRedHood();
                break;
            case RomeoData.CombatEvents.EvilSpirt:
                SetUpEvilSpirt();
                break;
            case RomeoData.CombatEvents.Tybalt:
                SetUpTybalt();
                break;
           
            default:
                break;
        }
    }

    void SetUpCastleKnight()
    {
        pCastleKnight.gameObject.SetActive(true);
    }

    void SetUpForestKnight()
    {
        pForestKnight.gameObject.SetActive(true);
    }

    void SetUpCultistPriest()
    {
        pGraveyardPriest.gameObject.SetActive(true);
    }

    void SetUpRedHood()
    {
        pForestRedHood.gameObject.SetActive(true);
    }

    void SetUpEvilSpirt()
    {
        pChurchPriest.gameObject.SetActive(true);
    }

    void SetUpTybalt()
    {
        PTybalt.gameObject.SetActive(true);
    }
}