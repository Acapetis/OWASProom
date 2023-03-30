using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstSceneManager : MonoBehaviour
{
    
    public GameObject door1;
    public GameObject door2;
    public GameObject door3;
    public GameObject door4;

    
    // Variables to store the positions of the doors
    public Vector3 door1Position;
    public Vector3 door2Position;
    public Vector3 door3Position;
    public Vector3 door4Position;


    // Array of possible door positions
    private Vector3[] doorPositions = {
        new Vector3(5, 2, 0),
        new Vector3(8, 2, 0),
        new Vector3(11, 2, 0),
        new Vector3(14, 2, 0)
        
    };

    // Function to swap the positions of the doors
    void SwapPositions(Vector3 door1Pos, Vector3 door2Pos, Vector3 door3Pos, Vector3 door4Pos)
    {
        door1.transform.position = door1Pos;
        door2.transform.position = door2Pos;
        door3.transform.position = door3Pos;
        door4.transform.position = door4Pos;
    }

    // Function to randomize the positions of the doors
    void RandomizeDoors()
    {
        // Generate 3 random numbers between 0 and 2
        int door1 = Random.Range(0, 3);
        int door2 = Random.Range(0, 3);
        int door3 = Random.Range(0, 3);
        int door4 = Random.Range(0, 4);

        // Make sure that the numbers are different
        while (door1 == door2 || door1 == door3 || door1 == door4 || door2 == door3 || door2 == door4 || door3 == door4)
    {
        door1 = Random.Range(0, 4);
        door2 = Random.Range(0, 4);
        door3 = Random.Range(0, 4);
        door4 = Random.Range(0, 4);
    }

        // Swap the positions of the doors based on the random numbers
       SwapPositions(doorPositions[door1], doorPositions[door2], doorPositions[door3], doorPositions[door4]);
    }

    void Start()
    {
        RandomizeDoors();
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
