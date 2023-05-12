using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDB : MonoBehaviour
{
    public GameObject[] items;
    void Start()
    {
        int i = 0;
        foreach (GameObject item in items)
        {
            item.GetComponent<Item>().setItemIndex(i);
            i++;
        }
    }
}
