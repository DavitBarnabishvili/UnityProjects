using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public AudioClip collisionSound; // Assign the sound clip in the Inspector
    public GameObject replacementObject; // Assign the replacement object in the Inspector
    public float yOffset = 1.0f; // Adjust the offset as needed

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Death"))
        {
            // Play the collision sound
            AudioSource.PlayClipAtPoint(collisionSound, transform.position);

            // Destroy the enemy
            Destroy(gameObject);

            // Instantiate the replacement object at a slightly lower y position
            InstantiateReplacementObject(collision.transform.position);
        }
    }

    private void InstantiateReplacementObject(Vector3 position)
    {
        // Adjust the y position by subtracting yOffset
        Vector3 newPosition = new Vector3(position.x, position.y - 4, position.z);

        // Instantiate the assigned replacement object at the adjusted position
        Instantiate(replacementObject, newPosition, Quaternion.identity);
    }
}
