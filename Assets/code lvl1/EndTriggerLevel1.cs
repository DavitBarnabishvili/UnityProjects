using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingTriggerLevel1 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Player has entered the ending trigger, load the next level
            LoadNextLevel();
        }
    }

    private void LoadNextLevel()
    {
        // Assuming the next level is named "Level2"
        SceneManager.LoadScene("VideoLevel2");
    }
}
