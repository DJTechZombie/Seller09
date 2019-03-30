using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleMusic : MonoBehaviour
{
    public static TitleMusic titleMusic;
    public AudioClip titleClip;
    public AudioSource titleSource;

    private void Awake()
    {

        titleSource.clip = titleClip;
        if (titleMusic == null)
        {
            DontDestroyOnLoad(gameObject);
            titleMusic = this;          
        }
        else if(titleMusic != this)
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        titleSource.Play();
    }

    
    public void startMusic()
    {
        titleSource.Play();
    }

    public void StopTitleMusic()
    {
        titleSource.Stop();
    }
    
}
