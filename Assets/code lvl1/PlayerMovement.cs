using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private Animator animator;
    private HealthBar healthBar;
    private Rigidbody2D rb;
    private BoxCollider2D bc;
    [SerializeField] private LayerMask jumpableGround;
    private Vector3 respawnPosition;  // Store the initial respawn position
    private bool isOnTrampoline = false;
    private bool isSliding = false;
    private float slideSpeed = 10f; // Adjust the slide speed as needed
    private Scene currentScene;

    // Start is called before the first frame update
    private void Start()
    {
        animator = GetComponent<Animator>();
        GameObject healthBarObject = GameObject.FindGameObjectWithTag("HealthBar");
        healthBar = healthBarObject.GetComponent<HealthBar>();
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
        currentScene = SceneManager.GetActiveScene();

        // Store the initial respawn position
        respawnPosition = transform.position;
    }

    // Update is called once per frame
    private void Update()
    {

        float dirX = Input.GetAxisRaw("Horizontal");

        if (isSliding)
        {
            // Apply sliding speed when hitting Ice and holding a directional key
            rb.velocity = new Vector2(slideSpeed * dirX, rb.velocity.y);
        }
        else
        {
            // Apply regular movement
            rb.velocity = new Vector2(5f * dirX, rb.velocity.y);
        }

        animator.SetBool("ClickedLeft", dirX < 0);
        animator.SetBool("ClickedRight", dirX > 0);

        if (isOnTrampoline)
        {
            rb.velocity = new Vector2(rb.velocity.x, 18f);
            isOnTrampoline = false;
        }

        // Check for sliding condition
        if (Input.GetKey(KeyCode.RightArrow) && IsGrounded() && isSliding)
        {
            // Continue sliding to the right
            rb.velocity = new Vector2(slideSpeed, rb.velocity.y);
        }
        else if (Input.GetKey(KeyCode.LeftArrow) && IsGrounded() && isSliding)
        {
            // Continue sliding to the left
            rb.velocity = new Vector2(-slideSpeed, rb.velocity.y);
        }
        else
        {
            // Slow down in the direction of movement when the key is released
            float slowDownFactor = 0.9f; // Adjust the slow down factor as needed
            rb.velocity = new Vector2(rb.velocity.x * slowDownFactor, rb.velocity.y);
        }

        // Disable jumping
        if (!isSliding && Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, 12f);
        }
    }

    private bool IsGrounded()
    {
        // Use RaycastHit2D for 2D physics
        RaycastHit2D hit = Physics2D.BoxCast(bc.bounds.center, bc.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
        return hit.collider != null;
    }

    // Add this method to handle respawn
    public void Respawn()
    {
        // Reset the player's position to the initial respawn position
        transform.position = respawnPosition;
        if(currentScene.name == "Level 5 (baxmaro)") GameManager.isPlayerLocked = false;

        // You might want to reset other aspects of the player's state here
    }

    // Add this method to handle pacifier damage
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Pacifier"))
        {
            // Handle pacifier collision (e.g., apply damage)
            if (healthBar.currentHearts == 0)
            {
                healthBar.IncreaseHealth(5);
                Respawn();
            }
        }
        else if (other.CompareTag("Death"))
        {
            healthBar.IncreaseHealth(5);
            Respawn();
        }
        else if (other.CompareTag("Trampoline"))
        {
            // Set trampoline flag when colliding with a trampoline
            isOnTrampoline = true;
        }
        else if (other.CompareTag("Ice"))
        {
            // Set sliding flag when hitting something labeled "Ice"
            isSliding = true;
        }
    }

    // Add this method to handle exiting the Ice area
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Ice"))
        {
            // Reset sliding flag when leaving the Ice area
            isSliding = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
            if (collision.collider.CompareTag("Pacifier"))
            {
                // Handle pacifier collision (e.g., apply damage)
                if (healthBar.currentHearts == 0)
                {
                    healthBar.IncreaseHealth(5);
                    Respawn();
                }
            }
    }
}




