using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Item> items;

    public Slot[] slots;

    private void Awake()
    {
    }

    // Start is called before the first frame update
    void Start()
    {
        slots = GetComponentsInChildren<Slot>();
        InitSlot();
    }

    private void InitSlot()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            slots[i].item = null;
        }

        for (int i=0; i<items.Count && i<slots.Length; i++)
        {
            slots[i].item = items[i];
        }
    }

    public void AddItem(Item _item)
    {
        if(items.Count < slots.Length)
        {
            items.Add(_item);
            InitSlot();
        }
        else
        {
            Debug.Log("Full Slot");
        }
    }
}
