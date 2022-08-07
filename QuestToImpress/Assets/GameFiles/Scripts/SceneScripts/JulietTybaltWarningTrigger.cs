using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class JulietTybaltWarningTrigger : MonoBehaviour
{
    public DialogueRunner dialogueRunner;
    public SceneBasedPlayerControls playerControls;
    public Animator julietAnimator;
    public GameObject level2Ender;
    bool trigger = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player" && !trigger)
        {
            level2Ender.SetActive(true);
            trigger = true;
            playerControls.StopPlayer();
            playerControls.TurnPlayerRight();
            julietAnimator.SetTrigger("MoveToPlayer");
            dialogueRunner.StartDialogue("WarnRomeo");        
        }
    }
}
