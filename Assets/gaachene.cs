using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gaachene : MonoBehaviour
{
    public GameObject[] objectsToToggle; // Array to hold objects to toggle visibility
    public float moveSpeed = 5f;  // Adjust the movement speed as needed
    public float loopHeight = 5f; // Adjust the height of the loop

    private Vector3 startPosition;
    private float direction = 1; // 1 for up and right, -1 for down and left
    private bool go = false;
    private GameObject player;
    //private Transform playerTransform;


    void Start()
    {
        ToggleObjectsVisibility(false);
        startPosition = transform.position;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && transform.position.y < 5)
        {
            direction = 1;
            ToggleObjectsVisibility(true);
            go = true;
            other.transform.parent = transform;
        }
    }

    private void DetachPlayer()
    {
        ToggleObjectsVisibility(false);
        player.transform.parent = null;
    }
    void Update()
    {
        if (go)
        {
            transform.Translate(new Vector2(1f, 0.8f) * direction * moveSpeed * Time.deltaTime);

            // Check if the sprite reached the end of the movement distance
            if (transform.position.y - startPosition.y >= loopHeight)
            {
                // Change the direction to move in the opposite direction
                direction *= 0;
                DetachPlayer();
                go = false;
                Invoke("Reset", 15);
                
            }

        }
    }

    private void Reset()
    {
        transform.position = startPosition;
    }

    private void ToggleObjectsVisibility(bool visible)
    {
        foreach (GameObject obj in objectsToToggle)
        {
            if (obj != null)
            {
                obj.SetActive(visible);
            }
        }
    }
}
