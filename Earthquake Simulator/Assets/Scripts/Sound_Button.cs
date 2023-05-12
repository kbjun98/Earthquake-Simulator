using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound_Button : MonoBehaviour
{
    private GameObject stage1, stage2;

    void Awake()
    {
        stage1 = GameObject.Find("Button_Stage1");
        stage2 = GameObject.Find("Button_Stage2");
    }
    void Start()
    {
        stage1.SetActive(true);
        stage2.SetActive(false);
    }

    void Update()
    {
        
    }
    public bool Button_Click()
    {
        var sound = GameObject.Find("Sound_click").GetComponent<AudioSource>();
        sound.Play();
        if (stage1.activeSelf)
        {
            stage1.SetActive(false);
            stage2.SetActive(true);
        }
        else
        {
            stage1.SetActive(true);
            stage2.SetActive(false);
        }
        return true;
    }
}
