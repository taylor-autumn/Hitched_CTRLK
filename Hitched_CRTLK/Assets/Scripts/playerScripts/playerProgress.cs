using UnityEngine;

public class playerProgress : MonoBehaviour
{
    public float levelsCompleted=0;
    //this will be a tracker of what level we on (adulthood, childhood, or teenhood). 
    //if it is 1, it's adulthood, if it is 2, it is teenhood, and if it is 3 it is childhood).



    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            print("passed level 1?" + passedLevel1());

            print("passed level 2?" + passedLevel2());

            print("passed level 3?" + passedLevel3());
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


}
