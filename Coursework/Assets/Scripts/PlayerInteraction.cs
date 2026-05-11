using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private float interactDistance = 15f;

    private Camera m_Camera;

    public GameObject cluePanel;
    public TextMeshProUGUI clueText;

    void Awake()
    {
        m_Camera = GetComponent<Camera>();

        if (m_Camera == null)
            m_Camera = Camera.main;

        cluePanel.SetActive(false);
    }

    void Update()
{
    if (Keyboard.current.fKey.wasPressedThisFrame)
    {
        if (cluePanel.activeSelf)
        {
            cluePanel.SetActive(false);
        }
        else
        {
            Inspect();
        }
    }
}

    void Inspect()
{
    Ray ray = new Ray(
        m_Camera.transform.position,
        m_Camera.transform.forward);

    RaycastHit hit;

    if (Physics.Raycast(ray, out hit, interactDistance))
    {
        Debug.Log("HIT OBJECT: " + hit.collider.name);

        Interactable interactable =
            hit.collider.GetComponent<Interactable>();

        if (interactable == null)
        {
            interactable =
                hit.collider.GetComponentInParent<Interactable>();
        }

        if (interactable != null)
        {
            cluePanel.SetActive(true);
            clueText.text = interactable.GetClue();
        }
        else
        {
            Debug.Log("NO INTERACTABLE SCRIPT");
        }
    }
}
}