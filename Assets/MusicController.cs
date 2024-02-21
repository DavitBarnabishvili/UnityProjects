using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicController : MonoBehaviour
{
    private static MusicController instance;
    private AudioSource audioSource;

    public AudioClip[] musicTracks; // Add your music tracks in the Inspector

    private void Awake()
    {
        if (instance == null)
        {
            // If no instance exists, set this as the instance and don't destroy it when loading a new scene
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // If an instance already exists, destroy this object
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

        // Play the first music track
        PlayMusic(0);

        // Subscribe to the scene load event to handle transitions between scenes
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Play a new music track for each scene (adjust as needed)
        int trackIndex = scene.buildIndex % musicTracks.Length;
        StartCoroutine(Crossfade(musicTracks[trackIndex], 2f));
    }

    private IEnumerator Crossfade(AudioClip newClip, float fadeDuration)
    {
        float startVolume = audioSource.volume;
        float startTime = Time.time;

        while (Time.time < startTime + fadeDuration)
        {
            audioSource.volume = Mathf.Lerp(startVolume, 0f, (Time.time - startTime) / fadeDuration);
            yield return null;
        }

        audioSource.Stop();

        audioSource.clip = newClip;
        audioSource.Play();

        startTime = Time.time;

        while (Time.time < startTime + fadeDuration)
        {
            audioSource.volume = Mathf.Lerp(0f, startVolume, (Time.time - startTime) / fadeDuration);
            yield return null;
        }

        audioSource.volume = startVolume;
    }

    public void PlayMusic(int trackIndex)
    {
        if (trackIndex >= 0 && trackIndex < musicTracks.Length)
        {
            audioSource.clip = musicTracks[trackIndex];
            audioSource.Play();
        }
    }
}
