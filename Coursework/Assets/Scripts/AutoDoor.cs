using System.Collections;
using UnityEngine;

public class AutoDoor : MonoBehaviour
{
    [Header("Door Settings")]
    public float openAngle = 90f;
    public float openSpeed = 2f;
    public float closeDelay = 5f;

    private Quaternion closedRotation;
    private Quaternion openRotation;

    private bool isOpen = false;
    private Coroutine closeCoroutine;

    void Start()
    {
        closedRotation = transform.rotation;
        openRotation = Quaternion.Euler(
            transform.eulerAngles + new Vector3(0, openAngle, 0)
        );
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OpenDoor();

            if (closeCoroutine != null)
            {
                StopCoroutine(closeCoroutine);
            }

            closeCoroutine = StartCoroutine(CloseDoorAfterDelay());
        }
    }

    void OpenDoor()
    {
        isOpen = true;
        StopAllCoroutines();
        StartCoroutine(RotateDoor(openRotation));
    }

    IEnumerator CloseDoorAfterDelay()
    {
        yield return new WaitForSeconds(closeDelay);

        isOpen = false;
        StartCoroutine(RotateDoor(closedRotation));
    }

    IEnumerator RotateDoor(Quaternion targetRotation)
    {
        while (Quaternion.Angle(transform.rotation, targetRotation) > 0.1f)
        {
            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                targetRotation,
                Time.deltaTime * openSpeed
            );

            yield return null;
        }

        transform.rotation = targetRotation;
    }
}