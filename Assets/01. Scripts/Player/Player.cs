using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    public enum PlayerHeartState // �÷��̾��� �ɸ�
    {
        Normal,
        Unstable,
        Fear,
        Revenge
    }

    private float moveSpeed = 15f;

    private Rigidbody2D rigid;
    private float inputX;
    private bool movingMan;//�̵��� �ʿ���
    private Vector3 dirVec;//�̵��� �ʿ���
    private GameObject Obj;
    private SpriteRenderer sr;
    private WaitForSeconds ws;
    private float delay = 3f;
    public GameObject Fire;

    public bool dir = false;
    public bool isSlow = false; // ������ �Ȱ��ִ°�
    public float divideSlowSpeed = 0.5f; // �����԰����� speed * dividespeed�� �̼Ӱ���
    public bool isFired = false;
    public bool isTurnedLastUpdate = false; // Turn�Ǹ� true �ǰ� FixedUpdate���� false

    public Item currentItem; // ��������
    public Transform equipItemTrm; // ���°�
    public Transform leftTrm;
    public Transform rightTrm;

    private Player player;
    private Inventory inven;
    public bool isItem = false; // �������������ִ°�
    // �̰ɷ� �����ϴ��� �ƴϸ� GameManager instance�� ������, player�� turnAction += void�Լ�(�͸�) �������
    GameObject obj = null;

    [HideInInspector]
    public LayerMask collisionlayer;

    public Action<bool> turnAction; // Inventory���� ���� ��������Ʈ

    

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        ws = new WaitForSeconds(delay);

        //turnAction += (x) => { }; // ��ɷ� �ʱ�ȭ

        player = GetComponent<Player>();
        inven = GetComponent<Inventory>();

        turnAction += (dir) =>
        {
            equipItemTrm = dir ? rightTrm : leftTrm;
        };
    }

    public PlayerHeartState state = PlayerHeartState.Normal;

    // Start is called before the first frame update
    void Start()
    {
        state = PlayerHeartState.Normal;
    }

    // Update is called once per frame
    void Update()
    {
        if(!SayManager.instance.isTextReading)
        {
            inputX = Input.GetAxisRaw("Horizontal");
        }

        bool hDown = SayManager.instance.isTextReading ? false : Input.GetButtonDown("Horizontal"); //��ư ����
        bool hUp = SayManager.instance.isTextReading ? false : Input.GetButtonUp("Horizontal"); //��

        if (hDown || hUp)
            movingMan = true;
        // movingMan = (hDown || hUp) ? true : false;

        int lastDir = dir ? 1 : -1; // �Է¹ޱ��� ���������� ���� �Է�
        if (inputX != lastDir && inputX != 0) // �� ����Է��̴ٸ��� == ȸ��
        {
            TurnEvent();
        }

        if (inputX == -1 && hDown)
        {
            dirVec = Vector3.left;
            dir = false;
        }

        else if (inputX == 1 && hDown)
        {
            dirVec = Vector3.right;
            dir = true;
        }

        if (movingMan) // PlayerEquip�� ����
            //GameManager.Instance.playerEquip.TurnItem(dir);

        //Debug.Log(Obj);
        if (Input.GetButtonDown("Jump") && Obj != null)
        {
         //   Action(Obj); // ��ü�� �����ϸ� ��簡 ������ ���ǹ�
            Debug.Log("�־ȵ�");
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
        {
            SlowMove(true);
        }

        if (Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.RightShift))
        {
            SlowMove(false);
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            DropEquip();
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            if (currentItem != null)
            {
                currentItem.Use();
            }
            else
            {
                Debug.Log("������ ����!");
            }
        }
    }
    private void FixedUpdate()
    {
        Debug.DrawRay(rigid.position, dirVec * 3, new Color(1, 0, 1));
        RaycastHit2D[] hit = Physics2D.RaycastAll(rigid.position, dirVec, 3, LayerMask.GetMask("Objection"));
        for(int i = 0; i < hit.Length; i++)
        {
            //if(GameManager.Instance.playerEquip.currentItem == null)
            {
                Obj = hit[i].collider.gameObject;
       //         break;
            }
            //if( !GameObject.ReferenceEquals( hit[i].collider.gameObject, GameManager.Instance.playerEquip.currentItem.gameObject))
            {
         //       Obj = hit[i].collider.gameObject;
         //       break;
            }
        }
        

        Vector2 moveDir = new Vector2(inputX, 0); // �¿��̵� ����
        rigid.velocity = moveDir * moveSpeed;

        RaycastHit2D hitt = Physics2D.Raycast(transform.position, player.GetDir(), 3, LayerMask.GetMask("Objection"));
        obj = null;
        if (hitt.collider != null)
        {
            obj = hitt.collider.gameObject;
            if (IsPlayerPutItem())
            {
                if (GameObject.ReferenceEquals(obj, currentItem.gameObject))
                {
                    obj = null;
                }
            }
        }
        //else
        //{
        //    obj = null;
        //}
    }


    public void TurnEvent()
    {
        Debug.Log("���ҽ��ϴ�");
        isTurnedLastUpdate = true;
        sr.flipX = !dir;
        turnAction(dir);
    }

    public void SlowMove(bool isSlow)
    {
        this.isSlow = isSlow;
        moveSpeed = isSlow ? moveSpeed * divideSlowSpeed : moveSpeed / divideSlowSpeed;
    }

    

    public void StopFire()
    {
        Fire.gameObject.SetActive(false);
    }

    private IEnumerator DoFeeling()
    {
        while (true)
        {
            yield return ws;
            switch (state)
            {
                case PlayerHeartState.Normal:
                    break;
                case PlayerHeartState.Unstable:
                    moveSpeed = 12;
                    break;
                case PlayerHeartState.Fear:
                    moveSpeed = 8;
                    break;
                case PlayerHeartState.Revenge:
                    moveSpeed = 12;
                    break;
                default:
                    break;
            }
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (1 << collision.gameObject.layer == collisionlayer.value)
        {
            if (Fire != null && !isFired)
            {
                Fire.gameObject.SetActive(true);
                Invoke("StopFire", 3);
            }
        }
    }

    public Vector3 GetDir()
    {
        return dirVec;
    }

    public void EquipItem(Item item)
    {
        item.Get();

        // ��ġ �����Ҳ��� 
        // item.transform.parent = EquipItemTrm;
    }

    public void DropItem()
    {
        if (currentItem != null)
        {
            currentItem.Drop(transform.position);
            currentItem = null;
        }
    }

    public bool IsPlayerPutItem()
    {
        return (currentItem != null); // ������ �������̸� true
    }

    public void TurnItem(bool dir)
    {
        // Debug.Log(equipItemTrm.position);

        //int turnLength = dir ? -4 : 4;
        //equipItemTrm.position = new Vector3(equipItemTrm.position.x + turnLength, equipItemTrm.position.y, equipItemTrm.position.z); // x flip Trm
    }

    public void DropEquip()
    {
        if (currentItem != null) // ���
        {
            inven.DeleteItem(currentItem);
            // Inventory2.DeleteItem(currentItem);
            DropItem();
        }

        if (obj == null) return; // ��ü������ ����

        Item item = obj.GetComponent<Item>(); // ȹ��
        if (item != null)
        {
            Debug.Log("Get Item");
            inven.InsertItem(item);
            EquipItem(item);
        }
    }
}
