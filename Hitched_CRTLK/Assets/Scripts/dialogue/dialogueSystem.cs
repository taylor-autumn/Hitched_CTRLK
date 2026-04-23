using TMPro;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;

public class dialogueSystem : MonoBehaviour
{
    [Header("Dialogue UI Objects")]
    public GameObject dialogueBox;
    public TMP_Text dialogueText;
    public TMP_Text nameText;
    public Image spriteImage;

    [Header("List Shit")]
    public List<string> listOfChoice;
    public int listIndex = 0;
    public float textSpeed = 0.05f;
    bool isTyping = false;
    public bool inDialogue = false;

    //reference
    storyProgression storyProgression;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        storyProgression=GameObject.Find("gameManager").GetComponent<storyProgression>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!enabled || listOfChoice == null || storyProgression.mode != storyProgression.gameMode.dialogue)
        {
            print("SOMETHING IS WRONG RETURNING NOW");
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (isTyping)
            {
                StopAllCoroutines();
                dialogueText.text = listOfChoice[listIndex];
                isTyping = false;
            }
            else
            {
                nextLine();
            }

        }

    }

    public void startDialogue(List<string> lines, string charName, Sprite charSprite)
    {
        //just a precaution so no glitches, also emptying the shit just in case
        StopAllCoroutines();
        dialogueText.text=string.Empty;

        //setting this bool just in case
        inDialogue = true;

        //turn on dialogue stuff
        dialogueBox.SetActive(true);
        nameText.text = charName;
        spriteImage.sprite = charSprite;

        //setting the stuff I provide to its corresponding shit
        listOfChoice= lines;
        listIndex = 0;

        //precuation if the list is null or empty
        if (listOfChoice==null || listOfChoice.Count == 0)
        {
            Debug.LogError("THE LIST DIALOGUE IS EMPTY OR NULL");
            return;
        }

        StartCoroutine(typeLine());


    }

    IEnumerator typeLine()
    {
        isTyping = true;
        yield return null;

        foreach (char c in listOfChoice[listIndex].ToCharArray())
        {
            dialogueText.text += c;
            yield return new WaitForSeconds(textSpeed);
        }

        isTyping = false;

    }

    void nextLine()
    {
        if (listIndex<listOfChoice.Count - 1)
        {
            listIndex++;
            dialogueText.text = string.Empty;
            StartCoroutine(typeLine());
        }
        else
        {
            print("dialogue finished");
            endDialogue();
        }
    }

    public void endDialogue()
    {
        storyProgression.mode = storyProgression.gameMode.normal;
        //resets all the shit
        StopAllCoroutines();
        listOfChoice = null;
        listIndex = 0;
        spriteImage.sprite = null;
        dialogueText.text = string.Empty;
        nameText.text = string.Empty;
        inDialogue = false;
        dialogueBox.SetActive(false);
        enabled = false;
    }
}
