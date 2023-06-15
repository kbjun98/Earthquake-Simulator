using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructManager : MonoBehaviour
{
    public GameObject Floor1;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            Floor1.GetComponent<FloorDestruct>().isDestructed = true;
            Debug.Log("Floor check");
        }
    }
}
