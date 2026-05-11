using System.Collections.Generic;
using UnityEngine;

public class JugManager : MonoBehaviour
{
    private List<GameObject> children = new List<GameObject>();
    private bool childrenVisible = false;

    void Start()
    {
        // Find all child objects tagged "Information"
        Transform[] allChildren = GetComponentsInChildren<Transform>(true);

        foreach (Transform child in allChildren)
        {
            if (child.CompareTag("Information"))
            {
                children.Add(child.gameObject);
            }
        }

        SetChildrenVisibility(false);
    }

    // CHANGED: Made this public and renamed it so the Camera can call it
    public void ToggleInformation()
    {
        childrenVisible = !childrenVisible;
        SetChildrenVisibility(childrenVisible);
        Debug.Log("ToggleInformation called on: " + gameObject.name);
    }

    void SetChildrenVisibility(bool visible)
    {
        foreach (GameObject child in children)
        {
            if (child != null)
            {
                child.SetActive(visible);
            }
        }
    }
}