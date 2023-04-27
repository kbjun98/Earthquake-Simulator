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
        }
        else
        {
            thisImg.sprite = image_easy;
            isHard = false;
        }
          
    }
}
