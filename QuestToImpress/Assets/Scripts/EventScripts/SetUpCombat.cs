using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetUpCombat : MonoBehaviour
{
    public RomeoData romeoData;

    public GameObject cityScene;
    public GameObject graveyardScene;
    public GameObject tavernScene;
    public GameObject lakeScene;
    public GameObject forestScene;
    public GameObject churchScene;
    public GameObject castleScene;

    public LevelLoader levelLoader;
    LevelLoader.Levels returnDestination = LevelLoader.Levels.City;

    private void Awake()
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

    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            romeoData.previousLocation = LevelLoader.Levels.CardGame;
            levelLoader.LoadLevel(returnDestination);
        }
    }
}
