using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    public Scene scene;
    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
           // Quit();
        }
        else if (Input.anyKeyDown)
        {
            SoundPlay();
            SceneManager.LoadScene("GameSelect");
        }
    }
    /*

    private void Quit()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Applicaiton.Quit();
        #endif
    }
    */
    public bool SoundPlay()
    {
        var sound = GameObject.Find("Sound_confirm").GetComponent<AudioSource>();
        sound.Play();
        return true;
    }
    public bool OnApplicationQuit()
    {
        Debug.Log("game quit");
        return true;
    }
}
