using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VirusCodeTrigger : MonoBehaviour
{
    public GameObject textBox;

    private bool playerInRange = false;

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
            textBox.SetActive(false);
            //signText.SetActive(false);
        }
    }

    void Update()
    {
        if (playerInRange)
        {
            textBox.SetActive(true);
            
        }
    }
}
