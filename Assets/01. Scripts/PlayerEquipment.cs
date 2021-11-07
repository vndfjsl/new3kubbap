using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEquipment : MonoBehaviour
{
    private PlayerInput input; // from outer
    private PlayerMove move;
    private ObjSensor sensor;

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
            if (equipItem != null) // �������� �����ϰ� ��ø�
            {
                // ���� ����ϴ��ڵ�
                DropItem();
                return;
            }

            GetItem();
        }
    }

    private void GetItem()
    {
        if (sensor.frontItems.Count > 0)
        {
            Debug.Log("ȹ����");

            // �տ��ִ� ������ ȹ��
            for (int i = 0; i < sensor.frontItems.Count; i++)
            {
                Item itemObj = sensor.frontItems[i];
                if (!itemObj.isGround) return; // ���� �ȶ��������� ���ֿ���
                equipItem = itemObj;
                equipItem.Get();

                bool dir = move.GetFront().x > 0 ? true : false; // �÷��̾ ->�� �����ִ��� ? �� : �ƴϿ�

                bool dir2 = equipItem.transform.localScale.x > 0 ? true : false; // ������=�⺻ ������, ->�� �����ִ��� ? �� : �ƴϿ�

                if (dir != dir2)
                {
                    Vector3 scale = equipItem.transform.localScale;
                    scale.x *= -1;
                    equipItem.transform.localScale = scale;
                }

                // �κ��丮�� ���������� �ֱ� : TODO

                // �տ� ��°���
                itemObj.transform.parent = handTrm; // ȸ���ϱ� ���� parent�� �ٲ���� �����°Ե����
                equipItem.RotateOrigin();
                MoveHandPos();
            }
        }
    }

    private void DropItem()
    {
        Debug.Log("��������");
        equipItem.Drop(transform.position);
        equipItem = null;
        // �κ��丮���� ���������� ������
        

    }

    private void MoveHandPos()
    {
        if (equipItem == null) return;

        equipItem.transform.position = handTrm.position;
        Vector3 moveVec = handTrm.position - equipItem.handleTrm.position;
        equipItem.transform.position += moveVec;
    }
}
