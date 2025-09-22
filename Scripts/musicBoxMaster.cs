using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicBoxMaster : MonoBehaviour
{
    private AudioSource audioSource;

    // Attach audio clips for your music tracks in the Inspector
    public AudioClip musicTrack1;
    public AudioClip musicTrack2;
    public AudioClip musicTrack3;
    public AudioClip musicTrack4;
    public AudioClip musicTrack5;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayMusicTrack1()
    {
        audioSource.Stop();
        audioSource.volume = 0.75f;
        audioSource.clip = musicTrack1;
        audioSource.Play();
    }

    public void PlayMusicTrack2()
    {
        audioSource.Stop();
        audioSource.volume = 1;
        audioSource.clip = musicTrack2;
        audioSource.Play();
    }

    public void PlayMusicTrack3()
    {
        audioSource.Stop();
        audioSource.volume = 0.75f;
        audioSource.clip = musicTrack3;
        audioSource.Play();
    }

    public void PlayMusicTrack4()
    {
        audioSource.Stop();
        audioSource.volume = 1;
        audioSource.clip = musicTrack4;
        audioSource.Play();
    }

    public void PlayMusicTrack5()
    {
        audioSource.Stop();
        audioSource.volume = 1;
        audioSource.clip = musicTrack5;
        audioSource.Play();
    }
    // You can add more methods for additional music tracks as needed
}
