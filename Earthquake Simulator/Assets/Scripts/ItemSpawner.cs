using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    
    public List<Transform> spots;
    public GameObject item;
    void Awake()
    {
        int randomSpot = Random.Range(0, spots.Count);
        Instantiate(item, spots[randomSpot]);
    }

    void Update()
    {
        
    }

}
