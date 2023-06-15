using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemEquipmentUI : MonoBehaviour
{
    public ItemDB itemDB;
    private List<GameObject> equipments = new List<GameObject>();

    
    void Start()
    {
        foreach (GameObject equipment in itemDB.items)
        {
            GameObject tmp = Instantiate(equipment, transform);
            Item tmpItem= tmp.GetComponent<Item>();
            if(tmpItem != null)
            {
                float renderScale = tmpItem.renderScale;
                tmp.transform.localScale = new Vector3(renderScale,renderScale,renderScale);
            }
            tmp.layer = LayerMask.NameToLayer("HandEquipment");
            tmp.transform.Rotate(0, -45, 30);
            tmp.SetActive(false);
            equipments.Add(tmp);
        }
    }

    void Update()
    {
    }

    public void setItemEquiped(Item item)
    {
        foreach(GameObject equipment in equipments)
        {
            equipment.SetActive(false);
        }
        equipments[item.itemIndex].gameObject.SetActive(true);
    }
}
