using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class LM5 : MonoBehaviour
{
    public VideoPlayer videoPlayer; // Reference to VideoPlayer component

    void Start()
    {
        // Play the opening video
        videoPlayer.Play();
        videoPlayer.loopPointReached += OnVideoEnd; // Subscribe to the video end event
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        Debug.Log("Video ended!");
        LoadNextLevel();
    }

    void LoadNextLevel()
    {
        SceneManager.LoadScene("Level 5 (baxmaro)");
    }
}
