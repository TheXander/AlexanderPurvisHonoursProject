using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class OnStartDialogueTrigger : MonoBehaviour
{
    public DialogueRunner dialogueRunner;
    public string conversationStartNode;
    float startDialogueCooldown = 1f;
    float cooldownCounter = 0f;

    bool StartCountdown = false;


    private void Start()
    {
        StartCountdown = true;
    }

    private void Update()
    {
        if (StartCountdown)
        {
            cooldownCounter += Time.deltaTime;
            if (cooldownCounter >= startDialogueCooldown)
            {
                dialogueRunner.StartDialogue(conversationStartNode);
                StartCountdown = false;
            }
        }       
    }
}
