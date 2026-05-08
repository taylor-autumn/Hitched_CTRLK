using UnityEngine;

public class animationProgression : MonoBehaviour
{
    //rose stuff
    Animator wiltedRoseAnim;
    Animator fullRoseAnim;

    //mural stuff
    Animator muralAnim;

    //adulthood stuff
    GameObject soundsParent;
    Animator scissorAnim;
    AudioSource doorSource;
    Animator adulthoodDoorAnim;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        wiltedRoseAnim = GameObject.Find("wiltedRose").GetComponent<Animator>();
        fullRoseAnim = GameObject.Find("fullRose").GetComponent<Animator>();
        muralAnim = GameObject.Find("mural").GetComponent<Animator>();

        GameObject mapsParent = GameObject.Find("maps");

        GameObject scissors = mapsParent.transform.Find("adulthoodMap/scissors").gameObject;
        scissorAnim = scissors.GetComponent<Animator>();
        scissors.SetActive(false);
        adulthoodDoorAnim = mapsParent.transform.Find("adulthoodMap/doorOut").GetComponent<Animator>();
        adulthoodDoorAnim.gameObject.SetActive(false);

        soundsParent = GameObject.Find("sounds");
        doorSource = soundsParent.transform.Find("adulthood/doorSound").GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void roseChange()
    {
        wiltedRoseAnim.SetTrigger("bloom");
        print("changing rose");
    }

    public void bloom()
    {
        fullRoseAnim.SetTrigger("bloom");
    }

    public void muralChange()
    {
        muralAnim.SetTrigger("paint");
        print("painting mural");
    }

    public void spawnScissors()
    {
        scissorAnim.gameObject.SetActive(true);
    }

    public void doorSound()
    {
        doorSource.Play();
    }

    public void spawnAdulthoodDoor()
    {
        adulthoodDoorAnim.gameObject.SetActive(true);
    }

    public void useAdulthoodDoor()
    {
        adulthoodDoorAnim.SetTrigger("use");
    }
}
