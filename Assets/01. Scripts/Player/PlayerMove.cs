using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private PlayerInput input; // 외부에서 가져올것
    private PlayerEquipment equip;
    private PlayerAnimation anim;
    private Rigidbody2D rigid;

    public bool facingRight; // 외부로 내보낼것 // 초기 그림이 오른쪽을 보고있는가?
    public bool isSlow = false; // 느리게 걷고있는가?
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
        // if(!SayManager.instance.isTextReading) // 텍스트가 뜨고있으면
        // GameManager.TimeScale로 교체필요

        #region 회전

        if (facingRight) // 오른쪽을 보고있으면
        {
            // 1입력(오른쪽) + 왼쪽(-1) || -1입력(왼쪽) + 오른쪽(1)
            if(xMove > 0 && transform.localScale.x < 0 || xMove < 0 && transform.localScale.x > 0)
            {
                Flip();
            }
        }
        else // 왼쪽을 보고있으면
        {
            // 1입력(오른쪽) + 왼쪽(1) || -1입력(왼쪽) + 오른쪽(-1)
            if(xMove > 0 && transform.localScale.x > 0 || xMove < 0 && transform.localScale.x < 0)
            {
                Flip();
            }
        }

        #endregion

        #region 이동
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

    public Vector2 GetFront() // 내가 보는방향을 반환
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
