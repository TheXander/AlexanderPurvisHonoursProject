using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public enum Levels { MainMenu, MainGame };
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
            default:
                print("Incorrect level, Error");
                break;
        }

        StartCoroutine(LoadNewLevel(newLevelIndex));
    }

    IEnumerator LoadNewLevel(int LevelIndex)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(LevelIndex);
    }
}
