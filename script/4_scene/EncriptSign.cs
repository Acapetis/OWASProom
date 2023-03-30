using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class EncriptSign : MonoBehaviour
{
    public string cipher = "cipher: ";
    public string key = "key: ";
    public TMP_Text cipherText;
    public TMP_Text keyText;
    private bool playerInRange = false;
    public GameObject panel;
    
    // Start is called before the first frame update
    void Start()
    {
        // Find the VigenereTable script in the scene
        VigenereTable vigenereTable = GameObject.FindObjectOfType<VigenereTable>();
        // Set the correct code to the decrypted value from the VigenereTable script
        // cipher += vigenereTable.encrypted.ToLower();
        // key += vigenereTable.key.ToLower();
        cipherText.text = cipher;
        keyText.text = key;

    }

    public void SetKey(string newPhrase)
    {
        key += newPhrase;
    }

    public void SetCipher(string newPhrase)
    {
        cipher += newPhrase;
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
            //signText.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInRange)
        {
            panel.gameObject.SetActive(true);
        }
    }
}
