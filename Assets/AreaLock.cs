using UnityEngine;

public class AreaLock : MonoBehaviour
{
    public GameObject[] objectsToToggle; // Array to hold objects to toggle visibility


    private void Start()
    {
        ToggleObjectsVisibility(false);

    }

    private void Update()
    {
        if (!GameManager.IsPlayerLocked())
        {
            ToggleObjectsVisibility(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Activate objects
            ToggleObjectsVisibility(true);
            GameManager.isPlayerLocked=true;
        }
    }

    private void ToggleObjectsVisibility(bool visible)
    {
        foreach (GameObject obj in objectsToToggle)
        {
            if (obj != null)
            {
                obj.SetActive(visible);
            }
        }
    }
}






