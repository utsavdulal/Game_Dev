using UnityEngine;

public class AutoDoor : MonoBehaviour
{
    public Transform door;
    public float openAngle = 90f;
    public float speed = 2f;

    private Quaternion closedRotation;
    private Quaternion openRotation;

    private bool isOpen = false;

    void Start()
    {
        closedRotation = door.rotation;
        openRotation = Quaternion.Euler(
            door.eulerAngles.x,
            door.eulerAngles.y + openAngle,
            door.eulerAngles.z
        );
    }

    void Update()
    {
        if (isOpen)
        {
            door.rotation = Quaternion.Slerp(
                door.rotation,
                openRotation,
                Time.deltaTime * speed
            );
        }
        else
        {
            door.rotation = Quaternion.Slerp(
                door.rotation,
                closedRotation,
                Time.deltaTime * speed
            );
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isOpen = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isOpen = false;
        }
    }
}