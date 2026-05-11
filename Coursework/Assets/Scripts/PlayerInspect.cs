using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInspect : MonoBehaviour
{
    [SerializeField] private float interactDistance = 4.0f; 
    private Camera m_Camera;

    void Awake()
    {
        m_Camera = GetComponent<Camera>();
        if (m_Camera == null) m_Camera = Camera.main;
    }

    void Update()
    {
        // Visualize the ray in the Scene window (Green = looking, Red = hit)
        Vector3 eyePosition = m_Camera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
        Debug.DrawRay(eyePosition, transform.forward * interactDistance, Color.green);

        if (Keyboard.current.fKey.wasPressedThisFrame)
        {
            Inspect();
        }
    }

    void Inspect()
    {
        Ray ray = m_Camera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactDistance))
        {
            Debug.Log("Hit something: " + hit.collider.name);

            ChairManager chair = hit.collider.GetComponent<ChairManager>();
            if (chair == null) chair = hit.collider.GetComponentInParent<ChairManager>();

            if (chair != null)
            {
                chair.ToggleInformation();
            }
        }
        else
        {
            Debug.Log("Raycast hit nothing. Distance might be too short.");
        }
    }
}