using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetUpCardGameEvent : MonoBehaviour
{
    public RomeoData romeoData;
    public CardGameManager cardGameManager;
    // Scenes
    public GameObject cityScene;
    public GameObject graveyardScene;
    public GameObject tavernScene;
    public GameObject lakeScene;
    public GameObject forestScene;
    public GameObject churchScene;
    public GameObject castleScene;

    // Level Loader
    public LevelLoader levelLoader;
    LevelLoader.Levels returnDestination;

    // Character Portraits
    public Image PLakeFighter, PTavernFighter, PCityKnight,
                        PTavernAxeMan, PForestGhoul, PTybalt;
    // Characters
    public GameObject LakeFighter, TavernFighter, CityKnight,
                        TavernAxeMan, ForestGhoul, Tybalt;

    private void Awake()
    {
        SetUpScene();
        SetUpOpponent();
    }


    public void ReturnPlayer()
    {
        romeoData.previousLocation = LevelLoader.Levels.CardGame;
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
                forestScene.SetActive(true);
                break;
            case LevelLoader.Levels.Church:
                returnDestination = LevelLoader.Levels.Church;
                churchScene.SetActive(true);
                break;
            case LevelLoader.Levels.Castle:
                returnDestination = LevelLoader.Levels.Castle;
                castleScene.SetActive(true);
                break;
            default:
                break;
        }
    }

    void SetUpOpponent()
    {
        switch (romeoData.CurrentCardgame)
        {
            case RomeoData.CardgameEvents.LakeFighter:                
                PLakeFighter.gameObject.SetActive(true);
                LakeFighter.SetActive(true);
                cardGameManager.enemyAnimator = LakeFighter.GetComponent<Animator>();
                break;
            case RomeoData.CardgameEvents.TavernFighter:
                PTavernFighter.gameObject.SetActive(true);
                TavernFighter.SetActive(true);
                cardGameManager.enemyAnimator = TavernFighter.GetComponent<Animator>();
                break;
            case RomeoData.CardgameEvents.CityKnight:
                PCityKnight.gameObject.SetActive(true);
                CityKnight.SetActive(true);
                cardGameManager.enemyAnimator = CityKnight.GetComponent<Animator>();
                break;
            case RomeoData.CardgameEvents.TavernAxeMan:
                PTavernAxeMan.gameObject.SetActive(true);
                TavernAxeMan.SetActive(true);
                cardGameManager.enemyAnimator = TavernAxeMan.GetComponent<Animator>();
                break;
            case RomeoData.CardgameEvents.ForestGhoul:
                PForestGhoul.gameObject.SetActive(true);
                ForestGhoul.SetActive(true);
                cardGameManager.enemyAnimator = ForestGhoul.GetComponent<Animator>();
                break;
            case RomeoData.CardgameEvents.Tybalt:
                PTybalt.gameObject.SetActive(true);
                Tybalt.SetActive(true);
                cardGameManager.enemyAnimator = Tybalt.GetComponent<Animator>();
                break;

            default:
                break;
        }      
        cardGameManager.LoadEnemyDeckCSVFile(romeoData.CurrentCardgame);
    }
}