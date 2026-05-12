using UnityEngine;

public class choiceCode : MonoBehaviour
{
    public bool leaveHim;
    public GameObject ending;
    public Animator panelFade;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {  
            ending.gameObject.SetActive(true);
        }
    }
}
