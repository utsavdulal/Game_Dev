using UnityEngine;

public class AutoDoor : MonoBehaviour
{
    public Vector3 openRotation;
    public float speed = 2f;

    private Quaternion closedRot;
    private Quaternion openRot;

    private bool opening = false;

    void Start()
    {
        closedRot = transform.rotation;
        openRot = Quaternion.Euler(openRotation) * closedRot;
    }

    void Update()
    {
        if (opening)
        {
            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                openRot,
                speed * Time.deltaTime
            );
        }
        else
        {
            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                closedRot,
                speed * Time.deltaTime
            );
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            opening = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            opening = false;
        }
    }
}