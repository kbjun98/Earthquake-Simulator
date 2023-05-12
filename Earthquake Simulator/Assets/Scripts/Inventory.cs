using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public ItemEquipmentUI equpimentUI;
    private List<Item> items = new List<Item>();
    private int itemEquiped;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeItem(int next)
    {
        if (items.Count == 0)
        {
            Debug.Log("No Item. Cannot change item.");
            return;
        }
        itemEquiped += 1;
        itemEquiped = itemEquiped%(items.Count);
        Debug.Log(itemEquiped);
        equpimentUI.setItemEquiped(items[itemEquiped]);
        return;
    }

    public void addItem(Item newItem)
    {
        if(items.Count == 0)
        {
            itemEquiped=0;
            items.Add(newItem);
            equpimentUI.setItemEquiped(items[0]);
        }
        else
        {
            items.Add(newItem);
        }
    }
}
