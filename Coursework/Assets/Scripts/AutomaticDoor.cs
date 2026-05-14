using UnityEngine;

public class AutomaticDoor : MonoBehaviour
{
    public Transform doorTransform;
    public float openAngle = 90f;
    public float openSpeed = 2f;
    public string playerTag = "Player";

    private Quaternion closedRotation;
    private Quaternion openRotation;
    private bool isOpen = false;

    void Start()
    {
        if (doorTransform == null)
            doorTransform = transform;

        closedRotation = doorTransform.localRotation;
        openRotation = closedRotation * Quaternion.Euler(openAngle, 0f, 0f);
    }

    void Update()
    {
        Quaternion target = isOpen ? openRotation : closedRotation;
        doorTransform.localRotation = Quaternion.Slerp(
            doorTransform.localRotation,
            target,
            Time.deltaTime * openSpeed
        );
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag))
            isOpen = true;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(playerTag))
            isOpen = false;
    }
}