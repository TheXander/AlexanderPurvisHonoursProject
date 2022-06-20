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
  
    public GameObject background;
    public PlayerProgress playerProgress;

    SceneBasedPlayerControls playerControls;
    public GameObject player;

    public GameObject L1ForestCombat, L1CityCombat, L1TavernCardgame, L1TavernDialoge, L1GraveyardDialoge, L1GraveyardCombat;

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
            OpenMapview();
        }    
    }

    public void OpenMapview()
    {

        if (!preTutorial)
        {
            SetUpIcons();
        }

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
 
    public void ExitMapView()
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
        playerControls.StartPlayer();
        ShutDownIcons();
    }

    void SetUpIcons()
    {
        if (!playerProgress.forestKCombatCompelte)
        {
            L1ForestCombat.SetActive(true);

            Debug.Log("!forestKCombatCompelte");
        }
        else
        {
            L1ForestCombat.SetActive(false);
        }

        if (!playerProgress.cityCardGameComplete)
        {
            L1CityCombat.SetActive(true);
            Debug.Log("!cityCardGameComplete");
        }
        else
        {
            L1CityCombat.SetActive(false);
        }

        if (!playerProgress.tavernFCardGameComplete)
        {
            L1TavernCardgame.SetActive(true);
            Debug.Log("!tavernFCardGameComplete");
        }
        else
        {
            L1TavernCardgame.SetActive(false);
        }

        if (!playerProgress.tavernDialogCompelte)
        {
            L1TavernDialoge.SetActive(true);
            Debug.Log("!tavernDialogCompelte");
        }
        else
        {
            L1TavernDialoge.SetActive(false);
        }

        if (!playerProgress.gravyardCombatCompelte)
        {
            L1GraveyardCombat.SetActive(true);
            Debug.Log("!gravyardCombatCompelte");
        }
        else
        {
            L1GraveyardCombat.SetActive(false);
        }

        if (!playerProgress.gravyardTDialogCompelte)
        {
            L1GraveyardDialoge.SetActive(true);
            Debug.Log("!gravyardTDialogCompelte");
        }
        else
        {
            L1GraveyardDialoge.SetActive(false);
        }
    }

    void ShutDownIcons()
    {
        L1ForestCombat.SetActive(false); 
        L1CityCombat.SetActive(false); 
        L1TavernCardgame.SetActive(false);
        L1TavernDialoge.SetActive(false); 
        L1GraveyardCombat.SetActive(false); 
        L1GraveyardDialoge.SetActive(false);
    }
}
