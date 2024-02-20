using UnityEngine;

public class ToasterController : MonoBehaviour
{
    public float throwForce = 5f;
    public float downwardForce = 1f;
    public AudioClip collisionSound;

    private Rigidbody2D toasterRb;
    private AudioSource audioSource;
    private bool hasBeenThrown = false;

    void Start()
    {
        toasterRb = GetComponent<Rigidbody2D>();
        toasterRb.isKinematic = true;
        toasterRb.gravityScale = 0f;

        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = collisionSound;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !hasBeenThrown)
        {
            ThrowToaster();
        }
    }

    void ThrowToaster()
    {
        toasterRb.isKinematic = false;
        toasterRb.gravityScale = 1f;
        toasterRb.AddForce(new Vector2(throwForce, -downwardForce), ForceMode2D.Impulse);

        hasBeenThrown = true;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("jumpableGround"))
        {
            toasterRb.velocity = Vector2.zero;
            toasterRb.isKinematic = true;
            toasterRb.angularVelocity = 0f;
            toasterRb.Sleep();
            toasterRb.gravityScale = 0f;

            // Play the collision sound
            audioSource.Play();
            //Debug.Log("DEDAMOVTYAN");
        }
    }
}


