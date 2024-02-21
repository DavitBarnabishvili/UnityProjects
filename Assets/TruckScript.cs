using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckScript : MonoBehaviour
{
    public GameObject chumbu;
    public GameObject us;
    public GameObject newParent;
    public Transform mainCameraTransform;

    public AudioClip firstSound;
    public AudioClip secondSound;

    private AudioSource audioSource1;
    private AudioSource audioSource2;

    public float moveSpeed = 5f; // Adjust the movement speed as needed

    private Rigidbody2D rb;
    private bool isTriggered = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ToggleObjectsVisibility(false);
        audioSource1 = gameObject.AddComponent<AudioSource>();
        audioSource2 = gameObject.AddComponent<AudioSource>();

        // Assign audio clips to the AudioSources
        audioSource1.clip = firstSound;
        audioSource2.clip = secondSound;
    }

    void Update()
    {
        if (isTriggered) {
            MoveToRight();
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isTriggered = true;
            // Activate objects
            ToggleObjectsVisibility(true);
            if (us != null)
            {
                us.SetActive(false);
            }
            float startVolume = audioSource1.volume;
            audioSource1.Play();
            audioSource1.volume = startVolume * 0.5f;
            audioSource2.Play();
            audioSource2.volume = startVolume * 0.5f;
        }
    }

    private void ToggleObjectsVisibility(bool visible)
    {
        if (chumbu != null)
        {
            chumbu.SetActive(visible);
            if (visible)
            {
                if (mainCameraTransform != null)
                {
                    // Transfer the main camera to the new parent
                    mainCameraTransform.SetParent(newParent.transform);
                }
            }
        }
    }

    void MoveToRight()
    {
        Vector2 movement = new Vector2(moveSpeed, 0f);
        rb.velocity = movement;
    }
}
