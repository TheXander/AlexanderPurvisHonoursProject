using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class DialogEventTrigger : MonoBehaviour
{
    public SceneBasedPlayerControls playerControls;
    public DialogueRunner dialogueRunner;
    public string conversationStartNode;
    bool triggered = false;

    // Update is called once per frame
    void Update()
    {
        if (playerControls.eventReady && triggered && !playerControls.confirmingEvent)
        {
            playerControls.confirmingEvent = true;
            StartConversation();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!triggered)
        {
            triggered = true;
            playerControls.confirmingEvent = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        triggered = false;     
    }


    private void StartConversation()
    {
        dialogueRunner.StartDialogue(conversationStartNode);
    }
}
