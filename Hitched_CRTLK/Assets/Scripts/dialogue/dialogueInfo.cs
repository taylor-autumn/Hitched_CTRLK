using System.Collections.Generic;
using UnityEngine;

public class dialogueInfo : MonoBehaviour
{
    [Header("Sprites")]
    public Sprite herSprite;
    public Sprite youngHerSprite;
    public Sprite himSprite;
    public Sprite teacherSprite;
    public Sprite teenHerSprite;
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

    [Header("Maze Lines")]
    [TextArea(3, 3)]
    public List<string> HerMazeIntro1;
    [TextArea(3, 3)]
    public List<string> VoidMazeIntro1;
    [TextArea(3, 3)]
    public List<string> HerMazeIntro2;
    [TextArea(3, 3)]
    public List<string> VoidMazeIntro2;
    [TextArea(3, 3)]
    public List<string> HerMazeIntro3;
    [TextArea(3, 3)]
    public List<string> VoidMazeIntro3;
    [TextArea(3, 3)]
    public List<string> HerMazeIntro4;
    [TextArea(3, 3)]
    public List<string> VoidMazeIntro4;

    [Header("Adulthood Cutscene Lines")]
    [TextArea(3, 3)]
    public List<string> HerAdulthood1;
    [TextArea(3, 3)]
    public List<string> VoidAdulthood1;
    [TextArea(3, 3)]
    public List<string> HerAdulthood2;
    [TextArea(3, 3)]
    public List<string> VoidAdulthood2;
    [TextArea(3, 3)]
    public List<string> HerAdulthood3;
    [TextArea(3, 3)]
    public List<string> VoidAdulthood3;
    [TextArea(3, 3)]
    public List<string> HerAdulthood4;
    [TextArea(3, 3)]
    public List<string> VoidAdulthood4;
    [TextArea(3, 3)]
    public List<string> HerAdulthood5;
    [TextArea(3, 3)]
    public List<string> VoidAdulthood5;
    [TextArea(3, 3)]
    public List<string> HerAdulthood6;
    [TextArea(3, 3)]
    public List<string> VoidAdulthood6;
    [TextArea(3, 3)]
    public List<string> HerAdulthood7;
    [TextArea(3, 3)]
    public List<string> VoidAdulthood7;
    [TextArea(3, 3)]
    public List<string> VoidAdulthood7Pt2;
    [TextArea(3, 3)]
    public List<string> HerAdulthood8;
    [TextArea(3, 3)]
    public List<string> VoidAdulthood8;
    [TextArea(3, 3)]
    public List<string> HerAdulthood9;
    [TextArea(3, 3)]
    public List<string> VoidAdulthood9;
    [TextArea(3, 3)]
    public List<string> HimAdulthood1;
    [TextArea(3, 3)]
    public List<string> VoidAdulthood10;

    [Header("End Adulthood Lines")]
    [TextArea(3, 3)]
    public List<string> VoidEndAdulthood1;
    [TextArea(3, 3)]
    public List<string> HerEndAdulthood1;
    [TextArea(3, 3)]
    public List<string> VoidEndAdulthood2;
    [TextArea(3, 3)]
    public List<string> HerEndAdulthood2;
    [TextArea(3, 3)]
    public List<string> VoidEndAdulthood3;

    [Header("Teen Maze Lines")]
    [TextArea(3, 3)]
    public List<string> HerTeenMaze1;
    [TextArea(3, 3)]
    public List<string> VoidTeenMaze1;
    [TextArea(3, 3)]
    public List<string> HerTeenMaze2;

    [Header("Teen Cutscene1 Lines")]
    [TextArea(3, 3)]
    public List<string> HerTeenCut1;
    [TextArea(3, 3)]
    public List<string> VoidTeenCut1;
    [TextArea(3, 3)]
    public List<string> HerTeenCut2;
    [TextArea(3, 3)]
    public List<string> VoidTeenCut2;
    [TextArea(3, 3)]
    public List<string> VoidTeenCut3;

    [Header("Teen Cutscene2 Lines")]
    [TextArea(3, 3)]
    public List<string> HerTeen2Cut1;
    [TextArea(3, 3)]
    public List<string> VoidTeen2Cut1;
    [TextArea(3, 3)]
    public List<string> TeenHerTeen2Cut2;
    [TextArea(3, 3)]
    public List<string> HimTeen2Cut2;
    [TextArea(3, 3)]
    public List<string> TeenHerTeen2Cut3;

}
