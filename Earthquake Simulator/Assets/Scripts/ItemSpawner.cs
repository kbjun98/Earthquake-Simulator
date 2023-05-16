using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public Transform[] spots;
    public ItemDB itemDB;
    public int itemIndex;
    void Start()
    {
        int randomSpot = Random.Range(0, spots.Length);
        GameObject tmp = Instantiate(itemDB.items[itemIndex]);
        tmp.transform.position = spots[randomSpot].position;
    }

    void Update()
    {
        
    }

}
