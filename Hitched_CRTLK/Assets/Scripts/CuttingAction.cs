using UnityEngine;

public class CuttingAction : MonoBehaviour
{
    public int CuttingAmount =1;
    public bool MetalChain;

    private bool playerInRange;

    storyProgression storyProgression;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        storyProgression = GameObject.Find("gameManager").GetComponent<storyProgression>();

        if (MetalChain == true)
        {
            CuttingAmount = Random.Range(2,5);
        } else
        {
            CuttingAmount = 1;
        }
    }

void Update()
    {
        if (playerInRange && storyProgression.mode == storyProgression.gameMode.normal && Input.GetKeyDown(KeyCode.C))
        {
            CuttingAmount -= 1;

            if (CuttingAmount <= 0)
            {
                Destroy(gameObject);
            }

            if (gameObject.name == "rope")
            {
                storyProgression.scissorSound.Play();
            }

        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}
