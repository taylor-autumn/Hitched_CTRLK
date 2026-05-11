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

    [Header("Animators")]
    public Animator adulthoodDoorAnim;
    public Animator teenhoodDoorAnim;
    public Animator childhoodDoorAnim;

    [Header("Stuff in Scene")]
    public GameObject progressBar;
    public GameObject vignetteMain;

    [Header("Audio Sources")]
    public AudioSource memorySound;
    public AudioSource scissorSound;
    public AudioSource openDoorSound;

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
    public bool enteredTeenhoodMaze = false;
    public bool enteredTeenhood = false;
    public bool enteredTeenhood2 = false;
    public bool enteredChildhood = false;

    [Header("Adulthood Stuff")]
    public GameObject workHer;
    public GameObject watchingHer;
    public GameObject paperStack;
    public AudioSource knockingSound;
    public AudioSource bgAdultMusic;

    [Header("Teenhood Stuff")]
    public AudioSource schoolBell;
    public AudioSource romanticMusic;
    public AudioSource hsBGSound;
    public AudioSource bufferSound;
    public GameObject followHer;
    public Animator himDoorAnim;
    public Animator firstDoorAnim;
    public Animator teenHerAnim;
    public Animator himAnim;
    public Animator sunMoonAnim;
    public Animator sketchbook;

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

        //teenhood shit
        sketchbook.gameObject.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {
        //calls the start of the maze dialogue
        if (enteredAdulthood)
        {
            //play maze music here==================
            openDoorSound.Play();
            enteredAdulthood = false;
            StartCoroutine(mazeIntro());
        }
        if (enteredAdulthoodCutscene)
        {
            //placeholder for swap function===========
            bgAdultMusic.Play();
            enteredAdulthoodCutscene = false;
            StartCoroutine(adulthoodCutscene());
        }
        if (enteredTeenhoodMaze)
        {
            //play maze music here=================
            enteredTeenhoodMaze = false;
            openDoorSound.Play();
            StartCoroutine(teenMaze());
        }
        if (enteredTeenhood)
        {
            //placeholder to swap maze music with the teen music===========================
             hsBGSound.Play();
            enteredTeenhood = false;
            StartCoroutine(teenScene1());
        }
        if (enteredTeenhood2)
        {
            enteredTeenhood2 = false;
            hsBGSound.Stop();
            StartCoroutine(teenScene2());
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
        if (Input.GetKeyDown(KeyCode.M))
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

    public IEnumerator SwapAudio(AudioSource oldSound, AudioSource newSound, float fadeTime)
    {
        // Fade out old sound
        float startVolume = oldSound.volume;

        while (oldSound.volume > 0)
        {
            oldSound.volume -= startVolume * Time.deltaTime / fadeTime;
            yield return null;
        }

        oldSound.Stop();

        //fade in new sound
        newSound.volume = 0;
        newSound.Play();

        while (newSound.volume < 1)
        {
            newSound.volume += Time.deltaTime / fadeTime;
            yield return null;
        }

        newSound.volume = 1;
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

    IEnumerator teenScene2()
    {

        yield return new WaitForSeconds(2f);
        mode = gameMode.dialogue;
        //animator stuff for her
        herAnimator.enabled = false;
        herSpriteRenderer.sprite = herRight;
        //progress bar inactive
        progressBar.SetActive(false);
        //she appears
        teenHerAnim.gameObject.SetActive(true);

        //scene starts================
        //her1 line
        startDialogue(dialogueInfo.HerTeen2Cut1, "Her", dialogueInfo.herSprite, false);
        yield return new WaitUntil(() => dialogueSystem.dialogueFinished);
        //void1 line
        startDialogue(dialogueInfo.VoidTeen2Cut1, "The Void", dialogueInfo.voidSprite, false);
        yield return new WaitUntil(() => dialogueSystem.dialogueFinished);

        //day1========================
        romanticMusic.Play();
        romanticMusic.volume = 0.8f;
        yield return new WaitForSeconds(1f);
        //teenHer0 line
        startDialogue(dialogueInfo.TeenHerTeen2Cut0, "Teen Her", dialogueInfo.teenHerSprite, false);
        yield return new WaitUntil(() => dialogueSystem.dialogueFinished);
        //him0 line
        startDialogue(dialogueInfo.HimTeen2Cut0, "Teen Him", dialogueInfo.himSprite, false);
        yield return new WaitUntil(() => dialogueSystem.dialogueFinished);
        //teenHer1 line
        startDialogue(dialogueInfo.TeenHerTeen2Cut1, "Teen Her", dialogueInfo.teenHerSprite, false);
        yield return new WaitUntil(() => dialogueSystem.dialogueFinished);
        //teenHim1 line
        startDialogue(dialogueInfo.HimTeen2Cut1, "Teen Him", dialogueInfo.himSprite, false);
        yield return new WaitUntil(() => dialogueSystem.dialogueFinished);
        //she moves
        teenHerAnim.SetTrigger("go");
        yield return new WaitForSeconds(7f);
        //teenHer2 line
        startDialogue(dialogueInfo.TeenHerTeen2Cut2, "Teen Her", dialogueInfo.teenHerSprite, false);
        yield return new WaitUntil(() => dialogueSystem.dialogueFinished);
        //teenHim2 line
        startDialogue(dialogueInfo.HimTeen2Cut2, "Teen Him", dialogueInfo.himSprite, false);
        yield return new WaitUntil(() => dialogueSystem.dialogueFinished);
        //teenHer3 line
        startDialogue(dialogueInfo.TeenHerTeen2Cut3, "Teen Her", dialogueInfo.teenHerSprite, false);
        yield return new WaitUntil(() => dialogueSystem.dialogueFinished);
        //teenHim3 line
        startDialogue(dialogueInfo.HimTeen2Cut3, "Teen Him", dialogueInfo.himSprite, false);
        yield return new WaitUntil(() => dialogueSystem.dialogueFinished);
        //teenHer4 line
        startDialogue(dialogueInfo.TeenHerTeen2Cut4, "Teen Her", dialogueInfo.teenHerSprite, false);
        yield return new WaitUntil(() => dialogueSystem.dialogueFinished);
        //teenHim4 line
        startDialogue(dialogueInfo.HimTeen2Cut4, "Teen Him", dialogueInfo.himSprite, false);
        yield return new WaitUntil(() => dialogueSystem.dialogueFinished);
        //teenHer5 line
        startDialogue(dialogueInfo.TeenHerTeen2Cut5, "Teen Her", dialogueInfo.teenHerSprite, false);
        yield return new WaitUntil(() => dialogueSystem.dialogueFinished);
        //teenHim4 line
        startDialogue(dialogueInfo.HimTeen2Cut5, "Teen Him", dialogueInfo.himSprite, false);
        yield return new WaitUntil(() => dialogueSystem.dialogueFinished);
        //stop music
        romanticMusic.Stop();
        bufferSound.Play();
        yield return new WaitForSeconds(1f);
        //her1 line
        startDialogue(dialogueInfo.HerTeen2Cut2, "Her", dialogueInfo.herSprite, false);
        yield return new WaitUntil(() => dialogueSystem.dialogueFinished);
        //void1 line
        startDialogue(dialogueInfo.VoidTeen2Cut2, "The Void", dialogueInfo.voidSprite, false);
        yield return new WaitUntil(() => dialogueSystem.dialogueFinished);

        //day2==================
        //day change
        sunMoonAnim.SetTrigger("change"); //day change
        teenHerAnim.SetTrigger("go"); //she leaves, he changes back to idle via event in her anim
        //music change
        romanticMusic.Play();
        romanticMusic.volume = 0.8f;
        romanticMusic.pitch = 0.7f;
        //Him
        startDialogue(dialogueInfo.HimTeen2Cut5Pt2, "Teen Him", dialogueInfo.himSprite, false);
        yield return new WaitUntil(() => dialogueSystem.dialogueFinished);
        //Teen Her
        startDialogue(dialogueInfo.TeenHerTeen2Cut6, "Teen Her", dialogueInfo.teenHerSprite, false);
        yield return new WaitUntil(() => dialogueSystem.dialogueFinished);
        //she moves
        teenHerAnim.SetTrigger("go");
        yield return new WaitForSeconds(7f);
        //Him
        startDialogue(dialogueInfo.HimTeen2Cut6, "Teen Him", dialogueInfo.himSprite, false);
        yield return new WaitUntil(() => dialogueSystem.dialogueFinished);
        //Teen Her
        startDialogue(dialogueInfo.TeenHerTeen2Cut7, "Teen Her", dialogueInfo.teenHerSprite, false);
        yield return new WaitUntil(() => dialogueSystem.dialogueFinished);
        //Him
        startDialogue(dialogueInfo.HimTeen2Cut7, "Teen Him", dialogueInfo.himSprite, false);
        yield return new WaitUntil(() => dialogueSystem.dialogueFinished);
        //Teen Her
        startDialogue(dialogueInfo.TeenHerTeen2Cut8, "Teen Her", dialogueInfo.teenHerSprite, false);
        yield return new WaitUntil(() => dialogueSystem.dialogueFinished);
        //Him
        startDialogue(dialogueInfo.HimTeen2Cut8, "Teen Him", dialogueInfo.himSprite, false);
        yield return new WaitUntil(() => dialogueSystem.dialogueFinished);
        //Teen Her
        startDialogue(dialogueInfo.TeenHerTeen2Cut9, "Teen Her", dialogueInfo.teenHerSprite, false);
        yield return new WaitUntil(() => dialogueSystem.dialogueFinished);
        //Him
        startDialogue(dialogueInfo.HimTeen2Cut9, "Teen Him", dialogueInfo.himSprite, false);
        yield return new WaitUntil(() => dialogueSystem.dialogueFinished);
        sketchbook.gameObject.SetActive(true);
        yield return new WaitForSeconds(2f);
        sketchbook.gameObject.SetActive(false);
        //Teen Her
        startDialogue(dialogueInfo.TeenHerTeen2Cut10, "Teen Her", dialogueInfo.teenHerSprite, false);
        yield return new WaitUntil(() => dialogueSystem.dialogueFinished);
        //Him
        startDialogue(dialogueInfo.HimTeen2Cut10, "Teen Him", dialogueInfo.himSprite, false);
        yield return new WaitUntil(() => dialogueSystem.dialogueFinished);
        //Teen Her
        startDialogue(dialogueInfo.TeenHerTeen2Cut11, "Teen Her", dialogueInfo.teenHerSprite, false);
        yield return new WaitUntil(() => dialogueSystem.dialogueFinished);
        //Him
        startDialogue(dialogueInfo.HimTeen2Cut11, "Teen Him", dialogueInfo.himSprite, false);
        yield return new WaitUntil(() => dialogueSystem.dialogueFinished);
        //stop music
        romanticMusic.Stop();
        bufferSound.Play();
        yield return new WaitForSeconds(1f);
        //her line
        startDialogue(dialogueInfo.HerTeen2Cut3, "Her", dialogueInfo.herSprite, false);
        yield return new WaitUntil(() => dialogueSystem.dialogueFinished);
        //void line
        startDialogue(dialogueInfo.VoidTeen2Cut3, "The Void", dialogueInfo.voidSprite, false);
        yield return new WaitUntil(() => dialogueSystem.dialogueFinished);
        //her line
        startDialogue(dialogueInfo.HerTeen2Cut4, "Her", dialogueInfo.herSprite, false);
        yield return new WaitUntil(() => dialogueSystem.dialogueFinished);
        yield return new WaitForSeconds(1.5f);
        StartCoroutine(teenScene2Pt2());
    }

    IEnumerator teenScene2Pt2()
    {
         //day3==================
        //day change
        sunMoonAnim.SetTrigger("change"); //day change
        teenHerAnim.SetTrigger("go"); //she leaves, he changes back to idle via event in her anim
        //music change
        romanticMusic.Play();
        romanticMusic.volume = 0.6f;
        romanticMusic.pitch = 0.5f;
        //Teen Her
        startDialogue(dialogueInfo.TeenHerScene3Line1, "Teen Her", dialogueInfo.teenHerSprite, false);
        yield return new WaitUntil(() => dialogueSystem.dialogueFinished);
        //she moves
        teenHerAnim.SetTrigger("go");
        yield return new WaitForSeconds(7f);
        //Him
        startDialogue(dialogueInfo.HimScene3Line1, "Teen Him", dialogueInfo.himSprite, false);
        yield return new WaitUntil(() => dialogueSystem.dialogueFinished);
        //Teen Her
        startDialogue(dialogueInfo.TeenHerScene3Line2, "Teen Her", dialogueInfo.teenHerSprite, false);
        yield return new WaitUntil(() => dialogueSystem.dialogueFinished);
        //Teen Her
        startDialogue(dialogueInfo.TeenHerScene3Line2, "Teen Her", dialogueInfo.teenHerSprite, false);
        yield return new WaitUntil(() => dialogueSystem.dialogueFinished);
        //Him
        startDialogue(dialogueInfo.HimScene3Line3, "Teen Him", dialogueInfo.himSprite, false);
        yield return new WaitUntil(() => dialogueSystem.dialogueFinished);
        //Teen Her
        startDialogue(dialogueInfo.TeenHerScene3Line3, "Teen Her", dialogueInfo.teenHerSprite, false);
        yield return new WaitUntil(() => dialogueSystem.dialogueFinished);
        //Him
        startDialogue(dialogueInfo.HimScene3Line4, "Teen Him", dialogueInfo.himSprite, false);
        yield return new WaitUntil(() => dialogueSystem.dialogueFinished);
        //Teen Her
        startDialogue(dialogueInfo.TeenHerScene3Line4, "Teen Her", dialogueInfo.teenHerSprite, false);
        yield return new WaitUntil(() => dialogueSystem.dialogueFinished);
        //Him
        startDialogue(dialogueInfo.HimScene3Line5, "Teen Him", dialogueInfo.himSprite, false);
        yield return new WaitUntil(() => dialogueSystem.dialogueFinished);
        //Teen Her
        startDialogue(dialogueInfo.TeenHerScene3Line5, "Teen Her", dialogueInfo.teenHerSprite, false);
        yield return new WaitUntil(() => dialogueSystem.dialogueFinished);
        //Him
        startDialogue(dialogueInfo.HimScene3Line6, "Teen Him", dialogueInfo.himSprite, false);
        yield return new WaitUntil(() => dialogueSystem.dialogueFinished);
        //Teen Her
        startDialogue(dialogueInfo.TeenHerScene3Line6, "Teen Her", dialogueInfo.teenHerSprite, false);
        yield return new WaitUntil(() => dialogueSystem.dialogueFinished);
        //stop music
        romanticMusic.Stop();
        bufferSound.Play();
        yield return new WaitForSeconds(1f);
        //her line
        startDialogue(dialogueInfo.HerTeen2Cut5, "Her", dialogueInfo.herSprite, false);
        yield return new WaitUntil(() => dialogueSystem.dialogueFinished);
        //void line
        startDialogue(dialogueInfo.VoidTeen2Cut4, "The Void", dialogueInfo.voidSprite, false);
        yield return new WaitUntil(() => dialogueSystem.dialogueFinished);
        //her line
        startDialogue(dialogueInfo.HerTeen2Cut6, "Her", dialogueInfo.herSprite, false);
        yield return new WaitUntil(() => dialogueSystem.dialogueFinished);

        //day4==================
        //day change
        sunMoonAnim.SetTrigger("change"); //day change
        teenHerAnim.SetTrigger("go"); //she leaves, he changes back to idle via event in her anim
        //her line
        startDialogue(dialogueInfo.VoidTeen2Cut5, "The Void", dialogueInfo.voidSprite, false);
        yield return new WaitUntil(() => dialogueSystem.dialogueFinished);
        //music change
        romanticMusic.Play();
        romanticMusic.volume = 0.6f;
        romanticMusic.pitch = 0.3f;
        //she moves
        //teenHerAnim.SetTrigger("go");
        //yield return new WaitForSeconds(7f);
        print("STARTING LAST ONE");
    }

    IEnumerator teenScene1()
    {
        //sets vignette inactive
        vignetteMain.SetActive(false);
        yield return new WaitForSeconds(2f);
        schoolBell.Play();
        mode = gameMode.dialogue;
        //animator stuff for her
        herAnimator.enabled = false;
        herSpriteRenderer.sprite = herRight;
        //progress bar inactive
        progressBar.SetActive(false);

        //her1 line
        startDialogue(dialogueInfo.HerTeenCut1, "Her", dialogueInfo.herSprite, false);
        yield return new WaitUntil(() => dialogueSystem.dialogueFinished);
        //SHE APPEARS
        followHer.SetActive(true);
        firstDoorAnim.SetTrigger("openClassDoor");
        //void1 line
        startDialogue(dialogueInfo.VoidTeenCut1,"The Void",dialogueInfo.voidSprite, false);
        yield return new WaitUntil(() => dialogueSystem.dialogueFinished);
        //her2 line
        startDialogue(dialogueInfo.HerTeenCut2, "Her", dialogueInfo.herSprite, false);
        yield return new WaitUntil(() => dialogueSystem.dialogueFinished);
        //void2 line
        startDialogue(dialogueInfo.VoidTeenCut2, "The Void", dialogueInfo.voidSprite, false);
        yield return new WaitUntil(() => dialogueSystem.dialogueFinished);
        //move her
        Animator followHerAnim = followHer.GetComponent<Animator>();
        followHerAnim.SetTrigger("go");
        yield return new WaitForSeconds(14f);
        //void3 line
        startDialogue(dialogueInfo.VoidTeenCut3, "The Void", dialogueInfo.voidSprite, true);
        yield return new WaitUntil(() => dialogueSystem.dialogueFinished);
        //progress bar re-activate
        progressBar.SetActive(true);
        //re-enable her animator
        herAnimator.enabled = true;

    }

    IEnumerator teenMaze()
    {
        yield return new WaitForSeconds(2f);
        mode = gameMode.dialogue;
        //her1 line
        startDialogue(dialogueInfo.HerTeenMaze1, "Her", dialogueInfo.herSprite, false);
        yield return new WaitUntil(() => dialogueSystem.dialogueFinished);
        //void1 line
        startDialogue(dialogueInfo.VoidTeenMaze1, "The Void", dialogueInfo.voidSprite, false);
        yield return new WaitUntil(() => dialogueSystem.dialogueFinished);
        //her2 line
        startDialogue(dialogueInfo.HerTeenMaze2, "Her", dialogueInfo.herSprite, true);
        yield return new WaitUntil(() => dialogueSystem.dialogueFinished);

    }
    public IEnumerator endAdulthood()
    {
        mode = gameMode.dialogue;
        //close adulthood door
        adulthoodDoorAnim.SetTrigger("close");
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
        mode = gameMode.dialogue;
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
