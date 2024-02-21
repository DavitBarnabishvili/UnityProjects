using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsController : MonoBehaviour
{
    public float creditsDuration = 35.2f; // Set the duration of your end credits

    void Start()
    {
        // Start the coroutine to wait for the credits to finish
        StartCoroutine(WaitAndLoadMenu());
    }

    IEnumerator WaitAndLoadMenu()
    {
        // Wait for the specified duration
        yield return new WaitForSeconds(creditsDuration);

        // Load the menu scene
        SceneManager.LoadScene(0);
    }
}
