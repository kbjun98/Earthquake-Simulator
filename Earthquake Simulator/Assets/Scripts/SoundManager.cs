using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private AudioSource audioSource;
    private GameObject[] musics;

    // temporary code for hardmode variable

    public bool hardMode = false;
    private bool locker = true;

    private void Awake()
    {
        musics = GameObject.FindGameObjectsWithTag("Sound");

        if(musics.Length >= 2)
            Destroy(this.gameObject);

        DontDestroyOnLoad(transform.gameObject);
        audioSource = GetComponent<AudioSource>();
        Cursor.lockState = CursorLockMode.Confined;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(locker)
            {
                Cursor.lockState = CursorLockMode.None;
                locker = false;
            }
            else if (!locker)
            {
                Cursor.lockState = CursorLockMode.Confined;
                locker = true;
            }
            
        }
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
