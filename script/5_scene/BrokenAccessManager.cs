using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BrokenAccessManager : MonoBehaviour
{
    public GameObject door;
    public AudioClip unlockSound;

    private List<Capsule2> capsules = new List<Capsule2>();
    private int capsuleCount = 0;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void CollectCapsule(Capsule2 capsule)
    {
        capsules.Add(capsule);
        capsuleCount++;

        if (capsuleCount == 4)
        {
            CheckCapsuleOrder();
        }
    }

    private void CheckCapsuleOrder()
    {
        bool orderCorrect = true;
        for (int i = 0; i < capsules.Count; i++)
        {
            if (!capsules[i].IsCorrectPosition(i + 1))
            {
                orderCorrect = false;
                break;
            }
        }

        if (orderCorrect)
        {
            UnlockDoor();
        }
        else
        {
            // Restart the scene
            StartCoroutine(RestartScene());
        }
    }

    private void UnlockDoor()
    {
        Destroy(door);
        audioSource.PlayOneShot(unlockSound);
        SceneManager.LoadScene("lesson_5");
    }

    IEnumerator RestartScene()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
