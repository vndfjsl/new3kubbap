//오민규
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class Slot : MonoBehaviour
{
    [SerializeField] private PlayerEquipment equip;

    private SpriteRenderer image;
    public Item slotItem;

    private float doubleClickOKTime = 0.3f;
    private bool isOneClick = false;
    private float clickRememberTime;


    private void Awake()
    {
        image = GetComponent<SpriteRenderer>();
    }

    public void EmptySlot()
    {
        image.color = new Color(1, 1, 1, 0);
    }

    public void OnSlot(Item item)
    {
        slotItem = item;
        image.color = new Color(1, 1, 1, 1);
    }
    


    public void OnMouseDown()
    {

        if(clickRememberTime < Time.time) // 더블클릭 시간 지체되면
        {
            isOneClick = false; // 아웃
        }

        if (!isOneClick) // 한번도안누르면
        {
            isOneClick = true;
            clickRememberTime = Time.time + doubleClickOKTime;
        }
        else // 한번눌렀으면
        {
            DoubleClick();
            isOneClick = false;
        }
    }

    public void DoubleClick()
    {
        if(equip != null)
        {
            // 장착중인 아이템이 아니라면 slot의 아이템 장착
            // eequip에서 bool 메서드 하나만~
            if(equip.IsEquipItem(slotItem))// 고유값을 비교해야 한다!!
            {
                equip.EquipItem(slotItem);
            }
        }

    }
}
