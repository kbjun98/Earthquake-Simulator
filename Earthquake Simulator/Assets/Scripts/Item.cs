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
    public float renderScale = 1.0f;
    public float fireDefense;
    public float rockFallDefense;
    public float smokeDefense;
    private int ItemNumber;
    private GameObject player;
    private Useable useable;

    public Item()
    {

    }

    public Item(int index)
    {
        itemIndex= index;
    }

    public void Use()
    {
        if(useable != null)
        {
            useable.use();
        }
    }

    // 아이템 인덱스값 배열 순으로 초기화(by itemDB)
    public void setItemIndex(int index)
    {
        this.itemIndex = index;
    }


    private void Start()
    {
        gameObject.tag= "Item";
        WhatIsThis wis = gameObject.GetComponent<WhatIsThis>();
        if( wis != null )
        {
            ItemNumber = wis.number;
        }
        player = GameObject.Find("Player");
        useable = GetComponent<Useable>();
    }
    private void Update()
    {
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player")
        {
            if (ItemNumber == 1)
            {
                player.GetComponent<Inventory>().haveExtinguisher = true;
            }
            Destroy(gameObject);

        }
    }
}
