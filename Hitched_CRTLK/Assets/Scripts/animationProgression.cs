using UnityEngine;

public class animationProgression : MonoBehaviour
{
    //rose stuff
    Animator wiltedRoseAnim;
    Animator fullRoseAnim;

    //mural stuff
    Animator muralAnim;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        wiltedRoseAnim = GameObject.Find("wiltedRose").GetComponent<Animator>();
        fullRoseAnim = GameObject.Find("fullRose").GetComponent<Animator>();
        muralAnim = GameObject.Find("mural").GetComponent<Animator>();
        
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

    public void muralChange()
    {
        muralAnim.SetTrigger("paint");
        print("painting mural");
    }

    void triggerFullRose()
    {
        fullRoseAnim.SetTrigger("bloom");
    }

}
