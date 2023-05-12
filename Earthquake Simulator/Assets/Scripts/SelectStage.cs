using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectStage: MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void OnStageClick()
    {
        var sound = GameObject.Find("Sound_confirm").GetComponent<AudioSource>();
        sound.Play();
        SceneManager.LoadScene("Briefing");
    }
}
