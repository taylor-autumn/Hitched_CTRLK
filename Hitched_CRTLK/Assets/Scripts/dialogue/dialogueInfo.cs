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

    [Header("Mindscape Lines")]
    [TextArea(3, 3)]
    public List<string> startingMindscape;
    [TextArea(3, 3)]
    public List<string> adulthoodDoor;

    [Header("Adulthood Lines")]
    [TextArea(3, 3)]
    public List<string> introAdulthood;
    [TextArea(3, 3)]
    public List<string> adulthoodEnd;


}
