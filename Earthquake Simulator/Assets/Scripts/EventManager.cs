using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    //for sound volume test
    public AudioSource audioSource;

    public bool isBurning = false;

    //// [if isBurning is true] ////////
    public bool isExtinguished = false;
    public bool isReported = false;
    ////////////////////////////////////

    public bool triggered_valve = false;
    public bool triggered_electric = false;

    public bool escaped_elevator = false;
    public bool escaped_stairs = false;
    public bool escaped_window = false;


    
    void Start()
    {

    }

    
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Debug.Log("옵션창 진입");
        }

        if(Input.GetKeyDown(KeyCode.Alpha4)) // for sound test
        {
            audioSource.Play();
        }
        
    }
}
