using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventCheck : MonoBehaviour
{
    public float HP;
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
    public bool used_towel = false;

    private GameObject[] eventCheck;

    private void Awake()
    {
        eventCheck = GameObject.FindGameObjectsWithTag("EventCheck");

        if(eventCheck.Length >= 2)
            Destroy(this.gameObject);

        DontDestroyOnLoad(transform.gameObject);
    }
}
