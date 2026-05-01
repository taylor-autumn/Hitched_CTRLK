using System.Collections;
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
    animationProgression animationProgression;

    public Animator blinkAnim;
    public Animator fadeAnim;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mode = gameMode.dialogue;
        dialogueSystem = GameObject.Find("dialogueManager").GetComponent<dialogueSystem>();
        dialogueInfo = GameObject.Find("dialogueManager").GetComponent<dialogueInfo>();
        uiSprites = gameObject.GetComponent<uiSprites>();
        animationProgression = gameObject.GetComponent<animationProgression>();
        
        StartCoroutine(startOfScene());

    }

    IEnumerator startOfScene()
    {
        blinkAnim.gameObject.SetActive(true);
        blinkAnim.SetTrigger("go");
        yield return new WaitForSeconds(6f);
        startDialogue(dialogueInfo.startingHerDialogue, "Her", dialogueInfo.herSprite, false);

        yield return new WaitUntil(() => dialogueSystem.dialogueFinished);
        yield return new WaitForSeconds(2f);
        startDialogue(dialogueInfo.voidFirstLines, "The Void", dialogueInfo.voidSprite, true);
        
    }
    // Update is called once per frame
    void Update()
    {
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

        //placeholder to trigger rose change
        if (Input.GetKeyDown(KeyCode.X))
        {
            animationProgression.roseChange();
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            animationProgression.muralChange();
        }
    }

    public void startDialogue(List<string> dialogueLines, string charName, Sprite charSprite, bool endOfDialogue)
    {

        print("calling dialogue");
        //sets it so the game mode is dialogue
        mode = gameMode.dialogue;
        dialogueSystem.enabled = true;
        dialogueSystem.startDialogue(dialogueLines, charName, charSprite, endOfDialogue);
    }



}
