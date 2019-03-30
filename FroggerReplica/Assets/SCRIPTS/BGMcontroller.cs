using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMcontroller : MonoBehaviour
{
    public static BGMcontroller bgm;
    public AudioClip music;
    public AudioSource audioSource;

    private void Awake()
    {
        audioSource.clip = music;
        if (bgm == null)
        {
            DontDestroyOnLoad(gameObject);
            bgm = this;
        }
        else if (bgm != this)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        PlayMusic();
    }

    public void PlayMusic()
    {
        audioSource.Play();
    }

    public void StopMusic()
    {
        audioSource.Stop();
    }
}
