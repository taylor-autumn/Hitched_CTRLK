using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class uiSprites : MonoBehaviour
{

    public List<Image> uiImages;
    playerProgress playerProgress;

    private void OnEnable()
    {
        uiType("adulthood");
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerProgress = Object.FindAnyObjectByType<playerProgress>();
    }

    // Update is called once per frame
    void Update()
    {
        moveImgs();

    }

    public void moveImgs()
    {
        float glideSpeedX = 100f;
        float glideSpeedY = -150f;

        float xLimit = Screen.width/2f;
        float yLimit = Screen.height/2f;

        foreach (Image img in uiImages)
        {
            if (img == null) continue;

            RectTransform imgRectTransform = img.GetComponent<RectTransform>();

            imgRectTransform.anchoredPosition += new Vector2(glideSpeedX, glideSpeedY) * Time.deltaTime;

            // If it goes off bottom or right side
            if (imgRectTransform.anchoredPosition.x > xLimit + 50f || imgRectTransform.anchoredPosition.y < -yLimit + -50f)
            {
                float randomX = Random.Range(-xLimit-Random.Range(200,500f), 500f);
                float randomY = Random.Range(yLimit + 100f, yLimit + 150f);

                imgRectTransform.anchoredPosition = new Vector2(randomX, randomY);
            }
        }

    }

    public void uiType(string type)
    {
        switch (type)
        {
            case ("adulthood"):
                foreach (Image img in uiImages)
                {
                    Animator imgAnim = img.GetComponent<Animator>();

                    if (imgAnim == null)
                    {
                        Debug.LogWarning("No Animator on " + img.name);
                        continue;
                    }
                    int picChoice = Random.Range(0, 2);
                    switch (picChoice)
                    {
                        case 0:
                            imgAnim.SetInteger("type", 3);
                            //clocks
                            break;
                        case 1:
                            imgAnim.SetInteger("type", 1);
                            //papers
                            break;
                        default:
                            imgAnim.SetInteger("type", 0);
                            //nothing
                            break;
                    }
                }
                break;
        }
    }
}
