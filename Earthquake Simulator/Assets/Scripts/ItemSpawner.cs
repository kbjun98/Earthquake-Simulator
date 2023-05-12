using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public Transform[] spots;
    public ItemDB itemDB;
    public int itemIndex;
    // Start is called before the first frame update
    void Start()
    {
        int randomSpot = Random.Range(0, spots.Length);
        GameObject tmp = Instantiate(itemDB.items[itemIndex]);
        tmp.transform.position = spots[randomSpot].position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
