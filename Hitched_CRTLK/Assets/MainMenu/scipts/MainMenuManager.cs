using UnityEngine;
using UnityEngine.SceneManagement; 

public class MainMenuManager : MonoBehaviour
{
    [Header("팝업창 UI 연결")]
    public GameObject creditPopup;
    public GameObject settingPopup;

    // 1. Start 
    public void StartGame()
    {
        // "MainScene" 
        SceneManager.LoadScene("03_mindscape"); 
    }

    // 2. Credit
    public void OpenCreditPopup()
    {
        creditPopup.SetActive(true);
    }
    public void CloseCreditPopup()
    {
        creditPopup.SetActive(false);
    }

    // 3. Setting
    public void OpenSettingPopup()
    {
        settingPopup.SetActive(true);
    }
    public void CloseSettingPopup()
    {
        settingPopup.SetActive(false);
    }
}