using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEquipment : MonoBehaviour
{
    private PlayerInput input; // from outer
    private PlayerMove move;
    private ObjSensor sensor;
    public Inventory inventory;

    public Item equipItem; // to outer
    public bool isEquipItem = false;

    public Transform handTrm; // inner

    private void Awake()
    {
        input = GetComponent<PlayerInput>();
        sensor = GetComponent<ObjSensor>();
        move = GetComponent<PlayerMove>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (input.isGet)
        {
            Debug.Log(sensor.frontItems.Count);
            if(equipItem == null || sensor.frontItems.Count != 0) // �������� �������� ���ٸ� || �տ� �������� �ִٸ�(�����۳��� �⺻�� 1)
            {
                GetItem(); // get
                return;
            }
            else if(equipItem != null)// �������� �����ϰ� ��ø�
            {
                DropItem(); // drop
            }
        }

        if(input.isOpenInven)
        {
            inventory.OpenInven();
            return;
        }
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

                if(equipItem == null) // �̹� ���� �������� ���ٸ�
                {
                    equipItem = itemObj;
                    equipItem.Get();

                    inventory.AddItem(equipItem); // �κ��丮�� ���������� �ֱ�.

                    bool dir = move.GetFront().x > 0 ? true : false; // �÷��̾ ->�� �����ִ��� ? �� : �ƴϿ�

                    bool dir2 = equipItem.transform.localScale.x > 0 ? true : false; // ������=�⺻ ������, ->�� �����ִ��� ? �� : �ƴϿ�

                    if (dir != dir2)
                    {
                        Vector3 scale = equipItem.transform.localScale;
                        scale.x *= -1;
                        equipItem.transform.localScale = scale;
                    }
                }
                else // �ִٸ�
                {
                    inventory.AddItem(itemObj); // �κ��丮�� �߰��� ���ش�.
                    itemObj.gameObject.SetActive(false); // �κ��丮�� ������ ���ӻ󿡴� �������� �ʱ⶧���� ���� ���߿� �κ����������� �ٽ�Ų�� + Rotate

                    // ���� �Ƹ� �տ����� �ܷ��Ұ���. �̰Ÿ³�??
                }

                

                


                // �տ� ��°���
                itemObj.transform.parent = handTrm; // ȸ���ϱ� ���� parent�� �ٲ���� �����°Ե����
                equipItem.RotateOrigin();
                MoveHandPos();
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
}
