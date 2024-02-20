using UnityEngine;
using System.Collections;

public class ButtonScript : MonoBehaviour
{
    // Reference to the two Death objects
    public GameObject deathObject1;
    public GameObject deathObject2;

    // Initial positions of Death objects
    private Vector3 initialPosition1;
    private Vector3 initialPosition2;

    // The target Y position for the drop-down effect
    public float targetY = 2.0f;

    // Speed of the drop-down effect
    public float dropSpeed = 5.0f;

    private void Start()
    {
        // Store the initial positions of Death objects
        initialPosition1 = deathObject1.transform.position;
        initialPosition2 = deathObject2.transform.position;

        // Disable gravity for Death objects at the start
        SetGravityScale(deathObject1, 0);
        SetGravityScale(deathObject2, 0);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Trigger drop down behavior for Death objects
            Debug.Log("Player triggered the button.");
            DropDownObjects();
        }
    }

    private void DropDownObjects()
    {
        // Activate the Death objects
        deathObject1.SetActive(true);
        deathObject2.SetActive(true);

        // Enable gravity for Death objects
        SetGravityScale(deathObject1, 3);
        SetGravityScale(deathObject2, 3);

        // Move Death objects to the target Y position
        StartCoroutine(MoveObject(deathObject1.transform, targetY, dropSpeed));
        StartCoroutine(MoveObject(deathObject2.transform, targetY, dropSpeed));
    }

    private IEnumerator MoveObject(Transform objTransform, float targetY, float speed)
    {
        // Move the object to the target Y position
        while (objTransform.position.y > targetY)
        {
            objTransform.position -= new Vector3(0, speed * Time.deltaTime, 0);
            Debug.Log("Moving object down.");
            yield return null;
        }
    }

    private void SetGravityScale(GameObject obj, float gravityScale)
    {
        Rigidbody2D rb = obj.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.gravityScale = gravityScale;
        }
    }
}

