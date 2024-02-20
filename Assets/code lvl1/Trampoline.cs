using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    private Animator trampolineAnimator;

    void Start()
    {
        trampolineAnimator = GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Trigger the jump animation
            trampolineAnimator.SetBool("PlayerPresent", true);


            // Add additional logic here, like applying force to the player for a high jump
            // Example: other.GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Set the boolean parameter to false when leaving the trampoline
            trampolineAnimator.SetBool("PlayerPresent", false);
        }
    }
}

