using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class CastleDialougeTrigger : MonoBehaviour
{
    public DialogueRunner dialogueRunner;
    public string conversationStartNode;
    bool triggered = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {      
        if (!triggered)
        {
            triggered = true;
            StartConversation();
           
        }
    }

    private void StartConversation()
    {
        dialogueRunner.StartDialogue(conversationStartNode);
    }
}
