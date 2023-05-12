using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_escape : MonoBehaviour
{
    public GameObject EventSystem;

    void Start()
    {
        
    }


    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Player")
        {   
            EventSystem.GetComponent<EventManager>().escaped_stairs = true;
            Debug.Log("계단으로 탈출.");
        }
        
    }
}