using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInterection : MonoBehaviour
{
    public float interactDiastance = 5f;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, interactDiastance))
            {
                if (hit.collider.CompareTag("Door"))
                {
                    Debug.Log("ENTER");
                    hit.collider.transform.parent.GetComponent<DoorOpen>().ChangeDoorState();
                    Debug.Log("Enter2");
                }
            }
        }

    }
}
