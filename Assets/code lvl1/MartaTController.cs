using System;
using UnityEngine;

public class MartaTController : MonoBehaviour
{
    public float throwForce = 5f;
    public float downwardForce = 1f;

    private Transform toasterTransform;
    private bool hasBeenThrown = false;

    private void Start()
    {
        toasterTransform = transform.Find("Toaster");
        toasterTransform.gameObject.AddComponent<ToasterController>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !hasBeenThrown)
        {
            // Player has triggered the collider for the first time
            ThrowToaster();
        }
    }

    private void ThrowToaster()
    {
        // Enable gravity and apply forces to the toaster
        Rigidbody2D toasterRb = toasterTransform.gameObject.GetComponent<Rigidbody2D>();
        toasterRb.isKinematic = false;
        toasterRb.gravityScale = 1f;
        toasterRb.AddForce(new Vector2(throwForce, -downwardForce), ForceMode2D.Impulse);

        // Toaster has been thrown, prevent further interactions with the player
        hasBeenThrown = true;
    }
}





