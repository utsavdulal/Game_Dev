using UnityEngine;

public class HelicopterController : MonoBehaviour
{
    public float liftForce = 20f;
    public float moveSpeed = 10f;
    public float rotateSpeed = 60f;

    public Transform mainRotor;
    public Transform tailRotor;

    public float rotorSpeed = 2000f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Rotor spinning
        if (mainRotor != null)
            mainRotor.Rotate(Vector3.up * rotorSpeed * Time.deltaTime);

        if (tailRotor != null)
            tailRotor.Rotate(Vector3.right * rotorSpeed * Time.deltaTime);
    }

    void FixedUpdate()
    {
        // UP / DOWN
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * liftForce, ForceMode.Acceleration);
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            rb.AddForce(Vector3.down * liftForce, ForceMode.Acceleration);
        }

        // FORWARD / BACKWARD
        float move = Input.GetAxis("Vertical");
        rb.AddForce(transform.forward * move * moveSpeed);

        // TURN LEFT / RIGHT
        float turn = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up * turn * rotateSpeed * Time.deltaTime);
    }
}