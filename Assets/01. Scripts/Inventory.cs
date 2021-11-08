using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public List<Item> itemNumbers;
    public Slot[] slots;

    void Start()
    {
        slots = GetComponentsInChildren<Slot>();
        InitSlot();
    }

    private void InitSlot()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            slots[i].EmptySlot();
        }

        for (int i = 0; i < itemNumbers.Count; i++)
        {
            slots[itemNumbers[i].itemNumber].OnSlot(itemNumbers[i].itemImage);
        }
    }

    public void AddItem(Item item)
    {
        if (itemNumbers.Count < slots.Length) // 먹은아이템개수 < 슬롯길이(가방크기)
        {
            itemNumbers.Add(item);
            InitSlot();
        }
        else
        {
            Debug.Log("Full Slot");
        }
    }

    public void RemoveItem(Item item)
    {
        if (itemNumbers.Contains(item))
        {
            itemNumbers.Remove(item);
            InitSlot();
        }
        else
        {
            Debug.Log("인벤토리에 버릴 게 없어");
        }
    }
}
