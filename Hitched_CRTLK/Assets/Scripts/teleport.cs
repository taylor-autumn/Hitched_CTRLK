using UnityEngine;
using System.Collections;

public class teleport : MonoBehaviour
{
    //teleports the player
    public Vector2 targetCharPosition;
    //teleports the camera
    public Vector3 targetCamPosition;
    
    [SerializeField] private GameObject mainCam;
    [SerializeField] private GameObject mazeCam;
    public bool toMaze;
    public bool currentlyTping = false;

    [Header("CUSTOMIZE")]
    public int progressRequiredToStart;
    public string transition;

    storyProgression storyProgression;

    public float delayTime;

    //effect?

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentlyTping = false;
        storyProgression = GameObject.Find("gameManager").GetComponent<storyProgression>();
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
            
            float levelsCompleted = collision.gameObject.GetComponent<playerProgress>().levelsCompleted;
            if (progressRequiredToStart == levelsCompleted)
            {
                storyProgression.fadeScreen();
                //only if the level is unlocked go through
                StartCoroutine(EnableBoolRoutine());//coroutine for stopping tp glitch

                //transition

                //choose if they want a transition or not
                //chooseAnimation(transition);
                Invoke("movePlayerAndCam", delayTime);   //delay for transition, also tp debug
                //GameObject player = collision.gameObject;
                //player.transform.position = targetCharPosition; //tps the player
                //mainCam.transform.position = targetCamPosition; //tps the cam
                GetComponent<BoxCollider2D>().enabled = false; ;//closes door after entering

                return;
            }
            else
            {
                print("Sorry, LEVEL NOT OPEN");
            }


        }
    }


    public void chooseAnimation(string choice)
    {
        if (choice == "no") return; //this means there should be no transition
        if (choice == "fade")
        {
            print("playing fade");
            storyProgression.fadeScreen();
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

    void movePlayerAndCam()
    {
        currentlyTping = true;
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.transform.position = targetCharPosition; //tps the player
        mainCam.transform.position = targetCamPosition; //tps the cam

        if (toMaze == true)
        {
            mainCam.SetActive(false);
            mazeCam.SetActive(true);
        }
        else
        {
            mainCam.SetActive(true);
            mazeCam.SetActive(false);
        }
    }

    IEnumerator EnableBoolRoutine() 
    {
        currentlyTping = true;
        yield return new WaitForSeconds(1f); //pause, tp debug
        currentlyTping = false;
    }

}
