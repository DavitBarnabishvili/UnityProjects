using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BackAndForthMovement : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float moveDistance = 5f;

    private Vector2 startPos;
    private float direction = 1; // 1 for right, -1 for left

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        // Move the sprite back and forth
        transform.Translate(Vector2.right * direction * moveSpeed * Time.deltaTime);

        // Check if the sprite reached the end of the movement distance
        if (Mathf.Abs(transform.position.x - startPos.x) >= moveDistance)
        {
            // Change the direction to move in the opposite direction
            direction *= -1;
        }
    }
}
