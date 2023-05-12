using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SliderValue : MonoBehaviour
{

    GameObject player;
    public Slider slider_sensitivity;
    public Slider slider_sound;
    
    public AudioMixer audioMixer;

    void Start()
    {
        player = GameObject.Find("Player");
    }

    void Update()
    {

    }

    public void UpdateSensitivity()
    {
        player.GetComponent<PlayerController>().lookSensitivity = slider_sensitivity.value;
    }

    public void UpdateSound()
    {
        float volume = slider_sound.value;

        if (volume == -40f) audioMixer.SetFloat("Sound_master", -80);
        else audioMixer.SetFloat("Sound_master", volume);
    }
}
