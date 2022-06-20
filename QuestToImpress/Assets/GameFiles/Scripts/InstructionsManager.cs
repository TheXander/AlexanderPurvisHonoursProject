using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstructionsManager : MonoBehaviour
{

    public GameObject instructionView;

    public GameObject completeInstructions;
    public GameObject genralInstructions;
    public GameObject combatInstructions;
    public GameObject cardGameInstructions;

    public GameObject playerHintText;

    public Button exitButton;
    public Button backButton;

    public bool firstCombat;
    public bool firstCardGame;
    public bool preTotorial;
    public bool totorialInstructions = false;

    bool viewUp = false;

    // Created by ALexander Purvis copyright Alexander Purvis
    public GameObject mapsView;
    public GameObject dialogueView;

    public GameObject instructionsBackButton;
    public GameObject instructionsmapsExitButton;
    public GameObject background;
    public GameObject bigBackground;


    public bool totorialRead = false;

    SceneBasedPlayerControls playerControls;
    public GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerControls = player.GetComponent<SceneBasedPlayerControls>();
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !viewUp && !totorialInstructions && !playerControls.movmentLocked)
        {
            mapsView.SetActive(false);

   
            dialogueView.SetActive(false);
           

            backButton.gameObject.SetActive(true);
            playerHintText.SetActive(false);
            instructionView.SetActive(true);
            viewUp = true;
            background.SetActive(true);
            bigBackground.SetActive(true);
            if (firstCombat)
            {
                combatInstructions.SetActive(true);
            }
            else if (firstCardGame)
            {
                cardGameInstructions.SetActive(true);
            }
            else if (preTotorial)
            {
                genralInstructions.SetActive(true);
                exitButton.gameObject.SetActive(true);

                Debug.Log("pretotorial");
            }
            else
            {
                completeInstructions.SetActive(true);
                exitButton.gameObject.SetActive(true);
            }
            instructionsmapsExitButton.SetActive(true);
            instructionsBackButton.SetActive(true);
        }
    }

    public void ViewInstructions()
    {
        mapsView.SetActive(false);
        bigBackground.SetActive(true);
        backButton.gameObject.SetActive(true);
        playerHintText.SetActive(false);
        instructionView.SetActive(true);
        viewUp = true;
        background.SetActive(true);
        dialogueView.SetActive(false);

        if (firstCombat)
        {
            combatInstructions.SetActive(true);       
        }
        else if (firstCardGame)
        {
            cardGameInstructions.SetActive(true);
        }
        else if (preTotorial)
        {
            genralInstructions.SetActive(true);
         
        }
        else
        {
            completeInstructions.SetActive(true);
            
        }
      
        instructionsBackButton.SetActive(true);
    }

    public void ExitView()
    {
        mapsView.SetActive(true);

        instructionView.SetActive(false);

     
       dialogueView.SetActive(true);
        
        
        viewUp = false;

        if (firstCombat)
        {
            combatInstructions.SetActive(true);
        }
        else if (firstCardGame)
        {
            cardGameInstructions.SetActive(true);
        }
        else if (preTotorial)
        {
            genralInstructions.SetActive(true);
            exitButton.gameObject.SetActive(false);
        }
        else
        {
            completeInstructions.SetActive(false);
            exitButton.gameObject.SetActive(false);
        }

        backButton.gameObject.SetActive(false);

        if (!firstCardGame && !firstCombat)
        {
            playerHintText.SetActive(true);
        }
      

        instructionsmapsExitButton.SetActive(false);
        instructionsBackButton.SetActive(false);
        background.SetActive(false);
        bigBackground.SetActive(false);
        totorialRead = true;

        playerControls.StartPlayer();
    }

    public void ExitTheGame()
    {
        Application.Quit();
    }
}
