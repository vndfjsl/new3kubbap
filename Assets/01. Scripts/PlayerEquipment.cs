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
            if (equipItem != null) // 아이템을 장착하고 계시면
            {
                // 땅에 드롭하는코드
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
            Debug.Log("획득중");

            // 앞에있는 아이템 획득
            for (int i = 0; i < sensor.frontItems.Count; i++)
            {
                Item itemObj = sensor.frontItems[i];
                if (!itemObj.isGround) return; // 땅에 안떨어졌으면 못주워요
                equipItem = itemObj;
                equipItem.Get();

                bool dir = move.GetFront().x > 0 ? true : false; // 플레이어가 ->을 보고있느냐 ? 예 : 아니오

                bool dir2 = equipItem.transform.localScale.x > 0 ? true : false; // 아이템=기본 오른쪽, ->을 보고있느냐 ? 예 : 아니오

                if (dir != dir2)
                {
                    Vector3 scale = equipItem.transform.localScale;
                    scale.x *= -1;
                    equipItem.transform.localScale = scale;
                }

                // 인벤토리에 장착아이템 넣기 : TODO

                // 손에 드는과정
                itemObj.transform.parent = handTrm; // 회전하기 전에 parent를 바꿔줘야 각도맞게들려짐
                equipItem.RotateOrigin();
                MoveHandPos();
            }
        }
    }

    private void DropItem()
    {
        Debug.Log("버리는중");
        equipItem.Drop(transform.position);
        equipItem = null;
        // 인벤토리에서 장착아이템 버리기
        

    }

    private void MoveHandPos()
    {
        if (equipItem == null) return;

        equipItem.transform.position = handTrm.position;
        Vector3 moveVec = handTrm.position - equipItem.handleTrm.position;
        equipItem.transform.position += moveVec;
    }
}
