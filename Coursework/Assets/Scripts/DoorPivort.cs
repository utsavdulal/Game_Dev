using UnityEngine;

public class SimpleDoor : MonoBehaviour
{
    public float openAngle = -90f;
    public float speed = 2f;

    private Quaternion closedRotation;
    private Quaternion openRotation;

    private bool opening = false;
    private bool closing = false;

    void Start()
    {
        closedRotation = transform.rotation;
        openRotation = Quaternion.Euler(
            transform.eulerAngles + new Vector3(0, openAngle, 0)
        );
    }

    void Update()
    {
        if (opening)
        {
            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                openRotation,
                Time.deltaTime * speed
            );
        }

        if (closing)
        {
            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                closedRotation,
                Time.deltaTime * speed
            );
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            opening = true;
            closing = false;

            CancelInvoke();
            Invoke("CloseDoor", 5f);
        }
    }

    void CloseDoor()
    {
        opening = false;
        closing = true;
    }
}