using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine.UI;

public class Dial : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public TextMeshProUGUI nameplate;
    public Image CharacterDisplay;
    public List<Animator> TheAnim;
    public Animator End;
    public List<Sprite> characterSprites;
    public string[] lines;
    public string[] names;
    public float textSpeed;
    private int index;
    public string nextScenename;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        textComponent.text = string.Empty;
        StartDialougue();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
    }
    void StartDialougue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }
    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            nameplate.text = names[index];
            foreach (Animator anim in TheAnim)
            {
                anim.SetInteger("int", index);
            }
            CharacterDisplay.sprite = characterSprites[index];
            Debug.Log("Changing to sprite: " + characterSprites[index].name);
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            End.SetBool("finish", true);
            Invoke("END", 2f);
        }
    }

    void END()
    {
            SceneManager.LoadScene(nextScenename);
    }
}