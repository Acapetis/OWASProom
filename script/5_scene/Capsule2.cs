using UnityEngine;

public class Capsule2 : MonoBehaviour
{
    public int position = 1;
    public string codeSnippet = "authentication";

    private bool collected = false;
    private BrokenAccessManager uiPanel;

    void Start()
    {
        uiPanel = FindObjectOfType<BrokenAccessManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !collected)
        {
            collected = true;
            Debug.Log("You collected a capsule!");
            uiPanel.CollectCapsule(this);
            Destroy(this.gameObject);

        }
    }

    public string GetCodeSnippet()
    {
        return codeSnippet;
    }

    public bool IsCorrectPosition(int pos)
    {
        return position == pos;
    }
}



