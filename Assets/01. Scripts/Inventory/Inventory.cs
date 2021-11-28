//���α�
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
        transform.localPosition = new Vector3 // �������� : �����Ϳ��� �κ��丮�����°Բ��ͼ�
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
        if (items.Count < slots.Length) // ���������۰��� < ���Ա���(����ũ��)
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
            Debug.Log("�κ��丮�� ���� �� ����");
        }
    }
}
