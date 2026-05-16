using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private float interactDistance = 15f;

    public AudioSource inspectSound;
    private Camera m_Camera;

    public GameObject cluePanel;
    public TextMeshProUGUI clueText;

    public GameObject interactPrompt;

    void Awake()
    {
        m_Camera = GetComponent<Camera>();

        if (m_Camera == null)
            m_Camera = Camera.main;

        cluePanel.SetActive(false);

        if (interactPrompt != null)
        {
            interactPrompt.SetActive(false);
        }
    }

    void Update()
    {
        CheckForInteractable();

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

    void CheckForInteractable()
    {
        Ray ray = new Ray(
            m_Camera.transform.position,
            m_Camera.transform.forward);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactDistance))
        {
            Interactable interactable =
                hit.collider.GetComponentInParent<Interactable>();

            if (interactable != null)
            {
                interactPrompt.SetActive(true);
            }
            else
            {
                interactPrompt.SetActive(false);
            }
        }
        else
        {
            interactPrompt.SetActive(false);
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
                hit.collider.GetComponentInParent<Interactable>();

            if (interactable != null)
            {
                cluePanel.SetActive(true);

                clueText.text =
                    interactable.GetClue();
                    

                interactable.FoundEvidence();

                inspectSound.Play();
            }
            else
            {
                Debug.Log("NO INTERACTABLE SCRIPT");
            }
        }
    }
}