using UnityEngine;

public class Follow : MonoBehaviour
{
    private GameObject player;
    private bool isFollowing = false;
    private Vector3 initialPosition;  // Store the initial starting point

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        initialPosition = transform.position;  // Store the initial starting point
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isFollowing = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Ice"))
        {
            isFollowing = false;
        }
    }

    void Update()
    {
        if (isFollowing)
        {
            // Move the ice skates with the player
            transform.position = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
        }

        if (player.transform.position.x < initialPosition.x)
        {
            // Reset the ice skates' position to the initial position
            transform.position = initialPosition;
        }
    }

    // Add this method to handle resetting the ice skates' position
    public void ResetPosition()
    {
        transform.position = initialPosition;
    }
}


