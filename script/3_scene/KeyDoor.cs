using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KeyDoor : MonoBehaviour
{
   [SerializeField] private Key.KeyType keyType;

   public Key.KeyType GetKeyType(){
        return keyType;
    }

    public void OpenDoor(){
        Debug.Log("Removed key" + keyType);        
        gameObject.SetActive(false); 
        // To switch to a different scene:
        SceneManager.LoadScene("question_3");
    }
}
