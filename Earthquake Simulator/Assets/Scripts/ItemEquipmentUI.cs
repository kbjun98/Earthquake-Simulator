using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemEquipmentUI : MonoBehaviour
{
    public ItemDB itemDB;
    private List<GameObject> equipments = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject equipment in itemDB.items)
        {
            GameObject tmp = Instantiate(equipment, transform);
            tmp.layer = LayerMask.NameToLayer("HandEquipment");
            tmp.transform.Rotate(0, -45, 30);
            tmp.SetActive(false);
            equipments.Add(tmp);
        }
    }

    // Update is called once per frame
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
