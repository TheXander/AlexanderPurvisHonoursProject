﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class CityIntroDialogTrigger : MonoBehaviour
{
    public RomeoData romeoData;
    public DialogueRunner dialogueRunner;
    public string conversationStartNode;
    bool triggered = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!triggered && romeoData.previousLocation == LevelLoader.Levels.MainMenu)
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
