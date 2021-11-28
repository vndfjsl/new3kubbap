//오민규
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public List<Item> items;
    public Slot[] slots;

    void Start()
    {
        slots = GetComponentsInChildren<Slot>();
        transform.localPosition = new Vector3 // 쓰는이유 : 에디터에서 인벤토리가리는게꼬와서
            (transform.localPosition.x, transform.localPosition.y, 10);
        InitSlot();
        OpenInven();
    }

    public void OpenInven()
    {
        bool isOpen = (gameObject.activeSelf) ? true : false;
        gameObject.SetActive(!isOpen);
    }

    private void InitSlot()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            slots[i].EmptySlot();
        }

        for (int i = 0; i < items.Count; i++)
        {
            slots[items[i].itemNumber].OnSlot(items[i]);
        }
    }

    public void AddItem(Item item)
    {
        Debug.Log("Add");
        if (items.Count < slots.Length) // 먹은아이템개수 < 슬롯길이(가방크기)
        {
            items.Add(item);
            InitSlot();
        }
        else
        {
            Debug.Log("Full Slot");
        }
    }

    public void RemoveItem(Item item)
    {
        if (items.Contains(item))
        {
            items.Remove(item);
            InitSlot();
        }
        else
        {
            Debug.Log("인벤토리에 버릴 게 없어");
        }
    }
}
