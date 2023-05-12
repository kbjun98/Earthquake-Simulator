using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Equipment,
    Consumable,
    ETC
}

[System.Serializable]
public class Item : MonoBehaviour
{
    public ItemType itemType;
    public int itemIndex;
    public float periodSpeed = 3.0f;
    public float pitch = 3.0f;

    public Item()
    {

    }

    public Item(int index)
    {
        itemIndex= index;
    }

    public bool Use()
    {
        return false;
    }
    public void setItemIndex(int index)
    {
        this.itemIndex = index;
    }

    private void Start()
    {
        gameObject.tag= "Item";
    }
    private void Update()
    {
        //periodMove();
    }

    private void periodMove()
    {
        Vector3 pos = transform.position;
        pos.y += pitch * Mathf.Sin(Time.time * periodSpeed) / 1000;
        transform.position = pos;
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(this.gameObject);
    }
}
