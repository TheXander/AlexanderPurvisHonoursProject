﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class CastleDialougeTrigger : MonoBehaviour
{
    public RomeoData romeoData;
    public DialogueRunner dialogueRunner;
    public string conversationStartNode;
    bool triggered = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {      
        if (!triggered && romeoData.previousLocation == LevelLoader.Levels.Lake)
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
