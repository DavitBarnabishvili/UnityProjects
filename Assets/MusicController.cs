using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicController : MonoBehaviour
{
    private static MusicController instance;
    private AudioSource audioSource1;
    private AudioSource audioSource2;

    public AudioClip[] musicTracks; // Add your music tracks in the Inspector
    private int currentTrackIndex = 0;

    private void Awake()
    {
        if (instance == null)
        {
            // If no instance exists, set this as the instance and don't destroy it when loading a new scene
            instance = this;
            DontDestroyOnLoad(gameObject);

            // Create two AudioSources
            audioSource1 = gameObject.AddComponent<AudioSource>();
            audioSource2 = gameObject.AddComponent<AudioSource>();
        }
        else
        {
            // If an instance already exists, destroy this object
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // Play the first music track on audioSource1
        PlayMusic(0, audioSource1);

        // Subscribe to the scene load event to handle transitions between scenes
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Play a new music track on the other audio source (adjust as needed)
        int newTrackIndex = scene.buildIndex % musicTracks.Length;

        // Determine which audio source to fade out and which to fade in
        AudioSource fadingOutSource = currentTrackIndex % 2 == 0 ? audioSource1 : audioSource2;
        AudioSource fadingInSource = currentTrackIndex % 2 == 0 ? audioSource2 : audioSource1;

        // Crossfade between the two audio sources, but only if not transitioning from End Credits to the first scene
        if (scene.buildIndex != 0)
        {
            StartCoroutine(Crossfade(musicTracks[newTrackIndex], 2f, fadingOutSource, fadingInSource));
        }
    }

    private IEnumerator Crossfade(AudioClip newClip, float fadeDuration, AudioSource OutSource, AudioSource InSource)
    {
        float outStartVolume = OutSource.volume;
        float inFinishVolume = outStartVolume;
        float startTime = Time.time;

        InSource.clip = newClip;
        InSource.volume = 0.2f;
        InSource.Play();

        while (Time.time < startTime + fadeDuration)
        {
            InSource.volume = Mathf.Lerp(0.2f, inFinishVolume, (Time.time - startTime) / fadeDuration);
            OutSource.volume = Mathf.Lerp(outStartVolume, 0f, (Time.time - startTime) / fadeDuration);
            yield return null;
        }

        OutSource.Stop();
        // Update the current track index for future transitions
        currentTrackIndex = (currentTrackIndex + 1) % 2;
    }

    public void PlayMusic(int trackIndex, AudioSource source)
    {
        if (trackIndex >= 0 && trackIndex < musicTracks.Length)
        {
            source.clip = musicTracks[trackIndex];
            source.Play();
        }
    }
}

