using UnityEngine;

public class teleport : MonoBehaviour
{
    //teleports the player
    playerProgress playerProgress;
    public Vector2 targetCharPosition;

    //teleports the camera
    public Vector3 targetCamPosition;
    Camera mainCam;
    Camera mazeCam;

    [Header("CUSTOMIZE")]
    public int progressRequiredToStart;
    public string transition;

    //effect?

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mainCam = Camera.main;

        //THIS IS THE MAZE CAM. we should have it so when we enter the maze main cam
        //turns off and this one turns on, then we need to turn it back off once the
        //transition into the scene is over,and then turn on the main cam again.
        //also, this is parented under the child so it moves with the character.
        //mazeCam = GameObject.Find("mazeCam").GetComponent<Camera>();

        playerProgress = FindAnyObjectByType<playerProgress>();
    }

    // Update is called once per frame
    void Update()
    {
        //developer cheat reset player and cam
        if (Input.GetKey(KeyCode.P) && Input.GetKey(KeyCode.LeftShift))
        {
            GameObject player = GameObject.Find("HER");
            player.transform.position = new Vector2(0, 0);
            mainCam.transform.position = new Vector3(0, 1, -9);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //right now it is happening if you are in the area, this needs to be adjusted
        //so it only happens like on space and if in range

        if (collision.gameObject.CompareTag("Player"))
        {

            if (progressRequiredToStart == 0)
            {
                //this means that this teleporter does not require a level to move on,
                //therefore it is a free teleport. this will be used like between flashback scenes

                GameObject player = collision.gameObject;
                print("moving player");

                //moves the player
                player.transform.position = targetCharPosition;

                //moves the cam
                mainCam.transform.position = targetCamPosition;

                //choose if they want a transition or not
                chooseAnimation(transition);
                return;
            }
            else if (levelOpen())
            {
                print("level is open, moving player");
                GameObject player = collision.gameObject;
                player.transform.position = targetCharPosition;

                mainCam.transform.position = targetCamPosition;

                chooseAnimation(transition);
            }
            else
            {
                print("Sorry, LEVEL NOT OPEN");
            }


        }
    }

    public bool levelOpen()
    {
        if (progressRequiredToStart == 1)
        {
            //if this door requires level 1 to be complete,
            //this checks that level 1 has been passed, if so,
            //it returns true.
            return playerProgress.passedLevel1();
        }
        else if (progressRequiredToStart == 2)
        {
            //if this door requires level 2 to be complete,
            //this checks that level 2 has been passed, if so,
            //it returns true.
            return playerProgress.passedLevel2();
        }
        else if (progressRequiredToStart == 3)
        {
            //if this door requires level 3 to be complete,
            //this checks that level 3 has been passed, if so,
            //it returns true.
            return playerProgress.passedLevel3();
        }
        return false;
        //this runs if none of those levels have been completed

    }

    public void chooseAnimation(string choice)
    {
        if (choice == "no") return; //this means there should be no transition
        if (choice == "fade")
        {
            print("playing fade");
            //reference scene transition script here 

            //reference scene transition function to call on like
            //ex: sceneTransitions.playFadeTransition();
        }
        if (choice == "dream")
        {
            //this is just a placeholder for whatever other transition you want to do
            print("playing dream");
            //reference scene transition script here 

            //reference scene transition function to call on like
            //ex: sceneTransitions.play____Transition();
        }
        //and so on for however many transitions we have
    }

}
