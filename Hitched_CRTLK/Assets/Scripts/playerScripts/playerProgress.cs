using UnityEngine;
using UnityEngine.UI;

public class playerProgress : MonoBehaviour
{
    public float levelsCompleted=0;
    //this will be a tracker of what level we on (adulthood, childhood, or teenhood). 
    //if it is 1, it's adulthood, if it is 2, it is teenhood, and if it is 3 it is childhood).
    public bool wonInsight = false;
    public bool wonAwareness = false;
    public bool wonPassion = false;

    [Header("UI Stuff")]
    public Image insightObj;
    public Image awarenessObj;
    public Image passionObj;
    public Image scissors;
    public Image boltCutters;
    public Image paintbrush;
    //bars
    public Image bars;
    public Sprite emptyBars;
    public Sprite oneBar;
    public Sprite twoBars;
    public Sprite fullBars;

    private void Start()
    {
        //this is just to make sure that the player progress is reset when we start the game, so if we test it multiple times it will be accurate
        //levels completed at 0
        levelsCompleted = 0;

        //abilities at 0
        wonInsight = false;
        wonAwareness = false;
        wonPassion = false;

        //ui stuff
        bars.sprite = emptyBars;
        insightObj.color = Color.black;
        awarenessObj.color = Color.black;
        passionObj.color = Color.black;
    }

    private void Update()
    {
        //commented out, but if u want to cheat to see what the status is of level uncomment this
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    print("passed level 1?" + passedLevel1());

        //    print("passed level 2?" + passedLevel2());

        //    print("passed level 3?" + passedLevel3());
        //}

        //this on space thing is a placeholder, normally it would be if like you just got an abilitiy or something, then call it, so it is not ALWAYS running
        if (Input.GetKeyDown(KeyCode.P))
        {
            monitorUI();
        }

    }
    public bool passedLevel1()
    {
        return levelsCompleted == 1;
    }

    public bool passedLevel2()
    {
        return levelsCompleted == 2;
    }

    public bool passedLevel3()
    {
        return levelsCompleted == 3;
    }

    public bool hasInsight()
    {
        return wonInsight;
    }

    public bool hasAwareness()
    {
        return wonAwareness;
    }

    public bool hasPassion()
    {
        return wonPassion;
    }

    public void monitorUI()
    {
        if (hasInsight())
        {
            insightObj.color = Color.white;
            scissors.gameObject.SetActive(true);
            bars.sprite = oneBar;
        }
        if (hasInsight() && hasAwareness())
        {
            awarenessObj.color = Color.white;
            boltCutters.gameObject.SetActive(true);
            bars.sprite = twoBars;
        }
        if (hasInsight() && hasAwareness() && hasPassion())
        {
            passionObj.color = Color.white;
            paintbrush.gameObject.SetActive(true);
            bars.sprite = fullBars;
        }
    }
}
