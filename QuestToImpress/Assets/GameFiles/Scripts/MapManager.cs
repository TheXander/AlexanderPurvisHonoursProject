using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapManager : MonoBehaviour
{
    public GameObject maps;
    public GameObject playerHintText;
    public GameObject tutorialMap;
    public GameObject level1Map;
    public GameObject Level1EndMap;

    public bool preTutorial = false;
    bool enoughQuestsComplete = false;
    public bool totorialMaps = false;

    bool viewUp = false;

    public GameObject instructionsView;
    public GameObject dialogueView;

    public Button mapsBackButton;
    //public GameObject mapsBackButton;

    public GameObject background;

    public PlayerProgress playerProgress;

    SceneBasedPlayerControls playerControls;
    public GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerControls = player.GetComponent<SceneBasedPlayerControls>();
    }

    // Update is called once per frame
    void Update()
    {

        if (playerProgress.julietsReady && !enoughQuestsComplete)
        {
            enoughQuestsComplete = true;
        }


        if (Input.GetKeyDown(KeyCode.M) && !viewUp && !totorialMaps && !playerControls.movmentLocked)
        {
            instructionsView.SetActive(false);
            dialogueView.SetActive(false);
            playerHintText.SetActive(false);
            viewUp = true;
            maps.SetActive(true);
            background.SetActive(true);

            if (preTutorial)
            {
                tutorialMap.SetActive(true);
            }
            else if (enoughQuestsComplete)
            {
                Level1EndMap.SetActive(true);
            }
            else
            {
                level1Map.SetActive(true);
                
            }
            mapsBackButton.gameObject.SetActive(true);
        }
       
    }

 
    public void ExitView()
    {
        viewUp = false;
        playerHintText.SetActive(true);
        instructionsView.SetActive(true);
        dialogueView.SetActive(true);
        if (preTutorial)
        {
            tutorialMap.SetActive(false);
        }
        else if (enoughQuestsComplete)
        {
            Level1EndMap.SetActive(false);
        }
        else
        {
            level1Map.SetActive(false);
            
        }

        maps.SetActive(false);
        mapsBackButton.gameObject.SetActive(false);
        background.SetActive(false);
    }
}
