using UnityEngine;

public class CarAutoDrive : MonoBehaviour
{
    public Transform point1;
    public Transform point2;

    public float speed = 10f;
    public float rotationSpeed = 5f;

    private Transform target;

    void Start()
    {
        target = point1;
    }

    void Update()
    {
        // Direction
        Vector3 direction = (target.position - transform.position).normalized;

        // Smooth rotation
        Quaternion lookRotation = Quaternion.LookRotation(direction);

        transform.rotation = Quaternion.Slerp(
            transform.rotation,
            lookRotation,
            rotationSpeed * Time.deltaTime
        );

        // Always move forward
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        // Distance check
        float distance = Vector3.Distance(
            transform.position,
            target.position
        );

        // BEFORE reaching exact point switch target
        if (distance < 3f)
        {
            if (target == point1)
            {
                target = point2;
            }
            else
            {
                target = point1;
            }
        }
    }
}