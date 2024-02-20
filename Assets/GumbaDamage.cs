using UnityEngine;

public class GumbaDamage : MonoBehaviour
{
    public int damageAmount = 1;
    public float moveSpeed = 2f; // Adjust the movement speed as needed
    public float moveDistance = 5f; // Adjust the distance to move as needed

    private HealthBar healthBar;
    private float startPosX;
    private float direction = -1; // 1 for right, -1 for left

    void Start()
    {
        GameObject healthBarObject = GameObject.FindGameObjectWithTag("HealthBar");
        healthBar = healthBarObject.GetComponent<HealthBar>();

        startPosX = transform.position.x;
    }

    void Update()
    {
        MoveBackAndForth();
    }

    void MoveBackAndForth()
    {
        // Move the object back and forth
        transform.Translate(Vector2.right * direction * moveSpeed * Time.deltaTime);

        // Check if the object reached the end of the movement distance
        if (startPosX - transform.position.x >= moveDistance)
        {
            // Change the direction to move in the opposite direction
            direction *= -1;
        }
        else if (startPosX < transform.position.x)
        {
            direction *= -1;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            direction *= -1;
            if (healthBar != null)
            {
                healthBar.TakeDamage(damageAmount);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager.instance.GumbaDefeated();
            Destroy(gameObject);
        }
    }
}

