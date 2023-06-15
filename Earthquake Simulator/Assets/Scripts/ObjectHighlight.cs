using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ObjectHighlight : MonoBehaviour
{
    private float interactDiastance = 2f;
    public bool isTargeting = false;
    private string[] tags = {"Desk", "Door", "Item"};

    void Awake()
    {

    }

    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactDiastance))
        {
            for(int i = 0 ; i < tags.Length ; i++)
            {
                if(hit.collider.CompareTag(tags[i]))
                {
                    isTargeting = true;
                }
            }
            
        }
        else
        {
            isTargeting = false;
        }
        //Debug.Log("IsTargeting : " +  isTargeting);
        
    }
}


