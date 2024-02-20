using UnityEngine;

public class CarController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 2f;

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Rotate the car gradually based on horizontal input
        transform.Rotate(Vector3.forward, -horizontalInput * rotationSpeed);

        // Move the car forward or backward based on vertical input
        transform.Translate(Vector3.up * verticalInput * moveSpeed * Time.deltaTime);
    }
}







