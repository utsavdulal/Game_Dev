using UnityEngine;

public class Interactable : MonoBehaviour
{
    [TextArea(3, 5)]
    public string clueText = "This is a clue...";

    public string GetClue()
    {
        return clueText;
    }
    private bool found = false;


public void FoundEvidence()
{
    if(found) return;

    found = true;

    GameManager.Instance.AddEvidence();
}

}