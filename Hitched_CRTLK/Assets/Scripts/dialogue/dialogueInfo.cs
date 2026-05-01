using System.Collections.Generic;
using UnityEngine;

public class dialogueInfo : MonoBehaviour
{
    [Header("Sprites")]
    public Sprite herSprite;
    public Sprite himSprite;
    public Sprite teacherSprite;
    public Sprite npcSprite;
    public Sprite voidSprite;

    [Header("Intro Lines")]
    [TextArea(3, 3)]
    public List<string> startingHerDialogue;
    [TextArea(3, 3)]
    public List<string> voidFirstLines;
    [TextArea(3, 3)]
    public List<string> HerResponse;
    [TextArea(3, 3)]
    public List<string> voidSecondLines;
    [TextArea(3, 3)]
    public List<string> HerSecondResponse;
    [TextArea(3, 3)]
    public List<string> voidThirdLines;

    [Header("Adulthood Lines")]
    [TextArea(3, 3)]
    public List<string> introAdulthood;
    [TextArea(3, 3)]
    public List<string> adulthoodEnd;


}
