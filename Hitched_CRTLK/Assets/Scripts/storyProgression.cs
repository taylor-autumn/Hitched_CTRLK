using System.Collections.Generic;
using UnityEngine;

public class storyProgression : MonoBehaviour
{
    public enum gameMode
    {
        normal,
        dialogue,
        menu
    }
    public gameMode mode;

    dialogueSystem dialogueSystem;
    dialogueInfo dialogueInfo;
    uiSprites uiSprites;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mode = gameMode.normal;
        dialogueSystem = GameObject.Find("dialogueManager").GetComponent<dialogueSystem>();
        dialogueInfo = GameObject.Find("dialogueManager").GetComponent<dialogueInfo>();
        uiSprites = gameObject.GetComponent<uiSprites>();

    }

    // Update is called once per frame
    void Update()
    {
        //this is a placeholder for now, this would happen after like a starter animation
        if (Input.GetKeyDown(KeyCode.Space) && mode == gameMode.normal && !dialogueSystem.inDialogue)
        {
            startDialogue(dialogueInfo.startingMindscape, "The Void", dialogueInfo.voidSprite);
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (uiSprites.enabled == false)
            {
                uiSprites.enabled = true;
            }
            else
            {
                uiSprites.enabled = false;
            }
        }
    }

    public void startDialogue(List<string> dialogueLines, string charName, Sprite charSprite)
    {
        print("calling dialogue");
        //sets it so the game mode is dialogue
        mode = gameMode.dialogue;
        dialogueSystem.enabled = true;
        dialogueSystem.startDialogue(dialogueLines, charName, charSprite);
    }



}
