using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public List<Item> items;
    public Slot[] slots;

    private float doubleClickOKTime = 0.3f;
    private bool isOneClick = false;
    private float clickRememberTime;

    void Start()
    {
        slots = GetComponentsInChildren<Slot>();
        transform.localPosition = new Vector3 // 쓰는이유 : 에디터에서 인벤토리가리는게꼬와서
            (transform.localPosition.x, transform.localPosition.y, 10);
        InitSlot();
        OpenInven();
    }

    private void Update()
    {
        if(isOneClick)
        {
            clickRememberTime += Time.deltaTime;
        }

        //Vector2 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //Collider2D hit = Physics2D.OverlapCircle(mouse, 0.5f);

        //Debug.Log(hit);

        if (!isOneClick) // <- 더블클릭
        {
            isOneClick = true;
            clickRememberTime = Time.time + doubleClickOKTime;
        }
        else if (clickRememberTime > Time.time)
        {
            isOneClick = false;
        }
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
