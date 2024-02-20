using UnityEngine;

public class Cannonball : MonoBehaviour
{
    public int damage = 1;
    public float destroyXPosition = -77f; // Set the X position where you want to destroy the cannonball

    void Update()
    {
        // Check the current X position of the cannonball
        if (transform.position.x < destroyXPosition)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
