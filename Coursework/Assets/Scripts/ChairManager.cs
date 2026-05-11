using System.Collections.Generic;
using UnityEngine;

public class ChairManager : MonoBehaviour
{
    private List<GameObject> children = new List<GameObject>();
    private bool childrenVisible = false;

    void Start()
    {
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

    public void ToggleInformation()
    {
        childrenVisible = !childrenVisible;
        SetChildrenVisibility(childrenVisible);
    }

    void SetChildrenVisibility(bool visible)
    {
        foreach (GameObject child in children)
        {
            if (child != null) child.SetActive(visible);
        }
    }
}