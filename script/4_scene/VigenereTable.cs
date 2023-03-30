using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class VigenereTable : MonoBehaviour
{
    public string decrypted;
    public string encrypted;
    public string key;
    public GameObject sign;
    public GameObject door;
    
    private List<string[]> passwordKeyPairs = new List<string[]>()
    {
        new string[] { "lemon", "cat", "nef" }, 
        new string[] { "orange", "car", "qrr" },
        new string[] { "grape", "hat", "nrt" },
        new string[] { "banana", "cow", "doj" },
        new string[] { "strawberry", "dog", "vhx" },
        new string[] { "kiwi", "cup", "icl" },
        new string[] { "mango", "egg", "qgt" },
        new string[] { "peach", "boy", "gsy" },
        new string[] { "pineapple", "top", "vii" },
        new string[] { "watermelon", "zip", "yfx" }
    };

    void Start()
    {
        // Choose a random password-key pair from the list
        int index = Random.Range(0, passwordKeyPairs.Count);
        string[] theKeyPair = passwordKeyPairs[index];
        decrypted = theKeyPair[1];
        encrypted = theKeyPair[2];
        key = theKeyPair[0];
        
        EncriptSign signPanel = sign.GetComponent<EncriptSign>();
        signPanel.SetKey(key);
        signPanel.SetCipher(encrypted);

        AlphaPad doorP = door.GetComponent<AlphaPad>();
        doorP.setPass(decrypted);

    }

}
