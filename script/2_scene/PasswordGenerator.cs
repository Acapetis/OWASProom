using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PasswordGenerator : MonoBehaviour
{
    public GameObject[] signObjects; // An array of 10 sign game objects
    public string[] badPasswords = new string[] {"password","123456","123456789","guest","qwerty","12345678","111111","12345","col123456","123123","1234567","1234","1234567890","000000","555555","666666","123321","654321","7777777","123"};
    public string[] goodPasswords = new string[] {
        "P@ssw0rd!",
        "5tr0ngP@ssw0rd!",
        "C0mpl3xP@ssw0rd",
        "H3ll0_W0rld!2023",
        "S3cur3_L0g1n_",
        "Fr33D0mP@ssw0rd",
        "T0pS3cr3tP@ssw0rd",
        "B3tt3rS@f3Th@nS0rry",
        "P@ssphr@s3_1$L0ng",
        "N3v3rG0nnaGiv3Y0uUp!",
        "S3cur3P@ssw0rd123",
        "I@mTh3Greatest!",
        "W3N33dt0g0D33p3r",
        "3xtr3m3lyS3cur3!",
        "P@ssw0rdM@n1@!",
        "Y0U+M3=UNSTOPPABLE",
        "R3@llyG00dP@ssw0rd",
        "S3cur3_@cc3$$Gr@nt3d",
        "1Am@H@ck3r!",
        "Th1sP@ssw0rdIsAw3s0m3"
    };

    public List<string> selectedPasswords = new List<string>(); // A list of selected passwords
    public List<string> selectedPasswords2 = new List<string>(); // A list of selected password

    void Start()
    {
        GeneratePasswords();
    }

    void GeneratePasswords()
    {
        List<string> availablePasswords = new List<string>(badPasswords);
        List<string> availablePasswords2 = new List<string>(goodPasswords);

        // Select random passwords from the badPasswords array
        for (int i = 0; i < 3; i++)
        {
            int randomIndex = Random.Range(0, availablePasswords.Count);
            selectedPasswords.Add(availablePasswords[randomIndex]);
            selectedPasswords2.Add(availablePasswords[randomIndex]);
            availablePasswords.RemoveAt(randomIndex);
        }
        for (int i = 0; i < 7; i++)
        {
            int randomIndex = Random.Range(0, availablePasswords2.Count);
            selectedPasswords.Add(availablePasswords2[randomIndex]);
            availablePasswords2.RemoveAt(randomIndex);
        }


        // Assign the selected passwords to the sign objects
        for (int i = 0; i < signObjects.Length; i++)
        {
            if (i < selectedPasswords.Count)
            {
                Label_Board labelBoard = signObjects[i].GetComponent<Label_Board>();
                labelBoard.SetPhrase(selectedPasswords[i]);
            }
        }
    }
}
