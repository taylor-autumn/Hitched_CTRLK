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
    [Header("Narrate")]
    //day1
    [TextArea(3, 3)]
    public List<string> HerTeen2Cut1;
    [TextArea(3, 3)]
    public List<string> VoidTeen2Cut1;
    [Header("Confession")]
    [TextArea(3, 3)]
    public List<string> TeenHerTeen2Cut0;
    [TextArea(3, 3)]
    public List<string> HimTeen2Cut0;
    [TextArea(3, 3)]
    public List<string> TeenHerTeen2Cut1;
    [TextArea(3, 3)]
    public List<string> HimTeen2Cut1;
    [TextArea(3, 3)]
    public List<string> TeenHerTeen2Cut2;
    [TextArea(3, 3)]
    public List<string> HimTeen2Cut2;
    [TextArea(3, 3)]
    public List<string> TeenHerTeen2Cut3;
    [TextArea(3, 3)]
    public List<string> HimTeen2Cut3;
    [TextArea(3, 3)]
    public List<string> TeenHerTeen2Cut4;
    [TextArea(3, 3)]
    public List<string> HimTeen2Cut4;
    [TextArea(3, 3)]
    public List<string> TeenHerTeen2Cut5;
    [TextArea(3, 3)]
    public List<string> HimTeen2Cut5;
    [Header("Back to Narrate")]
    [TextArea(3, 3)]
    public List<string> HerTeen2Cut2;
    [TextArea(3, 3)]
    public List<string> VoidTeen2Cut2;

    [Header("Scene2")]
    [TextArea(3, 3)]
    public List<string> HimTeen2Cut5Pt2;
    [TextArea(3, 3)]
    public List<string> TeenHerTeen2Cut6;
    [TextArea(3, 3)]
    public List<string> HimTeen2Cut6;
    [TextArea(3, 3)]
    public List<string> TeenHerTeen2Cut7;
    [TextArea(3, 3)]
    public List<string> HimTeen2Cut7;
    [TextArea(3, 3)]
    public List<string> TeenHerTeen2Cut8;
    [TextArea(3, 3)]
    public List<string> HimTeen2Cut8;
    [TextArea(3, 3)]
    public List<string> TeenHerTeen2Cut9;
    [TextArea(3, 3)]
    public List<string> HimTeen2Cut9;
    [TextArea(3, 3)]
    public List<string> TeenHerTeen2Cut10;
    [TextArea(3, 3)]
    public List<string> HimTeen2Cut10;
    [TextArea(3, 3)]
    public List<string> TeenHerTeen2Cut11;
    [TextArea(3, 3)]
    public List<string> HimTeen2Cut11;
    [Header("Narrators")]
    [TextArea(3, 3)]
    public List<string> HerTeen2Cut3;
    [TextArea(3, 3)]
    public List<string> VoidTeen2Cut3;
    [TextArea(3, 3)]
    public List<string> HerTeen2Cut4;
    [TextArea(3, 3)]
    public List<string> VoidTeen2Cut3Pt2;

    [Header("Scene 3")]
    [TextArea(3, 3)]
    public List<string> TeenHerScene3Line1;
    [TextArea(3, 3)]
    public List<string> HimScene3Line1;
    [TextArea(3, 3)]
    public List<string> TeenHerScene3Line2;
    [TextArea(3, 3)]
    public List<string> HimScene3Line2;
    [TextArea(3, 3)]
    public List<string> TeenHerScene3Line3;
    [TextArea(3, 3)]
    public List<string> HimScene3Line3;
    [TextArea(3, 3)]
    public List<string> TeenHerScene3Line4;
    [TextArea(3, 3)]
    public List<string> HimScene3Line4;
    [TextArea(3, 3)]
    public List<string> TeenHerScene3Line5;
    [TextArea(3, 3)]
    public List<string> HimScene3Line5;
    [TextArea(3, 3)]
    public List<string> TeenHerScene3Line6;
    [TextArea(3, 3)]
    public List<string> HimScene3Line6;
    [Header("Narrators")]
    [TextArea(3, 3)]
    public List<string> HerTeen2Cut5;
    [TextArea(3, 3)]
    public List<string> VoidTeen2Cut4;
    [TextArea(3, 3)]
    public List<string> HerTeen2Cut6;

    [Header("Scene 4")]
    [TextArea(3, 3)]
    public List<string> VoidTeen2Cut5;
    [TextArea(3, 3)]
    public List<string> TeenHerScene4Line1;
    [TextArea(3, 3)]
    public List<string> HimScene4Line1;
    [TextArea(3, 3)]
    public List<string> TeenHerScene4Line2;
    [TextArea(3, 3)]
    public List<string> HimScene4Line2;
    [TextArea(3, 3)]
    public List<string> TeenHerScene4Line3;
    [TextArea(3, 3)]
    public List<string> HimScene4Line03;
    [TextArea(3, 3)]
    public List<string> HimScene4Line3;
    [TextArea(3, 3)]
    public List<string> TeenHerScene4Line4;
    [TextArea(3, 3)]
    public List<string> HimScene4Line4;
    [TextArea(3, 3)]
    public List<string> TeenHerScene4Line5;
    [TextArea(3, 3)]
    public List<string> HimScene4Line5;
    [TextArea(3, 3)]
    public List<string> TeenHerScene4Line6;
    [TextArea(3, 3)]
    public List<string> HimScene4Line6;
    [Header("Narrators")]
    [TextArea(3, 3)]
    public List<string> HerTeen2Cut7;
    [TextArea(3, 3)]
    public List<string> VoidTeen2Cut6;
    [TextArea(3, 3)]
    public List<string> HerTeen2Cut8;
    [TextArea(3, 3)]
    public List<string> VoidTeen2Cut7;

    [Header("End of Teenhood")]
    [TextArea(3, 3)]
    public List<string> EndTeenVoid1;
    [TextArea(3, 3)]
    public List<string> EndTeenHer1;
    [TextArea(3, 3)]
    public List<string> EndTeenVoid2;

    [Header("End of Demo")]
    [TextArea(3, 3)]
    public List<string> demoVoidLine;

}
