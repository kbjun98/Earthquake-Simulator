using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound_Button : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public void Button_Click()
    {
        var sound = GameObject.Find("Sound_click").GetComponent<AudioSource>();
        sound.Play();
    }
}
