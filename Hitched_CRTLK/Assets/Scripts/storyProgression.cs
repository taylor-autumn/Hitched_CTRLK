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
    playerProgress playerProgress;

    public Animator blinkAnim;
    public Animator fadeAnim;

    [Header("Stuff in Scene")]
    public GameObject progressBar;

    //reference to track going in memory doors
    public bool enteredAdulthood = false;
    public bool enteredTeenhood = false;
    public bool enteredChildhood = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //unset the progress bar for now
        progressBar.SetActive(false);

        //mode is dialogue
        mode = gameMode.dialogue;

        //getting all the shit
        dialogueSystem = GameObject.Find("dialogueManager").GetComponent<dialogueSystem>();
        dialogueInfo = GameObject.Find("dialogueManager").GetComponent<dialogueInfo>();
        uiSprites = gameObject.GetComponent<uiSprites>();
        animationProgression = gameObject.GetComponent<animationProgression>();
        playerProgress=GameObject.FindAnyObjectByType<playerProgress>();

        //coroutine starting dialogue
        StartCoroutine(startOfScene());

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

        if (Input.GetKeyDown(KeyCode.Q))
        {
            playerProgress.levelsCompleted += 1;
        }

        //placeholder to trigger rose change
        if (Input.GetKeyDown(KeyCode.X))
        {
            animationProgression.roseChange();
        }

        //placeholder to trigger mural change
        if (Input.GetKeyDown(KeyCode.C))
        {
            animationProgression.muralChange();
        }
    }

    public void startDialogue(List<string> dialogueLines, string charName, Sprite charSprite, bool endOfDialogue)
    {

        //sets it so the game mode is dialogue
        mode = gameMode.dialogue;
        dialogueSystem.enabled = true;
        dialogueSystem.startDialogue(dialogueLines, charName, charSprite, endOfDialogue);
    }

    public void fadeScreen()
    {
        fadeAnim.SetTrigger("go");
    }

    //CO ROUTINES FOR DIALOGUE===================================

    IEnumerator mazeIntro()
    {
        yield return new WaitForSeconds(2f);
        //Her 1 line

    }


    IEnumerator startOfScene()
    {
        //starting blinking animation
        blinkAnim.gameObject.SetActive(true);
        blinkAnim.SetTrigger("go");

        yield return new WaitForSeconds(6f);
        //Her1 line
        startDialogue(dialogueInfo.HerOpening1, "Her", dialogueInfo.herSprite, false);

        yield return new WaitUntil(() => dialogueSystem.dialogueFinished);
        //pause
        yield return new WaitForSeconds(2f);

        //Void1 line
        startDialogue(dialogueInfo.VoidOpening1, "The Void", dialogueInfo.voidSprite, false);

        yield return new WaitUntil(() => dialogueSystem.dialogueFinished);
        //Her2 line
        startDialogue(dialogueInfo.HerOpening2, "Her", dialogueInfo.herSprite, false);

        yield return new WaitUntil(() => dialogueSystem.dialogueFinished);
        //Void2 line
        startDialogue(dialogueInfo.VoidOpening2, "The Void", dialogueInfo.voidSprite, false);

        yield return new WaitUntil(() => dialogueSystem.dialogueFinished);
        //Her3 line
        startDialogue(dialogueInfo.HerOpening3, "Her", dialogueInfo.herSprite, false);

        yield return new WaitUntil(() => dialogueSystem.dialogueFinished);
        //Void3 line
        startDialogue(dialogueInfo.VoidOpening3, "The Void", dialogueInfo.voidSprite, false);

        yield return new WaitUntil(() => dialogueSystem.dialogueFinished);
        //Her4 line
        startDialogue(dialogueInfo.HerOpening4, "Her", dialogueInfo.herSprite, false);

        yield return new WaitUntil(() => dialogueSystem.dialogueFinished);
        //Void4 line
        startDialogue(dialogueInfo.VoidOpening4, "The Void", dialogueInfo.voidSprite, true);

        yield return new WaitUntil(() => dialogueSystem.dialogueFinished);
        //set the progress bar active
        progressBar.SetActive(true);
    }


}
