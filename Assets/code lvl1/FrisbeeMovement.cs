using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class FrisbeeMovement : MonoBehaviour
{
    public float moveSpeed = 5f;  // Adjust the movement speed as needed
    public float loopHeight = 5f; // Adjust the height of the loop

    private Vector3 startPosition;
    private float direction = 1; // 1 for up and right, -1 for down and left
    private bool go = false;

    void Start()
    {
        startPosition = transform.position;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            go = true;
        }
    }

    void Update() {
        if (go) {
            transform.Translate(new Vector2(0.8f, 0.4f) * direction * moveSpeed * Time.deltaTime);

            // Check if the sprite reached the end of the movement distance
            if (transform.position.y - startPosition.y >= loopHeight)
            {
                // Change the direction to move in the opposite direction
                direction *= -1;
            }
            else if (startPosition.y > transform.position.y) { 
                direction *= -1;
            }

        }
    }
}
