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
            Debug.Log("x 누름");
            anim.SetUse(input.isUse ? true : false);
            
            if(equipItem == null)
            {
                GameManager.instance.col.HandFucntion(); // 여기서 없애는거 불러옴. 디버그 로그 잘 뜸 여기문제 아닌거같음
                Debug.Log("맨손입니다.");
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

            if(equipItem == null || sensor.frontItems.Count != 0) // 장착중인 아이템이 없다면 || 앞에 아이템이 있다면(아이템끼면 기본이 1)
            {
                GetItem(); // get
                return;
            }
            else if(equipItem != null)// 아이템을 장착하고 계시면
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
        if(equipItem != null) // 임시
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

        bool dir = move.GetFront().x > 0 ? true : false; // 플레이어가 ->을 보고있느냐 ? 예 : 아니오

        bool dir2 = equipItem.transform.localScale.x > 0 ? true : false; // 아이템=기본 오른쪽, ->을 보고있느냐 ? 예 : 아니오

        if (dir != dir2)
        {
            Vector3 scale = equipItem.transform.localScale;
            scale.x *= -1;
            equipItem.transform.localScale = scale;
        }

        equipItem.transform.parent = handTrm; // 회전하기 전에 parent를 바꿔줘야 각도맞게들려짐
        equipItem.RotateOrigin();
    }

    private void GetItem()
    {
        if (sensor.frontItems.Count > 0)
        {
            // 앞에있는 아이템 획득
            for (int i = 0; i < sensor.frontItems.Count; i++)
            {
                Item itemObj = sensor.frontItems[i];
                if (!itemObj.isGround) return; // 땅에 안떨어졌으면 못주워요

                if(equipItem == null) // 장착 아이템이 없다면
                {
                    EquipItem(itemObj);
                    inventory.AddItem(equipItem); // 인벤토리에 장착아이템 넣기.
                }
                else // 있다면
                {
                    inventory.AddItem(itemObj); // 인벤토리에 추가만 해준다.
                    itemObj.gameObject.SetActive(false); // 인벤토리에 넣으면 게임상에는 존재하지 않기때문에 끄고 나중에 인벤에서꺼낼때 다시킨다 + Rotate

                    // 꺼도 아마 손에서는 잔류할거임. 이거맞나??
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
        if (equipItem == null) return true; // 든게없으면 바꿀수있게.
        return (equipItem.itemNumber != item.itemNumber) ? true : false;
    }
}
