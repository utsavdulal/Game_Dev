using UnityEngine;

public class DoorAutomation : MonoBehaviour
{
    public Transform door;

    public float openAngle = 90f;
    public float speed = 2f;

    private Quaternion closedRotation;
    private Quaternion openRotation;

    private bool isOpen = false;

    void Start()
    {
        closedRotation = door.localRotation;
        openRotation = Quaternion.Euler(0, openAngle, 0) * closedRotation;
    }

    void Update()
    {
        Quaternion target = isOpen ? openRotation : closedRotation;

        door.localRotation = Quaternion.Slerp(
            door.localRotation,
            target,
            Time.deltaTime * speed
        );
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            isOpen = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            isOpen = false;
    }
}