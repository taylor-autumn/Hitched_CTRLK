using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class storyProgression : MonoBehaviour
{
    public enum gameMode
    {
        normal,
        dialogue,
        menu
    }
    public gameMode mode;

    public GameObject canvasMenu;

    //script references
    dialogueSystem dialogueSystem;
    dialogueInfo dialogueInfo;
    uiSprites uiSprites;
    animationProgression animationProgression;
    playerProgress playerProgress;

    //animators for the ui fade screens
    public Animator blinkAnim;
    public Animator fadeAnim;

    [Header("Stuff in Scene")]
    public GameObject progressBar;
    public GameObject vignetteMain;

    [Header("Audio Sources")]
    public AudioSource memorySound;

    [Header("Her Sprites")]
    public GameObject her;
    SpriteRenderer herSpriteRenderer;
    Animator herAnimator;
    //directions
    public Sprite herLeft;
    public Sprite herRight;
    public Sprite herIdle;
    public Sprite herUp;
    public Sprite herRightMove;
    public Sprite herDown;
    public Sprite herLeftMove;

    [Header("Cutscene Trigger Bools")]
    //reference to track going in memory doors
    public bool enteredAdulthood = false;
    public bool enteredAdulthoodCutscene = false;
    public bool enteredTeenhood = false;
    public bool enteredChildhood = false;
    public bool returnedFromAdulthood = false;

    [Header("Adulthood Stuff")]
    public GameObject workHer;
    public GameObject watchingHer;
    public GameObject paperStack;
    public AudioSource knockingSound;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        //unset the progress bar for now
        progressBar.SetActive(false);

        //mode is dialogue
        mode = gameMode.dialogue;

        //her shit
        herAnimator = her.GetComponent<Animator>();
        herSpriteRenderer = her.GetComponent<SpriteRenderer>();

        //getting all the shit
        dialogueSystem = GameObject.Find("dialogueManager").GetComponent<dialogueSystem>();
        dialogueInfo = GameObject.Find("dialogueManager").GetComponent<dialogueInfo>();
        uiSprites = gameObject.GetComponent<uiSprites>();
        animationProgression = gameObject.GetComponent<animationProgression>();
        playerProgress=GameObject.FindAnyObjectByType<playerProgress>();

        //sets ui to starting look
        uiSprites.uiType("adulthood");

        //coroutine starting dialogue
        StartCoroutine(startOfScene());

        //adulthood shit
        workHer.SetActive(false);
        watchingHer.SetActive(false);
        paperStack.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {
        //calls the start of the maze dialogue
        if (enteredAdulthood)
        {
            enteredAdulthood = false;
            StartCoroutine(mazeIntro());
        }
        if (enteredAdulthoodCutscene)
        {
            enteredAdulthoodCutscene = false;
            StartCoroutine(adulthoodCutscene());
        }
        if (returnedFromAdulthood)
        {
            returnedFromAdulthood = false;
            StartCoroutine(endOfDemo());
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

        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("01_menu");
        }

        if (Input.GetKeyDown(KeyCode.M) && (mode == gameMode.normal || mode == gameMode.menu))
        {
            mode = gameMode.menu;
            ToggleMenu();
        }
    }

    public void ToggleMenu()
    {
        bool isActive = canvasMenu.activeSelf;
        canvasMenu.SetActive(!isActive);

        if (isActive)
        {
            mode = gameMode.normal;
            Time.timeScale = 1f;
        }
        else
        {
            mode = gameMode.menu;
            Time.timeScale = 0f;
        }
    }

    public void startDialogue(List<string> dialogueLines, string charName, Sprite charSprite, bool endOfDialogue)
    {
        if (mode!=gameMode.dialogue)
        {
            //sets it so the game mode is dialogue
            mode = gameMode.dialogue;
        }
        dialogueSystem.enabled = true;
        dialogueSystem.startDialogue(dialogueLines, charName, charSprite, endOfDialogue);
    }

    public void fadeScreen()
    {
        fadeAnim.SetTrigger("go");
    }

    //CO ROUTINES FOR DIALOGUE===================================

    IEnumerator endOfDemo()
    {
        yield return new WaitForSeconds(2f);
        //sets vignette active
        vignetteMain.SetActive(true);
        mode = gameMode.dialogue;
        //void1 line
        startDialogue(dialogueInfo.VoidDemoLines, "The Void", dialogueInfo.voidSprite, false);
        yield return new WaitUntil(() => dialogueSystem.dialogueFinished);
    }
    public IEnumerator endAdulthood()
    {
        mode = gameMode.dialogue;
        //making the real her in position and invisible for now
        herAnimator.enabled = false;
        herSpriteRenderer.sprite = herRight;

        yield return new WaitForSeconds(1f);
        herSpriteRenderer.sprite = herIdle;
        yield return new WaitForSeconds(2f);
        //void1 line
        startDialogue(dialogueInfo.VoidEndAdulthood1, "The Void", dialogueInfo.voidSprite, false);
        yield return new WaitUntil(() => dialogueSystem.dialogueFinished);
        //her1 line
        startDialogue(dialogueInfo.HerEndAdulthood1, "Her", dialogueInfo.herSprite, false);
        yield return new WaitUntil(() => dialogueSystem.dialogueFinished);
        //void2 line
        startDialogue(dialogueInfo.VoidEndAdulthood2, "The Void", dialogueInfo.voidSprite, false);
        yield return new WaitUntil(() => dialogueSystem.dialogueFinished);
        //her2 line
        startDialogue(dialogueInfo.HerEndAdulthood2, "Her", dialogueInfo.herSprite, false);
        yield return new WaitUntil(() => dialogueSystem.dialogueFinished);
        //void3 line
        startDialogue(dialogueInfo.VoidEndAdulthood3, "The Void", dialogueInfo.voidSprite, true);
        yield return new WaitUntil(() => dialogueSystem.dialogueFinished);
        herAnimator.enabled = true;

    }
    IEnumerator adulthoodCutscene()
    {
        mode = gameMode.dialogue;
        //sets vignette inactive
        vignetteMain.SetActive(false);
        //set other cutscene stuff active
        workHer.SetActive(true);
        paperStack.SetActive(true);
        //play the memory sound
        memorySound.Play();
        //set the progress bar inactive
        progressBar.SetActive(false);
        //wait for transition
        yield return new WaitForSeconds(2f);
        //making the real her in position and invisible for now
        herAnimator.enabled = false;
        herSpriteRenderer.sprite = herRight;
        herSpriteRenderer.enabled = false;
        watchingHer.SetActive(true);

        yield return new WaitForSeconds(10f);
        //her1 line
        startDialogue(dialogueInfo.HerAdulthood1, "Her", dialogueInfo.herSprite, false);
        yield return new WaitUntil(() => dialogueSystem.dialogueFinished);
        //void1 line
        startDialogue(dialogueInfo.VoidAdulthood1, "The Void", dialogueInfo.voidSprite, false);
        yield return new WaitUntil(() => dialogueSystem.dialogueFinished);
        //her2 line
        startDialogue(dialogueInfo.HerAdulthood2, "Her", dialogueInfo.herSprite, false);
        yield return new WaitUntil(() => dialogueSystem.dialogueFinished);
        //pause
        yield return new WaitForSeconds(4f);
        //void 2 line
        startDialogue(dialogueInfo.VoidAdulthood2, "The Void", dialogueInfo.voidSprite, false);
        yield return new WaitUntil(() => dialogueSystem.dialogueFinished);
        //her3 line
        startDialogue(dialogueInfo.HerAdulthood3, "Her", dialogueInfo.herSprite, false);
        yield return new WaitUntil(() => dialogueSystem.dialogueFinished);
        //void3 line
        startDialogue(dialogueInfo.VoidAdulthood3, "The Void", dialogueInfo.voidSprite, false);
        yield return new WaitUntil(() => dialogueSystem.dialogueFinished);
        //her4 line
        startDialogue(dialogueInfo.HerAdulthood4, "Her", dialogueInfo.herSprite, false);
        yield return new WaitUntil(() => dialogueSystem.dialogueFinished);
        //void4 line
        startDialogue(dialogueInfo.VoidAdulthood4, "The Void", dialogueInfo.voidSprite, false);
        yield return new WaitUntil(() => dialogueSystem.dialogueFinished);
        //her5 line
        startDialogue(dialogueInfo.HerAdulthood5, "Her", dialogueInfo.herSprite, false);
        yield return new WaitUntil(() => dialogueSystem.dialogueFinished);
        //void5 line
        startDialogue(dialogueInfo.VoidAdulthood5, "The Void", dialogueInfo.voidSprite, false);
        yield return new WaitUntil(() => dialogueSystem.dialogueFinished);
        //her6 line
        startDialogue(dialogueInfo.HerAdulthood6, "Her", dialogueInfo.herSprite, false);
        yield return new WaitUntil(() => dialogueSystem.dialogueFinished);
        //void6 line
        startDialogue(dialogueInfo.VoidAdulthood6, "The Void", dialogueInfo.voidSprite, false);
        yield return new WaitUntil(() => dialogueSystem.dialogueFinished);
        //pause
        yield return new WaitForSeconds(5f);
        //her7 line
        startDialogue(dialogueInfo.HerAdulthood7, "Her", dialogueInfo.herSprite, false);
        yield return new WaitUntil(() => dialogueSystem.dialogueFinished);
        //void7 line
        startDialogue(dialogueInfo.VoidAdulthood7, "The Void", dialogueInfo.voidSprite, false);
        yield return new WaitUntil(() => dialogueSystem.dialogueFinished);
        //pause
        yield return new WaitForSeconds(2f);
        //void 7 pt2 line
        startDialogue(dialogueInfo.VoidAdulthood7Pt2, "The Void", dialogueInfo.voidSprite, false);
        yield return new WaitUntil(() => dialogueSystem.dialogueFinished);
        //her8 line
        startDialogue(dialogueInfo.HerAdulthood8, "Her", dialogueInfo.herSprite, false);
        yield return new WaitUntil(() => dialogueSystem.dialogueFinished);
        //void8 line
        startDialogue(dialogueInfo.VoidAdulthood8, "The Void", dialogueInfo.voidSprite, false);
        yield return new WaitUntil(() => dialogueSystem.dialogueFinished);
        //pause
        yield return new WaitForSeconds(1f);
        //her9 line
        startDialogue(dialogueInfo.HerAdulthood9, "Her", dialogueInfo.herSprite, false);
        yield return new WaitUntil(() => dialogueSystem.dialogueFinished);
        //void9 line
        startDialogue(dialogueInfo.VoidAdulthood9, "The Void", dialogueInfo.voidSprite, false);
        yield return new WaitUntil(() => dialogueSystem.dialogueFinished);
        Animator herWorkAnim = workHer.GetComponent<Animator>();
        herWorkAnim.SetTrigger("look");
        knockingSound.Play();
        yield return new WaitForSeconds(4f);
        //him1 line
        startDialogue(dialogueInfo.HimAdulthood1, "Him", dialogueInfo.himSprite, false);
        yield return new WaitUntil(() => dialogueSystem.dialogueFinished);
        yield return new WaitForSeconds(1.5f);
        //ANIMATION OF HER LEAVING GOES HERE
        herWorkAnim.SetTrigger("leave");
        yield return new WaitForSeconds(12f);
        //void10 line
        startDialogue(dialogueInfo.VoidAdulthood10, "The Void", dialogueInfo.voidSprite, true);
        yield return new WaitUntil(() => dialogueSystem.dialogueFinished);
        //set the progress bar active
        progressBar.SetActive(true);

        //making the real her in position and invisible for now
        workHer.SetActive(false);
        watchingHer.SetActive(false);
        herAnimator.enabled = true;
        herSpriteRenderer.enabled = true;
    }
    IEnumerator mazeIntro()
    {
        //set the progress bar inactive
        progressBar.SetActive(false);
        yield return new WaitForSeconds(2f);
        //Her 1 line
        startDialogue(dialogueInfo.HerMazeIntro1, "Her", dialogueInfo.herSprite, false);
        yield return new WaitUntil(() => dialogueSystem.dialogueFinished);
        //Void 1 line
        startDialogue(dialogueInfo.VoidMazeIntro1, "The Void", dialogueInfo.voidSprite, false);
        yield return new WaitUntil(() => dialogueSystem.dialogueFinished);
        //Her 2 line
        startDialogue(dialogueInfo.HerMazeIntro2, "Her", dialogueInfo.herSprite, false);
        //set the progress bar active
        yield return new WaitUntil(() => dialogueSystem.dialogueFinished);
        startDialogue(dialogueInfo.VoidMazeIntro2, "The Void", dialogueInfo.voidSprite, false);
        yield return new WaitUntil(() => dialogueSystem.dialogueFinished);
        startDialogue(dialogueInfo.HerMazeIntro3, "Her", dialogueInfo.herSprite, false);
        yield return new WaitUntil(() => dialogueSystem.dialogueFinished);
        startDialogue(dialogueInfo.VoidMazeIntro3, "The Void", dialogueInfo.voidSprite, false);
        yield return new WaitUntil(() => dialogueSystem.dialogueFinished);
        startDialogue(dialogueInfo.HerMazeIntro4, "Her", dialogueInfo.herSprite, false);
        yield return new WaitUntil(() => dialogueSystem.dialogueFinished);
        startDialogue(dialogueInfo.VoidMazeIntro4, "The Void", dialogueInfo.voidSprite, true);
        yield return new WaitUntil(() => dialogueSystem.dialogueFinished);
        progressBar.SetActive(true);
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
        //pause, she looks left and right, also disables her animator system
        herAnimator.enabled = false;
        herSpriteRenderer.sprite = herIdle;
        yield return new WaitForSeconds(0.5f);
        herSpriteRenderer.sprite = herLeft;
        yield return new WaitForSeconds(0.8f);
        herSpriteRenderer.sprite = herRight;
        yield return new WaitForSeconds(0.8f);
        herSpriteRenderer.sprite = herLeft;
        yield return new WaitForSeconds(0.8f);
        herSpriteRenderer.sprite = herRight;
        yield return new WaitForSeconds(0.8f);

        //Void1 line
        startDialogue(dialogueInfo.VoidOpening1, "The Void", dialogueInfo.voidSprite, false);

        yield return new WaitUntil(() => dialogueSystem.dialogueFinished);
        herSpriteRenderer.sprite = herIdle;
        herAnimator.enabled = true;
        yield return new WaitForSeconds(1f);
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
