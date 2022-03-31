using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public enum Levels { MainMenu, MainGame, City, Graveyard, Forest, Tavern, Lake, Church, Castle, Juliets};
    public Animator transition;
    float transitionTime = 1f;
    int newLevelIndex;

    public void LoadLevel(Levels levelToLoad)
    {              
        switch (levelToLoad)
        {
            case Levels.MainMenu:
                newLevelIndex = 0;
                break;
            case Levels.MainGame:
                newLevelIndex = 1;
                break;
            case Levels.City:
                newLevelIndex = 2;
                break;
            case Levels.Graveyard:
                newLevelIndex = 3;
                break;
            case Levels.Forest:
                newLevelIndex = 4;
                break;
            case Levels.Tavern:
                newLevelIndex = 5;
                break;
            case Levels.Lake:
                newLevelIndex = 6;
                break;
            case Levels.Church:
                newLevelIndex = 7;
                break;
            case Levels.Castle:
                newLevelIndex = 8;
                break;
            case Levels.Juliets:
                newLevelIndex = 9;
                break;
            default:
                print("Incorrect level, Error");
                break;
        }

        StartCoroutine(LoadNewLevel(newLevelIndex));
    }

    IEnumerator LoadNewLevel(int LevelIndex)
    {
        transition.SetTrigger("FadeOut");
        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(LevelIndex);
    }
}
