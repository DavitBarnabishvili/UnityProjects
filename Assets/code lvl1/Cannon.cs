using System.Collections;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public GameObject cannonballPrefab;
    public Transform shootPoint;
    public float shootForce = 10f;
    public float shootInterval = 2f; // Time between shots

    void Start()
    {
        // Start shooting coroutine
        StartCoroutine(ShootContinuously());
    }

    IEnumerator ShootContinuously()
    {
        while (true)
        {
            yield return new WaitForSeconds(shootInterval);

            // Shoot a cannonball
            ShootCannonball();
        }
    }

    void ShootCannonball()
    {
        // Instantiate a new cannonball
        GameObject cannonball = Instantiate(cannonballPrefab, shootPoint.position, Quaternion.identity);

        // Apply force to the cannonball
        Rigidbody2D rb = cannonball.GetComponent<Rigidbody2D>();
        rb.AddForce(Vector2.left * shootForce, ForceMode2D.Impulse);
    }
}

