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
    public List<string> HerOpening1;
    [TextArea(3, 3)]
    public List<string> VoidOpening1;
    [TextArea(3, 3)]
    public List<string> HerOpening2;
    [TextArea(3, 3)]
    public List<string> VoidOpening2;
    [TextArea(3, 3)]
    public List<string> HerOpening3;
    [TextArea(3, 3)]
    public List<string> VoidOpening3;
    [TextArea(3, 3)]
    public List<string> HerOpening4;
    [TextArea(3, 3)]
    public List<string> VoidOpening4;

    [Header("Adulthood Lines")]
    [TextArea(3, 3)]
    public List<string> introAdulthood;
    [TextArea(3, 3)]
    public List<string> adulthoodEnd;


}
