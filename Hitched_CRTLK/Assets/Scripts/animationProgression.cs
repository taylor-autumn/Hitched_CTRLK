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

    //teenhood stuff
    Animator toHimDoor;
    Animator himAnim;
    public Animator teenDoorOutAnim;
    GameObject boltCutters;

    //story progression stuff
    storyProgression storyProgression;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        storyProgression = GameObject.Find("gameManager").GetComponent<storyProgression>();

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

        toHimDoor = mapsParent.transform.Find("teenhoodMaps/teenhood1/toHimDoor").GetComponent<Animator>();
        himAnim = mapsParent.transform.Find("teenhoodMaps/teenhood2/cutSceneStuff/Him").GetComponent<Animator>();
        teenDoorOutAnim = GameObject.Find("teenDoorOut").GetComponent<Animator>();

        boltCutters = mapsParent.transform.Find("teenhoodMaps/teenhood2/cutSceneStuff/boltCutters").gameObject;
        boltCutters.SetActive(false);
    }

    private void Update()
    {
        if (boltCutters == null)
        {
            print("THEY NULL");
        }
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

    public void spawnBoltCutters()
    {
        boltCutters.SetActive(true);
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

    public void openTeenDoor()
    {
        toHimDoor.SetTrigger("open");

    }

    public void HimTurnToHer()
    {
        himAnim.SetTrigger("toHer");
    }

    public void HimBackIdle()
    {
        himAnim.SetTrigger("idle");
    }

    public void activateTeenDoorOut()
    {
        teenDoorOutAnim.SetTrigger("in");
    }

    public void openTeenDoorOut()
    {
        teenDoorOutAnim.SetTrigger("open");
    }
}
