using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class closePanel : MonoBehaviour
{
    public GameObject objectToDeactivate;

    void Update(){
        if(Input.GetKeyUp(KeyCode.Space)){
            Debug.Log("x");
            objectToDeactivate.SetActive(false);
        }
    }
}

