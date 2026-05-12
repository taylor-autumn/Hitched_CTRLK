using UnityEngine;

public class choiceCode : MonoBehaviour
{
    public GameObject ending;
    public Animator panelFade;
    public GameObject oldcanvas;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {  
            other.gameObject.GetComponent<threeDmovement>().enabled = false;
            Invoke("changeed", 3f);
            panelFade.SetBool("finish", true);
        }
    }
    void changeed()
    {
        ending.gameObject.SetActive(true);
        oldcanvas.SetActive(false);
    }
}
