using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    public Transform player; // Drag the player GameObject here in the Inspector
    public float smoothFollowingSpeed = 5f; // Adjust this value for desired smoothness

    private void LateUpdate()
    {
        if (player != null)
        {
            // Smoothly follow player's position
            transform.position = Vector3.MoveTowards(transform.position, player.position, smoothFollowingSpeed * Time.deltaTime);
        }
    }
}


