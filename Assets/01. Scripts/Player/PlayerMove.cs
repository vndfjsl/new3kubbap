using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private PlayerInput input; // �ܺο��� �����ð�
    private PlayerEquipment equip;
    private PlayerAnimation anim;
    private Rigidbody2D rigid;

    public bool facingRight; // �ܺη� �������� // �ʱ� �׸��� �������� �����ִ°�?
    public bool isSlow = false; // ������ �Ȱ��ִ°�?
    public float moveSpeed = 15f;
    public float slowSpeed = 3f;

    

    private void Awake()
    {
        input = GetComponent<PlayerInput>();
        equip = GetComponent<PlayerEquipment>();
        anim = GetComponent<PlayerAnimation>();
        rigid = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        float xMove = input.xMove;
        // if(!SayManager.instance.isTextReading) // �ؽ�Ʈ�� �߰�������
        // GameManager.TimeScale�� ��ü�ʿ�

        #region ȸ��

        if (facingRight) // �������� ����������
        {
            // 1�Է�(������) + ����(-1) || -1�Է�(����) + ������(1)
            if(xMove > 0 && transform.localScale.x < 0 || xMove < 0 && transform.localScale.x > 0)
            {
                Flip();
            }
        }
        else // ������ ����������
        {
            // 1�Է�(������) + ����(1) || -1�Է�(����) + ������(-1)
            if(xMove > 0 && transform.localScale.x > 0 || xMove < 0 && transform.localScale.x < 0)
            {
                Flip();
            }
        }

        #endregion

        #region �̵�
        float speed = isSlow ? slowSpeed : moveSpeed;
        rigid.velocity = new Vector2(xMove * speed, rigid.velocity.y);

        #endregion
    }

    public void Flip()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    public Vector2 GetFront() // ���� ���¹����� ��ȯ
    {
        if (facingRight)
        {
            return transform.localScale.x > 0 ? transform.right : transform.right * -1;
        }
        else
        {
            return transform.localScale.x > 0 ? transform.right * -1 : transform.right;
        }
    }

    public void SlowSpeed(bool slow)
    {
        isSlow = slow;
    }

    public void SetSpeed(float speed)
    {
        moveSpeed = speed;
    }
}
