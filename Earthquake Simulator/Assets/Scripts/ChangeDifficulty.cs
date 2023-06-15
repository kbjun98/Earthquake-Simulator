using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeDifficulty : MonoBehaviour
{
    public Sprite image_easy;
    public Sprite image_hard;
    public bool isHard = false;
    Image thisImg;
    private bool hardMode;    //temp
    void Awake()
    {
        hardMode = GameObject.Find("SoundManager").GetComponent<SoundManager>().hardMode;
    }

    void Start()
    {
        thisImg = GetComponent<Image>();
    }

    public void ChangeImage()
    {
        if (!isHard)
        {
            thisImg.sprite = image_hard;
            isHard = true;
            GameObject.Find("SoundManager").GetComponent<SoundManager>().hardMode = true;
        }
        else
        {
            thisImg.sprite = image_easy;
            isHard = false;
            GameObject.Find("SoundManager").GetComponent<SoundManager>().hardMode = false;
        }

    }
}
