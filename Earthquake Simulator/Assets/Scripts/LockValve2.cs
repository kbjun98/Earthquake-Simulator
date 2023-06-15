using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockValve2 : MonoBehaviour
{

    public GameObject valve_handle;
    private GameObject EventCheck;

    void Start()
    {
        EventCheck = GameObject.Find("EventCheck");
    }

    void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E) && other.transform.tag == "Player")
        {
            Debug.Log("Valve area");
            EventCheck.GetComponent<EventCheck>().triggered_valve = true;
            valve_handle.GetComponent<LockValve>().turnValve();
        }
    }
}
