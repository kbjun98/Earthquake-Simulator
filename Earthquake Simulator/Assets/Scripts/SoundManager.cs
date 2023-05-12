using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private AudioSource audioSource;
    private GameObject[] musics;

    private void Awake()
    {
        musics = GameObject.FindGameObjectsWithTag("Sound");

        if(musics.Length >= 2)        
            Destroy(this.gameObject);
        
        DontDestroyOnLoad(transform.gameObject);
        audioSource = GetComponent<AudioSource>();
    }
    
    public void Play_BGM()
    {
        if (audioSource.isPlaying)
            return;
        audioSource.Play();
    }

    public void Stop_BGM()
    {
        audioSource.Stop();
    }
}
