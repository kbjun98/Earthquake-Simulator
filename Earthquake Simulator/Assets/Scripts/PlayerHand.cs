using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHand : MonoBehaviour
{
    public List<GameObject> handItems = new List<GameObject>();

    void Start()
    {
        foreach(GameObject hand in handItems)
        {
            hand.SetActive(false);
        }
    }

    public void setItemEquiped(Item item)
    {
        foreach (GameObject equipment in handItems)
        {
            equipment.SetActive(false);
        }
        handItems[item.itemIndex].gameObject.SetActive(true);
    }
}
