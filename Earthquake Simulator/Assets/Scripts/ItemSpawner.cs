using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public Transform[] spots;
    public ItemDB itemDB;
    public int itemIndex;
<<<<<<< HEAD

=======
    // Start is called before the first frame update
>>>>>>> cb3dcd3490ef5f8543a027c058185c7ba7a7f6aa
    void Start()
    {
        int randomSpot = Random.Range(0, spots.Length);
        GameObject tmp = Instantiate(itemDB.items[itemIndex]);
        tmp.transform.position = spots[randomSpot].position;
    }

<<<<<<< HEAD

=======
    // Update is called once per frame
>>>>>>> cb3dcd3490ef5f8543a027c058185c7ba7a7f6aa
    void Update()
    {
        
    }

}
