using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public ItemEquipmentUI equpimentUI;
    public PlayerHand playerHand;
    public PlayerHealth playerHealth;
    private List<Item> items = new List<Item>();
    private int itemEquiped=-1;

    public bool haveExtinguisher;
    public GameObject extinguisher;
    //public AudioClip sound_extinguish;

    void Start()
    {
        haveExtinguisher = false;
    }

    public void changeItem(int next)
    {
        if (items.Count == 0)
        {
            Debug.Log("No Item. Cannot change item.");
            return;
        }
        else if(items.Count == 1)
        {
            return;
        }
        removeItemEffect(items[itemEquiped]);   //
        itemEquiped += 1;
        itemEquiped = itemEquiped%(items.Count);
        Item currentItem = items[itemEquiped];
        playerHealth.setDefense(currentItem);
        equpimentUI.setItemEquiped(currentItem);
        playerHand.setItemEquiped(currentItem);
        return;
    }

    public void addItem(Item newItem)
    {
        if(items.Count == 0)
        {
            itemEquiped=0;
            items.Add(newItem);
            playerHealth.setDefense(newItem);
            equpimentUI.setItemEquiped(newItem);
            playerHand.setItemEquiped(newItem);
        }
        else
        {
            items.Add(newItem);
        }
    }

    public Item getEquippedItem()
    {
        if(items.Count==0) return null;
        Item item = items[itemEquiped];
        return item;
    }

    private void removeItemEffect(Item item)
    {
        if(GameManager.hardMode&&item.itemIndex==1)
        {
            RenderSettings.fogDensity = GameManager.darkFog;
        }
    }
}
