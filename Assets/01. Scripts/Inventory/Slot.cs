//���α�
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

        if(clickRememberTime < Time.time) // ����Ŭ�� �ð� ��ü�Ǹ�
        {
            isOneClick = false; // �ƿ�
        }

        if (!isOneClick) // �ѹ����ȴ�����
        {
            isOneClick = true;
            clickRememberTime = Time.time + doubleClickOKTime;
        }
        else // �ѹ���������
        {
            DoubleClick();
            isOneClick = false;
        }
    }

    public void DoubleClick()
    {
        if(equip != null)
        {
            // �������� �������� �ƴ϶�� slot�� ������ ����
            // eequip���� bool �޼��� �ϳ���~
            if(equip.IsEquipItem(slotItem))// �������� ���ؾ� �Ѵ�!!
            {
                equip.EquipItem(slotItem);
            }
        }

    }
}
