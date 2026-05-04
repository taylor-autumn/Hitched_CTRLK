using UnityEngine;

public class CuttingAction : MonoBehaviour
{
    public int CuttingAmount =1;
    public bool MetalChain;

    private bool playerInRange;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(MetalChain == true)
        {
            CuttingAmount = Random.Range(2,5);
        } else
        {
            CuttingAmount = 1;
        }
    }

void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.H))
        {
            CuttingAmount -= 1;

            if (CuttingAmount <= 0)
            {
                Destroy(gameObject);
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
