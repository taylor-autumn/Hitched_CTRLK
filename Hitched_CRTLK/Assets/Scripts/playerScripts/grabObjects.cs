using UnityEngine;

public class grabObjects : MonoBehaviour
{
    playerProgress playerProgress;
    storyProgression storyProgression;
    uiSprites uiSprites;

    public AudioSource victorySource;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerProgress=gameObject.GetComponent<playerProgress>();
        storyProgression = GameObject.Find("gameManager").GetComponent<storyProgression>();
        uiSprites = GameObject.Find("gameManager").GetComponent<uiSprites>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "scissors")
        {
            //victory sound
            victorySound();
            //kills the scissors
            collision.gameObject.SetActive(false);
            //this is the reward
            playerProgress.wonInsight = true;
            playerProgress.monitorUI();
            playerProgress.levelsCompleted = 1;
            gameObject.GetComponent<SwimMovement>().speed = 3f;
            //changes UI
            uiSprites.uiType("teenhood");

            //start the dialogue
            storyProgression.StartCoroutine(storyProgression.endAdulthood());

        }
    }

    public void victorySound()
    {
        victorySource.Play();
    }

}
