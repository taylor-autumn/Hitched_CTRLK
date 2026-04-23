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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mode = gameMode.normal;
        dialogueSystem = GameObject.Find("dialogueManager").GetComponent<dialogueSystem>();
        dialogueInfo = GameObject.Find("dialogueManager").GetComponent<dialogueInfo>();

    }

    // Update is called once per frame
    void Update()
    {
        //this is a placeholder for now, this would happen after like a starter animation
        if (Input.GetKeyDown(KeyCode.Space) && mode == gameMode.normal && !dialogueSystem.inDialogue)
        {
            print("calling dialogue");
            //sets it so the game mode is dialogue
            mode = gameMode.dialogue;
            dialogueSystem.enabled = true;
            dialogueSystem.startDialogue(dialogueInfo.startingMindscape, "The Void", dialogueInfo.voidSprite);

        }

    }
}
