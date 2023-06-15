using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Extinguisher : MonoBehaviour
{

    private AudioSource sound_extinguish;
    private GameObject smokeFX;
    public bool isEnabled = false;
    
    void Awake()
    {
        smokeFX = GameObject.Find("FX_extinguish");
    }

    void Start()
    {   
        smokeFX.SetActive(false);
        sound_extinguish = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            if(!isEnabled)
            {
                smokeFX.SetActive(true);
                Debug.Log("PRESSED");
                sound_extinguish.Play();
                isEnabled = true;
            }
            else
            {
                smokeFX.SetActive(false);
                Debug.Log("NO PRESSED");
                sound_extinguish.Stop();
                isEnabled = false;

                //fadeout??
            }
            
        }
    }
}
