using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEquipment : MonoBehaviour
{
    private PlayerInput input; // from outer
    private PlayerMove move;
    private ObjSensor sensor;
    private PlayerAnimation anim;
    public Inventory inventory;

    public Item equipItem; // to outer

    [SerializeField] private Transform handTrm; // inner

    private void Awake()
    {
        input = GetComponent<PlayerInput>();
        sensor = GetComponent<ObjSensor>();
        move = GetComponent<PlayerMove>();
        anim = GetComponent<PlayerAnimation>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (input.isUse)
        {
            Debug.Log("x ����");
            anim.SetUse(input.isUse ? true : false);
            
            if(equipItem == null)
            {
                GameManager.instance.col.HandFucntion(); // ���⼭ ���ִ°� �ҷ���. ����� �α� �� �� ���⹮�� �ƴѰŰ���
                Debug.Log("�Ǽ��Դϴ�.");
                return;
            }
            equipItem.Use();
            return;
        }

        if (input.isGet)
        {
            Debug.Log(sensor.frontItems.Count); 

            foreach (Item item in sensor.frontItems)
            {
                Debug.Log(item.gameObject.name);
            }

            if(equipItem == null || sensor.frontItems.Count != 0) // �������� �������� ���ٸ� || �տ� �������� �ִٸ�(�����۳��� �⺻�� 1)
            {
                GetItem(); // get
                return;
            }
            else if(equipItem != null)// �������� �����ϰ� ��ø�
            {
                DropItem(); // drop
            }

            return;
        }

        if(input.isOpenInven)
        {
            inventory.OpenInven();
            return;
        }
    }

    public void EquipItem(Item item)
    {
        if(equipItem != null) // �ӽ�
        {
            equipItem.gameObject.SetActive(false);
            equipItem = null;
        }

        equipItem = item;
        equipItem.gameObject.SetActive(true);
        equipItem.Get();

        RotateItem();
        MoveHandPos();
    }

    private void RotateItem()
    {


        if (equipItem == null) return;

        bool dir = move.GetFront().x > 0 ? true : false; // �÷��̾ ->�� �����ִ��� ? �� : �ƴϿ�

        bool dir2 = equipItem.transform.localScale.x > 0 ? true : false; // ������=�⺻ ������, ->�� �����ִ��� ? �� : �ƴϿ�

        if (dir != dir2)
        {
            Vector3 scale = equipItem.transform.localScale;
            scale.x *= -1;
            equipItem.transform.localScale = scale;
        }

        equipItem.transform.parent = handTrm; // ȸ���ϱ� ���� parent�� �ٲ���� �����°Ե����
        equipItem.RotateOrigin();
    }

    private void GetItem()
    {
        if (sensor.frontItems.Count > 0)
        {
            // �տ��ִ� ������ ȹ��
            for (int i = 0; i < sensor.frontItems.Count; i++)
            {
                Item itemObj = sensor.frontItems[i];
                if (!itemObj.isGround) return; // ���� �ȶ��������� ���ֿ���

                if(equipItem == null) // ���� �������� ���ٸ�
                {
                    EquipItem(itemObj);
                    inventory.AddItem(equipItem); // �κ��丮�� ���������� �ֱ�.
                }
                else // �ִٸ�
                {
                    inventory.AddItem(itemObj); // �κ��丮�� �߰��� ���ش�.
                    itemObj.gameObject.SetActive(false); // �κ��丮�� ������ ���ӻ󿡴� �������� �ʱ⶧���� ���� ���߿� �κ����������� �ٽ�Ų�� + Rotate

                    // ���� �Ƹ� �տ����� �ܷ��Ұ���. �̰Ÿ³�??
                }
            }
        }
    }

    private void DropItem()
    {
        inventory.RemoveItem(equipItem);

        equipItem.Drop(transform.position);
        equipItem = null;
    }

    private void MoveHandPos()
    {
        if (equipItem == null) return;

        equipItem.transform.position = handTrm.position;
        Vector3 moveVec = handTrm.position - equipItem.handleTrm.position;
        equipItem.transform.position += moveVec;
    }

    public bool IsEquipItem(Item item)
    {
        if (equipItem == null) return true; // ��Ծ����� �ٲܼ��ְ�.
        return (equipItem.itemNumber != item.itemNumber) ? true : false;
    }
}
