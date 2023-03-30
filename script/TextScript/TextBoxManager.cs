using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextBoxManager : MonoBehaviour
{


    public GameObject textBox;
    public TMP_Text theText;
    
    public TextAsset textFile;
    
    public string[] textLines;
    public int currentline;
    public int endAtLine;

    public PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();

        if (textFile != null){
            textLines = (textFile.text.Split("\n"));
        }

        if (endAtLine == 0){
            endAtLine = textLines.Length - 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        theText.text = textLines[currentline];

        if (Input.GetKeyDown(KeyCode.Return) && currentline < endAtLine){
            currentline += 1; 
        }

        if (Input.GetKeyDown(KeyCode.Return) && currentline == endAtLine){
            theText.text = ""; 
        }
    }
}
