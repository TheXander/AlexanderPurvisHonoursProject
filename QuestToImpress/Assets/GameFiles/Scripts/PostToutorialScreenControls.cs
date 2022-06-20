using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PostToutorialScreenControls : MonoBehaviour
{
    public MapManager mapManager;

    public GameObject screen, background;
    public Button button;
    public GameObject dialogueView;
    public GameObject playerInstructions;

    public void OpenPostToutorialScreen()
    {
        screen.gameObject.SetActive(true);
        button.gameObject.SetActive(true);
        background.gameObject.SetActive(true);
        dialogueView.gameObject.SetActive(false);
        playerInstructions.gameObject.SetActive(false);
    }

    public void ClosePostToutorialScreen()
    {
        mapManager.OpenMapview();
        screen.gameObject.SetActive(false);      
        button.gameObject.SetActive(false);
        background.gameObject.SetActive(false);
    }
}
