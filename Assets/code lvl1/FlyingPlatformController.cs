using System.Collections;
using UnityEngine;

public class FlyingPlatformController : MonoBehaviour
{
    private Animator animator;

    // The initial position of the platform
    private Vector3 initialPosition;

    void Start()
    {
        animator = GetComponent<Animator>();
        initialPosition = transform.position;
        StartCoroutine(DropAndRise());
    }

    IEnumerator DropAndRise()
    {
        while (true)
        {
            // Wait for 1 second in the "Flying" state
            yield return new WaitForSeconds(1f);

            // Check if the player is on the platform
            if (IsPlayerOnPlatform())
            {
                // Trigger the transition to "Drop" animation
                animator.SetTrigger("Drop");

                // Wait for the "Drop" animation duration
                yield return new WaitForSeconds(GetAnimationDuration("Drop"));

                // Move the platform below the screen smoothly
                StartCoroutine(MovePlatformDown(0.7f)); // Adjust the speed as needed

                // Wait for 3 seconds before moving the platform back up
                yield return new WaitForSeconds(3f);

                // Move the platform back to the initial position smoothly
                StartCoroutine(MovePlatformUp(0.5f)); // Adjust the speed as needed
            }

            // Trigger the transition back to "Flying" animation
            animator.SetTrigger("Flying");

            // Wait for the "Flying" animation duration
            yield return new WaitForSeconds(GetAnimationDuration("Flying"));
        }
    }

    IEnumerator MovePlatformDown(float speed)
    {
        float t = 0f;
        Vector3 targetPosition = initialPosition - new Vector3(0f, 10f, 0f); // Adjust the distance as needed

        while (t < 1f)
        {
            t += Time.deltaTime * speed;
            transform.position = Vector3.Lerp(initialPosition, targetPosition, t);
            yield return null;
        }
    }

    IEnumerator MovePlatformUp(float speed)
    {
        float t = 0f;
        Vector3 targetPosition = initialPosition;

        while (t < 1f)
        {
            t += Time.deltaTime * speed;
            transform.position = Vector3.Lerp(transform.position, targetPosition, t);
            yield return null;
        }
    }

    bool IsPlayerOnPlatform()
    {
        // Check if any GameObject with the "Player" tag is on the platform
        Collider2D[] colliders = Physics2D.OverlapBoxAll(transform.position, GetComponent<BoxCollider2D>().size, 0f);
        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Player"))
            {
                return true;
            }
        }
        return false;
    }

    float GetAnimationDuration(string animationName)
    {
        // Retrieve the duration of the specified animation
        AnimationClip[] clips = animator.runtimeAnimatorController.animationClips;
        foreach (AnimationClip clip in clips)
        {
            if (clip.name == animationName)
            {
                return clip.length;
            }
        }
        return 0f;
    }
}



