using UnityEngine;
using UnityEngine.SceneManagement;
public class mainMenuButtons : MonoBehaviour
{
    //public GameObject debugBlink;
    public GameObject modesHere;
    void Start()
    {
        //debugBlink.SetActive(false);
    }
    public void LoadScenes()
    {
        modesHere.GetComponent<storyProgression>().mode = storyProgression.gameMode.normal;
        SceneManager.LoadScene("01_menu");
    }
}
